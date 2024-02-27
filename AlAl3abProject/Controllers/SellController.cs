using AlAl3abProject.Models;
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
    public class SellController : Controller
    {
        private readonly CompanyTybeService companyTybeService;
        private readonly SellerService _sellerService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly PurchasingCartService purchasingCartService;
        private readonly TypeService typeService;
        private readonly MainCategoryService mainCategoryService;
        private readonly SubCategoryService subCategoryService;
        private readonly SliderService sliderService;
        private readonly ILogger<HomeController> _logger;
        private readonly AlAl3abDbContext _alAl3abDbContext;
        public SellController(CompanyTybeService CompanyTybeService,SellerService sellerService,UserManager<ApplicationUser> userManager, PurchasingCartService PurchasingCartService, TypeService TypeService, MainCategoryService MainCategoryService, SubCategoryService SubCategoryService, SliderService SliderService, ILogger<HomeController> logger, AlAl3abDbContext alAl3abDbContext)
        {
            companyTybeService = CompanyTybeService;
            _sellerService = sellerService;
            _logger = logger;
            _alAl3abDbContext = alAl3abDbContext;
            typeService = TypeService;
            mainCategoryService = MainCategoryService;
            subCategoryService = SubCategoryService;
            sliderService = SliderService;
            purchasingCartService = PurchasingCartService;
            _userManager = userManager;


        }
        public async Task<IActionResult> IndexAsync()
        {
            IndexHomePageModel oIndexHomePageModel = new IndexHomePageModel();
            oIndexHomePageModel.lstTypes = typeService.getAll();
            oIndexHomePageModel.lstMainCategories = mainCategoryService.getAll();
            oIndexHomePageModel.lstSubCategories = subCategoryService.getAll();
            oIndexHomePageModel.lstSliders = sliderService.getAll();
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

        [Authorize]
        public async Task<IActionResult> StartSellingAsync()
        {
            IndexHomePageModel oIndexHomePageModel = new IndexHomePageModel();
            oIndexHomePageModel.lstTypes = typeService.getAll();
            oIndexHomePageModel.lstMainCategories = mainCategoryService.getAll();
            oIndexHomePageModel.lstSubCategories = subCategoryService.getAll();
            oIndexHomePageModel.lstSliders = sliderService.getAll();
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
            var userCurrent = await _userManager
                  .GetUserAsync(User);
            if (userCurrent != null)
            {
                TbSeller oTbSellerCurrent = _sellerService.getAll().Where(a => a.CreatedBy == userCurrent.Id).FirstOrDefault();
                oIndexHomePageModel.seller = oTbSellerCurrent;
                return View(oIndexHomePageModel);

            }
            return View(oIndexHomePageModel);
        }

      



        [HttpPost]
        public async Task<IActionResult> SaveForLaterStartSellingAsync(string fullnameen ,string fullname, string date , string email , string phone , string businessaddress ,string city, string zipcode ,string country , string tradename , string website , string taxidentiicationnumber , string vatnumber)
        {
            IndexHomePageModel oIndexHomePageModel = new IndexHomePageModel();
            oIndexHomePageModel.lstTypes = typeService.getAll();
            oIndexHomePageModel.lstMainCategories = mainCategoryService.getAll();
            oIndexHomePageModel.lstSubCategories = subCategoryService.getAll();
            oIndexHomePageModel.lstSliders = sliderService.getAll();
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
            var userc = await _userManager
                    .GetUserAsync(User);

           
           
            var result = true;
            if (_sellerService.getAll().Any(a=> a.CreatedBy == userc.Id)) 
            {
                TbSeller oTbSeller = _sellerService.getAll().Where(a => a.CreatedBy == userc.Id).FirstOrDefault();
                oTbSeller.SellerFullNamen = fullnameen;
                oTbSeller.SellerFullName = fullname;
                oTbSeller.Address = businessaddress;
                oTbSeller.DateOfBirth = date;
                oTbSeller.SellerEmail = email;
                oTbSeller.SellerPhoneNumber = phone;
                oTbSeller.CityName = city;
                oTbSeller.ZipCode = zipcode;
                oTbSeller.CountryName = country;
                oTbSeller.BusinessTradeName = tradename;
                oTbSeller.BusinessWebsite = website;
                oTbSeller.TaxIdentificationNo = taxidentiicationnumber;
                oTbSeller.VatNumber = vatnumber;

                oTbSeller.CreatedBy = userc.Id;
                result = _sellerService.Edit(oTbSeller);

            }
            else 
            {
                TbSeller oTbSeller = new TbSeller();
                oTbSeller.SellerFullNamen = fullnameen;
                oTbSeller.SellerFullName = fullname;
                oTbSeller.Address = businessaddress;
                oTbSeller.DateOfBirth = date;
                oTbSeller.SellerEmail = email;
                oTbSeller.SellerPhoneNumber = phone;
                oTbSeller.CityName = city;
                oTbSeller.ZipCode = zipcode;
                oTbSeller.CountryName = country;
                oTbSeller.BusinessTradeName = tradename;
                oTbSeller.BusinessWebsite = website;
                oTbSeller.TaxIdentificationNo = taxidentiicationnumber;
                oTbSeller.VatNumber = vatnumber;
                oTbSeller.CreatedBy = userc.Id;
               result = _sellerService.Add(oTbSeller);
            }
             


           
            
            if (result == true)
            {
                TempData[SD.Success] = "Seller  is saved for later successfully.";
            }
            else
            {
                TempData[SD.Error] = "Seller  is not saved for later.";
            }
            return RedirectToAction("Index", "Home");
        }



        [HttpPost]
        public async Task<IActionResult> ContinueStartSellingAsync(string fullname, string date, string email, string phone, string businessaddress, string city, string zipcode, string country, string tradename, string website, string taxidentiicationnumber, string vatnumber)
        {
            IndexHomePageModel oIndexHomePageModel = new IndexHomePageModel();
            oIndexHomePageModel.lstTypes = typeService.getAll();
            oIndexHomePageModel.lstMainCategories = mainCategoryService.getAll();
            oIndexHomePageModel.lstSubCategories = subCategoryService.getAll();
            oIndexHomePageModel.lstSliders = sliderService.getAll();
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

        [HttpGet]
        public async Task<IActionResult> tradeAsync()
        {
            IndexHomePageModel oIndexHomePageModel = new IndexHomePageModel();
            oIndexHomePageModel.lstTypes = typeService.getAll();
            oIndexHomePageModel.lstMainCategories = mainCategoryService.getAll();
            oIndexHomePageModel.lstSubCategories = subCategoryService.getAll();
            oIndexHomePageModel.lstSliders = sliderService.getAll();
            oIndexHomePageModel.lstCompanyTypes = companyTybeService.getAll();
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
            var userCurrent = await _userManager
                   .GetUserAsync(User);
            if (userCurrent != null)
            {
                TbSeller oTbSellerCurrent = _sellerService.getAll().Where(a => a.CreatedBy == userCurrent.Id).FirstOrDefault();
                oIndexHomePageModel.seller = oTbSellerCurrent;
                return View(oIndexHomePageModel);

            }
            return View(oIndexHomePageModel);
        }


        [HttpPost]
        public async Task<IActionResult> trade()
        {
            IndexHomePageModel oIndexHomePageModel = new IndexHomePageModel();
            oIndexHomePageModel.lstTypes = typeService.getAll();
            oIndexHomePageModel.lstMainCategories = mainCategoryService.getAll();
            oIndexHomePageModel.lstSubCategories = subCategoryService.getAll();
            oIndexHomePageModel.lstSliders = sliderService.getAll();
            oIndexHomePageModel.lstCompanyTypes = companyTybeService.getAll();
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
            var userCurrent = await _userManager
                   .GetUserAsync(User);
            if (userCurrent != null)
            {
                TbSeller oTbSellerCurrent = _sellerService.getAll().Where(a => a.CreatedBy == userCurrent.Id).FirstOrDefault();
                oIndexHomePageModel.seller = oTbSellerCurrent;
                oIndexHomePageModel.lstgtypes = new List<System.Web.Mvc.SelectListItem>();
                foreach (var item in oIndexHomePageModel.lstCompanyTypes)
                {
                    if (oTbSellerCurrent.CompanyTypeId == item.CompanyTypeId) 
                    {
                        System.Web.Mvc.SelectListItem a = new System.Web.Mvc.SelectListItem();
                        a.Value = item.CompanyTypeId.ToString();
                        a.Selected = true;
                        a.Text = item.CompanyTypeTitle;
                        oIndexHomePageModel.lstgtypes.Add(a);

                    }
                    else 
                    {
                        System.Web.Mvc.SelectListItem a = new System.Web.Mvc.SelectListItem();
                        a.Value = item.CompanyTypeId.ToString();
                        a.Selected = false;
                        a.Text = item.CompanyTypeTitle;
                        oIndexHomePageModel.lstgtypes.Add(a);

                    }
                   
                }
                return View(oIndexHomePageModel);

            }
           
            return View(oIndexHomePageModel);
        }




        [HttpPost]
        public async Task<IActionResult> SaveForLatertradeAsync(string fullnameen, string companytype, string companyname, string companynumber, string businessaddress, string businesscityname, string businsesszipcode, string businesscountry)
        {
            IndexHomePageModel oIndexHomePageModel = new IndexHomePageModel();
            oIndexHomePageModel.lstTypes = typeService.getAll();
            oIndexHomePageModel.lstMainCategories = mainCategoryService.getAll();
            oIndexHomePageModel.lstSubCategories = subCategoryService.getAll();
            oIndexHomePageModel.lstSliders = sliderService.getAll();
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
            var userc = await _userManager
                    .GetUserAsync(User);



            var result = true;
            if (_sellerService.getAll().Any(a => a.CreatedBy == userc.Id))
            {
                TbSeller oTbSeller = _sellerService.getAll().Where(a => a.CreatedBy == userc.Id).FirstOrDefault();
                oTbSeller.SupplierName = fullnameen;
                oTbSeller.CompanyTypeId = Guid.Parse(companytype);
                oTbSeller.CompanyType = companyTybeService.getAll().Where(a=> a.CompanyTypeId == oTbSeller.CompanyTypeId).FirstOrDefault().CompanyTypeTitle;
                oTbSeller.CompanyTypeEn = companyTybeService.getAll().Where(a => a.CompanyTypeId == oTbSeller.CompanyTypeId).FirstOrDefault().CompanyTypeEn;
                oTbSeller.CompanyName = companyname;
                oTbSeller.CompanyNumber = companynumber;
                oTbSeller.BusinessAddress = businessaddress;
                oTbSeller.BusinessCityName = businesscityname;
                oTbSeller.BusinessZipCode = businsesszipcode;
                oTbSeller.BusinessCountry = businesscountry;
                oTbSeller.CreatedBy = userc.Id;

                result = _sellerService.Edit(oTbSeller);

            }
            else
            {
                TbSeller oTbSeller = new TbSeller();
                oTbSeller.SupplierName = fullnameen;
                oTbSeller.CompanyTypeId = Guid.Parse(companytype);
                oTbSeller.CompanyType = companyTybeService.getAll().Where(a => a.CompanyTypeId == oTbSeller.CompanyTypeId).FirstOrDefault().CompanyTypeTitle;
                oTbSeller.CompanyTypeEn = companyTybeService.getAll().Where(a => a.CompanyTypeId == oTbSeller.CompanyTypeId).FirstOrDefault().CompanyTypeEn;
                oTbSeller.CompanyName = companyname;
                oTbSeller.CompanyNumber = companynumber;
                oTbSeller.BusinessAddress = businessaddress;
                oTbSeller.BusinessCityName = businesscityname;
                oTbSeller.BusinessZipCode = businsesszipcode;
                oTbSeller.BusinessCountry = businesscountry;
                oTbSeller.CreatedBy = userc.Id;
                result = _sellerService.Add(oTbSeller);
            }


            var userCurrent = await _userManager
                   .GetUserAsync(User);
            if (userCurrent != null)
            {
                TbSeller oTbSellerCurrent = _sellerService.getAll().Where(a => a.CreatedBy == userCurrent.Id).FirstOrDefault();
                oIndexHomePageModel.seller = oTbSellerCurrent;
                oIndexHomePageModel.lstgtypes = new List<System.Web.Mvc.SelectListItem>();
                foreach (var item in oIndexHomePageModel.lstCompanyTypes)
                {
                    if (oTbSellerCurrent.CompanyTypeId == item.CompanyTypeId)
                    {
                        System.Web.Mvc.SelectListItem a = new System.Web.Mvc.SelectListItem();
                        a.Value = item.CompanyTypeId.ToString();
                        a.Selected = true;
                        a.Text = item.CompanyTypeTitle;
                        oIndexHomePageModel.lstgtypes.Add(a);

                    }
                    else
                    {
                        System.Web.Mvc.SelectListItem a = new System.Web.Mvc.SelectListItem();
                        a.Value = item.CompanyTypeId.ToString();
                        a.Selected = false;
                        a.Text = item.CompanyTypeTitle;
                        oIndexHomePageModel.lstgtypes.Add(a);

                    }

                }
              

            }


            if (result == true)
            {
                TempData[SD.Success] = "Seller  is saved for later successfully.";
            }
            else
            {
                TempData[SD.Error] = "Seller  is not saved for later.";
            }
            return RedirectToAction("Index", "Home");
        }












        public async Task<IActionResult> offerAsync()
        {
            IndexHomePageModel oIndexHomePageModel = new IndexHomePageModel();
            oIndexHomePageModel.lstTypes = typeService.getAll();
            oIndexHomePageModel.lstMainCategories = mainCategoryService.getAll();
            oIndexHomePageModel.lstSubCategories = subCategoryService.getAll();
            oIndexHomePageModel.lstSliders = sliderService.getAll();
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




        public async Task<IActionResult> DocumentsAsync()
        {
            IndexHomePageModel oIndexHomePageModel = new IndexHomePageModel();
            oIndexHomePageModel.lstTypes = typeService.getAll();
            oIndexHomePageModel.lstMainCategories = mainCategoryService.getAll();
            oIndexHomePageModel.lstSubCategories = subCategoryService.getAll();
            oIndexHomePageModel.lstSliders = sliderService.getAll();
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
