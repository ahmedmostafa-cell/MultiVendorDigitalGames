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
using System.IO;

namespace AlAl3abProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CompetitionController : Controller
    {
        CompetitionService competitionService;

        AlAl3abDbContext ctx;
        public CompetitionController(CompetitionService CompetitionService, AlAl3abDbContext context)
        {

            competitionService = CompetitionService;
            ctx = context;

        }
        [Authorize(Roles = "Admin, المسابقات")]
        public IActionResult Index()
        {

            HomePageModel model = new HomePageModel();
            model.lstCompetitions = competitionService.getAll();

            return View(model);


        }




        [HttpPost]
        public async Task<IActionResult> Save(TbCompetition ITEM, int id, List<IFormFile> files)
        {
            if (ITEM.CompetitionId == null)
            {


                if (ModelState.IsValid)
                {
                    foreach (var file in files)
                    {
                        if (file.Length > 0)
                        {
                            string ImageName = Guid.NewGuid().ToString() + ".jpg";
                            var filePaths = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Uploads", ImageName);
                            using (var stream = System.IO.File.Create(filePaths))
                            {
                                await file.CopyToAsync(stream);
                            }
                            ITEM.CompetitonImagePath = ImageName;
                        }
                    }





                    var result = competitionService.Add(ITEM);
                    if (result == true)
                    {
                        TempData[SD.Success] = "Competition Profile successfully Created.";
                    }
                    else
                    {
                        TempData[SD.Error] = "Error in Competition Profile  Creating.";
                    }


                }


            }
            else
            {
                if (ModelState.IsValid)
                {
                    foreach (var file in files)
                    {
                        if (file.Length > 0)
                        {
                            string ImageName = Guid.NewGuid().ToString() + ".jpg";
                            var filePaths = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Uploads", ImageName);
                            using (var stream = System.IO.File.Create(filePaths))
                            {
                                await file.CopyToAsync(stream);
                            }
                            ITEM.CompetitonImagePath = ImageName;
                        }
                    }






                    var result = competitionService.Edit(ITEM);
                    if (result == true)
                    {
                        TempData[SD.Success] = "Competition Profile successfully Updated.";
                    }
                    else
                    {
                        TempData[SD.Error] = "Error in Competition Profile  Updating.";
                    }
                }
            }




            HomePageModel model = new HomePageModel();
            model.lstCompetitions = competitionService.getAll();
            return View("Index", model);
        }




        [Authorize(Roles = "Admin,حذف  المسابقات")]
        public IActionResult Delete(Guid id)
        {

            TbCompetition oldItem = ctx.TbCompetitions.Where(a => a.CompetitionId == id).FirstOrDefault();



            var result = competitionService.Delete(oldItem);
            if (result == true)
            {
                TempData[SD.Success] = "Competition Profile successfully Removed.";
            }
            else
            {
                TempData[SD.Error] = "Error in Competition Profile  Removing.";
            }

            HomePageModel model = new HomePageModel();
            model.lstCompetitions = competitionService.getAll();
            return View("Index", model);



        }



        [Authorize(Roles = "Admin,اضافة او تعديل  المسابقات")]
        public IActionResult Form(Guid? id)
        {
            TbCompetition oldItem = ctx.TbCompetitions.Where(a => a.CompetitionId == id).FirstOrDefault();


            return View(oldItem);
        }
    }
}
