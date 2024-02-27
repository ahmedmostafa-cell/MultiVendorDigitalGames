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
using Microsoft.AspNetCore.Identity;

namespace AlAl3abProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogCommentController : Controller
    {
        BlogService blogService;
        BlogCommentService blogCommentService;
        private readonly UserManager<ApplicationUser> _userManager;
        AlAl3abDbContext ctx;
        public BlogCommentController(BlogService BlogService,UserManager<ApplicationUser> UserManager, BlogCommentService BlogCommentService, AlAl3abDbContext context)
        {

            blogCommentService = BlogCommentService;
            ctx = context;
            _userManager = UserManager;
            blogService = BlogService;


        }
        [Authorize(Roles = "Admin, تعليقات المدونة")]
        public IActionResult Index()
        {

            HomePageModel model = new HomePageModel();
            model.lstBlogComments = blogCommentService.getAll();
            model.lstBlogs = blogService.getAll();
            return View(model);


        }




        [HttpPost]
        public async Task<IActionResult> Save(TbBlogComment ITEM, int id, List<IFormFile> files)
        {
           
            if (ITEM.BlogCommentId == null)
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





                    var result = blogCommentService.Add(ITEM);
                    if (result == true)
                    {
                        TempData[SD.Success] = "Blog Comment Profile successfully Created.";
                    }
                    else
                    {
                        TempData[SD.Error] = "Error in Blog Comment Profile  Creating.";
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






                    var result = blogCommentService.Edit(ITEM);
                    if (result == true)
                    {
                        TempData[SD.Success] = "Blog Comment Profile successfully Updated.";
                    }
                    else
                    {
                        TempData[SD.Error] = "Error in Blog Comment Profile  Updating.";
                    }
                }
            }




            HomePageModel model = new HomePageModel();
            model.lstBlogComments = blogCommentService.getAll();
            model.lstBlogs = blogService.getAll();
            return View("Index", model);
        }




        [Authorize(Roles = "Admin,حذف  تعليقات المدونة")]
        public IActionResult Delete(Guid id)
        {

            TbBlogComment oldItem = ctx.TbBlogComments.Where(a => a.BlogCommentId == id).FirstOrDefault();
            if (oldItem.CurrentState == 1) 
            {
                oldItem.CurrentState = 0;
            }
            else if (oldItem.CurrentState == 0) 
            {
                oldItem.CurrentState = 1;
            }




                var result = blogCommentService.Edit(oldItem);
            if (result == true)
            {
                TempData[SD.Success] = "Blog Comment Profile successfully Removed.";
            }
            else
            {
                TempData[SD.Error] = "Error in Blog Comment Profile  Removing.";
            }

            HomePageModel model = new HomePageModel();
            model.lstBlogComments = blogCommentService.getAll();
            model.lstBlogs = blogService.getAll();
            return View("Index", model);



        }



        [Authorize(Roles = "Admin,اضافة او تعديل  تعليقات المدونة")]
        public IActionResult Form(Guid? id)
        {
            TbBlogComment oldItem = ctx.TbBlogComments.Where(a => a.BlogCommentId == id).FirstOrDefault();


            return View(oldItem);
        }
    }
}
