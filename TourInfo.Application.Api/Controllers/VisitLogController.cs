using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TourInfo.Application.Api.Models;
using TourInfo.Domain.Base;
using TourInfo.Domain.DomainModel;

namespace TourInfo.Application.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitLogController : ControllerBase
    {
        IRepository<VisitLog,string> repository;

        public VisitLogController(IRepository<VisitLog, string> repository)
        {
            this.repository = repository;
        }

       
        [HttpGet("GetVisitLog")]
        public VisitLogModel GetVisitLog(int year, int month)

        {
            //最新数据不能超过上月
           var targetMonth= EnsureTargetTime(year, month);
            var total = GetTotal();
            var monthData = GetMonthData(targetMonth.Year, targetMonth.Month);
            var yearData = GetYearData(targetMonth.Year);
            return new VisitLogModel
            {
                TotalAmount = GetTotal(),
                MonthPV = monthData.PV,
                MonthUV = monthData.UV,
                MonthNewUserAmount = monthData.NewUser,

                YearPv = yearData.PV,
                YearUV = yearData.UV,
                YearNewUserAmount = yearData.NewUser
            };
           
        }
        private int GetTotal()
        {
            return repository.GetAll().Sum(x => x.UV);
        }
        private VisitLogData GetMonthData(int year, int month)
        {
            var where = PredicateBuilder.True<VisitLog>();
            where = where.And(x => x.Year == year && x.Month == x.Month);
            var monthData = repository.FindList(where.Compile(), x => x.Year, false, 0, 20);
            if (monthData.Count <=0) { throw new Exception($"没有找到对应数据{year},{month}"); }
            else if (monthData.Count > 1) { throw new Exception($"找到多条对应数据{year},{month}"); }
            return new VisitLogData { PV = monthData[0].PV, UV = monthData[0].UV, NewUser = monthData[0].NewUsersAmount };

        }
        public class VisitLogData { 
        public int PV { get; set; }
        public int UV { get; set; }
        public int NewUser { get; set; }
        }
        private VisitLogData GetYearData(int year)
        {
            var where = PredicateBuilder.True<VisitLog>();
            where = where.And(x => x.Year == year);
            var monthData = repository.FindList(where.Compile(), x => x.Year, false, 0, 99999);
            if (monthData.Count <= 0) { throw new Exception($"没有找到对应数据{year}"); }
            int pv = monthData.Sum(x => x.PV);
            return new VisitLogData
            {
                PV = monthData.Sum(x => x.PV),
                UV = monthData.Sum(x => x.UV),
                NewUser = monthData.Sum(x => x.NewUsersAmount)
            };
        }

        private DateTime EnsureTargetTime(int year, int month)
        {
            var targetMonth = new DateTime(year, month, 1);

            var now = DateTime.Now;
            var latestMonth = new DateTime(now.Year, now.Month, 1).AddMonths(-1);
            if (targetMonth > latestMonth)
            {
                targetMonth = latestMonth;
            }
            return targetMonth;
        }

        
    }
}
