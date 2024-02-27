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
    public class TicketCategoryController : Controller
    {
       TicketCategoryService ticketCategoryService;

        AlAl3abDbContext ctx;
        public TicketCategoryController(TicketCategoryService TicketCategoryService, AlAl3abDbContext context)
        {

            ticketCategoryService = TicketCategoryService;
            ctx = context;

        }
        [Authorize(Roles = "Admin, اقسام التيكيت")]
        public IActionResult Index()
        {

            HomePageModel model = new HomePageModel();
            model.lstTicketCategories = ticketCategoryService.getAll();

            return View(model);


        }




        [HttpPost]
        public async Task<IActionResult> Save(TbTicketCategory ITEM, int id, List<IFormFile> files)
        {
            if (ITEM.TicketCategoryId == null)
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





                    var result = ticketCategoryService.Add(ITEM);
                    if (result == true)
                    {
                        TempData[SD.Success] = "Ticket Category Profile successfully Created.";
                    }
                    else
                    {
                        TempData[SD.Error] = "Error in Ticket Category Profile  Creating.";
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






                    var result = ticketCategoryService.Edit(ITEM);
                    if (result == true)
                    {
                        TempData[SD.Success] = "Ticket Category Profile successfully Updated.";
                    }
                    else
                    {
                        TempData[SD.Error] = "Error in Ticket Category Profile  Updating.";
                    }
                }
            }




            HomePageModel model = new HomePageModel();
            model.lstTicketCategories = ticketCategoryService.getAll();
            return View("Index", model);
        }




        [Authorize(Roles = "Admin,حذف  اقسام التيكيت")]
        public IActionResult Delete(Guid id)
        {

            TbTicketCategory oldItem = ctx.TbTicketCategories.Where(a => a.TicketCategoryId == id).FirstOrDefault();



            var result = ticketCategoryService.Delete(oldItem);
            if (result == true)
            {
                TempData[SD.Success] = "Ticket Category Profile successfully Removed.";
            }
            else
            {
                TempData[SD.Error] = "Error in Ticket Category Profile  Removing.";
            }

            HomePageModel model = new HomePageModel();
            model.lstTicketCategories = ticketCategoryService.getAll();
            return View("Index", model);



        }



        [Authorize(Roles = "Admin,اضافة او تعديل  اقسام التيكيت")]
        public IActionResult Form(Guid? id)
        {
            TbTicketCategory oldItem = ctx.TbTicketCategories.Where(a => a.TicketCategoryId == id).FirstOrDefault();


            return View(oldItem);
        }
    }
}
