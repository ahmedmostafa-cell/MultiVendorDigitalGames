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
using Microsoft.EntityFrameworkCore;

namespace AlAl3abProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogItemSellerController : Controller
    {
        private readonly ItemSellerService _itemSellerService;
        private readonly SellerService _sellerService;
        private readonly BlogService blogService;
        BlogItemSellerService blogItemSellerService;

        AlAl3abDbContext ctx;
        public BlogItemSellerController(ItemSellerService itemSellerService,SellerService sellerService,BlogService BlogService,AbousUsService AbousUsService,BlogItemSellerService BlogItemSellerService, AlAl3abDbContext context)
        {
            _itemSellerService = itemSellerService;
            _sellerService = sellerService;
            blogService = BlogService;
             blogItemSellerService = BlogItemSellerService;
            ctx = context;

        }
        [Authorize(Roles = "Admin,المدونة المضافة من التجار بخصوص المنتجات")]
        public IActionResult Index()
        {

            HomePageModel model = new HomePageModel();
            model.lstBlogItemSellers = blogItemSellerService.getAll();
            ViewBag.sellers = _sellerService.getAll();
            ViewBag.itemSellers = _itemSellerService.getAll();
            ViewBag.blogs = blogService.getAll();
            return View(model);


        }




        [HttpPost]
        public async Task<IActionResult> Save(TbBlogItemSeller ITEM, int id, List<IFormFile> files)
        {
            ITEM.SellerName = _sellerService.getAll().Where(a=> a.SellerId == ITEM.SellerId).FirstOrDefault().SellerFullName;
            ITEM.SellerNameEn = _sellerService.getAll().Where(a => a.SellerId == ITEM.SellerId).FirstOrDefault().SellerFullNamen;
            ITEM.BlogTitle = blogService.getAll().Where(a => a.BlogId == ITEM.BlogId).FirstOrDefault().BlogTitle;
            ITEM.BlogTitleEn = blogService.getAll().Where(a => a.BlogId == ITEM.BlogId).FirstOrDefault().BlogTitleEn;
            ITEM.ItemName = _itemSellerService.getAll().Where(a => a.ItemSellerId == ITEM.ItemSellerId).FirstOrDefault().ItemName;
            ITEM.ItemNameEn = _itemSellerService.getAll().Where(a => a.ItemSellerId == ITEM.ItemSellerId).FirstOrDefault().ItemNameEn;
            ITEM.ItemPrice = _itemSellerService.getAll().Where(a => a.ItemSellerId == ITEM.ItemSellerId).FirstOrDefault().ItemSalePrice;
            ITEM.ItemId = _itemSellerService.getAll().Where(a => a.ItemSellerId == ITEM.ItemSellerId).FirstOrDefault().ItemId;
            
            if (ITEM.BlogItemSellerId == null)
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





                    var result = blogItemSellerService.Add(ITEM);
                    if (result == true)
                    {
                        TempData[SD.Success] = "Blog Item Seller Profile successfully Created.";
                    }
                    else
                    {
                        TempData[SD.Error] = "Error in Blog Item Seller Profile  Creating.";
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






                    var result = blogItemSellerService.Edit(ITEM);
                    if (result == true)
                    {
                        TempData[SD.Success] = "Blog Item Seller Profile successfully Updated.";
                    }
                    else
                    {
                        TempData[SD.Error] = "Error in Blog Item Seller Profile  Updating.";
                    }
                }
            }




            HomePageModel model = new HomePageModel();
            model.lstBlogItemSellers = blogItemSellerService.getAll();
            ViewBag.sellers = _sellerService.getAll();
            ViewBag.itemSellers = _itemSellerService.getAll();
            ViewBag.blogs = blogService.getAll();
            return View("Index", model);
        }




        [Authorize(Roles = "Admin,حذف  المدونة المضافة من التجار بخصوص المنتجات")]
        public IActionResult Delete(Guid id)
        {

            TbBlogItemSeller oldItem = ctx.TbBlogItemSellers.Where(a => a.BlogItemSellerId == id).FirstOrDefault();



            var result = blogItemSellerService.Delete(oldItem);
            if (result == true)
            {
                TempData[SD.Success] = "Blog Item Seller Profile successfully Removed.";
            }
            else
            {
                TempData[SD.Error] = "Error in Blog Item Seller Profile  Removing.";
            }

            HomePageModel model = new HomePageModel();
            model.lstBlogItemSellers = blogItemSellerService.getAll();
            ViewBag.sellers = _sellerService.getAll();
            ViewBag.itemSellers = _itemSellerService.getAll();
            ViewBag.blogs = blogService.getAll();
            return View("Index", model);



        }



        [Authorize(Roles = "Admin,اضافة او تعديل  المدونة المضافة من التجار بخصوص المنتجات")]
        public IActionResult Form(Guid? id)
        {
            TbBlogItemSeller oldItem = ctx.TbBlogItemSellers.Where(a => a.BlogItemSellerId == id).FirstOrDefault();
            ViewBag.sellers = _sellerService.getAll();
            ViewBag.itemSellers = _itemSellerService.getAll();
            ViewBag.blogs = blogService.getAll();

            return View(oldItem);
        }


        public async Task<JsonResult> GetAyatsBySurahId(string surahId)
        {
            if (surahId == null)
                return Json(new { message = "نحتاج لرقم السورة ", status = false });
            else
            {
               var ayats= await ctx.TbItemSellers.Where(s => s.SellerId == Guid.Parse(surahId)).ToListAsync();


                return !ayats.Any() ? Json(new { message = "لا يوجد ايات لهذه السورة", status = false }) : Json(new { data = ayats, status = true });
            }
        }
    }
}
