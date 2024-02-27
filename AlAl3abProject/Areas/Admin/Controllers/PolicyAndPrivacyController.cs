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
    public class PolicyAndPrivacyController : Controller
    {
        PolicyAndPrivacyService policyAndPrivacyService;

        AlAl3abDbContext ctx;
        public PolicyAndPrivacyController(PolicyAndPrivacyService PolicyAndPrivacyService, AlAl3abDbContext context)
        {

            policyAndPrivacyService = PolicyAndPrivacyService;
            ctx = context;

        }
        [Authorize(Roles = "Admin, السياسات و الخصوصية")]
        public IActionResult Index()
        {

            HomePageModel model = new HomePageModel();
            model.lstPolicyAndPrivacies = policyAndPrivacyService.getAll();

            return View(model);


        }




        [HttpPost]
        public async Task<IActionResult> Save(TbPolicyAndPrivacy ITEM, int id, List<IFormFile> files)
        {
            if (ITEM.PoliciesAndPrivacyId == null)
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





                    var result = policyAndPrivacyService.Add(ITEM);
                    if (result == true)
                    {
                        TempData[SD.Success] = "Policy And Privacy Profile successfully Created.";
                    }
                    else
                    {
                        TempData[SD.Error] = "Error in Policy And Privacy Profile  Creating.";
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






                    var result = policyAndPrivacyService.Edit(ITEM);
                    if (result == true)
                    {
                        TempData[SD.Success] = "Policy And Privacy Profile successfully Updated.";
                    }
                    else
                    {
                        TempData[SD.Error] = "Error in Policy And Privacy Profile  Updating.";
                    }
                }
            }




            HomePageModel model = new HomePageModel();
            model.lstPolicyAndPrivacies = policyAndPrivacyService.getAll();
            return View("Index", model);
        }




        [Authorize(Roles = "Admin,حذف  السياسات و الخصوصية")]
        public IActionResult Delete(Guid id)
        {

            TbPolicyAndPrivacy oldItem = ctx.TbPolicyAndPrivacies.Where(a => a.PoliciesAndPrivacyId == id).FirstOrDefault();



            var result = policyAndPrivacyService.Delete(oldItem);
            if (result == true)
            {
                TempData[SD.Success] = "Policy And Privacy Profile successfully Removed.";
            }
            else
            {
                TempData[SD.Error] = "Error in Policy And Privacy Profile  Removing.";
            }

            HomePageModel model = new HomePageModel();
            model.lstPolicyAndPrivacies = policyAndPrivacyService.getAll();
            return View("Index", model);



        }



        [Authorize(Roles = "Admin,اضافة او تعديل  السياسات و الخصوصية")]
        public IActionResult Form(Guid? id)
        {
            TbPolicyAndPrivacy oldItem = ctx.TbPolicyAndPrivacies.Where(a => a.PoliciesAndPrivacyId == id).FirstOrDefault();


            return View(oldItem);
        }
    }
}
