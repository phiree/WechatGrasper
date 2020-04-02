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
using TourInfo.Domain.Application.ZiBoWechatNews;
using TourInfo.Domain.Application.SDTA;

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
        IZiBoWechatNewsApplication ziBoWechatNewsApplication;
        ILogger<TourInfoController> logger;
          IMemoryCache _cache;
        ISDTAApplication sDTAApplication;
        public TourInfoController(ILogger<TourInfoController> logger, IServiceProvider serviceProvider, 
            IRapiApplication rapiApplication, 
            IZBTAApplication zBTAApplication, 
            IEWQYApplication eWQYApplication,
            IVideoApplication videoApplication,
            IWHYApplication wHYApplication,
            ISDTAApplication sDTAApplication,
            IMemoryCache cache,
            IDataService dataService,
            IZiBoWechatNewsApplication ziBoWechatNewsApplication)
        {
            this.wHYApplication=wHYApplication;
            this.logger=logger;
           this.rapiApplication = rapiApplication;
            this.zBTAApplication = zBTAApplication;
            this.eWQYApplication = eWQYApplication;
            this.videoApplication=videoApplication;
            this.sDTAApplication=sDTAApplication;
            this.dataService = dataService;
            this.serviceProvider=serviceProvider;
            this._cache = cache;
            this.ziBoWechatNewsApplication=ziBoWechatNewsApplication;
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
            
            logger.LogInformation("开始更新数据");
           this.GraspeData( );
           //不再需要创建前端适用的sqllite文件
            // dataService.CreateInitData(currentVersion);
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
        [HttpGet("GetZiboWechatNews")]
        public ActionResult<string> GetZiboWechatNews(string dataVersion)
        {

            string currentVersion = DateTime.Now.ToString("yyyyMMddhhmmss");
            logger.LogInformation("开始更新数据GetZiboWechatNews");
            ziBoWechatNewsApplication.Graspe(currentVersion);
            return "更新完毕GetZiboWechatNews";

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
        public ActionResult<dynamic> GraspeData( )
        {

            string currentVersion = DateTime.Now.ToString("yyyyMMddhhmmss");
            zBTAApplication.Graspe(currentVersion);
            eWQYApplication.Graspe(currentVersion);
            videoApplication.Graspe(currentVersion);
            logger.LogInformation(" 抓取完毕");
           
            return Content("抓取完毕");

        }
        [HttpGet("GraspeSDTA")]
        public ActionResult<dynamic> GraspeSDTA(string _dateVersion)
        {


            sDTAApplication.Graspe();
            
            return Content("Sdta抓取完毕");

        }





    }
}
