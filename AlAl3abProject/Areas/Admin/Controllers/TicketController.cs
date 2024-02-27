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
    public class TicketController : Controller
    {
        TicketService ticketService;
        TicketCategoryService ticketCategoryService;
        AlAl3abDbContext ctx;
        public TicketController(TicketCategoryService TicketCategoryService,TicketService TicketService, AlAl3abDbContext context)
        {

            ticketService = TicketService;
            ctx = context;
            ticketCategoryService = TicketCategoryService;

        }
        [Authorize(Roles = "Admin, التيكيت")]
        public IActionResult Index()
        {

            HomePageModel model = new HomePageModel();
            model.lstTickets = ticketService.getAll();
            model.lstTicketCategories = ticketCategoryService.getAll();
            return View(model);


        }




        [HttpPost]
        public async Task<IActionResult> Save(TbTicket ITEM, int id, List<IFormFile> files)
        {
            if (ITEM.TicketId == null)
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





                    var result = ticketService.Add(ITEM);
                    if (result == true)
                    {
                        TempData[SD.Success] = "Ticket Profile successfully Created.";
                    }
                    else
                    {
                        TempData[SD.Error] = "Error in Ticket Profile  Creating.";
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






                    var result = ticketService.Edit(ITEM);
                    if (result == true)
                    {
                        TempData[SD.Success] = "Ticket Profile successfully Updated.";
                    }
                    else
                    {
                        TempData[SD.Error] = "Error in Ticket Profile  Updating.";
                    }
                }
            }




            HomePageModel model = new HomePageModel();
            model.lstTickets = ticketService.getAll();
            model.lstTicketCategories = ticketCategoryService.getAll();
            return View("Index", model);
        }




        [Authorize(Roles = "Admin,حذف  التيكيت")]
        public IActionResult Delete(Guid id)
        {

            TbTicket oldItem = ctx.TbTickets.Where(a => a.TicketId == id).FirstOrDefault();



            var result = ticketService.Delete(oldItem);
            if (result == true)
            {
                TempData[SD.Success] = "Ticket Profile successfully Removed.";
            }
            else
            {
                TempData[SD.Error] = "Error in Ticket Profile  Removing.";
            }

            HomePageModel model = new HomePageModel();
            model.lstTickets = ticketService.getAll();
            model.lstTicketCategories = ticketCategoryService.getAll();
            return View("Index", model);



        }



        [Authorize(Roles = "Admin,اضافة او تعديل  التيكيت")]
        public IActionResult Form(Guid? id)
        {
            TbTicket oldItem = ctx.TbTickets.Where(a => a.TicketId == id).FirstOrDefault();


            return View(oldItem);
        }
    }
}
