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
        IRapiApplication  rapiApplication;
        IVideoApplication  videoApplication;
        IDataService dataService;
        IServiceProvider serviceProvider;
         IWHYApplication wHYApplication;
        IZiBoWechatNewsApplication ziBoWechatNewsApplication;
        ILogger<TourInfoController> logger;
          IMemoryCache _cache;
        ISDTAApplication sDTAApplication;
         IWeatherApplication weatherApplication;

        IRepository<FetchLog,string> fetchLogRepository;
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
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("GetFetchLogs")]
        public PagedResult<FetchLog> GetFetchLogs(int pageIndex, int pageSize)
        {

            var datas = fetchLogRepository.GetAll();
            return new PagedResult<FetchLog>
            {
                Data = datas.Skip((pageIndex - 1) * pageSize).ToList(),
                Total = datas.Count
            };
        }
        /// <summary>
        /// 分发日志
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("GetDistributeLogs")]
        public PagedResult<DistributeLog> GetDistributeLogs(int pageIndex, int pageSize)
        {

            var datas = distributeRepository.GetAll();
            return new PagedResult<DistributeLog>
            {
                Data = datas.Skip((pageIndex - 1) * pageSize).ToList(),
                Total = datas.Count
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
        public bool AdminLogin(string userId,string password)
        {

            return true;
        }

    }
}
