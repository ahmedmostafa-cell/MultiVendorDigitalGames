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
    public class CompetitionRuleController : Controller
    {
        CompeitionRuleService compeitionRuleService;
        CompetitionService competitionService;
        AlAl3abDbContext ctx;
        public CompetitionRuleController(CompetitionService CompetitionService,CompeitionRuleService CompeitionRuleService, AlAl3abDbContext context)
        {

            compeitionRuleService = CompeitionRuleService;
            ctx = context;
            competitionService = CompetitionService;

        }
        [Authorize(Roles = "Admin, النشاط المطلوب و النقاط المحصلة")]
        public IActionResult Index(Guid id)
        {

            HomePageModel model = new HomePageModel();
            model.lstCompetitionRules = compeitionRuleService.getAll().Where(a => a.CompetitionId == id);
            model.lstCompetitions = competitionService.getAll();
            return View(model);


        }




        [HttpPost]
        public async Task<IActionResult> Save(TbCompetitionRule ITEM, int id, List<IFormFile> files)
        {
            if (ITEM.CompetitionRulesId == null)
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





                    var result = compeitionRuleService.Add(ITEM);
                    if (result == true)
                    {
                        TempData[SD.Success] = "Competiton Rule Profile successfully Created.";
                    }
                    else
                    {
                        TempData[SD.Error] = "Error in Competiton Rule Profile  Creating.";
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






                    var result = compeitionRuleService.Edit(ITEM);
                    if (result == true)
                    {
                        TempData[SD.Success] = "Competiton Rule Profile successfully Updated.";
                    }
                    else
                    {
                        TempData[SD.Error] = "Error in Competiton Rule Profile  Updating.";
                    }
                }
            }




            HomePageModel model = new HomePageModel();
            model.lstCompetitionRules = compeitionRuleService.getAll().Where(a => a.CompetitionId == ITEM.CompetitionId);
            model.lstCompetitions = competitionService.getAll();
            return RedirectToAction("Index", "CompetitionRule", new { id = ITEM.CompetitionId });
        }




        [Authorize(Roles = "Admin,  حذف النشاط المطلوب و النقاط المحصلة")]
        public IActionResult Delete(Guid id)
        {

            TbCompetitionRule oldItem = ctx.TbCompetitionRules.Where(a => a.CompetitionRulesId == id).FirstOrDefault();

            Guid? id2 = oldItem.CompetitionId;

            var result = compeitionRuleService.Delete(oldItem);
            if (result == true)
            {
                TempData[SD.Success] = "Competiton Rule Profile successfully Removed.";
            }
            else
            {
                TempData[SD.Error] = "Error in Competiton Rule Profile  Removing.";
            }

            HomePageModel model = new HomePageModel();
            model.lstCompetitionRules = compeitionRuleService.getAll().Where(a => a.CompetitionId == id2);
            model.lstCompetitions = competitionService.getAll();
            return RedirectToAction("Index", "CompetitionRule", new { id = id2 });



        }



        [Authorize(Roles = "Admin,اضافة او تعديل  النشاط المطلوب و النقاط المحصلة")]
        public IActionResult Form(Guid? id)
        {
            TbCompetitionRule oldItem = ctx.TbCompetitionRules.Where(a => a.CompetitionRulesId == id).FirstOrDefault();


            return View(oldItem);
        }



        [Authorize(Roles = "Admin,اضافة او تعديل  النشاط المطلوب و النقاط المحصلة")]
        public IActionResult FormAdd(Guid? id)
        {
            TbCompetitionRule oldItem = new TbCompetitionRule();
            oldItem.CompetitionId = id;

            return View(oldItem);
        }
    }
}
