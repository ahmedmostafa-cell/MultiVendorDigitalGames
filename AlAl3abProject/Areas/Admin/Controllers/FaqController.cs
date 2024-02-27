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
    public class FaqController : Controller
    {
        FaqService  faqService;
        FaqsubCategoryService faqsubCategoryService;
        AlAl3abDbContext ctx;
        public FaqController(FaqsubCategoryService FaqsubCategoryService ,FaqService FaqService, AlAl3abDbContext context)
        {

            faqService = FaqService;
            ctx = context;
            faqsubCategoryService = FaqsubCategoryService;

        }
        [Authorize(Roles = "Admin, الاسئلة الشائعة")]
        public IActionResult Index()
        {

            HomePageModel model = new HomePageModel();
            model.lstFaqs = faqService.getAll();

            return View(model);


        }




        [HttpPost]
        public async Task<IActionResult> Save(TbFaq ITEM, int id, List<IFormFile> files)
        {
            ITEM.FaqsubCategoryName = faqsubCategoryService.getAll().Where(A=> A.FaqsubCategoryId == ITEM.FaqsubCategoryId).FirstOrDefault().FaqcategoryName;
            ITEM.FaqsubCategoryNameEn = faqsubCategoryService.getAll().Where(A => A.FaqsubCategoryId == ITEM.FaqsubCategoryId).FirstOrDefault().FaqsubCategoryNameEn;
            if (ITEM.Faqid == null)
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





                    var result = faqService.Add(ITEM);
                    if (result == true)
                    {
                        TempData[SD.Success] = "FAQ Profile successfully Created.";
                    }
                    else
                    {
                        TempData[SD.Error] = "Error in FAQ Profile  Creating.";
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






                    var result = faqService.Edit(ITEM);
                    if (result == true)
                    {
                        TempData[SD.Success] = "FAQ Profile successfully Updated.";
                    }
                    else
                    {
                        TempData[SD.Error] = "Error in FAQ Profile  Updating.";
                    }
                }
            }




            HomePageModel model = new HomePageModel();
            model.lstFaqs = faqService.getAll();
            return View("Index", model);
        }




        [Authorize(Roles = "Admin,حذف  الاسئلة الشائعة")]
        public IActionResult Delete(Guid id)
        {

            TbFaq oldItem = ctx.TbFaqs.Where(a => a.Faqid == id).FirstOrDefault();



            var result = faqService.Delete(oldItem);
            if (result == true)
            {
                TempData[SD.Success] = "FAQ Profile successfully Removed.";
            }
            else
            {
                TempData[SD.Error] = "Error in FAQ Profile  Removing.";
            }

            HomePageModel model = new HomePageModel();
            model.lstFaqs = faqService.getAll();
            return View("Index", model);



        }



        [Authorize(Roles = "Admin,اضافة او تعديل  الاسئلة الشائعة")]
        public IActionResult Form(Guid? id)
        {
            TbFaq oldItem = ctx.TbFaqs.Where(a => a.Faqid == id).FirstOrDefault();
            ViewBag.faqSubCategories = faqsubCategoryService.getAll();

            return View(oldItem);
        }
    }
}
