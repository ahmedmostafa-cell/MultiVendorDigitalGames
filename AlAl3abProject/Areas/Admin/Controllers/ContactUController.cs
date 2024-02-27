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
    public class ContactUController : Controller
    {
        ContactUService contactUService;

        AlAl3abDbContext ctx;
        public ContactUController(ContactUService ContactUService, AlAl3abDbContext context)
        {

            contactUService = ContactUService;
            ctx = context;

        }
        [Authorize(Roles = "Admin, تواصل معنا")]
        public IActionResult Index()
        {

            HomePageModel model = new HomePageModel();
            model.lstContactUs = contactUService.getAll();

            return View(model);


        }




        [HttpPost]
        public async Task<IActionResult> Save(TbContactU ITEM, int id, List<IFormFile> files)
        {
            if (ITEM.ContactUsId == null)
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





                    var result = contactUService.Add(ITEM);
                    if (result == true)
                    {
                        TempData[SD.Success] = "Contact US Profile successfully Created.";
                    }
                    else
                    {
                        TempData[SD.Error] = "Error in Contact US Profile  Creating.";
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






                    var result = contactUService.Edit(ITEM);
                    if (result == true)
                    {
                        TempData[SD.Success] = "Contact US Profile successfully Updated.";
                    }
                    else
                    {
                        TempData[SD.Error] = "Error in Contact US Profile  Updating.";
                    }
                }
            }




            HomePageModel model = new HomePageModel();
            model.lstContactUs = contactUService.getAll();
            return View("Index", model);
        }




        [Authorize(Roles = "Admin,حذف  تواصل معنا")]
        public IActionResult Delete(Guid id)
        {

            TbContactU oldItem = ctx.TbContactUs.Where(a => a.ContactUsId == id).FirstOrDefault();



            var result = contactUService.Delete(oldItem);
            if (result == true)
            {
                TempData[SD.Success] = "Contact US Profile successfully Removed.";
            }
            else
            {
                TempData[SD.Error] = "Error in Contact US Profile  Removing.";
            }

            HomePageModel model = new HomePageModel();
            model.lstContactUs = contactUService.getAll();
            return View("Index", model);



        }



        [Authorize(Roles = "Admin,اضافة او تعديل  تواصل معنا")]
        public IActionResult Form(Guid? id)
        {
            TbContactU oldItem = ctx.TbContactUs.Where(a => a.ContactUsId == id).FirstOrDefault();


            return View(oldItem);
        }
    }
}
