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
    public class CountryController : Controller
    {
        CountryService countryService;

        AlAl3abDbContext ctx;
        public CountryController(CountryService CountryService, AlAl3abDbContext context)
        {

            countryService = CountryService;
            ctx = context;

        }
        [Authorize(Roles = "Admin, الدول")]
        public IActionResult Index()
        {

            HomePageModel model = new HomePageModel();
            model.lstCountries = countryService.getAll();

            return View(model);


        }




        [HttpPost]
        public async Task<IActionResult> Save(TbCountry ITEM, int id, List<IFormFile> files)
        {
            if (ITEM.CountryId == null)
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





                    var result = countryService.Add(ITEM);
                    if (result == true)
                    {
                        TempData[SD.Success] = "Country Profile successfully Created.";
                    }
                    else
                    {
                        TempData[SD.Error] = "Error in Country Profile  Creating.";
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






                    var result = countryService.Edit(ITEM);
                    if (result == true)
                    {
                        TempData[SD.Success] = "Country Profile successfully Updated.";
                    }
                    else
                    {
                        TempData[SD.Error] = "Error in Country Profile  Updating.";
                    }
                }
            }




            HomePageModel model = new HomePageModel();
            model.lstCountries = countryService.getAll();
            return View("Index", model);
        }




        [Authorize(Roles = "Admin,حذف  الدول")]
        public IActionResult Delete(Guid id)
        {

            TbCountry oldItem = ctx.TbCountries.Where(a => a.CountryId == id).FirstOrDefault();



            var result = countryService.Delete(oldItem);
            if (result == true)
            {
                TempData[SD.Success] = "Country Profile successfully Removed.";
            }
            else
            {
                TempData[SD.Error] = "Error in Country Profile  Removing.";
            }

            HomePageModel model = new HomePageModel();
            model.lstCountries = countryService.getAll();
            return View("Index", model);



        }



        [Authorize(Roles = "Admin,اضافة او تعديل  الدول")]
        public IActionResult Form(Guid? id)
        {
            TbCountry oldItem = ctx.TbCountries.Where(a => a.CountryId == id).FirstOrDefault();


            return View(oldItem);
        }
    }
}
