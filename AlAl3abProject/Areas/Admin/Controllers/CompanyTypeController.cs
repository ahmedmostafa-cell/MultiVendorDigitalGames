using AlAl3abProject.Models;
using BL;
using Domains;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlAl3abProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CompanyTypeController : Controller
    {

        private readonly CompanyTybeService companyTybeService;
        AlAl3abDbContext ctx;
        public CompanyTypeController(CompanyTybeService CompanyTybeService, AlAl3abDbContext context)
        {
            companyTybeService = CompanyTybeService;
          
            ctx = context;

        }
        [Authorize(Roles = "Admin, المدن")]
        public IActionResult Index()
        {

            HomePageModel model = new HomePageModel();
            model.lstCompanyTypes = companyTybeService.getAll();

            return View(model);


        }




        [HttpPost]
        public async Task<IActionResult> Save(TbCompanyType ITEM, int id, List<IFormFile> files)
        {
            if (ITEM.CompanyTypeId == null)
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





                    var result = companyTybeService.Add(ITEM);
                    if (result == true)
                    {
                        TempData[SD.Success] = "Company Type Profile successfully Created.";
                    }
                    else
                    {
                        TempData[SD.Error] = "Error in Company Type Profile  Creating.";
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






                    var result = companyTybeService.Edit(ITEM);
                    if (result == true)
                    {
                        TempData[SD.Success] = "Company Type Profile successfully Updated.";
                    }
                    else
                    {
                        TempData[SD.Error] = "Error in Company Type Profile  Updating.";
                    }
                }
            }




            HomePageModel model = new HomePageModel();
            model.lstCompanyTypes = companyTybeService.getAll();
            return View("Index", model);
        }




        [Authorize(Roles = "Admin,حذف  المدن")]
        public IActionResult Delete(Guid id)
        {

            TbCompanyType oldItem = ctx.TbCompanyTypies.Where(a => a.CompanyTypeId == id).FirstOrDefault();



            var result = companyTybeService.Delete(oldItem);
            if (result == true)
            {
                TempData[SD.Success] = "Company Type Profile successfully Removed.";
            }
            else
            {
                TempData[SD.Error] = "Error in Company Type Profile  Removing.";
            }

            HomePageModel model = new HomePageModel();
            model.lstCompanyTypes = companyTybeService.getAll();
            return View("Index", model);



        }



        [Authorize(Roles = "Admin,اضافة او تعديل  المدن")]
        public IActionResult Form(Guid? id)
        {
            TbCompanyType oldItem = ctx.TbCompanyTypies.Where(a => a.CompanyTypeId == id).FirstOrDefault();


            return View(oldItem);
        }
    }
}
