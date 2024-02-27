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
    public class ItemController : Controller
    {
        OperatingSystemService operatingSystemService;
        ItemService itemService;
        RegionService regionService;
        AlAl3abDbContext ctx;
        public ItemController(OperatingSystemService OperatingSystemService,RegionService RegionService,ItemService ItemService, AlAl3abDbContext context)
        {
            operatingSystemService = OperatingSystemService;
            regionService = RegionService;
            itemService = ItemService;
            ctx = context;

        }
        [Authorize(Roles = "Admin, المنتجات")]
        public IActionResult Index()
        {

            HomePageModel model = new HomePageModel();
            model.lstItems = itemService.getAll();

            return View(model);


        }




        [HttpPost]
        public async Task<IActionResult> Save(TbItem ITEM, int id, List<IFormFile> files)
        {
            ITEM.Region = regionService.getAll().Where(a => a.RegionId == ITEM.RegionId).FirstOrDefault().RegionName;
            ITEM.WorksOn = operatingSystemService.getAll().Where(a => a.OperatingSystemId == ITEM.OperatingSystemId).FirstOrDefault().OperatingSystemName;
            ITEM.WorksOnEn = operatingSystemService.getAll().Where(a => a.OperatingSystemId == ITEM.OperatingSystemId).FirstOrDefault().OperatingSystemNameEn;
            if (ITEM.ItemId == null)
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





                    var result = itemService.Add(ITEM);
                    if (result == true)
                    {
                        TempData[SD.Success] = "Items Profile successfully Created.";
                    }
                    else
                    {
                        TempData[SD.Error] = "Error in Items Profile  Creating.";
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






                    var result = itemService.Edit(ITEM);
                    if (result == true)
                    {
                        TempData[SD.Success] = "Items Profile successfully Updated.";
                    }
                    else
                    {
                        TempData[SD.Error] = "Error in Items Profile  Updating.";
                    }
                }
            }




            HomePageModel model = new HomePageModel();
            model.lstItems = itemService.getAll();
            return View("Index", model);
        }




        [Authorize(Roles = "Admin,حذف  المنتجات")]
        public IActionResult Delete(Guid id)
        {

            TbItem oldItem = ctx.TbItems.Where(a => a.ItemId == id).FirstOrDefault();



            var result = itemService.Delete(oldItem);
            if (result == true)
            {
                TempData[SD.Success] = "Items Profile successfully Removed.";
            }
            else
            {
                TempData[SD.Error] = "Error in Items Profile  Removing.";
            }

            HomePageModel model = new HomePageModel();
            model.lstItems = itemService.getAll();
            return View("Index", model);



        }



        [Authorize(Roles = "Admin,اضافة او تعديل  المنتجات")]
        public IActionResult Form(Guid? id)
        {
            TbItem oldItem = ctx.TbItems.Where(a => a.ItemId == id).FirstOrDefault();
            ViewBag.regions = regionService.getAll();
            ViewBag.operatingSystems = operatingSystemService.getAll();
            return View(oldItem);
        }
    }
}
