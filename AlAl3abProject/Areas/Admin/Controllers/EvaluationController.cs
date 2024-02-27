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
using Microsoft.AspNetCore.Identity;

namespace AlAl3abProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EvaluationController : Controller
    {
        EvaluationService evaluationService;
        ItemService itemService;
        SellerService sellerService;
        AlAl3abDbContext ctx;
        private readonly UserManager<ApplicationUser> _userManager;
        public EvaluationController(UserManager<ApplicationUser> userManager, SellerService SellerService,ItemService ItemService,EvaluationService EvaluationService, AlAl3abDbContext context)
        {

            evaluationService = EvaluationService;
            ctx = context;
            itemService = ItemService;
            sellerService = SellerService;
            _userManager = userManager;

        }
        [Authorize(Roles = "Admin, التقييمات")]
        public IActionResult Index()
        {

            HomePageModel model = new HomePageModel();
            model.lstEvaluations = evaluationService.getAll();
            model.lstItems =itemService.getAll();
            model.lstSellers = sellerService.getAll();

            return View(model);


        }




        [HttpPost]
        public async Task<IActionResult> Save(TbEvaluation ITEM, int id, List<IFormFile> files)
        {
            if (ITEM.EvaluationId == null)
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





                    var result = evaluationService.Add(ITEM);
                    if (result == true)
                    {
                        TempData[SD.Success] = "Rating Profile successfully Created.";
                    }
                    else
                    {
                        TempData[SD.Error] = "Error in Rating Profile  Creating.";
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






                    var result = evaluationService.Edit(ITEM);
                    if (result == true)
                    {
                        TempData[SD.Success] = "Rating Profile successfully Updated.";
                    }
                    else
                    {
                        TempData[SD.Error] = "Error in Rating Profile  Updating.";
                    }
                }
            }




            HomePageModel model = new HomePageModel();
            model.lstEvaluations = evaluationService.getAll();
            model.lstItems = itemService.getAll();
            model.lstSellers = sellerService.getAll();
            return View("Index", model);
        }




        [Authorize(Roles = "Admin,حذف  التقييمات")]
        public IActionResult Delete(Guid id)
        {

            TbEvaluation oldItem = ctx.TbEvaluations.Where(a => a.EvaluationId == id).FirstOrDefault();

            if (oldItem.CurrentState == 1)
            {
                oldItem.CurrentState = 0;
            }
            else if (oldItem.CurrentState == 0)
            {
                oldItem.CurrentState = 1;
            }

            var result = evaluationService.Edit(oldItem);
            if (result == true)
            {
                TempData[SD.Success] = "Rating Profile successfully Removed.";
            }
            else
            {
                TempData[SD.Error] = "Error in Rating Profile  Removing.";
            }

            HomePageModel model = new HomePageModel();
            model.lstEvaluations = evaluationService.getAll();
            model.lstItems = itemService.getAll();
            model.lstSellers = sellerService.getAll();
            return View("Index", model);



        }



        [Authorize(Roles = "Admin,اضافة او تعديل  التقييمات")]
        public IActionResult Form(Guid? id)
        {
            TbEvaluation oldItem = ctx.TbEvaluations.Where(a => a.EvaluationId == id).FirstOrDefault();
            ViewBag.users = _userManager.Users.ToList();
            ViewBag.items = itemService.getAll();
            ViewBag.sellers = sellerService.getAll();
            return View(oldItem);
        }
    }
}
