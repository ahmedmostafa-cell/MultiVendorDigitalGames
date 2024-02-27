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
    public class BlogCommentLikeController : Controller
    {
        BlogCommentService blogCommentService;
        BlogCommentLikeService blogCommentLikeService;
        BlogService blogService;
        AlAl3abDbContext ctx;
        public BlogCommentLikeController(BlogCommentService BlogCommentService,BlogService BlogService,BlogCommentLikeService BlogCommentLikeService, AlAl3abDbContext context)
        {

            blogCommentLikeService = BlogCommentLikeService;
            ctx = context;
            blogService = BlogService;
            blogCommentService = BlogCommentService;

        }
        [Authorize(Roles = "Admin, التفاعل مع تعليقات المدونة")]
        public IActionResult Index()
        {

            HomePageModel model = new HomePageModel();
            model.lstBlogCommentLikes = blogCommentLikeService.getAll();
            model.lstBlogs = blogService.getAll();
            model.lstBlogComments = blogCommentService.getAll();
            return View(model);


        }




        [HttpPost]
        public async Task<IActionResult> Save(TbBlogCommentLike ITEM, int id, List<IFormFile> files)
        {
            if (ITEM.BlogCommentLikeId == null)
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





                    var result = blogCommentLikeService.Add(ITEM);
                    if (result == true)
                    {
                        TempData[SD.Success] = "Blog Comment Like Profile successfully Created.";
                    }
                    else
                    {
                        TempData[SD.Error] = "Error in Blog Comment Like Profile  Creating.";
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






                    var result = blogCommentLikeService.Edit(ITEM);
                    if (result == true)
                    {
                        TempData[SD.Success] = "Blog Comment Like Profile successfully Updated.";
                    }
                    else
                    {
                        TempData[SD.Error] = "Error in Blog Comment Like Profile  Updating.";
                    }
                }
            }




            HomePageModel model = new HomePageModel();
            model.lstBlogCommentLikes = blogCommentLikeService.getAll();
            model.lstBlogs = blogService.getAll();
            model.lstBlogComments = blogCommentService.getAll();
            return View("Index", model);
        }




        [Authorize(Roles = "Admin,حذف  التفاعل مع تعليقات المدونة")]
        public IActionResult Delete(Guid id)
        {

            TbBlogCommentLike oldItem = ctx.TbBlogCommentLikes.Where(a => a.BlogCommentLikeId == id).FirstOrDefault();



            var result = blogCommentLikeService.Delete(oldItem);
            if (result == true)
            {
                TempData[SD.Success] = "Blog Comment Like Profile successfully Removed.";
            }
            else
            {
                TempData[SD.Error] = "Error in Blog Comment Like Profile  Removing.";
            }

            HomePageModel model = new HomePageModel();
            model.lstBlogCommentLikes = blogCommentLikeService.getAll();
            model.lstBlogs = blogService.getAll();
            model.lstBlogComments = blogCommentService.getAll();
            return View("Index", model);



        }



        [Authorize(Roles = "Admin,اضافة او تعديل  التفاعل مع تعليقات المدونة")]
        public IActionResult Form(Guid? id)
        {
            TbBlogCommentLike oldItem = ctx.TbBlogCommentLikes.Where(a => a.BlogCommentLikeId == id).FirstOrDefault();


            return View(oldItem);
        }
    }
}
