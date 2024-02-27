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
    public class BlogCategoryController : Controller
    {
        BlogCategoryService blogCategoryService;

        AlAl3abDbContext ctx;
        public BlogCategoryController(BlogCategoryService BlogCategoryService, AlAl3abDbContext context)
        {

            blogCategoryService = BlogCategoryService;
            ctx = context;

        }
        [Authorize(Roles = "Admin, فئة المدونة")]
        public IActionResult Index()
        {

            HomePageModel model = new HomePageModel();
            model.lstBlogCategories = blogCategoryService.getAll();

            return View(model);


        }




        [HttpPost]
        public async Task<IActionResult> Save(TbBlogCategory ITEM, int id, List<IFormFile> files)
        {
            if (ITEM.BlogCategoryId == null)
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





                    var result = blogCategoryService.Add(ITEM);
                    if (result == true)
                    {
                        TempData[SD.Success] = "Blog Category Profile successfully Created.";
                    }
                    else
                    {
                        TempData[SD.Error] = "Error in Blog Category Profile  Creating.";
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






                    var result = blogCategoryService.Edit(ITEM);
                    if (result == true)
                    {
                        TempData[SD.Success] = "Blog Category Profile successfully Updated.";
                    }
                    else
                    {
                        TempData[SD.Error] = "Error in Blog Category Profile  Updating.";
                    }
                }
            }




            HomePageModel model = new HomePageModel();
            model.lstBlogCategories = blogCategoryService.getAll();
            return View("Index", model);
        }




        [Authorize(Roles = "Admin,حذف  فئة المدونة")]
        public IActionResult Delete(Guid id)
        {

            TbBlogCategory oldItem = ctx.TbBlogCategories.Where(a => a.BlogCategoryId == id).FirstOrDefault();



            var result = blogCategoryService.Delete(oldItem);
            if (result == true)
            {
                TempData[SD.Success] = "Blog Category Profile successfully Removed.";
            }
            else
            {
                TempData[SD.Error] = "Error in Blog Category Profile  Removing.";
            }

            HomePageModel model = new HomePageModel();
            model.lstBlogCategories = blogCategoryService.getAll();
            return View("Index", model);



        }



        [Authorize(Roles = "Admin,اضافة او تعديل  فئة المدونة")]
        public IActionResult Form(Guid? id)
        {
            TbBlogCategory oldItem = ctx.TbBlogCategories.Where(a => a.BlogCategoryId == id).FirstOrDefault();


            return View(oldItem);
        }
    }
}
