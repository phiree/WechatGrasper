using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TourInfo.Domain.Base;
using TourInfo.Domain.DomainModel.DataLog;

namespace TourInfo.Application.Api.Controllers
{
    public class DataLogFilter :IActionFilter
    {
        
        IRepository<FetchLog, string> repository;
        ILogger<DataLogFilter> logger;
        public string DataSourceName { get; set; }

        private string logId = Guid.NewGuid().ToString();
        public DataLogFilter(IRepository<FetchLog, string> repository,ILogger<DataLogFilter> logger, string datasourcename)
        {
            this.repository = repository;
            this.DataSourceName = datasourcename;
            this.logger = logger;
           
        }

        

        public void OnActionExecuting(ActionExecutingContext context)
        {
            logger.LogDebug("datalogfilter OnActionExecutionAsync" + DataSourceName);
            repository.Insert(new FetchLog
            {
                FetchAmount = DateTime.Now.Second+2,
                FetchBeginTime = DateTime.Now,
                id = logId,
                FetchResult = "抓取中",
                SourceName = DataSourceName
            });
            logger.LogDebug("抓取日志插入成功");
           
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            logger.LogDebug("datalogfilter OnResultExecutionAsync" + DataSourceName);
            var log = repository.Get(logId);
            log.FetchEndTime = DateTime.Now;
            log.FetchResult = "抓取完毕";
            repository.Update(log);
            logger.LogDebug("抓取日志更新成功");
        }
    }
}
