using BL;
using Domains;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AlAl3abProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypesMainCat1Controller : ControllerBase
    {
        private readonly AlAl3abDbContext _alAl3abDbContext;


        public TypesMainCat1Controller(AlAl3abDbContext alAl3abDbContext)
        {
            _alAl3abDbContext = alAl3abDbContext;
        }
        // GET: api/<TypesMainCat1Controller>
        [HttpGet]
        public async Task<IEnumerable<TbType>> GetAsync()
        {
            var TypesMainCat = await _alAl3abDbContext.TbTypes.ToListAsync();

            return TypesMainCat;
        }

        // GET api/<TypesMainCat1Controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TypesMainCat1Controller>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<TypesMainCat1Controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TypesMainCat1Controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
