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
    public class BlogController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        BlogTopicService blogTopicService;
        BlogCategoryService blogCategoryService;
        SellerService sellerService;
        BlogService blogService;
        ItemService itemService;
        AlAl3abDbContext ctx;
        public BlogController(UserManager<ApplicationUser> userManager, BlogTopicService BlogTopicService,BlogCategoryService BlogCategoryService,SellerService SellerService,ItemService ItemService,BlogService BlogService, AlAl3abDbContext context)
        {
            _userManager = userManager;
            blogTopicService = BlogTopicService;
            blogCategoryService = BlogCategoryService;
            sellerService = SellerService;
            itemService = ItemService;
            blogService = BlogService;
            ctx = context;

        }
        [Authorize(Roles = "Admin,المدونة")]
        public IActionResult Index()
        {

            HomePageModel model = new HomePageModel();
            model.lstBlogs = blogService.getAll();
            model.lstSellers = sellerService.getAll();
            model.lstItems = itemService.getAll();
            return View(model);


        }




        [HttpPost]
        public async Task<IActionResult> Save(TbBlog ITEM, int id, List<IFormFile> files)
        {
            //ITEM.ItemNameEn = itemService.getAll().Where(a => a.ItemId == ITEM.ItemId).FirstOrDefault().ItemNameEn;
            //ITEM.ItemName = itemService.getAll().Where(a => a.ItemId == ITEM.ItemId).FirstOrDefault().ItemName;
            //ITEM.SellerNameEn = sellerService.getAll().Where(a => a.SellerId == ITEM.SellerId).FirstOrDefault().SellerFullNamen;
            //ITEM.SellerName = sellerService.getAll().Where(a => a.SellerId == ITEM.SellerId).FirstOrDefault().SellerFullName;
            //ITEM.BlogCategoryNameEn = blogCategoryService.getAll().Where(a=> a.BlogCategoryId == ITEM.BlogCategoryId).FirstOrDefault().BlogCategoryNameEn;
            //ITEM.BlogCategoryName = blogCategoryService.getAll().Where(a => a.BlogCategoryId == ITEM.BlogCategoryId).FirstOrDefault().BlogCategoryName;
            ITEM.BlogTopicName = blogTopicService.getAll().Where(a=> a.BlogTopicId == ITEM.BlogTopicId).FirstOrDefault().BlogTopicName;
            ITEM.BlogTopicNameEn = blogTopicService.getAll().Where(a => a.BlogTopicId == ITEM.BlogTopicId).FirstOrDefault().BlogTopicNameEn;
            ITEM.CreatedBy += ";enablejsapi=1&amp;html5=1&amp;hd=1&amp;wmode=opaque&amp;showinfo=0&amp;rel=0&amp;playsinline=1";
            if (ITEM.BlogId == null)
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





                    var result = blogService.Add(ITEM);
                    if (result == true)
                    {
                        TempData[SD.Success] = "Blog Profile successfully Created.";
                    }
                    else
                    {
                        TempData[SD.Error] = "Error in Blog Profile  Creating.";
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






                    var result = blogService.Edit(ITEM);
                    if (result == true)
                    {
                        TempData[SD.Success] = "Blog Profile successfully Updated.";
                    }
                    else
                    {
                        TempData[SD.Error] = "Error in Blog Profile  Updating.";
                    }
                }
            }




            HomePageModel model = new HomePageModel();
            model.lstBlogs = blogService.getAll();
            model.lstSellers = sellerService.getAll();
            model.lstItems = itemService.getAll();
            return View("Index", model);
        }




        [Authorize(Roles = "Admin,حذف  المدونة")]
        public IActionResult Delete(Guid id)
        {

            TbBlog oldItem = ctx.TbBlogs.Where(a => a.BlogId == id).FirstOrDefault();



            var result = blogService.Delete(oldItem);
            if (result == true)
            {
                TempData[SD.Success] = "Blog Profile successfully Removed.";
            }
            else
            {
                TempData[SD.Error] = "Error in Blog Profile  Removing.";
            }

            HomePageModel model = new HomePageModel();
            model.lstBlogs = blogService.getAll();
            model.lstSellers = sellerService.getAll();
            model.lstItems = itemService.getAll();
            return View("Index", model);



        }



        [Authorize(Roles = "Admin,اضافة او تعديل  المدونة")]
        public IActionResult Form(Guid? id)
        {
            TbBlog oldItem = ctx.TbBlogs.Where(a => a.BlogId == id).FirstOrDefault();
            ViewBag.items = itemService.getAll();
            ViewBag.sellers = sellerService.getAll();
            ViewBag.blogcategories = blogCategoryService.getAll();
            ViewBag.blogtopic = blogTopicService.getAll();
            return View(oldItem);
        }
    }
}
