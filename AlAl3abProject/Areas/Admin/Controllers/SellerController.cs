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
using Microsoft.AspNetCore.Identity;

namespace AlAl3abProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SellerController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        SellerService sellerService;
        CountryService countryService;
        CityService cityService;
        AlAl3abDbContext ctx;
        public SellerController(UserManager<ApplicationUser> userManager,CityService CityService,CountryService CountryService,SellerService SellerService, AlAl3abDbContext context)
        {

            sellerService = SellerService;
            ctx = context;
            countryService = CountryService;
            cityService = CityService;
            _userManager = userManager;

        }
        [Authorize(Roles = "Admin, التجار")]
        public IActionResult Index()
        {

            HomePageModel model = new HomePageModel();
            model.lstSellers = sellerService.getAll();
            ViewBag.users = _userManager.Users.Where(a => a.AccountType != "المستخدم").ToList();
            return View(model);


        }




        [HttpPost]
        public async Task<IActionResult> Save(TbSeller ITEM, int id, List<IFormFile> files )
        {
            ITEM.CountryName = countryService.getAll().Where(a=> a.CountryId == ITEM.CountryId).FirstOrDefault().CountryName;
            if (ITEM.SellerId == null)
            {


                if (ModelState.IsValid)
                {
                    foreach (var file in files)
                    {
                        if(files.IndexOf(file) ==0) 
                        {
                            if (file.Length > 0)
                            {
                                string ImageName = Guid.NewGuid().ToString() + ".pdf";
                                var filePaths = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Uploads", ImageName);
                                using (var stream = System.IO.File.Create(filePaths))
                                {
                                    await file.CopyToAsync(stream);
                                }
                                ITEM.DocumentA = ImageName;
                            }

                        }
                        else if (files.IndexOf(file) == 1)
                        {
                            if (file.Length > 0)
                            {
                                string ImageName = Guid.NewGuid().ToString() + ".pdf";
                                var filePaths = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Uploads", ImageName);
                                using (var stream = System.IO.File.Create(filePaths))
                                {
                                    await file.CopyToAsync(stream);
                                }
                                ITEM.DocumentB = ImageName;
                            }

                        }
                        else if (files.IndexOf(file) == 2)
                        {
                            if (file.Length > 0)
                            {
                                string ImageName = Guid.NewGuid().ToString() + ".pdf";
                                var filePaths = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Uploads", ImageName);
                                using (var stream = System.IO.File.Create(filePaths))
                                {
                                    await file.CopyToAsync(stream);
                                }
                                ITEM.DocumentC = ImageName;
                            }

                        }
                        else if (files.IndexOf(file) == 3)
                        {
                            if (file.Length > 0)
                            {
                                string ImageName = Guid.NewGuid().ToString() + ".pdf";
                                var filePaths = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Uploads", ImageName);
                                using (var stream = System.IO.File.Create(filePaths))
                                {
                                    await file.CopyToAsync(stream);
                                }
                                ITEM.DocumentD = ImageName;
                            }

                        }
                        else if (files.IndexOf(file) == 4)
                        {
                            if (file.Length > 0)
                            {
                                string ImageName = Guid.NewGuid().ToString() + ".pdf";
                                var filePaths = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Uploads", ImageName);
                                using (var stream = System.IO.File.Create(filePaths))
                                {
                                    await file.CopyToAsync(stream);
                                }
                                ITEM.DocumentE = ImageName;
                            }

                        }
                        else if (files.IndexOf(file) == 5)
                        {
                            if (file.Length > 0)
                            {
                                string ImageName = Guid.NewGuid().ToString() + ".pdf";
                                var filePaths = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Uploads", ImageName);
                                using (var stream = System.IO.File.Create(filePaths))
                                {
                                    await file.CopyToAsync(stream);
                                }
                                ITEM.DocumentF = ImageName;
                            }

                        }

                    }





                    var result = sellerService.Add(ITEM);
                
                  
                    var user = _userManager.Users.Where(a => a.Id == ITEM.CreatedBy).FirstOrDefault();
                    user.AccountType = "التاجر";
                    user.ApprovalStatus = "Approved";
                    await _userManager.UpdateAsync(user);
                    if (result == true)
                    {
                        TempData[SD.Success] = "Seller Profile successfully Created.";
                    }
                    else
                    {
                        TempData[SD.Error] = "Error in Seller Profile  Creating.";
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






                    var result = sellerService.Edit(ITEM);
                    if (result == true)
                    {
                        TempData[SD.Success] = "Seller Profile successfully Updated.";
                    }
                    else
                    {
                        TempData[SD.Error] = "Error in Seller Profile  Updating.";
                    }
                }
            }




            HomePageModel model = new HomePageModel();
            model.lstSellers = sellerService.getAll();
            return View("Index", model);
        }




        [Authorize(Roles = "Admin,حذف  التجار")]
        public IActionResult Delete(Guid id)
        {

            TbSeller oldItem = ctx.TbSellers.Where(a => a.SellerId == id).FirstOrDefault();



            var result = sellerService.Delete(oldItem);
            if (result == true)
            {
                TempData[SD.Success] = "Seller Profile successfully Removed.";
            }
            else
            {
                TempData[SD.Error] = "Error in Seller Profile  Removing.";
            }

            HomePageModel model = new HomePageModel();
            model.lstSellers = sellerService.getAll();
            return View("Index", model);



        }



        [Authorize(Roles = "Admin,اضافة او تعديل  التجار")]
        public IActionResult Form(Guid? id)
        {
            TbSeller oldItem = ctx.TbSellers.Where(a => a.SellerId == id).FirstOrDefault();
            ViewBag.countries = countryService.getAll();
            ViewBag.cities = cityService.getAll();
            ViewBag.users = _userManager.Users.Where(a => a.AccountType != "المستخدم").ToList();
            return View(oldItem);
        }
    }
}
