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
    public class FaqcategoryController : Controller
    {
        FaqcategoryService  faqcategoryService;

        AlAl3abDbContext ctx;
        public FaqcategoryController(FaqcategoryService FaqcategoryService, AlAl3abDbContext context)
        {

            faqcategoryService = FaqcategoryService;
            ctx = context;

        }
        [Authorize(Roles = "Admin, اقسام الرئيسية للاسئلة الشائعة")]
        public IActionResult Index()
        {

            HomePageModel model = new HomePageModel();
            model.lstFaqcategories = faqcategoryService.getAll();

            return View(model);


        }




        [HttpPost]
        public async Task<IActionResult> Save(TbFaqcategory ITEM, int id, List<IFormFile> files)
        {
            if (ITEM.FaqcategoryId == null)
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





                    var result = faqcategoryService.Add(ITEM);
                    if (result == true)
                    {
                        TempData[SD.Success] = "FAQ Category Profile successfully Created.";
                    }
                    else
                    {
                        TempData[SD.Error] = "Error in FAQ Category Profile  Creating.";
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






                    var result = faqcategoryService.Edit(ITEM);
                    if (result == true)
                    {
                        TempData[SD.Success] = "FAQ Category Profile successfully Updated.";
                    }
                    else
                    {
                        TempData[SD.Error] = "Error in FAQ Category Profile  Updating.";
                    }
                }
            }




            HomePageModel model = new HomePageModel();
            model.lstFaqcategories = faqcategoryService.getAll();
            return View("Index", model);
        }




        [Authorize(Roles = "Admin,حذف  اقسام الرئيسية للاسئلة الشائعة")]
        public IActionResult Delete(Guid id)
        {

            TbFaqcategory oldItem = ctx.TbFaqcategories.Where(a => a.FaqcategoryId == id).FirstOrDefault();



            var result = faqcategoryService.Delete(oldItem);
            if (result == true)
            {
                TempData[SD.Success] = "FAQ Category Profile successfully Removed.";
            }
            else
            {
                TempData[SD.Error] = "Error in FAQ Category Profile  Removing.";
            }

            HomePageModel model = new HomePageModel();
            model.lstFaqcategories = faqcategoryService.getAll();
            return View("Index", model);



        }



        [Authorize(Roles = "Admin,اضافة او تعديل  اقسام الرئيسية للاسئلة الشائعة")]
        public IActionResult Form(Guid? id)
        {
            TbFaqcategory oldItem = ctx.TbFaqcategories.Where(a => a.FaqcategoryId == id).FirstOrDefault();
            

            return View(oldItem);
        }
    }
}
