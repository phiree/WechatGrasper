using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TourInfo.Application.Api.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TourInfo.Application.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZBTourController : ControllerBase
    {
        /// <summary>
        /// 获取首页轮播图
        /// </summary>
        /// <returns></returns>
        /// <param name="size">数量</param>
        // GET: api/<ZBTourController>/GetHomeCarousels
        [HttpGet("GetHomeCarousels")]
        public ResponseWrapperWithList<HomeCarousel> GetHomeCarousels(int size=5)
        {
           return new ResponseWrapperWithList<HomeCarousel>{ data=new List<HomeCarousel>() };
        }

        // GET api/<ZBTourController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ZBTourController>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<ZBTourController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<ZBTourController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
