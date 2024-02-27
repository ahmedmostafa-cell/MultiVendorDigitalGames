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
    public class MainCategoryController : Controller
    {
        MainCategoryService mainCategoryService;
        TypeService typeService;
        AlAl3abDbContext ctx;
        public MainCategoryController(TypeService TypeService ,MainCategoryService MainCategoryService, AlAl3abDbContext context)
        {

            mainCategoryService = MainCategoryService;
            ctx = context;
            typeService = TypeService;

        }
        [Authorize(Roles = "Admin, الاقسام الرئيسية ")]
        public IActionResult Index()
        {

            HomePageModel model = new HomePageModel();
            model.lstMainCategories = mainCategoryService.getAll();
            model.lstTypes = typeService.getAll();
            return View(model);


        }




        [HttpPost]
        public async Task<IActionResult> Save(TbMainCategory ITEM, int id, List<IFormFile> files)
        {
            if (ITEM.MainCategoryId == null)
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





                    var result = mainCategoryService.Add(ITEM);
                    if (result == true)
                    {
                        TempData[SD.Success] = "Main Category Profile successfully Created.";
                    }
                    else
                    {
                        TempData[SD.Error] = "Error in Main Category Profile  Creating.";
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






                    var result = mainCategoryService.Edit(ITEM);
                    if (result == true)
                    {
                        TempData[SD.Success] = "Main Category Profile successfully Updated.";
                    }
                    else
                    {
                        TempData[SD.Error] = "Error in Main Category Profile  Updating.";
                    }
                }
            }




            HomePageModel model = new HomePageModel();
            model.lstMainCategories = mainCategoryService.getAll();
            model.lstTypes = typeService.getAll();
            return View("Index", model);
        }




        [Authorize(Roles = "Admin,حذف  الاقسام الرئيسية")]
        public IActionResult Delete(Guid id)
        {

            TbMainCategory oldItem = ctx.TbMainCategories.Where(a => a.MainCategoryId == id).FirstOrDefault();



            var result = mainCategoryService.Delete(oldItem);
            if (result == true)
            {
                TempData[SD.Success] = "Main Category Profile successfully Removed.";
            }
            else
            {
                TempData[SD.Error] = "Error in Main Category Profile  Removing.";
            }

            HomePageModel model = new HomePageModel();
            model.lstMainCategories = mainCategoryService.getAll();
            model.lstTypes = typeService.getAll();
            return View("Index", model);



        }



        [Authorize(Roles = "Admin,اضافة او تعديل  الاقسام الرئيسية")]
        public IActionResult Form(Guid? id)
        {
            TbMainCategory oldItem = ctx.TbMainCategories.Where(a => a.MainCategoryId == id).FirstOrDefault();
            ViewBag.types = typeService.getAll();

            return View(oldItem);
        }
    }
}
