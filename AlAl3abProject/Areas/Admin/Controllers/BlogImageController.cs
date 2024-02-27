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
using System.IO;
using System.Security.Policy;

namespace AlAl3abProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogImageController : Controller
    {
        BlogImageService blogImageService;
        BlogService blogService;
        AlAl3abDbContext ctx;
        public BlogImageController(BlogService BlogService,BlogImageService BlogImageService, AlAl3abDbContext context)
        {

            blogImageService = BlogImageService;
            ctx = context;
            blogService = BlogService;

        }
        [Authorize(Roles = "Admin, صور المدونة")]
        public IActionResult Index(Guid id)
        {

            HomePageModel model = new HomePageModel();
            model.lstBlogImages = blogImageService.getAll().Where(a=> a.BlogId == id);
            model.lstBlogs = blogService.getAll();
            return View(model);


        }




        [HttpPost]
        public async Task<IActionResult> Save(TbBlogImage ITEM, int id, List<IFormFile> files)
        {
           
            if (ITEM.BlogImageId == null)
            {

                 var result=false;
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
                            ITEM.BlogImagePath = ImageName;
                            ITEM.BlogImageId = Guid.NewGuid();
                            result = blogImageService.Add(ITEM);
                        }
                    }





                   
                    if (result == true)
                    {
                        TempData[SD.Success] = "Blog Image Profile successfully Created.";
                    }
                    else
                    {
                        TempData[SD.Error] = "Error in Blog Image Profile  Creating.";
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
                            ITEM.BlogImagePath = ImageName;
                         
                        }
                    }






                     var result = blogImageService.Edit(ITEM);
                    if (result == true)
                    {
                        TempData[SD.Success] = "Blog Image Profile successfully Updated.";
                    }
                    else
                    {
                        TempData[SD.Error] = "Error in Blog Image Profile  Updating.";
                    }
                }
            }




            HomePageModel model = new HomePageModel();
            model.lstBlogImages = blogImageService.getAll().Where(a => a.BlogId == ITEM.BlogId);
            model.lstBlogs = blogService.getAll();
           
            return RedirectToAction("Index", "BlogImage", new { id = ITEM.BlogId });
        }




        [Authorize(Roles = "Admin,حذف  صور المدونة")]
        public IActionResult Delete(Guid id)
        {

            TbBlogImage oldItem = ctx.TbBlogImages.Where(a => a.BlogImageId == id).FirstOrDefault();

            Guid? id2 = oldItem.BlogId;

            var result = blogImageService.Delete(oldItem);
            if (result == true)
            {
                TempData[SD.Success] = "Blog Image Profile successfully Removed.";
            }
            else
            {
                TempData[SD.Error] = "Error in Blog Image Profile  Removing.";
            }

            HomePageModel model = new HomePageModel();
            model.lstBlogImages = blogImageService.getAll().Where(a => a.BlogId == id2);
            model.lstBlogs = blogService.getAll();
            return RedirectToAction("Index", "BlogImage", new { id = id2 });




        }



        [Authorize(Roles = "Admin,اضافة او تعديل  صور المدونة")]
        public IActionResult Form(Guid? id)
        {
            TbBlogImage oldItem = ctx.TbBlogImages.Where(a => a.BlogImageId == id).FirstOrDefault();


            return View(oldItem);
        }


        [Authorize(Roles = "Admin, اضافة او تعديل  صور المدونة")]
        public IActionResult FormAdd(Guid? id)
        {
            TbBlogImage oldItem = new TbBlogImage();
            oldItem.BlogId = id;

            return View(oldItem);
        }
    }
}
