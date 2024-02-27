using AlAl3abProject.Models;
using BL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Authorization;
using Domains;
using System.Linq;

namespace AlAl3abProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AboutUController : Controller
    {
        AbousUsService abousUsService;

        AlAl3abDbContext ctx;
        public AboutUController(AbousUsService AbousUsService, AlAl3abDbContext context)
        {

            abousUsService = AbousUsService;
            ctx = context;

        }
        [Authorize(Roles = "Admin,عن التطبيق")]
        public IActionResult Index()
        {

            HomePageModel model = new HomePageModel();
            model.lstAboutU = abousUsService.getAll();

            return View(model);


        }




        [HttpPost]
        public async Task<IActionResult> Save(TbAboutU ITEM, int id, List<IFormFile> files)
        {
            if (ITEM.AboutUsId == null)
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





                    var result = abousUsService.Add(ITEM);
                    if (result == true)
                    {
                        TempData[SD.Success] = "AboutUs Profile successfully Created.";
                    }
                    else
                    {
                        TempData[SD.Error] = "Error in AboutUs Profile  Creating.";
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






                    var result = abousUsService.Edit(ITEM);
                    if (result == true)
                    {
                        TempData[SD.Success] = "AboutUs Profile successfully Updated.";
                    }
                    else
                    {
                        TempData[SD.Error] = "Error in AboutUs Profile  Updating.";
                    }

                }
            }




            HomePageModel model = new HomePageModel();
            model.lstAboutU = abousUsService.getAll();
            return View("Index", model);
        }




        [Authorize(Roles = "Admin,حذف عن الموقع")]
        public IActionResult Delete(Guid id)
        {

            TbAboutU oldItem = ctx.TbAboutUs.Where(a => a.AboutUsId == id).FirstOrDefault();



            var result = abousUsService.Delete(oldItem);
            if (result == true)
            {
                TempData[SD.Success] = "AboutUs Profile successfully Removed.";
            }
            else
            {
                TempData[SD.Error] = "Error in AboutUs Profile  Removing.";
            }

            HomePageModel model = new HomePageModel();
            model.lstAboutU = abousUsService.getAll();
            return View("Index", model);



        }



        [Authorize(Roles = "Admin,اضافة او تعديل عن التطبيق")]
        public IActionResult Form(Guid? id)
        {
            TbAboutU oldItem = ctx.TbAboutUs.Where(a => a.AboutUsId == id).FirstOrDefault();
           

            return View(oldItem);
        }
    }
}
