using BL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace AlAl3abProject.Controllers
{
    public class TypesMainCatController : Controller
    {
        private readonly AlAl3abDbContext _alAl3abDbContext;


        public TypesMainCatController(AlAl3abDbContext alAl3abDbContext)
        {
            _alAl3abDbContext = alAl3abDbContext;
        }
        public IActionResult Index()
        {
            return View();
        }
        //--------------------------------------------------------------------- RetieveData
        [HttpGet]
        public  JsonResult GetTypesMainCat()
        {
           
            
                var TypesMainCat =  _alAl3abDbContext.TbTypes.ToList();

                return Json(new { data = TypesMainCat, status = true });
            
        }
    }
}
