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
    public class BlogTopicController : Controller
    {
        AbousUsService abousUsService;
        BlogTopicService blogTopicService;

        AlAl3abDbContext ctx;
        public BlogTopicController( BlogTopicService BlogTopicService, AlAl3abDbContext context)
        {
            
            blogTopicService = BlogTopicService;
            ctx = context;

        }
        [Authorize(Roles = "Admin, موضوع المدونة")]
        public IActionResult Index()
        {

            HomePageModel model = new HomePageModel();
            model.lstBlogTopics = blogTopicService.getAll();

            return View(model);


        }




        [HttpPost]
        public async Task<IActionResult> Save(TbBlogTopic ITEM, int id, List<IFormFile> files)
        {
            if (ITEM.BlogTopicId == null)
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





                    var result = blogTopicService.Add(ITEM);
                    if (result == true)
                    {
                        TempData[SD.Success] = "Blog Topic Profile successfully Created.";
                    }
                    else
                    {
                        TempData[SD.Error] = "Error in Blog Topic Profile  Creating.";
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






                    var result = blogTopicService.Edit(ITEM);
                    if (result == true)
                    {
                        TempData[SD.Success] = "Blog Topic Profile successfully Updated.";
                    }
                    else
                    {
                        TempData[SD.Error] = "Error in Blog Topic Profile  Updating.";
                    }
                }
            }




            HomePageModel model = new HomePageModel();
            model.lstBlogTopics = blogTopicService.getAll();

            return View("Index", model);
        }




        [Authorize(Roles = "Admin,حذف  موضوع المدونة")]
        public IActionResult Delete(Guid id)
        {

            TbBlogTopic oldItem = ctx.TbBlogTopics.Where(a => a.BlogTopicId == id).FirstOrDefault();



            var result = blogTopicService.Delete(oldItem);
            if (result == true)
            {
                TempData[SD.Success] = "Blog Topic Profile successfully Removed.";
            }
            else
            {
                TempData[SD.Error] = "Error in Blog Topic Profile  Removing.";
            }

            HomePageModel model = new HomePageModel();
            model.lstBlogTopics = blogTopicService.getAll();

            return View("Index", model);



        }



        [Authorize(Roles = "Admin,اضافة او تعديل  موضوع المدونة")]
        public IActionResult Form(Guid? id)
        {
            TbBlogTopic oldItem = ctx.TbBlogTopics.Where(a => a.BlogTopicId == id).FirstOrDefault();


            return View(oldItem);
        }
    }
}
