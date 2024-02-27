using BL;
using Domains;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AlAl3abProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetCouponDiscountApiController : ControllerBase
    {
        AlAl3abDbContext ctx;
        private readonly PromocodeService promocodeService;
        public GetCouponDiscountApiController(AlAl3abDbContext context, PromocodeService PromocodeService)
        {

            ctx = context;
            promocodeService = PromocodeService;


        }
        // GET: api/<GetCouponDiscountApiController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<GetCouponDiscountApiController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<GetCouponDiscountApiController>
        [HttpGet("{id}")]
        public TbPromocode Get( string id)
        {
            TbPromocode oTbPromocode = promocodeService.getAll().Where(A => A.PromocodeTitle == id).FirstOrDefault();

            return oTbPromocode;
        }

        // PUT api/<GetCouponDiscountApiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<GetCouponDiscountApiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
