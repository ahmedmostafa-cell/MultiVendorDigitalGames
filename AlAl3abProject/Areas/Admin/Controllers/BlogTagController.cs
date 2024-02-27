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
    public class BlogTagController : Controller
    {
        private readonly BlogTagService _blogTagService;
        AlAl3abDbContext ctx;
        public BlogTagController(BlogTagService blogTagService, AlAl3abDbContext context)
        {

            _blogTagService = blogTagService;
            ctx = context;

        }
        [Authorize(Roles = "Admin, تاج المدونة")]
        public IActionResult Index()
        {

            HomePageModel model = new HomePageModel();
            model.lstBlogTags = _blogTagService.getAll();

            return View(model);


        }




        [HttpPost]
        public async Task<IActionResult> Save(TbBlogTag ITEM, int id, List<IFormFile> files)
        {
            if (ITEM.BlogTagId == null)
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





                    var result = _blogTagService.Add(ITEM);
                    if (result == true)
                    {
                        TempData[SD.Success] = "Blog Tag Profile successfully Created.";
                    }
                    else
                    {
                        TempData[SD.Error] = "Error in Blog Tag Profile  Creating.";
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






                    var result = _blogTagService.Edit(ITEM);
                    if (result == true)
                    {
                        TempData[SD.Success] = "Blog Tag Profile successfully Updated.";
                    }
                    else
                    {
                        TempData[SD.Error] = "Error in Blog Tag Profile  Updating.";
                    }
                }
            }




            HomePageModel model = new HomePageModel();
            model.lstBlogTags = _blogTagService.getAll();

            return View("Index", model);
        }




        [Authorize(Roles = "Admin,حذف  تاج المدونة")]
        public IActionResult Delete(Guid id)
        {

            TbBlogTag oldItem = ctx.TbBlogTags.Where(a => a.BlogTagId == id).FirstOrDefault();



            var result = _blogTagService.Delete(oldItem);
            if (result == true)
            {
                TempData[SD.Success] = "Blog Tag Profile successfully Removed.";
            }
            else
            {
                TempData[SD.Error] = "Error in Blog Tag Profile  Removing.";
            }

            HomePageModel model = new HomePageModel();
            model.lstBlogTags = _blogTagService.getAll();

            return View("Index", model);



        }



        [Authorize(Roles = "Admin,اضافة او تعديل  تاج المدونة")]
        public IActionResult Form(Guid? id)
        {
            TbBlogTag oldItem = ctx.TbBlogTags.Where(a => a.BlogTagId == id).FirstOrDefault();


            return View(oldItem);
        }
    }
}
