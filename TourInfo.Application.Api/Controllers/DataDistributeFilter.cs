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
    public class DataDistributeFilter :IActionFilter
    {
        
        IRepository<DistributeLog, string> repository;
        ILogger<DataDistributeFilter> logger;
       

        private string logId = Guid.NewGuid().ToString();
        public DataDistributeFilter(IRepository<DistributeLog, string> repository,ILogger<DataDistributeFilter> logger )
        {
            this.repository = repository;
            
            this.logger = logger;
           
        }


        static Random rnd = new Random();
        public void OnActionExecuting(ActionExecutingContext context)
        {
           
            var devices = repository.GetAll();
            var currentDevice = devices[rnd.Next(devices.Count)];
             repository.Insert(new DistributeLog
            {
                DistributeAmount = DateTime.Now.Second - 3,
                DistributeBeginTime = DateTime.Now,
                id = logId,
                DistirbuteResult = "开始分发",
                DeviceName = currentDevice.DeviceName
            }) ;
            logger.LogDebug("分发开始");
           
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
             var log = repository.Get(logId);
            log.DistributeEndTime = DateTime.Now;
            log.DistirbuteResult = "分发完毕";
            repository.Update(log);
            logger.LogDebug("分发完毕");
        }
    }
}
