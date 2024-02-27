using AlAl3abProject.Models;
using BL;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AlAl3abProject.Controllers
{
    public class AboutUsController : Controller
    {
        private readonly AbousUsService abousUsService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly PurchasingCartService purchasingCartService;
        private readonly TypeService typeService;
        private readonly MainCategoryService mainCategoryService;
        private readonly SubCategoryService subCategoryService;
        private readonly SliderService sliderService;
        private readonly ILogger<HomeController> _logger;
        private readonly AlAl3abDbContext _alAl3abDbContext;
        public AboutUsController(AbousUsService AbousUsService,UserManager<ApplicationUser> userManager, PurchasingCartService PurchasingCartService, TypeService TypeService, MainCategoryService MainCategoryService, SubCategoryService SubCategoryService, SliderService SliderService, ILogger<HomeController> logger, AlAl3abDbContext alAl3abDbContext)
        {
            _logger = logger;
            _alAl3abDbContext = alAl3abDbContext;
            typeService = TypeService;
            mainCategoryService = MainCategoryService;
            subCategoryService = SubCategoryService;
            sliderService = SliderService;
            purchasingCartService = PurchasingCartService;
            _userManager = userManager;
            abousUsService = AbousUsService;


        }
        public async Task<IActionResult> IndexAsync()
        {
            IndexHomePageModel oIndexHomePageModel = new IndexHomePageModel();
            oIndexHomePageModel.lstTypes = typeService.getAll();
            oIndexHomePageModel.lstMainCategories = mainCategoryService.getAll();
            oIndexHomePageModel.lstSubCategories = subCategoryService.getAll();
            oIndexHomePageModel.lstSliders = sliderService.getAll();
            oIndexHomePageModel.elelmentAboutUs = abousUsService.getAll().FirstOrDefault();
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
