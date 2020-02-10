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
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TourInfo.Domain.Application.Video;
using Microsoft.Extensions.Caching.Memory;
using TourInfo.Domain.Application.WHY;

namespace TourInfo.Application.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TourInfoController : ControllerBase
    {
       
        IZBTAApplication zBTAApplication;
        IEWQYApplication eWQYApplication;
        IRapiApplication  rapiApplication;
        IVideoApplication  videoApplication;
        IDataService dataService;
        IServiceProvider serviceProvider;
         IWHYApplication wHYApplication;
        ILogger<TourInfoController> logger;
          IMemoryCache _cache;
        public TourInfoController(ILogger<TourInfoController> logger, IServiceProvider serviceProvider, 
            IRapiApplication rapiApplication, 
            IZBTAApplication zBTAApplication, 
            IEWQYApplication eWQYApplication,
            IVideoApplication videoApplication,
            IWHYApplication wHYApplication,
            IMemoryCache cache,
            IDataService dataService)
        {
            this.wHYApplication=wHYApplication;
            this.logger=logger;
           this.rapiApplication = rapiApplication;
            this.zBTAApplication = zBTAApplication;
            this.eWQYApplication = eWQYApplication;
            this.videoApplication=videoApplication;
            this.dataService = dataService;
            this.serviceProvider=serviceProvider;
            this._cache = cache;
        }

        [HttpGet("InitData")]
        public ActionResult<string> InitData(string version)
        {

            dataService.CreateInitData(version);
            return new ActionResult<string>("初始化成功");
        }
        [HttpGet("SyncWHYData")]
        public ActionResult<string> SyncWHYData(string version)
        {
            logger.LogInformation("-----开始同步------");
            string currentVersion = DateTime.Now.ToString("yyyyMMddhhmmss");
            logger.LogInformation("开始更新数据");
              wHYApplication.Grasp(currentVersion);
            logger.LogInformation("-----同步完成------");
            return "同步完成";

        }
        [HttpGet("SyncData")]
        public ActionResult<dynamic> SyncData(string version)
        {
            logger.LogInformation("-----开始同步------");
            string currentVersion = DateTime.Now.ToString("yyyyMMddhhmmss");
            logger.LogInformation("开始更新数据");
            this.GraspeData(currentVersion);
            dataService.CreateInitData(currentVersion);
            logger.LogInformation("开始更新sqlite文件");
            
            var syncResult=  dataService.CreateSyncData(version);
            logger.LogInformation("-----同步完成------");
            return syncResult;

        }
        [HttpGet("SyncDataTest")]
        public ActionResult<dynamic> SyncDataTest( )
        {
            
            return dataService.CreateSyncDataForTest();

        }
        [HttpGet("GetZbtaNewsDetail")]
        public ActionResult<string> GetZbtaNewsDetail(string id)
        {
            
            var zbtanewsCss = _cache.GetOrCreate<string>("zbtanewscss", entry =>
            {
                
                entry.SlidingExpiration = TimeSpan.FromSeconds(1);
               return  System.IO.File.ReadAllText(Environment.CurrentDirectory + "\\css\\zbtanews.css");
            });

            string localizedDetail = zBTAApplication.GetNewsDetail(id);//.Replace("DownloadImages","/DownloadImages");
              localizedDetail += zbtanewsCss;
            return Content(localizedDetail, "text/html",System.Text.Encoding.Default);

        }

        [HttpGet("GraspeData")]
        public ActionResult<dynamic> GraspeData(string _dateVersion)
        {
           

          //  var rapiApplication = serviceProvider.GetService<IRapiApplication>();
            rapiApplication.Graspe(_dateVersion, false);
          //  var rapiApplication = serviceProvider.GetService<IRapiApplication>();
            zBTAApplication.Graspe(_dateVersion);
            eWQYApplication.Graspe(_dateVersion);
            videoApplication.Graspe(_dateVersion);
            logger.LogInformation(" 抓取完毕");
            //var typeInfoThread = new System.Threading.Thread(() => {

               
            //});
            //typeInfoThread.Start();


          //  BackgroundWorker ewqyWorker = new BackgroundWorker();
           // ewqyWorker.DoWork += (obj, e) => EwqyWorker_DoWork(_dateVersion);
           // ewqyWorker.RunWorkerCompleted += EwqyWorker_RunWorkerCompleted;
            //ewqyWorker.RunWorkerAsync();
            //BackgroundWorker zbtaWorker = new BackgroundWorker();
            //zbtaWorker.DoWork += (obj, e) => ZbtaWorker_DoWork(_dateVersion);
            //zbtaWorker.RunWorkerCompleted += ZbtaWorker_RunWorkerCompleted;
            //zbtaWorker.RunWorkerAsync(argument: _dateVersion);

            //BackgroundWorker rapiWorker = new BackgroundWorker();
            //rapiWorker.DoWork += (obj, e) => RapiWorker_DoWork(_dateVersion);
            //rapiWorker.RunWorkerCompleted += RapiWorker_RunWorkerCompleted;
            //rapiWorker.RunWorkerAsync(argument: _dateVersion);

            return Content("抓取完毕");

        }
        private   void RapiWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Console.WriteLine("rapi抓取完毕");
        }
       
        private   void RapiWorker_DoWork(string dataVersion)
        {
            var rapiApplication = serviceProvider.GetService<IRapiApplication>();
            rapiApplication.Graspe(dataVersion, true);
        }

        private   void ZbtaWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Console.WriteLine("zbta抓取完毕");
        }

        private   void ZbtaWorker_DoWork(string dateVersion)
        {
          
          // 

        }

        private   void EwqyWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Console.WriteLine("ewqy抓取完毕");
        }

        private   void EwqyWorker_DoWork(string dateVersion)
        {
            

           // 
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
