using Microsoft.AspNetCore.Http;

namespace AlAl3abProject.Models
{
    public class ProductViewModel
    {
       public string Name { get; set; }


        public IFormFile File { get; set; }
    }
}
