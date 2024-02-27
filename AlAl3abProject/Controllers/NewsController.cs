using Microsoft.AspNetCore.Mvc;

namespace AlAl3abProject.Controllers
{
    public class NewsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
