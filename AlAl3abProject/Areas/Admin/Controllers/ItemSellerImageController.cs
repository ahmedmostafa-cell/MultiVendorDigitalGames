using AlAl3abProject.Models;
using BL;
using Domains;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace AlAl3abProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ItemSellerImageController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ItemSellerImageService itemSellerImageService;
        RegionService regionService;
        SellerService sellerService;
        ItemSellerService itemSellerService;
        ItemService itemService;
        AlAl3abDbContext ctx;
        public ItemSellerImageController(UserManager<ApplicationUser> userManager ,ItemSellerImageService ItemSellerImageService,RegionService RegionService, SellerService SellerService, ItemService ItemService, ItemSellerService ItemSellerService, AlAl3abDbContext context)
        {

            itemSellerService = ItemSellerService;
            ctx = context;
            itemService = ItemService;
            sellerService = SellerService;
            regionService = RegionService;
            itemSellerImageService = ItemSellerImageService;
            _userManager = userManager;

        }
        [Authorize(Roles = "Admin, صور منتجات التجار")]
        public async Task<IActionResult> IndexAsync()
        {
            HomePageModel model = new HomePageModel();
            model.lstItemSellers = itemSellerService.getAll();
            model.lstItems = itemService.getAll();
            model.lstSellers = sellerService.getAll();
            model.lstRegions = regionService.getAll();
            var loggedUser = await  _userManager.GetUserAsync(HttpContext.User);
            var roles = await _userManager.GetRolesAsync(loggedUser);
            if (roles.Contains("Admin"))
            {
              
               
                model.lstItemSellerImages = itemSellerImageService.getAll();
                return View(model);
            }
            else 
            {
               
               
                model.lstItemSellerImages = itemSellerImageService.getAll().Where(A=> A.CreatedBy == loggedUser.Id).ToList();
                return View(model);
            }


            

        }




        [HttpPost]
        public async Task<IActionResult> Save(TbItemSellerImages ITEM, int id, List<IFormFile> files)
        {
            ITEM.RegionName = regionService.getAll().Where(A => A.RegionId == ITEM.RegionId).FirstOrDefault().RegionName;
            ITEM.RegionEn = regionService.getAll().Where(A => A.RegionId == ITEM.RegionId).FirstOrDefault().RegionNameEn;
            ITEM.ItemName = itemService.getAll().Where(a => a.ItemId == ITEM.ItemId).FirstOrDefault().ItemName;
            ITEM.ItemNameEn = itemService.getAll().Where(a => a.ItemId == ITEM.ItemId).FirstOrDefault().ItemNameEn;
            ITEM.SellerNameEn = sellerService.getAll().Where(a => a.SellerId == ITEM.SellerId).FirstOrDefault().SellerFullNamen;
            ITEM.SellerName = sellerService.getAll().Where(a => a.SellerId == ITEM.SellerId).FirstOrDefault().SellerFullName;
            
            if (ITEM.ItemSellerImageId == null)
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





                    var result = itemSellerImageService.Add(ITEM);
                    if (result == true)
                    {
                        TempData[SD.Success] = "Item Seller Image Profile successfully Created.";
                    }
                    else
                    {
                        TempData[SD.Error] = "Error in Item Seller Image Profile  Creating.";
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






                    var result = itemSellerImageService.Edit(ITEM);
                    if (result == true)
                    {
                        TempData[SD.Success] = "Item Seller Image Profile successfully Updated.";
                    }
                    else
                    {
                        TempData[SD.Error] = "Error in Item Seller Image Profile  Updating.";
                    }
                }
            }




            HomePageModel model = new HomePageModel();
            model.lstItemSellers = itemSellerService.getAll();
            model.lstItems = itemService.getAll();
            model.lstSellers = sellerService.getAll();
            model.lstRegions = regionService.getAll();
            var loggedUser = await _userManager.GetUserAsync(HttpContext.User);
            var roles = await _userManager.GetRolesAsync(loggedUser);
            if (roles.Contains("Admin"))
            {


                model.lstItemSellerImages = itemSellerImageService.getAll();
                return View("Index", model);
            }
            else
            {


                model.lstItemSellerImages = itemSellerImageService.getAll().Where(A => A.CreatedBy == loggedUser.Id).ToList();
                return View("Index", model);
            }
           
        }




        [Authorize(Roles = "Admin,حذف  صور منتجات التجار")]
        public IActionResult Delete(Guid id)
        {

            TbItemSellerImages oldItem = ctx.TbItemSellerImagess.Where(a => a.ItemSellerImageId == id).FirstOrDefault();



            var result = itemSellerImageService.Delete(oldItem);
            if (result == true)
            {
                TempData[SD.Success] = "Item Seller Profile Image successfully Removed.";
            }
            else
            {
                TempData[SD.Error] = "Error in Item Seller Image Profile  Removing.";
            }

            HomePageModel model = new HomePageModel();
            model.lstItemSellers = itemSellerService.getAll();
            model.lstItems = itemService.getAll();
            model.lstSellers = sellerService.getAll();
            model.lstRegions = regionService.getAll();
            model.lstItemSellerImages = itemSellerImageService.getAll();
            return View("Index", model);



        }



        [Authorize(Roles = "Admin,اضافة او تعديل  صور منتجات التجار")]
        public IActionResult Form(Guid? id)
        {
            TbItemSellerImages oldItem = ctx.TbItemSellerImagess.Where(a => a.ItemSellerImageId == id).FirstOrDefault();
            ViewBag.items = itemService.getAll();
            ViewBag.sellers = sellerService.getAll();
            ViewBag.regions = regionService.getAll();
            return View(oldItem);
        }
        [Authorize(Roles = "Admin,اضافة او تعديل  صور منتجات التجار")]
        public IActionResult GetItemSellerElement(Guid? id)
        {
            TbItemSellerImages oldItem = new TbItemSellerImages();
            TbItemSeller element = itemSellerService.getAll().Where(a => a.ItemSellerId == id).FirstOrDefault();
            oldItem.ItemName = element.ItemName;
            oldItem.ItemNameEn = element.ItemNameEn;
            oldItem.Notes = element.Notes;
            oldItem.SellerName = element.SellerName;
            oldItem.ItemId = element.ItemId;
            oldItem.BestSellingEGiftCard = element.BestSellingEGiftCard;
            oldItem.BestSellingGiftCard = element.BestSellingGiftCard;
            oldItem.UpComingGames = element.UpComingGames;
            oldItem.UpdatedBy = element.UpdatedBy;
            oldItem.CreatedBy = element.CreatedBy;
            oldItem.UpdatedDate = element.UpdatedDate;
            oldItem.UpdatedBy = element.UpdatedBy;
            oldItem.CurrentState = element.CurrentState;
            oldItem.ItemSalePrice = element.ItemSalePrice;
           
            oldItem.NumberOfAddFavourite = element.NumberOfAddFavourite;
            oldItem.NumberOfSalesTransaction = element.NumberOfSalesTransaction;
            oldItem.Promoted = element.Promoted;
            oldItem.Region = element.Region;
            oldItem.RegionEn = element.RegionEn;
            oldItem.RegionId = element.RegionId;
            oldItem.RegionName = element.RegionName;
            oldItem.WebsiteProfitMargin = element.WebsiteProfitMargin;
            oldItem.SellerNameEn = element.SellerNameEn;
            oldItem.SellerName = element.SellerName;
            oldItem.SellerItemEvaluationNumbers = element.SellerItemEvaluationNumbers;
            oldItem.SellerItemEvaluationStarts = element.SellerItemEvaluationStarts;
            oldItem.SellerId = element.SellerId;
            oldItem.RegionNavigation = element.RegionNavigation;
            ViewBag.items = itemService.getAll();
            ViewBag.sellers = sellerService.getAll();
            ViewBag.regions = regionService.getAll();
            return View(oldItem);
        }
    }
}
