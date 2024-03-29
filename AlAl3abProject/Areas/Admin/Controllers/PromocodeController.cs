﻿using AlAl3abProject.Models;
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
    public class PromocodeController : Controller
    {
        PromocodeService promocodeService;

        AlAl3abDbContext ctx;
        public PromocodeController(PromocodeService PromocodeService, AlAl3abDbContext context)
        {

            promocodeService = PromocodeService;
            ctx = context;

        }
        [Authorize(Roles = "Admin, البروموكود")]
        public IActionResult Index()
        {

            HomePageModel model = new HomePageModel();
            model.lstPromocodes = promocodeService.getAll();

            return View(model);


        }




        [HttpPost]
        public async Task<IActionResult> Save(TbPromocode ITEM, int id, List<IFormFile> files)
        {
            if (ITEM.PromocodeId == null)
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





                    var result = promocodeService.Add(ITEM);
                    if (result == true)
                    {
                        TempData[SD.Success] = "Promocode Profile successfully Created.";
                    }
                    else
                    {
                        TempData[SD.Error] = "Error in Promocode Profile  Creating.";
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






                    var result = promocodeService.Edit(ITEM);
                    if (result == true)
                    {
                        TempData[SD.Success] = "Promocode Profile successfully Updated.";
                    }
                    else
                    {
                        TempData[SD.Error] = "Error in Promocode Profile  Updating.";
                    }
                }
            }




            HomePageModel model = new HomePageModel();
            model.lstPromocodes = promocodeService.getAll();
            return View("Index", model);
        }




        [Authorize(Roles = "Admin,حذف  البروموكود")]
        public IActionResult Delete(Guid id)
        {

            TbPromocode oldItem = ctx.TbPromocodes.Where(a => a.PromocodeId == id).FirstOrDefault();



            var result = promocodeService.Delete(oldItem);
            if (result == true)
            {
                TempData[SD.Success] = "Promocode Profile successfully Removed.";
            }
            else
            {
                TempData[SD.Error] = "Error in Promocode Profile  Removing.";
            }

            HomePageModel model = new HomePageModel();
            model.lstPromocodes = promocodeService.getAll();
            return View("Index", model);



        }



        [Authorize(Roles = "Admin,اضافة او تعديل  البروموكود")]
        public IActionResult Form(Guid? id)
        {
            TbPromocode oldItem = ctx.TbPromocodes.Where(a => a.PromocodeId == id).FirstOrDefault();


            return View(oldItem);
        }
    }
}
