using AlAl3abProject.Models;
using AlAl3abProject.Resources;
using BL;
using Domains;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AlAl3abProject.Controllers
{
    [Authorize]
    public class ViewCartController : Controller
    {
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly PurchasingCartService purchasingCartService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ItemSellerService _itemSellerService;
        private readonly ILogger<HomeController> _logger;
        private readonly AlAl3abDbContext _alAl3abDbContext;
        public ViewCartController(SignInManager<ApplicationUser> SignInManager, PurchasingCartService PurchasingCartService, UserManager<ApplicationUser> UserManager, ILogger<HomeController> logger, AlAl3abDbContext alAl3abDbContext, ItemSellerService itemSellerService)
        {
            _logger = logger;
            _alAl3abDbContext = alAl3abDbContext;
            _itemSellerService = itemSellerService;
            userManager = UserManager;
            purchasingCartService = PurchasingCartService;
            signInManager = SignInManager;
        }
        public async Task<IActionResult> IndexAsync()
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
            return View(oIndexHomePageModel);
        }
        public async Task<IActionResult> AddToCartAsync(Guid itemSellerId)
        {
            IndexHomePageModel oIndexHomePageModel = new IndexHomePageModel();
            oIndexHomePageModel.lstTypes = _alAl3abDbContext.TbTypes.ToList();
            oIndexHomePageModel.lstMainCategories = _alAl3abDbContext.TbMainCategories.ToList();
            oIndexHomePageModel.lstSubCategories = _alAl3abDbContext.TbSubCategories.ToList();
            oIndexHomePageModel.lstSliders = _alAl3abDbContext.TbSliders.ToList();
            var user = await signInManager.UserManager.GetUserAsync(User);


            if (user == null)
            {
                return View("Index", oIndexHomePageModel);
            }
            TbItemSeller oTbItemSeller = _itemSellerService.getAll().Where(a => a.ItemSellerId == itemSellerId).FirstOrDefault();

            if (oTbItemSeller == null)
            {
                return View("Index", oIndexHomePageModel);
            }


            TbPurchasingCart oTbPurchasingCart = new TbPurchasingCart();
            oTbPurchasingCart.ItemId = oTbItemSeller.ItemId;
            oTbPurchasingCart.ItemImagePath = oTbItemSeller.ItemImagePath;
            oTbPurchasingCart.UserId = user.Id;
            oTbPurchasingCart.UserName = user.UserName;
            oTbPurchasingCart.ItemName = oTbItemSeller.ItemName;
            oTbPurchasingCart.SellerName = oTbItemSeller.SellerName;
            oTbPurchasingCart.ItemSalePrice = oTbItemSeller.ItemSalePrice;
            oTbPurchasingCart.ItemSellerId = oTbItemSeller.ItemSellerId;
            oTbPurchasingCart.SellerId = oTbItemSeller.SellerId;
            oTbPurchasingCart.Region = oTbItemSeller.Region;
            oTbPurchasingCart.SellerItemEvaluationNumbers = oTbItemSeller.SellerItemEvaluationNumbers;
            oTbPurchasingCart.SellerItemEvaluationStarts = oTbItemSeller.SellerItemEvaluationStarts;
            oTbPurchasingCart.CreatedBy = oTbItemSeller.ItemNameEn;
            oTbPurchasingCart.Quantity = 1;
            var result = purchasingCartService.Add(oTbPurchasingCart);
            if (result == true)
            {
                if (ResWebsite.Culture.Name == "en")
                {
                    TempData[SD.Success] = "The Game Is Added To Your Cart.";
                }
                else
                {
                    TempData[SD.Success] = "تمت اضافة اللعبة ال عربة التسوق";
                }

            }
            else
            {
                if (ResWebsite.Culture.Name == "en")
                {
                    TempData[SD.Error] = "Error in Adding The Game In The Cart.";
                }
                else
                {
                    TempData[SD.Error] = "لم يتم اضافة اللعبة ال عربة التسوق";
                }

            }
            oIndexHomePageModel.lstPurchasingCart = purchasingCartService.getAll();
            return View("Index", oIndexHomePageModel);
        }




        public async Task<IActionResult> RemoveCartAsync(Guid purchasingCartId)
        {
            IndexHomePageModel oIndexHomePageModel = new IndexHomePageModel();
            oIndexHomePageModel.lstTypes = _alAl3abDbContext.TbTypes.ToList();
            oIndexHomePageModel.lstMainCategories = _alAl3abDbContext.TbMainCategories.ToList();
            oIndexHomePageModel.lstSubCategories = _alAl3abDbContext.TbSubCategories.ToList();
            oIndexHomePageModel.lstSliders = _alAl3abDbContext.TbSliders.ToList();
            var user = await signInManager.UserManager.GetUserAsync(User);
            if (user == null)
            {
                return View("Index", oIndexHomePageModel);
            }
            TbPurchasingCart oTbPurchasingCart = purchasingCartService.getAll().Where(a=> a.PurchasingCartId == purchasingCartId).FirstOrDefault();
            if (oTbPurchasingCart == null)
            {
                return View("Index", oIndexHomePageModel);
            }
            var result = purchasingCartService.Delete(oTbPurchasingCart);
            if (result == true)
            {
                if (ResWebsite.Culture.Name == "en")
                {
                    TempData[SD.Success] = "The Game Is Removed From Your Cart.";
                }
                else
                {
                    TempData[SD.Success] = "تم مسح اللعبة من عربة التسوق";
                }

            }
            else
            {
                if (ResWebsite.Culture.Name == "en")
                {
                    TempData[SD.Error] = "Error in Removing The Game From The Cart.";
                }
                else
                {
                    TempData[SD.Error] = "لم يتم مسح اللعبة من عربة التسوق";
                }

            }
            oIndexHomePageModel.lstPurchasingCart = purchasingCartService.getAll();
            return View("Index", oIndexHomePageModel);
        }
    }
}
