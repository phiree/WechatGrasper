using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TourInfo.Domain.Application.Rapi;
using TourInfo.Domain.DomainModel;
using TourInfo.Domain.EWQY;
using TourInfo.Domain.TourNews;

namespace TourInfo.Application.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TourInfoController : ControllerBase
    {
        IRapiApplication rapiApplication;
        IZBTAApplication zBTAApplication;
        IEWQYApplication eWQYApplication;
        IDataService dataService;

        public TourInfoController(IRapiApplication rapiApplication, IZBTAApplication zBTAApplication, IEWQYApplication eWQYApplication, IDataService dataService)
        {
            this.rapiApplication = rapiApplication;
            this.zBTAApplication = zBTAApplication;
            this.eWQYApplication = eWQYApplication;
            this.dataService = dataService;
        }

        [HttpGet("InitData")]
        public ActionResult<string> InitData()
        {
            
            dataService.CreateInitData();
            return new ActionResult<string>("初始化成功");
        }

        [HttpGet("SyncData")]
        public ActionResult<dynamic> SyncData(string version)
        {

          return  dataService.CreateSyncData(version);
            
        }   
        [HttpGet("GraspeData")]
        public ActionResult<dynamic> GraspeData( )
        {

            string _dateVersion = DateTime.Now.ToString("yyyyMMddhhmmss");
            BackgroundWorker ewqyWorker = new BackgroundWorker();
            ewqyWorker.DoWork += (obj, e) => EwqyWorker_DoWork(_dateVersion);
            ewqyWorker.RunWorkerCompleted += EwqyWorker_RunWorkerCompleted;
            ewqyWorker.RunWorkerAsync();
            BackgroundWorker zbtaWorker = new BackgroundWorker();
            zbtaWorker.DoWork += (obj, e) => ZbtaWorker_DoWork(_dateVersion);
            zbtaWorker.RunWorkerCompleted += ZbtaWorker_RunWorkerCompleted;
            zbtaWorker.RunWorkerAsync(argument: _dateVersion);

            BackgroundWorker rapiWorker = new BackgroundWorker();
            rapiWorker.DoWork += (obj, e) => RapiWorker_DoWork(_dateVersion);
            rapiWorker.RunWorkerCompleted += RapiWorker_RunWorkerCompleted;
            rapiWorker.RunWorkerAsync(argument: _dateVersion);

            return Content("已在后台执行");

        }
        private   void RapiWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Console.WriteLine("rapi抓取完毕");
        }
       
        private   void RapiWorker_DoWork(string dataVersion)
        {
           
            rapiApplication.Graspe(dataVersion, true);
        }

        private   void ZbtaWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Console.WriteLine("zbta抓取完毕");
        }

        private   void ZbtaWorker_DoWork(string dateVersion)
        {
          
            zBTAApplication.Graspe(dateVersion);

        }

        private   void EwqyWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Console.WriteLine("ewqy抓取完毕");
        }

        private   void EwqyWorker_DoWork(string dateVersion)
        {
            

            eWQYApplication.Graspe(dateVersion);
        }
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
