using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TourInfo.Domain.Base;
using TourInfo.Domain.DomainModel;
using TourInfo.Domain.TourNews;

namespace TourInfo.Application.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TourInfoController : ControllerBase
    {
        IDataService dataService;
        IRepository<ZbtaNews, string> zbtanewsRepository;
        public TourInfoController(IDataService dataService, IRepository<ZbtaNews, string> zbtanewsRepository)
        {
            this.zbtanewsRepository = zbtanewsRepository;
            this.dataService = dataService;
        }
        [HttpGet("InitData")]
        public ActionResult<string> InitData()
        {
            
            dataService.CreateInitData();
            return new ActionResult<string>("初始化成功");
        }
        public ActionResult<string> ZbtaNewsDetail(string newsId)
        {
            var zbtaNews = zbtanewsRepository.Get(newsId);
            return Content(zbtaNews.details);
        }

        [HttpGet("SyncData")]
        public ActionResult<dynamic> SyncData(string version)
        {

          return  dataService.CreateSyncData(version);
            
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
