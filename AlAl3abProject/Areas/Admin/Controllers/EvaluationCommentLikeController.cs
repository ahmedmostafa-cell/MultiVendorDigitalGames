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
    public class EvaluationCommentLikeController : Controller
    {
        EvaluationCommentLikeService evaluationCommentLikeService;
        ItemService itemService;
        SellerService sellerService;
        EvaluationService evaluationService;
        AlAl3abDbContext ctx;
        public EvaluationCommentLikeController(EvaluationService EvaluationService,SellerService SellerService,ItemService ItemService,EvaluationCommentLikeService EvaluationCommentLikeService, AlAl3abDbContext context)
        {

            evaluationCommentLikeService = EvaluationCommentLikeService;
            ctx = context;
            itemService = ItemService;
            sellerService = SellerService;
            evaluationService = EvaluationService;
        }
        [Authorize(Roles = "Admin, التفاعل مع تعليقات عل التقييمات")]
        public IActionResult Index()
        {

            HomePageModel model = new HomePageModel();
            model.lstEvaluationCommentLikes = evaluationCommentLikeService.getAll();
            model.lstItems = itemService.getAll();
            model.lstSellers = sellerService.getAll();
            model.lstEvaluations = evaluationService.getAll();
            return View(model);


        }




        [HttpPost]
        public async Task<IActionResult> Save(TbEvaluationCommentLike ITEM, int id, List<IFormFile> files)
        {
            if (ITEM.EvaluationCommentLikeId == null)
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





                    var result = evaluationCommentLikeService.Add(ITEM);
                    if (result == true)
                    {
                        TempData[SD.Success] = "Rating Comment Like Profile successfully Created.";
                    }
                    else
                    {
                        TempData[SD.Error] = "Error in Rating Comment Like Profile  Creating.";
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






                    var result = evaluationCommentLikeService.Edit(ITEM);
                    if (result == true)
                    {
                        TempData[SD.Success] = "Rating Comment Like Profile successfully Updated.";
                    }
                    else
                    {
                        TempData[SD.Error] = "Error in Rating Comment Like Profile  Updating.";
                    }
                }
            }




            HomePageModel model = new HomePageModel();
            model.lstEvaluationCommentLikes = evaluationCommentLikeService.getAll();
            model.lstItems = itemService.getAll();
            model.lstSellers = sellerService.getAll();
            model.lstEvaluations = evaluationService.getAll();
            return View("Index", model);
        }




        [Authorize(Roles = "Admin,حذف  التفاعل مع تعليقات عل التقييمات")]
        public IActionResult Delete(Guid id)
        {

            TbEvaluationCommentLike oldItem = ctx.TbEvaluationCommentLikes.Where(a => a.EvaluationCommentLikeId == id).FirstOrDefault();



            var result = evaluationCommentLikeService.Delete(oldItem);
            if (result == true)
            {
                TempData[SD.Success] = "Rating Comment Like Profile successfully Removed.";
            }
            else
            {
                TempData[SD.Error] = "Error in Rating Comment Like Profile  Removing.";
            }

            HomePageModel model = new HomePageModel();
            model.lstEvaluationCommentLikes = evaluationCommentLikeService.getAll();
            model.lstItems = itemService.getAll();
            model.lstSellers = sellerService.getAll();
            model.lstEvaluations = evaluationService.getAll();
            return View("Index", model);



        }



        [Authorize(Roles = "Admin,اضافة او تعديل  التفاعل مع تعليقات عل التقييمات")]
        public IActionResult Form(Guid? id)
        {
            TbEvaluationCommentLike oldItem = ctx.TbEvaluationCommentLikes.Where(a => a.EvaluationCommentLikeId == id).FirstOrDefault();


            return View(oldItem);
        }
    }
}
