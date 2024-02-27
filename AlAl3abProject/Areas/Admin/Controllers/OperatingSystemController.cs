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
    public class OperatingSystemController : Controller
    {
       

        AlAl3abDbContext ctx;
        OperatingSystemService operatingSystemService;
        public OperatingSystemController(OperatingSystemService OperatingSystemService,BlogTopicService BlogTopicService, AlAl3abDbContext context)
        {

            operatingSystemService = OperatingSystemService;
            ctx = context;

        }
        [Authorize(Roles = "Admin, نظام التشغيل")]
        public IActionResult Index()
        {

            HomePageModel model = new HomePageModel();
            model.lstOperatingSystem = operatingSystemService.getAll();

            return View(model);


        }




        [HttpPost]
        public async Task<IActionResult> Save(TbOperatingSystem ITEM, int id, List<IFormFile> files)
        {
            if (ITEM.OperatingSystemId == null)
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





                    var result = operatingSystemService.Add(ITEM);
                    if (result == true)
                    {
                        TempData[SD.Success] = "Operating System Profile successfully Created.";
                    }
                    else
                    {
                        TempData[SD.Error] = "Error in Operating System Profile  Creating.";
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






                    var result = operatingSystemService.Edit(ITEM);
                    if (result == true)
                    {
                        TempData[SD.Success] = "Operating System Profile successfully Updated.";
                    }
                    else
                    {
                        TempData[SD.Error] = "Error in Operating System Profile  Updating.";
                    }
                }
            }




            HomePageModel model = new HomePageModel();
            model.lstOperatingSystem = operatingSystemService.getAll();

            return View("Index", model);
        }




        [Authorize(Roles = "Admin,حذف  نظام التشغيل")]
        public IActionResult Delete(Guid id)
        {

            TbOperatingSystem oldItem = ctx.TbOperatingSystems.Where(a => a.OperatingSystemId == id).FirstOrDefault();



            var result = operatingSystemService.Delete(oldItem);
            if (result == true)
            {
                TempData[SD.Success] = "Operating System Profile successfully Removed.";
            }
            else
            {
                TempData[SD.Error] = "Error in Operating System Profile  Removing.";
            }

            HomePageModel model = new HomePageModel();
            model.lstOperatingSystem = operatingSystemService.getAll();

            return View("Index", model);



        }



        [Authorize(Roles = "Admin,اضافة او تعديل  نظام التشغيل")]
        public IActionResult Form(Guid? id)
        {
            TbOperatingSystem oldItem = ctx.TbOperatingSystems.Where(a => a.OperatingSystemId == id).FirstOrDefault();


            return View(oldItem);
        }
    }
}
