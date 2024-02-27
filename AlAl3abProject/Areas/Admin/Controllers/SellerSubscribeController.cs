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
    public class SellerSubscribeController : Controller
    {
        SellerSubscribeService _sellerSubscribeService;
        SellerService sellerService;
        AlAl3abDbContext ctx;
        public SellerSubscribeController(SellerService SellerService , SellerSubscribeService sellerSubscribeService, AlAl3abDbContext context)
        {

            _sellerSubscribeService = sellerSubscribeService;
            ctx = context;
            sellerService = SellerService;
        }
        [Authorize(Roles = "Admin, اشتراكات التجار")]
        public IActionResult Index()
        {

            HomePageModel model = new HomePageModel();
            model.lstSellerSubscribes = _sellerSubscribeService.getAll();

            return View(model);


        }




        [HttpPost]
        public async Task<IActionResult> Save(TbSellerSubscribe ITEM, int id, List<IFormFile> files)
        {
            if (ITEM.SellerSubscribeId == null)
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





                    var result = _sellerSubscribeService.Add(ITEM);
                    if (result == true)
                    {
                        TempData[SD.Success] = "Seller Subscribe Profile successfully Created.";
                    }
                    else
                    {
                        TempData[SD.Error] = "Error in Seller Subscribe Profile  Creating.";
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






                    var result = _sellerSubscribeService.Edit(ITEM);
                    if (result == true)
                    {
                        TempData[SD.Success] = "Seller Subscribe Profile successfully Updated.";
                    }
                    else
                    {
                        TempData[SD.Error] = "Error in Seller Subscribe Profile  Updating.";
                    }
                }
            }




            HomePageModel model = new HomePageModel();
            model.lstSellerSubscribes = _sellerSubscribeService.getAll();
            return View("Index", model);
        }




        [Authorize(Roles = "Admin,حذف  اشتراكات التجار")]
        public IActionResult Delete(Guid id)
        {

            TbSellerSubscribe oldItem = ctx.TbSellerSubscribes.Where(a => a.SellerSubscribeId == id).FirstOrDefault();



            var result = _sellerSubscribeService.Delete(oldItem);
            if (result == true)
            {
                TempData[SD.Success] = "Seller Subscribe Profile successfully Removed.";
            }
            else
            {
                TempData[SD.Error] = "Error in Seller Subscribe Profile  Removing.";
            }

            HomePageModel model = new HomePageModel();
            model.lstSellerSubscribes = _sellerSubscribeService.getAll();
            return View("Index", model);



        }



        [Authorize(Roles = "Admin,اضافة او تعديل  اشتراكات التجار")]
        public IActionResult Form(Guid? id)
        {
            TbSellerSubscribe oldItem = ctx.TbSellerSubscribes.Where(a => a.SellerSubscribeId == id).FirstOrDefault();

            ViewBag.sellers = sellerService.getAll();
            return View(oldItem);
        }
    }
}
