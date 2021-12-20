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
using TourInfo.Domain.DomainModel.Weather;
using TourInfo.Infrastracture;
using TourInfo.Domain.Base;
using TourInfo.Domain.DomainModel.DataLog;
using TourInfo.Application.Api.Models;

namespace TourInfo.Application.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class DataLogController : ControllerBase
    {

        IZBTAApplication zBTAApplication;
        IEWQYApplication eWQYApplication;
        IRapiApplication rapiApplication;
        IVideoApplication videoApplication;
        IDataService dataService;
        IServiceProvider serviceProvider;
        IWHYApplication wHYApplication;
        IZiBoWechatNewsApplication ziBoWechatNewsApplication;
        ILogger<TourInfoController> logger;
        IMemoryCache _cache;
        ISDTAApplication sDTAApplication;
        IWeatherApplication weatherApplication;

        IRepository<FetchLog, string> fetchLogRepository;
        IRepository<Client, string> clientRepository;
        IRepository<DataSource, string> dataSourceRepository;
        IRepository<DistributeLog, string> distributeRepository;
        public DataLogController(ILogger<TourInfoController> logger, IServiceProvider serviceProvider,
            IRapiApplication rapiApplication,
            IZBTAApplication zBTAApplication,
            IEWQYApplication eWQYApplication,
            IVideoApplication videoApplication,
            IWHYApplication wHYApplication,
            ISDTAApplication sDTAApplication,
            IMemoryCache cache,
            IDataService dataService,
            IZiBoWechatNewsApplication ziBoWechatNewsApplication
            , IWeatherApplication weatherApplication
, IRepository<FetchLog, string> fetchLogRepository, IRepository<Client, string> clientRepository, IRepository<DataSource, string> dataSourceRepository, IRepository<DistributeLog, string> distributeRepository)
        {
            this.weatherApplication = weatherApplication;
            this.wHYApplication = wHYApplication;
            this.logger = logger;
            this.rapiApplication = rapiApplication;
            this.zBTAApplication = zBTAApplication;
            this.eWQYApplication = eWQYApplication;
            this.videoApplication = videoApplication;
            this.sDTAApplication = sDTAApplication;
            this.dataService = dataService;
            this.serviceProvider = serviceProvider;
            this._cache = cache;
            this.ziBoWechatNewsApplication = ziBoWechatNewsApplication;
            this.fetchLogRepository = fetchLogRepository;
            this.clientRepository = clientRepository;
            this.dataSourceRepository = dataSourceRepository;
            this.distributeRepository = distributeRepository;
        }


        /// <summary>
        /// 抓取日志
        /// </summary>
        /// <param name="pageIndex">页码 默认1</param>
        /// <param name="pageSize">每页数量 默认10</param>
        /// <param name="sourceName">数据源 默认空</param>
        /// <param name="begin">抓取开始时间 默认空</param>
        /// <param name="end">抓取结束时间 默认空</param>
        /// <returns></returns>
        [HttpGet("GetFetchLogs")]
        public PagedResult<FetchLog> GetFetchLogs(int pageIndex = 1, int pageSize = 10, string sourceName = "", DateTime? begin = null, DateTime? end = null)
        {
            var predicate = PredicateBuilder.True<FetchLog>();
            if (!string.IsNullOrEmpty(sourceName)) { predicate = predicate.And(x => x.SourceName == sourceName); }
            if (begin != null) { predicate = predicate.And(x => x.FetchBeginTime >= begin); }
            if (end != null) { predicate = predicate.And(x => x.FetchEndTime <= end); }

            var datas = fetchLogRepository.GetAll().Where(predicate.Compile()).OrderByDescending(x=>x.FetchBeginTime);
            return new PagedResult<FetchLog>
            {
                Data = datas.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList(),
                Total = datas.Count()
            };
        }
        /// <summary>
        /// 分发日志
        /// </summary>
        /// <param name="pageIndex">页码 默认1</param>
        /// <param name="pageSize">每页数量 默认10</param>
        /// <param name="sourceName">设备名 默认空</param>
        /// <param name="begin">抓取开始时间 默认空</param>
        /// <param name="end">抓取结束时间 默认空</param>
        /// <returns></returns>
        [HttpGet("GetDistributeLogs")]
        public PagedResult<DistributeLog> GetDistributeLogs(int pageIndex = 1, int pageSize = 10, string deviceName = "", DateTime? begin = null, DateTime? end = null)
        {
            var predicate = PredicateBuilder.True<DistributeLog>();
            if (!string.IsNullOrEmpty(deviceName)) { predicate = predicate.And(x => x.DeviceName == deviceName); }
            if (begin != null) { predicate = predicate.And(x => x.DistributeBeginTime >= begin); }
            if (end != null) { predicate = predicate.And(x => x.DistributeEndTime <= end); }


            var datas = distributeRepository.GetAll().Where(predicate.Compile()).OrderByDescending(x=>x.DistributeBeginTime);
            return new PagedResult<DistributeLog>
            {
                Data = datas.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList(),
                Total = datas.Count()
            };
        }
        /// <summary>
        /// 客户端列表
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("GetClients")]
        public PagedResult<Client> GetClients(int pageIndex, int pageSize)
        {

            var datas = clientRepository.GetAll();
            return new PagedResult<Client>
            {
                Data = datas.Skip((pageIndex - 1) * pageSize).ToList(),
                Total = datas.Count
            };
        }
        /// <summary>
        /// 数据源列表
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("GetDatasources")]
        public PagedResult<DataSource> GetDatasources(int pageIndex, int pageSize)
        {

            var datas = dataSourceRepository.GetAll();
            return new PagedResult<DataSource>
            {
                Data = datas.Skip((pageIndex - 1) * pageSize).ToList(),
                Total = datas.Count
            };
        }
        /// <summary>
        /// 管理员登录
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpGet("AdminLogin")]
        public bool AdminLogin(string userId, string password)
        {

            return true;
        }

        Random r = new Random(100);
        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPost("BuildDataTest")]
        public void BuildData()
        {
            var endTime = DateTime.Now;
            DateTime date = new DateTime(2019, 5, 10);

            var allClients = clientRepository.GetAll();
            var allSources = dataSourceRepository.GetAll();

            while (date <= endTime)
            {
                fetchLogRepository.Insert(
                    new FetchLog
                    {
                        FetchAmount = r.Next(100),
                        FetchBeginTime = date,
                        FetchEndTime = date.AddSeconds(r.Next(30))
                    ,
                        FetchResult = "抓取成功",
                        id = Guid.NewGuid().ToString(),
                        SourceName = allSources[r.Next(allSources.Count)].Name
                    });

                distributeRepository.Insert(
                     new DistributeLog
                     {
                         DistributeAmount = r.Next(50),
                         DistributeBeginTime = date.AddSeconds(r.Next(3600)),
                         DistributeEndTime = date.AddSeconds(r.Next(3600, 7200))
                    ,
                         DistirbuteResult = "分发成功",
                         id = Guid.NewGuid().ToString(),
                         DeviceName = allClients[r.Next(allSources.Count)].Name
                     }
                    );

                date = date.AddDays(1);

            }

        }

    }
}
