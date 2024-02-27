using AlAl3abProject.Models;
using BL;
using Domains;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace AlAl3abProject.Controllers
{
    public class CategoryController : Controller
    {
        private readonly FavouriteCartService _favouriteCartService;
       
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly CountryService countryService;
        private readonly ItemService _itemService;
        private readonly OperatingSystemService operatingSystemService;
        private readonly RegionService regionService;
        private readonly TypeService typeService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly PurchasingCartService purchasingCartService;
        private readonly ILogger<HomeController> _logger;
        private readonly AlAl3abDbContext _alAl3abDbContext;
        public CategoryController(SignInManager<ApplicationUser> SignInManager, FavouriteCartService favouriteCartService, CountryService CountryService,ItemService itemService,OperatingSystemService OperatingSystemService,RegionService RegionService,TypeService TypeService,UserManager<ApplicationUser> userManager, PurchasingCartService PurchasingCartService, ILogger<HomeController> logger, AlAl3abDbContext alAl3abDbContext)
        {
            signInManager = SignInManager;
           
            _favouriteCartService = favouriteCartService;
            _itemService = itemService;
            operatingSystemService = OperatingSystemService;
            regionService = RegionService;
            typeService = TypeService;
            _logger = logger;
            _alAl3abDbContext = alAl3abDbContext;
            purchasingCartService = PurchasingCartService;
            _userManager = userManager;
            countryService = CountryService;
        }
        public async Task<IActionResult> IndexAsync(string id)
        {

            IndexHomePageModel oIndexHomePageModel = new IndexHomePageModel();
            oIndexHomePageModel.LstCountries = countryService.getAll();
            oIndexHomePageModel.lstTypes = _alAl3abDbContext.TbTypes.ToList();
            oIndexHomePageModel.lstMainCategories = _alAl3abDbContext.TbMainCategories.ToList();
            oIndexHomePageModel.lstSubCategories = _alAl3abDbContext.TbSubCategories.ToList();
            oIndexHomePageModel.lstSliders = _alAl3abDbContext.TbSliders.ToList();
            oIndexHomePageModel.lstMainCategoriesFilters = _alAl3abDbContext.TbMainCategories.Where(a => a.TypeId == Guid.Parse(id)).ToList();
            oIndexHomePageModel.lstSubCategoriesFilters = _alAl3abDbContext.TbSubCategories.ToList();
            oIndexHomePageModel.lstSubCategoriesFinal = new List<TbSubCategory>();
            List<TbSubCategory> lstSubCategories = new List<TbSubCategory>();
            List<TbItemSubCategory> tbItemSubCategories = new List<TbItemSubCategory>();
            List<TbItemSeller> tbItemSellers = new List<TbItemSeller>();
            oIndexHomePageModel.lstItemSubCategory = _alAl3abDbContext.TbItemSubCategories.ToList();
            oIndexHomePageModel.lstItemSubCategoryFinal = new List<TbItemSubCategory>();
            oIndexHomePageModel.lstItemSellers = _alAl3abDbContext.TbItemSellers.ToList();
            oIndexHomePageModel.lstItemSellersFinal = new List<TbItemSeller>();
            foreach (var item in oIndexHomePageModel.lstMainCategoriesFilters) 
            {
                foreach(var element in oIndexHomePageModel.lstSubCategoriesFilters) 
                {
                    if(item.MainCategoryId == element.MainCategoryId) 
                    {
                        lstSubCategories.Add(element);
                    }
                }
            }

            foreach (var item in oIndexHomePageModel.lstItemSubCategory)
            {
                foreach (var element in lstSubCategories)
                {
                    if (item.SubCategoryId == element.SubCategoryId)
                    {
                        tbItemSubCategories.Add(item);
                    }
                }
            }



            foreach (var item in oIndexHomePageModel.lstItemSellers)
            {
                foreach (var element in tbItemSubCategories)
                {
                    if (item.ItemId == element.ItemId)
                    {
                        if(!tbItemSellers.Contains(item)) 
                        {
                            tbItemSellers.Add(item);
                        }
                        
                    }
                }
            }
            oIndexHomePageModel.lstItemSellersFinal = tbItemSellers;
            oIndexHomePageModel.lstTypes = typeService.getAll();
            oIndexHomePageModel.lstRegions = regionService.getAll();
            oIndexHomePageModel.lstOperatingSystems = operatingSystemService.getAll();
            oIndexHomePageModel.lstItems = _itemService.getAll();
            if (User.Identity.IsAuthenticated)
            {
                int? subtotal = 0;
                var user = await _userManager
                    .GetUserAsync(User);
                oIndexHomePageModel.lstPurchasingCart = purchasingCartService.getAll().Where(a => a.UserId == user.Id);
                foreach (var item in oIndexHomePageModel.lstPurchasingCart)
                {
                    subtotal += int.Parse(item.ItemSalePrice) * item.Quantity;
                }
                ViewBag.totalCart = subtotal.ToString();
            }
            ViewBag.type = id.ToString();
            return View(oIndexHomePageModel);
        }


        public async Task<IActionResult> IndexFilterAsync(string selectedValue2 , string typeid)
        {
            IndexHomePageModel oIndexHomePageModel = new IndexHomePageModel();
            oIndexHomePageModel.LstCountries = countryService.getAll();
            oIndexHomePageModel.lstTypes = _alAl3abDbContext.TbTypes.ToList();
            oIndexHomePageModel.lstMainCategories = _alAl3abDbContext.TbMainCategories.ToList();
            oIndexHomePageModel.lstSubCategories = _alAl3abDbContext.TbSubCategories.ToList();
            oIndexHomePageModel.lstSliders = _alAl3abDbContext.TbSliders.ToList();
            oIndexHomePageModel.lstMainCategoriesFilters = _alAl3abDbContext.TbMainCategories.Where(a => a.TypeId == Guid.Parse(typeid)).ToList();
            oIndexHomePageModel.lstSubCategoriesFilters = _alAl3abDbContext.TbSubCategories.ToList();
            oIndexHomePageModel.lstSubCategoriesFinal = new List<TbSubCategory>();
            List<TbSubCategory> lstSubCategories = new List<TbSubCategory>();
            List<TbItemSubCategory> tbItemSubCategories = new List<TbItemSubCategory>();
            List<TbItemSeller> tbItemSellers = new List<TbItemSeller>();
            oIndexHomePageModel.lstItemSubCategory = _alAl3abDbContext.TbItemSubCategories.ToList();
            oIndexHomePageModel.lstItemSubCategoryFinal = new List<TbItemSubCategory>();
            oIndexHomePageModel.lstItemSellers = _alAl3abDbContext.TbItemSellers.ToList();
            oIndexHomePageModel.lstItemSellersFinal = new List<TbItemSeller>();
            foreach (var item in oIndexHomePageModel.lstMainCategoriesFilters)
            {
                foreach (var element in oIndexHomePageModel.lstSubCategoriesFilters)
                {
                    if (item.MainCategoryId == element.MainCategoryId)
                    {
                        lstSubCategories.Add(element);
                    }
                }
            }

            foreach (var item in oIndexHomePageModel.lstItemSubCategory)
            {
                foreach (var element in lstSubCategories)
                {
                    if (item.SubCategoryId == element.SubCategoryId)
                    {
                        tbItemSubCategories.Add(item);
                    }
                }
            }



            foreach (var item in oIndexHomePageModel.lstItemSellers)
            {
                foreach (var element in tbItemSubCategories)
                {
                    if (item.ItemId == element.ItemId)
                    {
                        if (!tbItemSellers.Contains(item))
                        {
                            tbItemSellers.Add(item);
                        }

                    }
                }
            }
            oIndexHomePageModel.lstItemSellersFinal = tbItemSellers;
            oIndexHomePageModel.lstTypes = typeService.getAll();
            oIndexHomePageModel.lstRegions = regionService.getAll();
            oIndexHomePageModel.lstOperatingSystems = operatingSystemService.getAll();
            oIndexHomePageModel.lstItems = _itemService.getAll();
            if (User.Identity.IsAuthenticated)
            {
                int? subtotal = 0;
                var user = await _userManager
                    .GetUserAsync(User);
                oIndexHomePageModel.lstPurchasingCart = purchasingCartService.getAll().Where(a => a.UserId == user.Id);
                foreach (var item in oIndexHomePageModel.lstPurchasingCart)
                {
                    subtotal += int.Parse(item.ItemSalePrice) * item.Quantity;
                }
                ViewBag.totalCart = subtotal.ToString();
            }
            ViewBag.type = typeid.ToString();

            if (selectedValue2 == "lowprice")
            {
                oIndexHomePageModel.lstItemSellersFinal = oIndexHomePageModel.lstItemSellersFinal.OrderBy(a => a.ItemSalePrice);
            }
            else if (selectedValue2 == "highprice")
            {
                oIndexHomePageModel.lstItemSellersFinal = oIndexHomePageModel.lstItemSellersFinal.OrderByDescending(a => a.ItemSalePrice);
            }
            else if (selectedValue2 == "newdate")
            {
                oIndexHomePageModel.lstItemSellersFinal = oIndexHomePageModel.lstItemSellersFinal.OrderByDescending(a => a.CreatedDate);
            }
            else if (selectedValue2 == "olddate")
            {
                oIndexHomePageModel.lstItemSellersFinal = oIndexHomePageModel.lstItemSellersFinal.OrderBy(a => a.CreatedDate);
            }
            else if (selectedValue2 == "alphabeta")
            {
                oIndexHomePageModel.lstItemSellersFinal = oIndexHomePageModel.lstItemSellersFinal.OrderBy(a => a.ItemNameEn);
            }
            else if (selectedValue2 == "alphabetz")
            {
                oIndexHomePageModel.lstItemSellersFinal = oIndexHomePageModel.lstItemSellersFinal.OrderByDescending(a => a.ItemNameEn);
            }
            ViewBag.favcount = oIndexHomePageModel.lstItemSellersFinal.Count();
            if (User.Identity.IsAuthenticated)
            {
                int? subtotal = 0;
                var user = await _userManager
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
    }
}
