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

namespace AlAl3abProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PromotingItemSellerController : Controller
    {
       PromotingItemSellerService promotingItemSellerService;
        RegionService regionService;
        SellerService sellerService;
        ItemSellerService itemSellerService;
        ItemService itemService;
        AlAl3abDbContext ctx;
        public PromotingItemSellerController(PromotingItemSellerService PromotingItemSellerService, RegionService RegionService, SellerService SellerService, ItemService ItemService, ItemSellerService ItemSellerService, AlAl3abDbContext context)
        {

            promotingItemSellerService = PromotingItemSellerService;
            itemSellerService = ItemSellerService;
            ctx = context;
            itemService = ItemService;
            sellerService = SellerService;
            regionService = RegionService;

        }
        [Authorize(Roles = "Admin, منتجات التجار المسوقة")]
        public IActionResult Index()
        {

            HomePageModel model = new HomePageModel();
            model.lstItemSellers = itemSellerService.getAll();
            model.lstItems = itemService.getAll();
            model.lstSellers = sellerService.getAll();
            model.lstRegions = regionService.getAll();
            model.lstPromotingItemSellers = promotingItemSellerService.getAll();

            return View(model);


        }




        [HttpPost]
        public async Task<IActionResult> Save(TbPromotingItemSeller ITEM, int id, List<IFormFile> files)
        {
            if (ITEM.PromotingItemSellerId == null)
            {


                if (ModelState.IsValid)
                {
                    //foreach (var file in files)
                    //{
                    //    if (file.Length > 0)
                    //    {
                    //        string ImageName = Guid.NewGuid().ToString() + ".jpg";
                    //        var filePaths = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Uploads", ImageName);
                    //        using (var stream = System.IO.File.Create(filePaths))
                    //        {
                    //            await file.CopyToAsync(stream);
                    //        }
                    //        ITEM.ab = ImageName;
                    //    }
                    //}





                    var result = promotingItemSellerService.Add(ITEM);
                    if (result == true)
                    {
                        TempData[SD.Success] = "Promotoing Item Seller Profile successfully Created.";
                    }
                    else
                    {
                        TempData[SD.Error] = "Error in Promotoing Item Seller Profile  Creating.";
                    }


                }


            }
            else
            {
                if (ModelState.IsValid)
                {
                    //foreach (var file in files)
                    //{
                    //    if (file.Length > 0)
                    //    {
                    //        string ImageName = Guid.NewGuid().ToString() + ".jpg";
                    //        var filePaths = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Uploads", ImageName);
                    //        using (var stream = System.IO.File.Create(filePaths))
                    //        {
                    //            await file.CopyToAsync(stream);
                    //        }
                    //        ITEM.MainConsultingImage = ImageName;
                    //    }
                    //}






                    var result = promotingItemSellerService.Edit(ITEM);
                    if (result == true)
                    {
                        TempData[SD.Success] = "Promotoing Item Seller Profile successfully Updated.";
                    }
                    else
                    {
                        TempData[SD.Error] = "Error in Promotoing Item Seller Profile  Updating.";
                    }
                }
            }




            HomePageModel model = new HomePageModel();
            model.lstItemSellers = itemSellerService.getAll();
            model.lstItems = itemService.getAll();
            model.lstSellers = sellerService.getAll();
            model.lstRegions = regionService.getAll();
            model.lstPromotingItemSellers = promotingItemSellerService.getAll();
            return View("Index", model);
        }




        [Authorize(Roles = "Admin,حذف  منتجات التجار المسوقة")]
        public IActionResult Delete(Guid id)
        {

            TbPromotingItemSeller oldItem = ctx.TbPromotingItemSellers.Where(a => a.PromotingItemSellerId == id).FirstOrDefault();



            var result = promotingItemSellerService.Delete(oldItem);
            if (result == true)
            {
                TempData[SD.Success] = "Promotoing Item Seller Profile successfully Removed.";
            }
            else
            {
                TempData[SD.Error] = "Error in Promotoing Item Seller Profile  Removing.";
            }

            HomePageModel model = new HomePageModel();
            model.lstItemSellers = itemSellerService.getAll();
            model.lstItems = itemService.getAll();
            model.lstSellers = sellerService.getAll();
            model.lstRegions = regionService.getAll();
            model.lstPromotingItemSellers = promotingItemSellerService.getAll();
            return View("Index", model);



        }



        [Authorize(Roles = "Admin,اضافة او تعديل  منتجات التجار المسوقة")]
        public IActionResult Form(Guid? id)
        {
            TbPromotingItemSeller oldItem = ctx.TbPromotingItemSellers.Where(a => a.PromotingItemSellerId == id).FirstOrDefault();

            ViewBag.items = itemService.getAll();
            ViewBag.sellers = sellerService.getAll();
            ViewBag.regions = regionService.getAll();
            return View(oldItem);
        }
    }
}
