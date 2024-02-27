using AlAl3abProject.Models;
using AlAl3abProject.Resources;
using BL;
using Domains;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlAl3abProject.Controllers
{
    public class MyObject
    {
        public string id { get; set; }
        public string price { get; set; }
        public string qty { get; set; }
        public string promodiscount { get; set; }

        public string promotitle { get; set; }

        
    }
    [Authorize]
    public class CheckOutController : Controller
    {
        private readonly OrderDetailsService orderDetailsService;
        private readonly PromocodeService promocodeService;
        private readonly OrderService orderService;
        private readonly ItemSellerService itemSellerService;
        private readonly PurchasingCartService purchasingCartService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ILogger<HomeController> _logger;
        private readonly AlAl3abDbContext _alAl3abDbContext;
        public CheckOutController(OrderDetailsService OrderDetailsService,PromocodeService PromocodeService,OrderService OrderService,ItemSellerService ItemSellerService,PurchasingCartService PurchasingCartService, UserManager<ApplicationUser> UserManager, ILogger<HomeController> logger, AlAl3abDbContext alAl3abDbContext)
        {
            _logger = logger;
            _alAl3abDbContext = alAl3abDbContext;
            userManager = UserManager;
            purchasingCartService = PurchasingCartService;
            itemSellerService = ItemSellerService;
            orderService = OrderService;
            promocodeService = PromocodeService;
            orderDetailsService = OrderDetailsService;
        }
    
        public async Task<IActionResult> IndexAsync(string response)
        {
            IndexHomePageModel oIndexHomePageModel = new IndexHomePageModel();
            oIndexHomePageModel.lstTypes = _alAl3abDbContext.TbTypes.ToList();
            oIndexHomePageModel.lstMainCategories = _alAl3abDbContext.TbMainCategories.ToList();
            oIndexHomePageModel.lstSubCategories = _alAl3abDbContext.TbSubCategories.ToList();
            oIndexHomePageModel.lstSliders = _alAl3abDbContext.TbSliders.ToList();
           
            oIndexHomePageModel.Order = orderService.getAll().Where(a => a.OrderId == Guid.Parse(response)).FirstOrDefault();
            oIndexHomePageModel.lstOrderDetails = orderDetailsService.getAll().Where(a => a.CreatedBy == response).ToList();
            if (User.Identity.IsAuthenticated)
            {
               
                var user = await userManager
                    .GetUserAsync(User);
                oIndexHomePageModel.lstPurchasingCart = purchasingCartService.getAll().Where(a => a.UserId == user.Id);
                foreach (var item in oIndexHomePageModel.lstPurchasingCart)
                {
                    purchasingCartService.Delete(item);
                }
                
            }
            oIndexHomePageModel.lstPurchasingCart = purchasingCartService.getAll();
            return View(oIndexHomePageModel);
        }

        [HttpPost]
        public async Task<IActionResult> ProceedCheckout([FromBody] IEnumerable<MyObject> valuesCheck)
        {
            IndexHomePageModel oIndexHomePageModel = new IndexHomePageModel();
            oIndexHomePageModel.lstTypes = _alAl3abDbContext.TbTypes.ToList();
            oIndexHomePageModel.lstMainCategories = _alAl3abDbContext.TbMainCategories.ToList();
            oIndexHomePageModel.lstSubCategories = _alAl3abDbContext.TbSubCategories.ToList();
            oIndexHomePageModel.lstSliders = _alAl3abDbContext.TbSliders.ToList();
            oIndexHomePageModel.lstPurchasingCart = purchasingCartService.getAll();
            if (User.Identity.IsAuthenticated)
            {
                int? subtotal = 0;
                var user = await userManager
                    .GetUserAsync(User);
                oIndexHomePageModel.lstPurchasingCart = purchasingCartService.getAll().Where(a => a.UserId == user.Id);
                foreach (var item in oIndexHomePageModel.lstPurchasingCart)
                {
                    subtotal += int.Parse(item.ItemSalePrice) * item.Quantity;
                }
                ViewBag.totalCart = subtotal.ToString();
            }
            var userS = await userManager
                  .GetUserAsync(User);
            int OrderPriceAfterPromocode = 0;
            int OrderPricebeforePromocode = 0;
            TbOrder otborder = new TbOrder();
            foreach (var i in valuesCheck) 
            {
                if (i.promotitle != null) 
                {
                    OrderPriceAfterPromocode += (int.Parse(i.price) * int.Parse(i.qty)) - ((((int.Parse(i.price) * int.Parse(i.qty)) * int.Parse(i.promodiscount)) / 100));
                    OrderPricebeforePromocode += (int.Parse(i.price) * int.Parse(i.qty));
                    otborder.PromocodeDiscountPercent = valuesCheck.FirstOrDefault().promodiscount;
                    otborder.PromocodeTitle = valuesCheck.FirstOrDefault().promotitle;
                    otborder.PromocodeId = promocodeService.getAll().Where(A => A.PromocodeTitle == otborder.PromocodeTitle).FirstOrDefault().PromocodeId;

                }
                else 
                {
                    OrderPricebeforePromocode += (int.Parse(i.price) * int.Parse(i.qty));
                    OrderPriceAfterPromocode = OrderPricebeforePromocode;
                    otborder.PromocodeDiscountPercent = "0";
                    otborder.PromocodeTitle = "";
                  
                }
                    
            }
            
            otborder.OrderPriceAfterPromocode = OrderPriceAfterPromocode.ToString();
            otborder.OrderPriceBeforePromocode = OrderPricebeforePromocode.ToString().ToLower();
          
            otborder.UserName = userS.UserName;
            otborder.UserId = userS.Id;
           
            
            var result = orderService.Add(otborder);
            if (result == true)
            {
                if (ResWebsite.Culture.Name == "en")
                {
                    TempData[SD.Success] = "The Order Is Created.";
                }
                else
                {
                    TempData[SD.Success] = "تم طلب الاوردر";
                }
                foreach(var i in valuesCheck) 
                {
                    TbOrderDetails oTbOrderDetails = new TbOrderDetails();
                    oTbOrderDetails.ItemId = itemSellerService.getAll().Where(a => a.ItemSellerId == Guid.Parse(i.id)).FirstOrDefault().ItemId;
                    oTbOrderDetails.ItemImagePath = itemSellerService.getAll().Where(a => a.ItemSellerId == Guid.Parse(i.id)).FirstOrDefault().ItemImagePath;
                    oTbOrderDetails.ItemName = itemSellerService.getAll().Where(a => a.ItemSellerId == Guid.Parse(i.id)).FirstOrDefault().ItemName;
                    oTbOrderDetails.ItemNameEn = itemSellerService.getAll().Where(a => a.ItemSellerId == Guid.Parse(i.id)).FirstOrDefault().ItemNameEn;
                    oTbOrderDetails.ItemQty = int.Parse(i.qty);
                    oTbOrderDetails.ItemSalePrice = i.price;
                    if(i.promotitle !=null) 
                    {
                        
                        oTbOrderDetails.ItemSalePriceAfterPromocode = (int.Parse(i.price) - (int.Parse(i.price) * int.Parse(i.promodiscount) / 100)).ToString();
                        oTbOrderDetails.PromocodeDiscountPercent = i.promodiscount;
                        oTbOrderDetails.PromocodeTitle = i.promotitle;
                        oTbOrderDetails.PromocodeId = promocodeService.getAll().Where(A => A.PromocodeTitle == i.promotitle).FirstOrDefault().PromocodeId;
                    }
                    oTbOrderDetails.ItemSalePriceAfterPromocode = i.price;
                    oTbOrderDetails.PromocodeDiscountPercent = "";
                    oTbOrderDetails.PromocodeTitle = "";
                  
                    oTbOrderDetails.ItemSellerId = Guid.Parse( i.id);
                    oTbOrderDetails.UserName = userS.UserName;
                    oTbOrderDetails.UserId = userS.UserName;
                    oTbOrderDetails.SellerName = itemSellerService.getAll().Where(a => a.ItemSellerId == Guid.Parse(i.id)).FirstOrDefault().SellerName;
                    oTbOrderDetails.SellerNameEn = itemSellerService.getAll().Where(a => a.ItemSellerId == Guid.Parse(i.id)).FirstOrDefault().SellerNameEn;
                    oTbOrderDetails.SellerId = itemSellerService.getAll().Where(a => a.ItemSellerId == Guid.Parse(i.id)).FirstOrDefault().SellerId.ToString();
                    oTbOrderDetails.CreatedBy = otborder.OrderId.ToString();
                    var resultt = orderDetailsService.Add(oTbOrderDetails);
                    if(resultt == true) 
                    {
                        if (ResWebsite.Culture.Name == "en")
                        {
                            TempData[SD.Success] = "The Order Details Is Created.";
                        }
                        else
                        {
                            TempData[SD.Success] = "تم اضافة تفاصيل الاوردر";
                        }
                    }
                    else 
                    {
                        if (ResWebsite.Culture.Name == "en")
                        {
                            TempData[SD.Error] = "Error in Creating The Order Details.";
                        }
                        else
                        {
                            TempData[SD.Error] = "لم يتم اضافة تفاصيل الاوردر ";
                        }

                    }

                }
                return Ok(otborder.OrderId);
            }
            else
            {
                if (ResWebsite.Culture.Name == "en")
                {
                    TempData[SD.Error] = "Error in Creating The Order.";
                }
                else
                {
                    TempData[SD.Error] = "لم يتم طلب الاوردر ";
                }
            }
            return View(oIndexHomePageModel);
        }
    }
}
