using AlAl3abProject.Models;
using BL;
using Domains;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Authorization;
using System.IO;
using Microsoft.AspNetCore.Identity;

namespace AlAl3abProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ItemSellerController : Controller
    {
        private readonly CountryService countryService;
        private readonly UserManager<ApplicationUser> _userManager;
        RegionService regionService;
        SellerService sellerService;
        ItemSellerService itemSellerService;
        ItemService itemService;
        AlAl3abDbContext ctx;
        public ItemSellerController(CountryService CountryService,UserManager<ApplicationUser> userManager, RegionService RegionService,SellerService SellerService,ItemService ItemService ,ItemSellerService ItemSellerService, AlAl3abDbContext context)
        {
           
            itemSellerService = ItemSellerService;
            ctx = context;
            itemService = ItemService;
            sellerService = SellerService;
            regionService = RegionService;
            _userManager = userManager;
            countryService = CountryService;


        }
        [Authorize(Roles = "Admin, منتجات التجار")]
        public async Task<IActionResult> IndexAsync()
        {

            HomePageModel model = new HomePageModel();
           
            model.lstItems = itemService.getAll();
            model.lstSellers = sellerService.getAll();
            model.lstRegions = regionService.getAll();
            ViewBag.countries = countryService.getAll();
            var loggedUser = await _userManager.GetUserAsync(HttpContext.User);
            var roles = await _userManager.GetRolesAsync(loggedUser);
            if (roles.Contains("Admin"))
            {


                model.lstItemSellers = itemSellerService.getAll();
                return View(model);
            }
            else
            {


                model.lstItemSellers = itemSellerService.getAll().Where(A => A.CreatedBy == loggedUser.Id).ToList();
                return View(model);
            }
            

        }




        [HttpPost]
        public async Task<IActionResult> Save(TbItemSeller ITEM, int id, List<IFormFile> files)
        {
            HomePageModel model = new HomePageModel();
            model.lstCountries = countryService.getAll();
            if (ITEM.SellerId != null) 
            {
                ITEM.CreatedBy = sellerService.getAll().Where(a => a.SellerId == ITEM.SellerId).FirstOrDefault().CreatedBy;
            }
            else 
            {
                ITEM.SellerId = sellerService.getAll().Where(a => a.CreatedBy == ITEM.CreatedBy).FirstOrDefault().SellerId;
            }
            ITEM.CountryName = model.lstCountries.Where(A=> A.CountryId == ITEM.CountryId).FirstOrDefault().CountryName;
            ITEM.CountryNameEn = model.lstCountries.Where(A => A.CountryId == ITEM.CountryId).FirstOrDefault().CountryNameEn;
            ITEM.RegionName = regionService.getAll().Where(A => A.RegionId == ITEM.RegionId).FirstOrDefault().RegionName;
            ITEM.RegionEn = regionService.getAll().Where(A => A.RegionId == ITEM.RegionId).FirstOrDefault().RegionNameEn;
            ITEM.ItemName = itemService.getAll().Where(a=> a.ItemId == ITEM.ItemId).FirstOrDefault().ItemName;
            ITEM.ItemNameEn = itemService.getAll().Where(a => a.ItemId == ITEM.ItemId).FirstOrDefault().ItemNameEn;
            ITEM.SellerNameEn = sellerService.getAll().Where(a => a.SellerId == ITEM.SellerId).FirstOrDefault().SellerFullNamen;
            ITEM.SellerName = sellerService.getAll().Where(a => a.SellerId == ITEM.SellerId).FirstOrDefault().SellerFullName;
            ITEM.NumberOfAddFavourite = 0;
            ITEM.NumberOfSalesTransaction = "0";
            ITEM.SellerItemEvaluationNumbers = "0";
            ITEM.NumberOfSalesTransaction = "0";
            if (ITEM.ItemSellerId == null)
            {


                if (ModelState.IsValid)
                {
                    foreach (var file in files)
                    {
                        if (file.Length > 0)
                        {
                            string ImageName = Guid.NewGuid().ToString() + ".jpg";
                            var filePaths = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Uploads", ImageName);
                            using (var stream = System.IO.File.Create(filePaths))
                            {
                                await file.CopyToAsync(stream);
                            }
                            ITEM.ItemImagePath = ImageName;
                        }
                    }





                    var result = itemSellerService.Add(ITEM);
                    if (result == true)
                    {
                        TempData[SD.Success] = "Item Seller Profile successfully Created.";
                    }
                    else
                    {
                        TempData[SD.Error] = "Error in Item Seller Profile  Creating.";
                    }


                }


            }
            else
            {
                if (ModelState.IsValid)
                {
                    foreach (var file in files)
                    {
                        if (file.Length > 0)
                        {
                            string ImageName = Guid.NewGuid().ToString() + ".jpg";
                            var filePaths = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Uploads", ImageName);
                            using (var stream = System.IO.File.Create(filePaths))
                            {
                                await file.CopyToAsync(stream);
                            }
                            ITEM.ItemImagePath = ImageName;
                        }
                    }






                    var result = itemSellerService.Edit(ITEM);
                    if (result == true)
                    {
                        TempData[SD.Success] = "Item Seller Profile successfully Updated.";
                    }
                    else
                    {
                        TempData[SD.Error] = "Error in Item Seller Profile  Updating.";
                    }
                }
            }




           
            model.lstItemSellers = itemSellerService.getAll();
            model.lstItems = itemService.getAll();
            model.lstSellers = sellerService.getAll();
            model.lstRegions = regionService.getAll();
            ViewBag.countries = countryService.getAll();
            return View("Index", model);
        }




        [Authorize(Roles = "Admin,حذف  منتجات التجار")]
        public IActionResult Delete(Guid id)
        {

            TbItemSeller oldItem = ctx.TbItemSellers.Where(a => a.ItemSellerId == id).FirstOrDefault();



            var result = itemSellerService.Delete(oldItem);
            if (result == true)
            {
                TempData[SD.Success] = "Item Seller Profile successfully Removed.";
            }
            else
            {
                TempData[SD.Error] = "Error in Item Seller Profile  Removing.";
            }

            HomePageModel model = new HomePageModel();
            model.lstItemSellers = itemSellerService.getAll();
            model.lstItems = itemService.getAll();
            model.lstSellers = sellerService.getAll();
            model.lstRegions = regionService.getAll();
            ViewBag.countries = countryService.getAll();
            return View("Index", model);



        }



        [Authorize(Roles = "Admin,اضافة او تعديل  منتجات التجار")]
        public IActionResult Form(Guid? id)
        {
            TbItemSeller oldItem = ctx.TbItemSellers.Where(a => a.ItemSellerId == id).FirstOrDefault();
            ViewBag.items = itemService.getAll();
            ViewBag.sellers = sellerService.getAll();
            ViewBag.regions = regionService.getAll();
            ViewBag.countries = countryService.getAll();    
            return View(oldItem);
        }
    }
}
