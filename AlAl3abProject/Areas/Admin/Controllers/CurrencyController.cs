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
    public class CurrencyController : Controller
    {
        CurrencyService currencyService;

        AlAl3abDbContext ctx;
        public CurrencyController(CurrencyService CurrencyService, AlAl3abDbContext context)
        {

            currencyService = CurrencyService;
            ctx = context;

        }
        [Authorize(Roles = "Admin, العملة")]
        public IActionResult Index()
        {

            HomePageModel model = new HomePageModel();
            model.lstCurrencies = currencyService.getAll();

            return View(model);


        }




        [HttpPost]
        public async Task<IActionResult> Save(TbCurrency ITEM, int id, List<IFormFile> files)
        {
            if (ITEM.CurrencyId == null)
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





                    var result = currencyService.Add(ITEM);
                    if (result == true)
                    {
                        TempData[SD.Success] = "AboutUs Profile successfully Created.";
                    }
                    else
                    {
                        TempData[SD.Error] = "Error in AboutUs Profile  Creating.";
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






                    var result = currencyService.Edit(ITEM);
                    if (result == true)
                    {
                        TempData[SD.Success] = "AboutUs Profile successfully Updated.";
                    }
                    else
                    {
                        TempData[SD.Error] = "Error in AboutUs Profile  Updating.";
                    }
                }
            }




            HomePageModel model = new HomePageModel();
            model.lstCurrencies = currencyService.getAll();
            return View("Index", model);
        }




        [Authorize(Roles = "Admin,حذف  العملة")]
        public IActionResult Delete(Guid id)
        {

            TbCurrency oldItem = ctx.TbCurrencies.Where(a => a.CurrencyId == id).FirstOrDefault();



            var result = currencyService.Delete(oldItem);
            if (result == true)
            {
                TempData[SD.Success] = "AboutUs Profile successfully Removed.";
            }
            else
            {
                TempData[SD.Error] = "Error in AboutUs Profile  Removing.";
            }

            HomePageModel model = new HomePageModel();
            model.lstCurrencies = currencyService.getAll();
            return View("Index", model);



        }



        [Authorize(Roles = "Admin,اضافة او تعديل  العملة")]
        public IActionResult Form(Guid? id)
        {
            TbCurrency oldItem = ctx.TbCurrencies.Where(a => a.CurrencyId == id).FirstOrDefault();


            return View(oldItem);
        }
    }
}
