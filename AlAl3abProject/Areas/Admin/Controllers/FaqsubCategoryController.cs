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
    public class FaqsubCategoryController : Controller
    {
        FaqsubCategoryService faqsubCategoryService;
        FaqcategoryService faqcategoryService;
        AlAl3abDbContext ctx;
        public FaqsubCategoryController(FaqcategoryService FaqcategoryService,FaqsubCategoryService FaqsubCategoryService, AlAl3abDbContext context)
        {
            faqcategoryService = FaqcategoryService;
            faqsubCategoryService = FaqsubCategoryService;
            ctx = context;

        }
        [Authorize(Roles = "Admin, الاقسام الفرعية للاسئلة الشائعة")]
        public IActionResult Index()
        {

            HomePageModel model = new HomePageModel();
            model.lstFaqsubCategories = faqsubCategoryService.getAll();
            model.lstFaqcategories = faqcategoryService.getAll();
            return View(model);


        }




        [HttpPost]
        public async Task<IActionResult> Save(TbFaqsubCategory ITEM, int id, List<IFormFile> files)
        {
            ITEM.FaqcategoryName = faqcategoryService.getAll().Where(a=> a.FaqcategoryId == ITEM.FaqcategoryId).FirstOrDefault().FaqcategoryName;
            ITEM.FaqcategoryNameEn = faqcategoryService.getAll().Where(a => a.FaqcategoryId == ITEM.FaqcategoryId).FirstOrDefault().FaqcategoryNameEn;
            if (ITEM.FaqsubCategoryId == null)
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





                    var result = faqsubCategoryService.Add(ITEM);
                    if (result == true)
                    {
                        TempData[SD.Success] = "FAQ SubCategory Profile successfully Created.";
                    }
                    else
                    {
                        TempData[SD.Error] = "Error in FAQ SubCategory Profile  Creating.";
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






                    var result = faqsubCategoryService.Edit(ITEM);
                    if (result == true)
                    {
                        TempData[SD.Success] = "FAQ SubCategory Profile successfully Updated.";
                    }
                    else
                    {
                        TempData[SD.Error] = "Error in FAQ SubCategory Profile  Updating.";
                    }
                }
            }




            HomePageModel model = new HomePageModel();
            model.lstFaqsubCategories = faqsubCategoryService.getAll();
            model.lstFaqcategories = faqcategoryService.getAll();
            return View("Index", model);
        }




        [Authorize(Roles = "Admin,حذف  الاقسام الفرعية للاسئلة الشائعة")]
        public IActionResult Delete(Guid id)
        {

            TbFaqsubCategory oldItem = ctx.TbFaqsubCategories.Where(a => a.FaqsubCategoryId == id).FirstOrDefault();



            var result = faqsubCategoryService.Delete(oldItem);
            if (result == true)
            {
                TempData[SD.Success] = "FAQ SubCategory Profile successfully Removed.";
            }
            else
            {
                TempData[SD.Error] = "Error in FAQ SubCategory Profile  Removing.";
            }

            HomePageModel model = new HomePageModel();
            model.lstFaqsubCategories = faqsubCategoryService.getAll();
            model.lstFaqcategories = faqcategoryService.getAll();
            return View("Index", model);



        }



        [Authorize(Roles = "Admin,اضافة او تعديل  الاقسام الفرعية للاسئلة الشائعة")]
        public IActionResult Form(Guid? id)
        {
            TbFaqsubCategory oldItem = ctx.TbFaqsubCategories.Where(a => a.FaqsubCategoryId == id).FirstOrDefault();
            ViewBag.faqCategory = faqcategoryService.getAll();

            return View(oldItem);
        }
    }
}
