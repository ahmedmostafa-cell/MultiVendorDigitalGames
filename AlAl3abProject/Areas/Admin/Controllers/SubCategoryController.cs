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
    public class SubCategoryController : Controller
    {
        SubCategoryService subCategoryService;
        MainCategoryService mainCategoryService;
        AlAl3abDbContext ctx;
        public SubCategoryController(MainCategoryService MainCategoryService,SubCategoryService SubCategoryService, AlAl3abDbContext context)
        {

            subCategoryService = SubCategoryService;
            ctx = context;
            mainCategoryService = MainCategoryService;

        }
        [Authorize(Roles = "Admin,الاقسام الفرعية للاقسام الرئيسية ")]
        public IActionResult Index()
        {

            HomePageModel model = new HomePageModel();
            model.lstSubCategories = subCategoryService.getAll();
            model.lstMainCategories = mainCategoryService.getAll();
            return View(model);


        }




        [HttpPost]
        public async Task<IActionResult> Save(TbSubCategory ITEM, int id, List<IFormFile> files)
        {
            if (ITEM.SubCategoryId == null)
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





                    var result = subCategoryService.Add(ITEM);
                    if (result == true)
                    {
                        TempData[SD.Success] = "Sub Category Profile successfully Created.";
                    }
                    else
                    {
                        TempData[SD.Error] = "Error in Sub Category Profile  Creating.";
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






                    var result = subCategoryService.Edit(ITEM);
                    if (result == true)
                    {
                        TempData[SD.Success] = "Sub Category Profile successfully Updated.";
                    }
                    else
                    {
                        TempData[SD.Error] = "Error in Sub Category Profile  Updating.";
                    }
                }
            }




            HomePageModel model = new HomePageModel();
            model.lstSubCategories = subCategoryService.getAll();
            model.lstMainCategories = mainCategoryService.getAll();
            return View("Index", model);
        }




        [Authorize(Roles = "Admin,حذف  الاقسام الفرعية للاقسام الرئيسية")]
        public IActionResult Delete(Guid id)
        {

            TbSubCategory oldItem = ctx.TbSubCategories.Where(a => a.SubCategoryId == id).FirstOrDefault();



            var result = subCategoryService.Delete(oldItem);
            if (result == true)
            {
                TempData[SD.Success] = "Sub Category Profile successfully Removed.";
            }
            else
            {
                TempData[SD.Error] = "Error in Sub Category Profile  Removing.";
            }

            HomePageModel model = new HomePageModel();
            model.lstSubCategories = subCategoryService.getAll();
            model.lstMainCategories = mainCategoryService.getAll();
            return View("Index", model);



        }



        [Authorize(Roles = "Admin,اضافة او تعديل  الاقسام الفرعية للاقسام الرئيسية")]
        public IActionResult Form(Guid? id)
        {
            TbSubCategory oldItem = ctx.TbSubCategories.Where(a => a.SubCategoryId == id).FirstOrDefault();
          
            ViewBag.mainCategory = mainCategoryService.getAll();
            return View(oldItem);
        }
    }
}
