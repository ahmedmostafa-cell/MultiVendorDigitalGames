using AlAl3abProject.Models;
using BL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Data;
using System.IO;
using System.Threading.Tasks;
using System.Linq;

namespace AlAl3abProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,الصفحة الرئيسية")]
    public class HomeController : Controller
    {

        private readonly AlAl3abDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public HomeController(AlAl3abDbContext db, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;


            _db = db;

        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult List()
        {
            ViewBag.LawyersCount = _userManager.Users.ToList().Where(a => a.AccountType == "التاجر").Count();
            ViewBag.UsersCount = _userManager.Users.ToList().Where(a => a.AccountType == "المستخدم").Count();
            ViewBag.TotaCount = _userManager.Users.ToList().Count();
            HomePageModel model = new HomePageModel();
            model.lstUsers = _userManager.Users.ToList();
            return View(model);
        }

        public IActionResult Roles()
        {
            HomePageModel model = new HomePageModel();
            model.lstUserRole = _db.UserRoles.ToList();

            return View(model);
        }
        public IActionResult Account2(string id)
        {
            HomePageModel oHomePageModel = new HomePageModel();
            oHomePageModel.UserData = _db.Users.ToList();
            oHomePageModel.OneUser = _userManager.Users.Where(a => a.Id == id).FirstOrDefault();
            return View(oHomePageModel);
        }
        [HttpPost]
        public async Task<IActionResult> EditUserAsync(ApplicationUser u, string username, string email, string firstname, List<IFormFile> files)
        {


            var user = await _userManager.FindByEmailAsync(email);

            user.UserName = u.UserName;
            user.Email = u.Email;
            user.FirstName = u.FirstName;
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
                    user.Image = ImageName;
                }
            }







            var result = await _userManager.UpdateAsync(user);


            var a = result;








            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
    }
}
