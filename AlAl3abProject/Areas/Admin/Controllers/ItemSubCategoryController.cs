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
    public class ItemSubCategoryController : Controller
    {
        ItemSubCategoryService itemSubCategoryService;
        ItemService itemService;
        SubCategoryService subCategoryService;
        AlAl3abDbContext ctx;
        public ItemSubCategoryController(SubCategoryService SubCategoryService,ItemService ItemService, ItemSubCategoryService ItemSubCategoryService, AlAl3abDbContext context)
        {

            itemSubCategoryService = ItemSubCategoryService;
            ctx = context;
            itemService = ItemService;
            subCategoryService = SubCategoryService;
        }
        [Authorize(Roles = "Admin, الاقسام الفرعية للمنتجات")]
        public IActionResult Index()
        {

            HomePageModel model = new HomePageModel();
            model.lstItemSubCategories = itemSubCategoryService.getAll();
            model.lstSubCategories = subCategoryService.getAll();
            model.lstItems = itemService.getAll();
            return View(model);


        }




        [HttpPost]
        public async Task<IActionResult> Save(TbItemSubCategory ITEM, int id, List<IFormFile> files)
        {
            if (ITEM.ItemSubCategoryId == null)
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





                    var result = itemSubCategoryService.Add(ITEM);
                    if (result == true)
                    {
                        TempData[SD.Success] = "Item Sub Category Profile successfully Created.";
                    }
                    else
                    {
                        TempData[SD.Error] = "Error in Item Sub Category Profile  Creating.";
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






                    var result = itemSubCategoryService.Edit(ITEM);
                    if (result == true)
                    {
                        TempData[SD.Success] = "Item Sub Category Profile successfully Updated.";
                    }
                    else
                    {
                        TempData[SD.Error] = "Error in Item Sub Category Profile  Updating.";
                    }
                }
            }




            HomePageModel model = new HomePageModel();
            model.lstItemSubCategories = itemSubCategoryService.getAll();
            model.lstSubCategories = subCategoryService.getAll();
            model.lstItems = itemService.getAll();
            return View("Index", model);
        }




        [Authorize(Roles = "Admin,حذف  الاقسام الفرعية للمنتجات")]
        public IActionResult Delete(Guid id)
        {

            TbItemSubCategory oldItem = ctx.TbItemSubCategories.Where(a => a.ItemSubCategoryId == id).FirstOrDefault();



            var result = itemSubCategoryService.Delete(oldItem);
            if (result == true)
            {
                TempData[SD.Success] = "Item Sub Category Profile successfully Removed.";
            }
            else
            {
                TempData[SD.Error] = "Error in Item Sub Category Profile  Removing.";
            }

            HomePageModel model = new HomePageModel();
            model.lstItemSubCategories = itemSubCategoryService.getAll();
            model.lstSubCategories = subCategoryService.getAll();
            model.lstItems = itemService.getAll();
            return View("Index", model);



        }



        [Authorize(Roles = "Admin,اضافة او تعديل  الاقسام الفرعية للمنتجات")]
        public IActionResult Form(Guid? id)
        {
            TbItemSubCategory oldItem = ctx.TbItemSubCategories.Where(a => a.ItemSubCategoryId == id).FirstOrDefault();

            ViewBag.items = itemService.getAll();
            ViewBag.subCategories = subCategoryService.getAll();
            return View(oldItem);
        }
    }
}
