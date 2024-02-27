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
    public class OrderController : Controller
    {
        private readonly OrderDetailsService orderDetailsService;
        private readonly OrderService orderService;
        private readonly UserManager<ApplicationUser> _userManager;
        RegionService regionService;
        SellerService sellerService;
        ItemSellerService itemSellerService;
        ItemService itemService;
        AlAl3abDbContext ctx;
        public OrderController(OrderDetailsService OrderDetailsService,OrderService OrderService,UserManager<ApplicationUser> userManager, RegionService RegionService, SellerService SellerService, ItemService ItemService, ItemSellerService ItemSellerService, AlAl3abDbContext context)
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
        [Authorize(Roles = "Admin, الاوردرات")]
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




        [HttpPost]
        public async Task<IActionResult> Save(TbOrder ITEM, int id, List<IFormFile> files)
        {
           

           
            if (ITEM.OrderId == null)
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





                    var result = orderService.Add(ITEM);
                    if (result == true)
                    {
                        TempData[SD.Success] = "Order Profile successfully Created.";
                    }
                    else
                    {
                        TempData[SD.Error] = "Error in Order Profile  Creating.";
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






                    var result = orderService.Edit(ITEM);
                    if (result == true)
                    {
                        TempData[SD.Success] = "Order Profile successfully Updated.";
                    }
                    else
                    {
                        TempData[SD.Error] = "Error in Order Profile  Updating.";
                    }
                }
            }




            HomePageModel model = new HomePageModel();
            model.lstItemSellers = itemSellerService.getAll();
            model.lstItems = itemService.getAll();
            model.lstSellers = sellerService.getAll();
            model.lstRegions = regionService.getAll();
            var loggedUser = await _userManager.GetUserAsync(HttpContext.User);
            var roles = await _userManager.GetRolesAsync(loggedUser);
            if (roles.Contains("Admin"))
            {


                model.lstOrders = orderService.getAll();
                model.lstOrderDetails = orderDetailsService.getAll();
                return View("Index", model);
            }
            else
            {

                model.lstOrders = orderService.getAll().Where(A => A.SellerId == loggedUser.Id).ToList();
                model.lstOrderDetails = orderDetailsService.getAll().Where(A => A.SellerId == loggedUser.Id).ToList();

                return View("Index", model);
            }
           
        }




        [Authorize(Roles = "Admin,حذف  الاوردرات")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {

            TbOrder oldItem = ctx.TbOrders.Where(a => a.OrderId == id).FirstOrDefault();



            var result = orderService.Delete(oldItem);
            if (result == true)
            {
                TempData[SD.Success] = "Item Seller Profile successfully Removed.";
            }
            else
            {
                TempData[SD.Error] = "Error in Item Seller Profile  Removing.";
            }

            HomePageModel model = new HomePageModel();
            model.lstItemSellers = itemSellerService.getAll();
            model.lstItems = itemService.getAll();
            model.lstSellers = sellerService.getAll();
            model.lstRegions = regionService.getAll();
            var loggedUser = await _userManager.GetUserAsync(HttpContext.User);
            var roles = await _userManager.GetRolesAsync(loggedUser);
            if (roles.Contains("Admin"))
            {


                model.lstOrders = orderService.getAll();
                model.lstOrderDetails = orderDetailsService.getAll();
                return View("Index", model);
            }
            else
            {

                model.lstOrders = orderService.getAll().Where(A => A.SellerId ==loggedUser.Id).ToList();
                model.lstOrderDetails = orderDetailsService.getAll().Where(A => A.SellerId ==loggedUser.Id).ToList();

                return View("Index", model);
            }
          



        }



        [Authorize(Roles = "Admin,اضافة او تعديل  الاوردرات")]
        public IActionResult Form(Guid? id)
        {
            TbOrder oldItem = ctx.TbOrders.Where(a => a.OrderId == id).FirstOrDefault();
            ViewBag.items = itemService.getAll();
            ViewBag.sellers = sellerService.getAll();
            ViewBag.regions = regionService.getAll();

            return View(oldItem);
        }
    }
}
