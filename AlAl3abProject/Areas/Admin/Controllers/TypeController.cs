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
    public class TypeController : Controller
    {
       TypeService typeService;

        AlAl3abDbContext ctx;
        public TypeController(TypeService TypeService, AlAl3abDbContext context)
        {

            typeService = TypeService;
            ctx = context;

        }
        [Authorize(Roles = "Admin, الانواع")]
        public IActionResult Index()
        {

            HomePageModel model = new HomePageModel();
            model.lstTypes = typeService.getAll();

            return View(model);


        }




        [HttpPost]
        public async Task<IActionResult> Save(TbType ITEM, int id, List<IFormFile> files)
        {
            if (ITEM.TypeId == null)
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





                    var result = typeService.Add(ITEM);
                    if (result == true)
                    {
                        TempData[SD.Success] = "Type Profile successfully Created.";
                    }
                    else
                    {
                        TempData[SD.Error] = "Error in Type Profile  Creating.";
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






                    var result = typeService.Edit(ITEM);
                    if (result == true)
                    {
                        TempData[SD.Success] = "Type Profile successfully Updated.";
                    }
                    else
                    {
                        TempData[SD.Error] = "Error in Type Profile  Updating.";
                    }
                }
            }




            HomePageModel model = new HomePageModel();
            model.lstTypes = typeService.getAll();
            return View("Index", model);
        }




        [Authorize(Roles = "Admin,حذف  الانواع")]
        public IActionResult Delete(Guid id)
        {

            TbType oldItem = ctx.TbTypes.Where(a => a.TypeId == id).FirstOrDefault();



            var result = typeService.Delete(oldItem);
            if (result == true)
            {
                TempData[SD.Success] = "Type Profile successfully Removed.";
            }
            else
            {
                TempData[SD.Error] = "Error in Type Profile  Removing.";
            }

            HomePageModel model = new HomePageModel();
            model.lstTypes = typeService.getAll();
            return View("Index", model);



        }



        [Authorize(Roles = "Admin,اضافة او تعديل  الانواع")]
        public IActionResult Form(Guid? id)
        {
            TbType oldItem = ctx.TbTypes.Where(a => a.TypeId == id).FirstOrDefault();


            return View(oldItem);
        }
    }
}
