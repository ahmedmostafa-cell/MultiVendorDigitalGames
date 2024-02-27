using BL;
using Domains;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AlAl3abProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchApiController : ControllerBase
    {
       
        
        AlAl3abDbContext ctx;
        private readonly ItemSellerService itemSellerService;
        public SearchApiController( AlAl3abDbContext context , ItemSellerService ItemSellerService)
        {
        
            ctx = context;
            itemSellerService = ItemSellerService;


        }
        // GET: api/<SearchApiController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<SearchApiController>/5
        [HttpGet("{option}")]
        public IEnumerable<TbItemSeller> Get(string option)
        {
            if(option == "" || option ==null || option == "undefined") 
            {
                return new List<TbItemSeller>();
            }
            else 
            {
                List<TbItemSeller> lstItemSellers = itemSellerService.getAll().Where(A => A.ItemName.Contains(option)).ToList();

                return lstItemSellers;

            }
           
        }

        // POST api/<SearchApiController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<SearchApiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SearchApiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
