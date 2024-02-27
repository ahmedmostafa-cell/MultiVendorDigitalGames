using BL;
using Domains;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AlAl3abProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderApiController : ControllerBase
    {
       
        UserManager<ApplicationUser> Usermanager;
        private readonly OrderService orderService;
        AlAl3abDbContext ctx;
        public OrderApiController(OrderService OrderService,UserManager<ApplicationUser> usermanager, AlAl3abDbContext context)
        {
           
            ctx = context;
            Usermanager = usermanager;
            orderService = OrderService;


        }
        // GET: api/<OrderApiController>
        [HttpGet]
        public IEnumerable<TbOrder> Get()
        {
            List<TbOrder> lstLogHistories = orderService.getAll();

            return lstLogHistories;
        }

        // GET api/<OrderApiController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<OrderApiController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<OrderApiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<OrderApiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
