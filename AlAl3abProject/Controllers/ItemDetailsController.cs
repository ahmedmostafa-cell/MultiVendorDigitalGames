using AlAl3abProject.Models;
using AlAl3abProject.Services;
using BL;
using Domains;
using EmailService;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace AlAl3abProject.Controllers
{
    public class ItemDetailsController : Controller
    {
        private readonly PurchasingCartService purchasingCartService;
        private readonly ItemSellerImageService itemSellerImageService;
        private readonly EvaluationService evaluationService;
        private readonly ItemSubCategoryService itemSubCategoryService;
        private readonly ItemService itemService;
        private readonly TypeService typeService;
        private readonly ItemSellerService itemSellerService;
        private readonly MainCategoryService mainCategoryService;
        private readonly SubCategoryService subCategoryService;
        private readonly SliderService sliderService;
        private readonly ILogger<HomeController> _logger;
        private readonly AlAl3abDbContext _alAl3abDbContext;
        private readonly ISMSService _smsService;

        private readonly UserManager<ApplicationUser> _userManager;
        //one
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        //private readonly IEmailSender _emailSender;
        private readonly UrlEncoder _urlEncoder;
        private readonly IEmailSender _emailSender;
        public ItemDetailsController(PurchasingCartService PurchasingCartService,ItemSellerImageService ItemSellerImageService,EvaluationService EvaluationService,ItemSubCategoryService ItemSubCategoryService, ItemService ItemService, TypeService TypeService, ItemSellerService ItemSellerService, MainCategoryService MainCategoryService, SubCategoryService SubCategoryService, SliderService SliderService, ILogger<HomeController> logger, AlAl3abDbContext alAl3abDbContext,
            ISMSService smsService, IEmailSender emailSender, AlAl3abDbContext db, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,
            UrlEncoder urlEncoder, RoleManager<IdentityRole> roleManager



            )
        {
            purchasingCartService = PurchasingCartService;
            _logger = logger;
            _alAl3abDbContext = alAl3abDbContext;
            typeService = TypeService;
            itemSellerService = ItemSellerService;
            mainCategoryService = MainCategoryService;
            subCategoryService = SubCategoryService;
            sliderService = SliderService;
            itemService = ItemService;
            itemSubCategoryService = ItemSubCategoryService;
            _userManager = userManager;
            evaluationService = EvaluationService;
            _signInManager = signInManager;
            _urlEncoder = urlEncoder;
            _roleManager = roleManager;
            _emailSender = emailSender;
            itemSellerImageService = ItemSellerImageService;
            _smsService = smsService;

        }
        public async Task<IActionResult> IndexAsync(Guid id)
        {
            IndexHomePageModel oIndexHomePageModel = new IndexHomePageModel();
            oIndexHomePageModel.lstTypes = typeService.getAll();       
            oIndexHomePageModel.lstMainCategories = mainCategoryService.getAll();
            oIndexHomePageModel.lstSubCategories = subCategoryService.getAll();
            oIndexHomePageModel.lstVwItemSellerFavouriteCount = _alAl3abDbContext.VwItemSellerFavouriteCounts.ToList();
            oIndexHomePageModel.lstSliders = sliderService.getAll();
            oIndexHomePageModel.lstItemSellerImages = itemSellerImageService.getAll().Where(A => A.ItemSellerId == id);
            oIndexHomePageModel.VwItemSellerEvalauationParameters = _alAl3abDbContext.VwItemSellerEvalauationParameterss.Where(a => a.ItemSellerId == id).FirstOrDefault();
            oIndexHomePageModel.itemSeller = itemSellerService.getAll().Where(a => a.ItemSellerId == id).FirstOrDefault();
            oIndexHomePageModel.lstItemSubCategory = itemSubCategoryService.getAll().Where(A => A.ItemId == oIndexHomePageModel.itemSeller.ItemId);
            oIndexHomePageModel.lstUpdatedItemSubCategory = itemSubCategoryService.getAll().Where(A => A.ItemId != oIndexHomePageModel.itemSeller.ItemId);
            oIndexHomePageModel.lstUpdated2ItemSubCategory = new List<TbItemSubCategory>();
            oIndexHomePageModel.lstRelatedProducts = itemSellerService.getAll();
            if (User.Identity.IsAuthenticated)
            {
                int? subtotal = 0;
                var user = await _userManager
                    .GetUserAsync(User);
                oIndexHomePageModel.lstPurchasingCart = purchasingCartService.getAll().Where(a => a.UserId == user.Id);
                foreach(var item in oIndexHomePageModel.lstPurchasingCart) 
                {
                    subtotal  += int.Parse(item.ItemSalePrice) * item.Quantity;
                }
                ViewBag.totalCart = subtotal.ToString();
            }
            oIndexHomePageModel.lstRelated2Products = new List<TbItemSeller>();
            List<TbItemSeller> lstItemSeller = new List<TbItemSeller>();
            List<TbItemSubCategory> lstItemSubCategory = new List<TbItemSubCategory>();
            foreach (var i in oIndexHomePageModel.lstItemSubCategory) 
            {
                foreach(var item in oIndexHomePageModel.lstUpdatedItemSubCategory) 
                {
                    if(i.SubCategoryId == item.SubCategoryId) 
                    {
                        lstItemSubCategory.Add(item);
                    }
                }
            }
            oIndexHomePageModel.lstUpdated2ItemSubCategory = lstItemSubCategory;
            if (oIndexHomePageModel.lstUpdated2ItemSubCategory.Count()>0) 
            {
                foreach (var i in oIndexHomePageModel.lstUpdated2ItemSubCategory)
                {
                    foreach (var item in oIndexHomePageModel.lstRelatedProducts)
                    {
                        if (item.ItemId == i.ItemId)
                        {
                            lstItemSeller.Add(item);
                        }
                    }
                }
                oIndexHomePageModel.lstRelated2Products = lstItemSeller;
                foreach (var i in oIndexHomePageModel.lstRelated2Products)
                {
                    foreach (var e in oIndexHomePageModel.lstVwItemSellerFavouriteCount)
                    {
                        if (i.ItemSellerId == e.ItemSellerId)
                        {
                            i.NumberOfAddFavourite = e.NumberOfAdd;
                        }
                        else
                        {
                            i.NumberOfAddFavourite = 0;
                        }
                    }

                }

            }
            
          
           
            oIndexHomePageModel.lstItemSubCategory = _alAl3abDbContext.TbItemSubCategories.Where(a => a.ItemId == oIndexHomePageModel.itemSeller.ItemId).Include(a=> a.SubCategory).ToList();
            
            if (oIndexHomePageModel.VwItemSellerEvalauationParameters == null) 
            {
                ViewBag.itemCountOfRatings = 0;
                ViewBag.ratingPercent = 0;
                oIndexHomePageModel.itemSeller.SellerItemEvaluationNumbers = "0";
            }
            else 
            {
                ViewBag.itemCountOfRatings = evaluationService.getAll().Where(a => a.ItemSellerId == id).Count();
                oIndexHomePageModel.itemSeller.SellerItemEvaluationNumbers = (((oIndexHomePageModel.VwItemSellerEvalauationParameters.ParameterOneStarts + (float)oIndexHomePageModel.VwItemSellerEvalauationParameters.ParameterwoStarts + (float)oIndexHomePageModel.VwItemSellerEvalauationParameters.ParameterThreeStarts + (float)oIndexHomePageModel.VwItemSellerEvalauationParameters.ParameterFourStarts) / 4)).ToString();
                ViewBag.ratingPercent = ((((oIndexHomePageModel.VwItemSellerEvalauationParameters.ParameterOneStarts + (float)oIndexHomePageModel.VwItemSellerEvalauationParameters.ParameterwoStarts + (float)oIndexHomePageModel.VwItemSellerEvalauationParameters.ParameterThreeStarts + (float)oIndexHomePageModel.VwItemSellerEvalauationParameters.ParameterFourStarts) / 4)) / 5) * 100;
            }
          
            
           
           
            return View(oIndexHomePageModel);
        }
    }
}
