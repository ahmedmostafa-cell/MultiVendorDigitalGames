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
    public class CompetitionRecordController : Controller
    {
        CompeitionRecordService compeitionRecordService;
        CompeitionRuleService compeitionRuleService;
        CompetitionService competitionService;
        AlAl3abDbContext ctx;
        public CompetitionRecordController(CompetitionService CompetitionService, CompeitionRuleService CompeitionRuleService, CompeitionRecordService CompeitionRecordService, AlAl3abDbContext context)
        {

            compeitionRecordService = CompeitionRecordService;
            ctx = context;
            compeitionRuleService = CompeitionRuleService;
          
            competitionService = CompetitionService;

        }
        [Authorize(Roles = "Admin, نشاطات المتسابقين")]
        public IActionResult Index(Guid id)
        {

            HomePageModel model = new HomePageModel();
            model.lstCompetitionRecords = compeitionRecordService.getAll().Where(a => a.CompetitionId == id);
            model.lstCompetitionRules = compeitionRuleService.getAll();
            model.lstCompetitions = competitionService.getAll();

            return View(model);


        }




        [HttpPost]
        public async Task<IActionResult> Save(TbCompetitionRecord ITEM, int id, List<IFormFile> files)
        {
            if (ITEM.CompetitionRecordId == null)
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





                    var result = compeitionRecordService.Add(ITEM);
                    if (result == true)
                    {
                        TempData[SD.Success] = "Competition Record Profile successfully Created.";
                    }
                    else
                    {
                        TempData[SD.Error] = "Error in Competition Record Profile  Creating.";
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






                    var result = compeitionRecordService.Edit(ITEM);
                    if (result == true)
                    {
                        TempData[SD.Success] = "Competition Record Profile successfully Updated.";
                    }
                    else
                    {
                        TempData[SD.Error] = "Error in Competition Record Profile  Updating.";
                    }
                }
            }




            HomePageModel model = new HomePageModel();
            model.lstCompetitionRecords = compeitionRecordService.getAll().Where(a => a.CompetitionId == ITEM.CompetitionId);
            model.lstCompetitionRules = compeitionRuleService.getAll();
            model.lstCompetitions = competitionService.getAll();
            return RedirectToAction("Index", "CompetitionRecord", new { id = ITEM.CompetitionId });
        }




        [Authorize(Roles = "Admin,  حذف نشاطات المتسابقين")]
        public IActionResult Delete(Guid id)
        {

            TbCompetitionRecord oldItem = ctx.TbCompetitionRecords.Where(a => a.CompetitionRecordId == id).FirstOrDefault();

            Guid? id2 = oldItem.CompetitionId;

            var result = compeitionRecordService.Delete(oldItem);
            if (result == true)
            {
                TempData[SD.Success] = "Competition Record Profile successfully Removed.";
            }
            else
            {
                TempData[SD.Error] = "Error in Competition Record Profile  Removing.";
            }

            HomePageModel model = new HomePageModel();
            model.lstCompetitionRecords = compeitionRecordService.getAll().Where(a => a.CompetitionId == id2);
            model.lstCompetitionRules = compeitionRuleService.getAll();
            model.lstCompetitions = competitionService.getAll();
            return RedirectToAction("Index", "CompetitionRecord", new { id = id2 });



        }



        [Authorize(Roles = "Admin,اضافة او تعديل  نشاطات المتسابقين")]
        public IActionResult Form(Guid? id)
        {
            TbCompetitionRecord oldItem = ctx.TbCompetitionRecords.Where(a => a.CompetitionRecordId == id).FirstOrDefault();


            return View(oldItem);
        }
    }
}
