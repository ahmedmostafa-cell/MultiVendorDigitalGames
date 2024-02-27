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
    public class FavouriteCartController : Controller
    {
        FavouriteCartService favouriteCartService;
        ItemService itemService;
        SellerService sellerService;
        AlAl3abDbContext ctx;
        public FavouriteCartController(SellerService SellerService,ItemService ItemService,FavouriteCartService FavouriteCartService, AlAl3abDbContext context)
        {

            favouriteCartService = FavouriteCartService;
            ctx = context;
            itemService = ItemService;
            sellerService = SellerService;

        }
        [Authorize(Roles = "Admin, المفضلة")]
        public IActionResult Index()
        {

            HomePageModel model = new HomePageModel();
            model.lstFavouriteCarts = favouriteCartService.getAll();
            model.lstSellers = sellerService.getAll();
            model.lstItems = itemService.getAll();
            return View(model);


        }




        [HttpPost]
        public async Task<IActionResult> Save(TbFavouriteCart ITEM, int id, List<IFormFile> files)
        {
            if (ITEM.FavouriteCartId == null)
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





                    var result = favouriteCartService.Add(ITEM);
                    if (result == true)
                    {
                        TempData[SD.Success] = "Favourite Cart Profile successfully Created.";
                    }
                    else
                    {
                        TempData[SD.Error] = "Error in Favourite Cart Profile  Creating.";
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






                    var result = favouriteCartService.Edit(ITEM);
                    if (result == true)
                    {
                        TempData[SD.Success] = "Favourite Cart Profile successfully Updated.";
                    }
                    else
                    {
                        TempData[SD.Error] = "Error in Favourite Cart Profile  Updating.";
                    }
                }
            }




            HomePageModel model = new HomePageModel();
            model.lstFavouriteCarts = favouriteCartService.getAll();
            model.lstSellers = sellerService.getAll();
            model.lstItems = itemService.getAll();
            return View("Index", model);
        }




        [Authorize(Roles = "Admin,حذف  المفضلة")]
        public IActionResult Delete(Guid id)
        {

            TbFavouriteCart oldItem = ctx.TbFavouriteCarts.Where(a => a.FavouriteCartId == id).FirstOrDefault();



            var result = favouriteCartService.Delete(oldItem);
            if (result == true)
            {
                TempData[SD.Success] = "Favourite Cart Profile successfully Removed.";
            }
            else
            {
                TempData[SD.Error] = "Error in Favourite Cart Profile  Removing.";
            }

            HomePageModel model = new HomePageModel();
            model.lstFavouriteCarts = favouriteCartService.getAll();
            model.lstSellers = sellerService.getAll();
            model.lstItems = itemService.getAll();
            return View("Index", model);



        }



        [Authorize(Roles = "Admin,اضافة او تعديل  المفضلة")]
        public IActionResult Form(Guid? id)
        {
            TbFavouriteCart oldItem = ctx.TbFavouriteCarts.Where(a => a.FavouriteCartId == id).FirstOrDefault();


            return View(oldItem);
        }
    }
}
