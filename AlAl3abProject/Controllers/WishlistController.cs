using AlAl3abProject.Models;
using AlAl3abProject.Resources;
using BL;
using Domains;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace AlAl3abProject.Controllers
{
    [Authorize]
    public class WishlistController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly PurchasingCartService purchasingCartService;
        private readonly FavouriteCartService _favouriteCartService;
        private readonly ItemSellerService _itemSellerService; 
        private readonly ItemService _itemService;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly ILogger<HomeController> _logger;
        private readonly AlAl3abDbContext _alAl3abDbContext;
        public WishlistController(UserManager<ApplicationUser> userManager, PurchasingCartService PurchasingCartService, FavouriteCartService favouriteCartService,ItemSellerService itemSellerService,ILogger<HomeController> logger, AlAl3abDbContext alAl3abDbContext, SignInManager<ApplicationUser> SignInManager, ItemService itemService = null)
        {
            _logger = logger;
            _alAl3abDbContext = alAl3abDbContext;
            signInManager = SignInManager;
            _itemService = itemService;
            _itemSellerService = itemSellerService;
            _favouriteCartService = favouriteCartService;
            purchasingCartService = PurchasingCartService;
            _userManager = userManager;
        }
       
        public async Task<IActionResult> IndexAsync()
        {
            IndexHomePageModel oIndexHomePageModel = new IndexHomePageModel();
            oIndexHomePageModel.lstVwItemSellerFavouriteCount = _alAl3abDbContext.VwItemSellerFavouriteCounts.ToList();
            oIndexHomePageModel.lstTypes = _alAl3abDbContext.TbTypes.ToList();
            oIndexHomePageModel.lstMainCategories = _alAl3abDbContext.TbMainCategories.ToList();
            oIndexHomePageModel.lstSubCategories = _alAl3abDbContext.TbSubCategories.ToList();
            oIndexHomePageModel.lstSliders = _alAl3abDbContext.TbSliders.ToList();
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
            var currentUser = await signInManager.UserManager.GetUserAsync(User);
                if (currentUser == null)
                {
                    return View(oIndexHomePageModel);
                }
                oIndexHomePageModel.lstFavouriteCart = _favouriteCartService.getAll().Where(a => a.UserId == currentUser.Id);
                foreach (var i in oIndexHomePageModel.lstFavouriteCart)
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
            ViewBag.favcount = oIndexHomePageModel.lstFavouriteCart.Count();
            return View(oIndexHomePageModel);
              
           
            
           
        }
        
        public async Task<IActionResult> IndexFilterAsync(string selectedValue)
        {
            IndexHomePageModel oIndexHomePageModel = new IndexHomePageModel();
            oIndexHomePageModel.lstVwItemSellerFavouriteCount = _alAl3abDbContext.VwItemSellerFavouriteCounts.ToList();
            oIndexHomePageModel.lstTypes = _alAl3abDbContext.TbTypes.ToList();
            oIndexHomePageModel.lstMainCategories = _alAl3abDbContext.TbMainCategories.ToList();
            oIndexHomePageModel.lstSubCategories = _alAl3abDbContext.TbSubCategories.ToList();
            oIndexHomePageModel.lstSliders = _alAl3abDbContext.TbSliders.ToList();

            var currentUser = await signInManager.UserManager.GetUserAsync(User);
            if (currentUser == null)
            {
                return View(oIndexHomePageModel);
            }
            oIndexHomePageModel.lstFavouriteCart = _favouriteCartService.getAll().Where(a => a.UserId == currentUser.Id);
            foreach (var i in oIndexHomePageModel.lstFavouriteCart)
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
            if(selectedValue == "lowprice") 
            {
                oIndexHomePageModel.lstFavouriteCart = oIndexHomePageModel.lstFavouriteCart.OrderBy(a=> a.ItemSalePrice);
            }
            else if(selectedValue == "highprice") 
            {
                oIndexHomePageModel.lstFavouriteCart = oIndexHomePageModel.lstFavouriteCart.OrderByDescending(a => a.ItemSalePrice);
            }
            else if (selectedValue == "newdate")
            {
                oIndexHomePageModel.lstFavouriteCart = oIndexHomePageModel.lstFavouriteCart.OrderByDescending(a => a.CreatedDate);
            }
            else if (selectedValue == "olddate")
            {
                oIndexHomePageModel.lstFavouriteCart = oIndexHomePageModel.lstFavouriteCart.OrderBy(a => a.CreatedDate);
            }
            else if (selectedValue == "alphabeta")
            {
                oIndexHomePageModel.lstFavouriteCart = oIndexHomePageModel.lstFavouriteCart.OrderBy(a => a.ItemNameEn);
            }
            else if (selectedValue == "alphabetz")
            {
                oIndexHomePageModel.lstFavouriteCart = oIndexHomePageModel.lstFavouriteCart.OrderByDescending(a => a.ItemNameEn);
            }
            ViewBag.favcount = oIndexHomePageModel.lstFavouriteCart.Count();
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




        [HttpPost]
        public async Task<IActionResult> IndexByNameAsync(string searchInput)
        {
            var currentUserw = await signInManager.UserManager.GetUserAsync(User);
            IndexHomePageModel oIndexHomePageModel = new IndexHomePageModel();
            oIndexHomePageModel.lstVwItemSellerFavouriteCount = _alAl3abDbContext.VwItemSellerFavouriteCounts.ToList();
            oIndexHomePageModel.lstTypes = _alAl3abDbContext.TbTypes.ToList();
            oIndexHomePageModel.lstMainCategories = _alAl3abDbContext.TbMainCategories.ToList();
            oIndexHomePageModel.lstSubCategories = _alAl3abDbContext.TbSubCategories.ToList();
            oIndexHomePageModel.lstSliders = _alAl3abDbContext.TbSliders.ToList();
            if (searchInput == null)
            {
                var currentUser = await signInManager.UserManager.GetUserAsync(User);
                if (currentUser == null)
                {
                    return View(oIndexHomePageModel);
                }
                oIndexHomePageModel.lstFavouriteCart = _favouriteCartService.getAll().Where(a => a.UserId == currentUser.Id);
                foreach (var i in oIndexHomePageModel.lstFavouriteCart)
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
                return View(oIndexHomePageModel);

            }
            else
            {
                var currentUser = await signInManager.UserManager.GetUserAsync(User);
                if (currentUser == null)
                {
                    return View(oIndexHomePageModel);
                }
                oIndexHomePageModel.lstFavouriteCart = _favouriteCartService.getAll().Where(a => a.UserId == currentUser.Id).Where(a=> a.ItemNameEn.Contains(searchInput, StringComparison.OrdinalIgnoreCase)).ToList();
                foreach (var i in oIndexHomePageModel.lstFavouriteCart)
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
                ViewBag.favcount = oIndexHomePageModel.lstFavouriteCart.Count();
                return View(oIndexHomePageModel);
            }


        }
        public async Task<IActionResult> AddToWishListAsync( string itemSellerId)
        {
            IndexHomePageModel oIndexHomePageModel = new IndexHomePageModel();
            oIndexHomePageModel.lstTypes = _alAl3abDbContext.TbTypes.ToList();
            oIndexHomePageModel.lstMainCategories = _alAl3abDbContext.TbMainCategories.ToList();
            oIndexHomePageModel.lstSubCategories = _alAl3abDbContext.TbSubCategories.ToList();
            oIndexHomePageModel.lstSliders = _alAl3abDbContext.TbSliders.ToList();
            var currentUser = await signInManager.UserManager.GetUserAsync(User);
            if(currentUser ==null) 
            {
                return View(oIndexHomePageModel);
            }
            var itemSeller = _itemSellerService.getAll().Where(a => a.ItemSellerId == Guid.Parse(itemSellerId)).FirstOrDefault();
          
            if (itemSeller == null)
            {
                return View(oIndexHomePageModel);
            }
            TbFavouriteCart oTbFavouriteCart = new TbFavouriteCart();
            oTbFavouriteCart.UserId = currentUser.Id;
            oTbFavouriteCart.UserName = currentUser.FirstName;
            oTbFavouriteCart.ItemId = itemSeller.ItemId;
            oTbFavouriteCart.ItemName = itemSeller.ItemName;
            oTbFavouriteCart.ItemNameEn = itemSeller.ItemNameEn;
            oTbFavouriteCart.SellerId = itemSeller.SellerId;
            oTbFavouriteCart.SellerName = itemSeller.SellerName;
            oTbFavouriteCart.SellerNameEn = itemSeller.SellerNameEn;
            oTbFavouriteCart.ItemSellerId = Guid.Parse(itemSellerId);
            oTbFavouriteCart.ItemImagePath = itemSeller.ItemImagePath;
            oTbFavouriteCart.ItemSalePrice = itemSeller.ItemSalePrice;
            oTbFavouriteCart.Region = itemSeller.RegionName;
            oTbFavouriteCart.RegionEn = itemSeller.RegionEn;
            oTbFavouriteCart.SellerItemEvaluationStarts = itemSeller.SellerItemEvaluationStarts;
            oTbFavouriteCart.SellerItemEvaluationNumbers = itemSeller.SellerItemEvaluationNumbers;
           
            var result = _favouriteCartService.Add(oTbFavouriteCart);
          
            if (result == true)
            {
                if (ResWebsite.Culture.Name == "en")
                {
                    TempData[SD.Success] = "The Game Is Added To Your WishList.";
                }
                else
                {
                    TempData[SD.Success] = "تمت اضافة اللعبة ال قائمة امفضلات";
                }

            }
            else
            {
                if (ResWebsite.Culture.Name == "en")
                {
                    TempData[SD.Error] = "Error in Adding The Game In The WishList.";
                }
                else
                {
                    TempData[SD.Error] = "لم يتم اضافة اللعبة ال قائمة امفضلات";
                }
              
            }
            oIndexHomePageModel.lstFavouriteCart = _favouriteCartService.getAll().Where(a => a.UserId == currentUser.Id);
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
            return View("Index" , oIndexHomePageModel);
        }
    }
}
