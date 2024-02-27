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
    public class TicketDiscussionController : Controller
    {
        TicketDiscussionService ticketDiscussionService;

        AlAl3abDbContext ctx;
        public TicketDiscussionController(TicketDiscussionService TicketDiscussionService, AlAl3abDbContext context)
        {

            ticketDiscussionService = TicketDiscussionService;
            ctx = context;

        }
        [Authorize(Roles = "Admin, مناقشات التيكيت")]
        public IActionResult Index(Guid id)
        {

            HomePageModel model = new HomePageModel();
            model.lstTicketDiscussions = ticketDiscussionService.getAll().Where(a => a.TicketId == id);

            return View(model);


        }




        [HttpPost]
        public async Task<IActionResult> Save(TbTicketDiscussion ITEM, int id, List<IFormFile> files)
        {
            if (ITEM.TicketDiscussionId == null)
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





                    var result = ticketDiscussionService.Add(ITEM);
                    if (result == true)
                    {
                        TempData[SD.Success] = "Ticket Discussion Profile successfully Created.";
                    }
                    else
                    {
                        TempData[SD.Error] = "Error in Ticket Discussion Profile  Creating.";
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






                    var result = ticketDiscussionService.Edit(ITEM);
                    if (result == true)
                    {
                        TempData[SD.Success] = "Ticket Discussion Profile successfully Updated.";
                    }
                    else
                    {
                        TempData[SD.Error] = "Error in Ticket Discussion Profile  Updating.";
                    }
                }
            }




            HomePageModel model = new HomePageModel();
            model.lstTicketDiscussions = ticketDiscussionService.getAll().Where(a => a.TicketId == ITEM.TicketId);
            return View("Index", model);
        }




        [Authorize(Roles = "Admin,حذف  مناقشات التيكيت")]
        public IActionResult Delete(Guid id)
        {

            TbTicketDiscussion oldItem = ctx.TbTicketDiscussions.Where(a => a.TicketDiscussionId == id).FirstOrDefault();



            var result = ticketDiscussionService.Delete(oldItem);
            if (result == true)
            {
                TempData[SD.Success] = "Ticket Discussion Profile successfully Removed.";
            }
            else
            {
                TempData[SD.Error] = "Error in Ticket Discussion Profile  Removing.";
            }

            HomePageModel model = new HomePageModel();
            model.lstTicketDiscussions = ticketDiscussionService.getAll().Where(a => a.TicketId == id);
            return View("Index", model);



        }



        [Authorize(Roles = "Admin,اضافة او تعديل  مناقشات التيكيت")]
        public IActionResult Form(Guid? id)
        {
            TbTicketDiscussion oldItem = ctx.TbTicketDiscussions.Where(a => a.TicketDiscussionId == id).FirstOrDefault();


            return View(oldItem);
        }
    }
}
