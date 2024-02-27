using AlAl3abProject.Models;
using BL;
using Domains;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Authorization;

namespace AlAl3abProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrderDetailsController : Controller
    {
        private readonly OrderDetailsService orderDetailsService;
        private readonly OrderService orderService;
        private readonly UserManager<ApplicationUser> _userManager;
        RegionService regionService;
        SellerService sellerService;
        ItemSellerService itemSellerService;
        ItemService itemService;
        AlAl3abDbContext ctx;
        public OrderDetailsController(OrderDetailsService OrderDetailsService, OrderService OrderService, UserManager<ApplicationUser> userManager, RegionService RegionService, SellerService SellerService, ItemService ItemService, ItemSellerService ItemSellerService, AlAl3abDbContext context)
        {

            itemSellerService = ItemSellerService;
            ctx = context;
            itemService = ItemService;
            sellerService = SellerService;
            regionService = RegionService;
            _userManager = userManager;
            orderService = OrderService;
            orderDetailsService = OrderDetailsService;


        }
        [Authorize(Roles = "Admin, تفاصيل الاوردرات")]
        public async Task<IActionResult> IndexAsync()
        {

            HomePageModel model = new HomePageModel();

            model.lstItems = itemService.getAll();
            model.lstSellers = sellerService.getAll();
            model.lstRegions = regionService.getAll();
            var loggedUser = await _userManager.GetUserAsync(HttpContext.User);
            var roles = await _userManager.GetRolesAsync(loggedUser);
            if (roles.Contains("Admin"))
            {


                model.lstOrders = orderService.getAll();
                model.lstOrderDetails = orderDetailsService.getAll();
                return View(model);
            }
            else
            {

                model.lstOrders = orderService.getAll().Where(A => A.SellerId == loggedUser.Id).ToList();
                model.lstOrderDetails = orderDetailsService.getAll().Where(A => A.SellerId == loggedUser.Id).ToList();

                return View(model);
            }


        }




        [Authorize(Roles = "Admin, تفاصيل الاوردرات")]
        public async Task<IActionResult> IndexOrderAsync(string id)
        {

            HomePageModel model = new HomePageModel();

            model.lstItems = itemService.getAll();
            model.lstSellers = sellerService.getAll();
            model.lstRegions = regionService.getAll();
            var loggedUser = await _userManager.GetUserAsync(HttpContext.User);
            var roles = await _userManager.GetRolesAsync(loggedUser);
            if (roles.Contains("Admin"))
            {


                model.lstOrders = orderService.getAll();
                model.lstOrderDetails = orderDetailsService.getAll();
                return View(model);
            }
            else
            {

                model.lstOrders = orderService.getAll().Where(A => A.SellerId == loggedUser.Id).ToList();
                model.lstOrderDetails = orderDetailsService.getAll().Where(A => A.SellerId == loggedUser.Id && A.OrderDetailsId ==Guid.Parse( id)).ToList();

                return View(model);
            }


        }




        [HttpPost]
        public async Task<IActionResult> Save(TbOrderDetails ITEM, int id, List<IFormFile> files)
        {
         

            ITEM.Region = regionService.getAll().Where(A => A.RegionId == ITEM.RegionId).FirstOrDefault().RegionName;
            ITEM.RegionEn = regionService.getAll().Where(A => A.RegionId == ITEM.RegionId).FirstOrDefault().RegionNameEn;
            ITEM.ItemName = itemService.getAll().Where(a => a.ItemId == ITEM.ItemId).FirstOrDefault().ItemName;
            ITEM.ItemNameEn = itemService.getAll().Where(a => a.ItemId == ITEM.ItemId).FirstOrDefault().ItemNameEn;
            ITEM.SellerNameEn = sellerService.getAll().Where(a => a.SellerId == Guid.Parse(ITEM.SellerId)).FirstOrDefault().SellerFullNamen;
            ITEM.SellerName = sellerService.getAll().Where(a => a.SellerId == Guid.Parse(ITEM.SellerId)).FirstOrDefault().SellerFullName;
            if (ITEM.OrderDetailsId == null)
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
                    //        ITEM.ItemImagePath = ImageName;
                    //    }
                    //}





                    var result = orderDetailsService.Add(ITEM);
                    if (result == true)
                    {
                        TempData[SD.Success] = "Order Details Profile successfully Created.";
                    }
                    else
                    {
                        TempData[SD.Error] = "Error in Order Details Profile  Creating.";
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
                    //        ITEM.ItemImagePath = ImageName;
                    //    }
                    //}






                    var result = orderDetailsService.Edit(ITEM);
                    if (result == true)
                    {
                        TempData[SD.Success] = "Order Details Profile successfully Updated.";
                    }
                    else
                    {
                        TempData[SD.Error] = "Error in Order Details Profile  Updating.";
                    }
                }
            }




            HomePageModel model = new HomePageModel();
            model.lstItemSellers = itemSellerService.getAll();
            model.lstItems = itemService.getAll();
            model.lstSellers = sellerService.getAll();
            model.lstRegions = regionService.getAll();
            return View("Index", model);
        }




        [Authorize(Roles = "Admin,حذف  تفاصيل الاوردرات")]
        public IActionResult Delete(Guid id)
        {

            TbOrderDetails oldItem = ctx.TbOrderDetailss.Where(a => a.OrderDetailsId == id).FirstOrDefault();



            var result = orderDetailsService.Delete(oldItem);
            if (result == true)
            {
                TempData[SD.Success] = "Order Details Profile successfully Removed.";
            }
            else
            {
                TempData[SD.Error] = "Error in Order Details Profile  Removing.";
            }

            HomePageModel model = new HomePageModel();
            model.lstItemSellers = itemSellerService.getAll();
            model.lstItems = itemService.getAll();
            model.lstSellers = sellerService.getAll();
            model.lstRegions = regionService.getAll();
            return View("Index", model);



        }



        [Authorize(Roles = "Admin,اضافة او تعديل  تفاصيل الاوردرات")]
        public IActionResult Form(Guid? id)
        {
            TbOrderDetails oldItem = ctx.TbOrderDetailss.Where(a => a.OrderDetailsId == id).FirstOrDefault();
            ViewBag.items = itemService.getAll();
            ViewBag.sellers = sellerService.getAll();
            ViewBag.regions = regionService.getAll();
            return View(oldItem);
        }
    }
}
