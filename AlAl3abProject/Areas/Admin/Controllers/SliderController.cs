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
using System.IO;

namespace AlAl3abProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SliderController : Controller
    {
        SliderService sliderService;

        AlAl3abDbContext ctx;
        public SliderController(SliderService SliderService, AlAl3abDbContext context)
        {

            sliderService = SliderService;
            ctx = context;

        }
        [Authorize(Roles = "Admin, السليدر")]
        public IActionResult Index()
        {

            HomePageModel model = new HomePageModel();
            model.lstSliders = sliderService.getAll();

            return View(model);


        }




        [HttpPost]
        public async Task<IActionResult> Save(TbSlider ITEM, int id, List<IFormFile> files)
        {
            if (ITEM.SliderId == null)
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
                            ITEM.SliderImagePath = ImageName;
                        }
                    }





                    var result = sliderService.Add(ITEM);
                    if (result == true)
                    {
                        TempData[SD.Success] = "Slider Profile successfully Created.";
                    }
                    else
                    {
                        TempData[SD.Error] = "Error in Slider Profile  Creating.";
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
                            ITEM.SliderImagePath = ImageName;
                        }
                    }






                    var result = sliderService.Edit(ITEM);
                    if (result == true)
                    {
                        TempData[SD.Success] = "Slider Profile successfully Updated.";
                    }
                    else
                    {
                        TempData[SD.Error] = "Error in Slider Profile  Updating.";
                    }
                }
            }




            HomePageModel model = new HomePageModel();
            model.lstSliders = sliderService.getAll();
            return View("Index", model);
        }




        [Authorize(Roles = "Admin,حذف  السليدر")]
        public IActionResult Delete(Guid id)
        {

            TbSlider oldItem = ctx.TbSliders.Where(a => a.SliderId == id).FirstOrDefault();



            var result = sliderService.Delete(oldItem);
            if (result == true)
            {
                TempData[SD.Success] = "Slider Profile successfully Removed.";
            }
            else
            {
                TempData[SD.Error] = "Error in Slider Profile  Removing.";
            }

            HomePageModel model = new HomePageModel();
            model.lstSliders = sliderService.getAll();
            return View("Index", model);



        }



        [Authorize(Roles = "Admin,اضافة او تعديل  السليدر")]
        public IActionResult Form(Guid? id)
        {
            TbSlider oldItem = ctx.TbSliders.Where(a => a.SliderId == id).FirstOrDefault();


            return View(oldItem);
        }
    }
}
