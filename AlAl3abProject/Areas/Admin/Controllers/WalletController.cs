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
    public class WalletController : Controller
    {
        WalletService walletService;

        AlAl3abDbContext ctx;
        public WalletController(WalletService WalletService, AlAl3abDbContext context)
        {

            walletService = WalletService;
            ctx = context;

        }
        [Authorize(Roles = "Admin, المحفظة")]
        public IActionResult Index()
        {

            HomePageModel model = new HomePageModel();
            model.lstWallets = walletService.getAll();

            return View(model);


        }




        [HttpPost]
        public async Task<IActionResult> Save(TbWallet ITEM, int id, List<IFormFile> files)
        {
            if (ITEM.WalletId == null)
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





                    var result = walletService.Add(ITEM);
                    if (result == true)
                    {
                        TempData[SD.Success] = "Wallet Profile successfully Created.";
                    }
                    else
                    {
                        TempData[SD.Error] = "Error in Wallet Profile  Creating.";
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






                    var result = walletService.Edit(ITEM);
                    if (result == true)
                    {
                        TempData[SD.Success] = "Wallet Profile successfully Updated.";
                    }
                    else
                    {
                        TempData[SD.Error] = "Error in Wallet Profile  Updating.";
                    }
                }
            }




            HomePageModel model = new HomePageModel();
            model.lstWallets = walletService.getAll();
            return View("Index", model);
        }




        [Authorize(Roles = "Admin,حذف  المحفظة")]
        public IActionResult Delete(Guid id)
        {

            TbWallet oldItem = ctx.TbWallets.Where(a => a.WalletId == id).FirstOrDefault();



            var result = walletService.Delete(oldItem);
            if (result == true)
            {
                TempData[SD.Success] = "Wallet Profile successfully Removed.";
            }
            else
            {
                TempData[SD.Error] = "Error in Wallet Profile  Removing.";
            }

            HomePageModel model = new HomePageModel();
            model.lstWallets = walletService.getAll();
            return View("Index", model);



        }



        [Authorize(Roles = "Admin,اضافة او تعديل  المحفظة")]
        public IActionResult Form(Guid? id)
        {
            TbWallet oldItem = ctx.TbWallets.Where(a => a.WalletId == id).FirstOrDefault();


            return View(oldItem);
        }
    }
}
