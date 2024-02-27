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
    public class BlogBlogTagController : Controller
    {
        private readonly BlogTagService _blogTagService;
        private readonly BlogBlogTagService _blogBlogTagService;
        private readonly ItemSellerService _itemSellerService;
        private readonly SellerService _sellerService;
        private readonly BlogService blogService;
        BlogItemSellerService blogItemSellerService;

        AlAl3abDbContext ctx;
        public BlogBlogTagController(BlogTagService blogTagService,BlogBlogTagService blogBlogTagService,ItemSellerService itemSellerService, SellerService sellerService, BlogService BlogService, AbousUsService AbousUsService, BlogItemSellerService BlogItemSellerService, AlAl3abDbContext context)
        {
            _blogTagService = blogTagService;
            _blogBlogTagService = blogBlogTagService;
            _itemSellerService = itemSellerService;
            _sellerService = sellerService;
            blogService = BlogService;
            blogItemSellerService = BlogItemSellerService;
            ctx = context;

        }
        [Authorize(Roles = "Admin,ربط التاجات بالمدونات")]
        public IActionResult Index()
        {

            HomePageModel model = new HomePageModel();
            model.lstBlogItemSellers = blogItemSellerService.getAll();
            ViewBag.sellers = _sellerService.getAll();
            ViewBag.tags = _blogTagService.getAll();
            ViewBag.itemSellers = _itemSellerService.getAll();
            ViewBag.blogs = blogService.getAll();
            model.lstBlogBlogTags = _blogBlogTagService.getAll();
            return View(model);


        }




        [HttpPost]
        public async Task<IActionResult> Save(TbBlogBlogTag ITEM, int id, List<IFormFile> files)
        {
            ITEM.BlogTitle = blogService.getAll().Where(a => a.BlogId == ITEM.BlogId).FirstOrDefault().BlogTitle;
            ITEM.BlogTitleEn = blogService.getAll().Where(a => a.BlogId == ITEM.BlogId).FirstOrDefault().BlogTitleEn;
            ITEM.BlogTaName = _blogTagService.getAll().Where(a => a.BlogTagId == ITEM.BlogTagId).FirstOrDefault().BlogTaName;
            ITEM.BlogTaNameEn = _blogTagService.getAll().Where(a => a.BlogTagId == ITEM.BlogTagId).FirstOrDefault().BlogTaNameEn;
          
            if (ITEM.BlogBlogTagId == null)
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





                    var result = _blogBlogTagService.Add(ITEM);
                    if (result == true)
                    {
                        TempData[SD.Success] = "Blog Blog Tag Profile successfully Created.";
                    }
                    else
                    {
                        TempData[SD.Error] = "Error in Blog Blog Tag Profile  Creating.";
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






                    var result = _blogBlogTagService.Edit(ITEM);
                    if (result == true)
                    {
                        TempData[SD.Success] = "Blog Blog Tag Profile successfully Updated.";
                    }
                    else
                    {
                        TempData[SD.Error] = "Error in Blog Blog Tag Profile  Updating.";
                    }
                }
            }




            HomePageModel model = new HomePageModel();
            model.lstBlogItemSellers = blogItemSellerService.getAll();
            ViewBag.sellers = _sellerService.getAll();
            ViewBag.itemSellers = _itemSellerService.getAll();
            ViewBag.blogs = blogService.getAll();
            ViewBag.tags = _blogTagService.getAll();
            model.lstBlogBlogTags = _blogBlogTagService.getAll();
            return View("Index", model);
        }




        [Authorize(Roles = "Admin,حذف  ربط التاجات بالمدونات")]
        public IActionResult Delete(Guid id)
        {

            TbBlogBlogTag oldItem = ctx.TbBlogBlogTags.Where(a => a.BlogBlogTagId == id).FirstOrDefault();



            var result = _blogBlogTagService.Delete(oldItem);
            if (result == true)
            {
                TempData[SD.Success] = "Blog Blog Tag Profile successfully Removed.";
            }
            else
            {
                TempData[SD.Error] = "Error in Blog Blog Tag Profile  Removing.";
            }

            HomePageModel model = new HomePageModel();
            model.lstBlogItemSellers = blogItemSellerService.getAll();
            ViewBag.sellers = _sellerService.getAll();
            ViewBag.itemSellers = _itemSellerService.getAll();
            ViewBag.tags = _blogTagService.getAll();
            ViewBag.blogs = blogService.getAll();
            model.lstBlogBlogTags = _blogBlogTagService.getAll();
            return View("Index", model);



        }



        [Authorize(Roles = "Admin,اضافة او تعديل  ربط التاجات بالمدونات")]
        public IActionResult Form(Guid? id)
        {
            TbBlogBlogTag oldItem = ctx.TbBlogBlogTags.Where(a => a.BlogBlogTagId == id).FirstOrDefault();
            ViewBag.sellers = _sellerService.getAll();
            ViewBag.itemSellers = _itemSellerService.getAll();
            ViewBag.blogs = blogService.getAll();
            ViewBag.tags = _blogTagService.getAll();
            return View(oldItem);
        }


      
    }
}
