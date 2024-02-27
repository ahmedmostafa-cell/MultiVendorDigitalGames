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
    public class EnebaReviewController : Controller
    {
        EnebaReviewService enebaReviewService;

        AlAl3abDbContext ctx;
        public EnebaReviewController(EnebaReviewService EnebaReviewService, AlAl3abDbContext context)
        {

            enebaReviewService = EnebaReviewService;
            ctx = context;

        }
        [Authorize(Roles = "Admin, تقييم الموقع")]
        public IActionResult Index()
        {

            HomePageModel model = new HomePageModel();
            model.lstEnebaReviews = enebaReviewService.getAll();

            return View(model);


        }




        [HttpPost]
        public async Task<IActionResult> Save(TbEnebaReview ITEM, int id, List<IFormFile> files)
        {
            if (ITEM.EnebaReviewId == null)
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





                    var result = enebaReviewService.Add(ITEM);
                    if (result == true)
                    {
                        TempData[SD.Success] = "Benzoo Rating Profile successfully Created.";
                    }
                    else
                    {
                        TempData[SD.Error] = "Error in Benzoo Rating Profile  Creating.";
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






                    var result = enebaReviewService.Edit(ITEM);
                    if (result == true)
                    {
                        TempData[SD.Success] = "Benzoo Rating Profile successfully Updated.";
                    }
                    else
                    {
                        TempData[SD.Error] = "Error in Benzoo Rating Profile  Updating.";
                    }
                }
            }




            HomePageModel model = new HomePageModel();
            model.lstEnebaReviews = enebaReviewService.getAll();
            return View("Index", model);
        }




        [Authorize(Roles = "Admin,حذف  تقييم الموقع")]
        public IActionResult Delete(Guid id)
        {

            TbEnebaReview oldItem = ctx.TbEnebaReviews.Where(a => a.EnebaReviewId == id).FirstOrDefault();
            if (oldItem.CurrentState == 1)
            {
                oldItem.CurrentState = 0;
            }
            else if (oldItem.CurrentState == 0)
            {
                oldItem.CurrentState = 1;
            }


            var result = enebaReviewService.Edit(oldItem);
            if (result == true)
            {
                TempData[SD.Success] = "Benzoo Rating Profile successfully Removed.";
            }
            else
            {
                TempData[SD.Error] = "Error in Benzoo Rating Profile  Removing.";
            }
            HomePageModel model = new HomePageModel();
            model.lstEnebaReviews = enebaReviewService.getAll();
            return View("Index", model);



        }



        [Authorize(Roles = "Admin,اضافة او تعديل  تقييم الموقع")]
        public IActionResult Form(Guid? id)
        {
            TbEnebaReview oldItem = ctx.TbEnebaReviews.Where(a => a.EnebaReviewId == id).FirstOrDefault();


            return View(oldItem);
        }
    }
}
