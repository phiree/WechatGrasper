using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TourInfo.Application.Api.Models
{
    public class VisitLogModel
    {
       

        int MonthUVPrevious,YearPvPrevious,YearUVPrevious,YearNewUserAmountPrevious, MonthNewUserAmountPrevious, MonthPVPrevious;

        public VisitLogModel(int totalAmount,
             int monthPV, int monthUV, int monthNewUserAmount,
             int monthPVPrevious, int monthUVPrevious, int monthNewUserAmountPrevious,
              int yearPv, int yearUV, int yearNewUserAmount,
            int yearPvPrevious, int yearUVPrevious, int yearNewUserAmountPrevious
         )
        {
            MonthUVPrevious = monthUVPrevious;
            YearPvPrevious = yearPvPrevious;
            YearUVPrevious = yearUVPrevious;
            YearNewUserAmountPrevious = yearNewUserAmountPrevious;
            MonthNewUserAmountPrevious = monthNewUserAmountPrevious;
            MonthPVPrevious = monthPVPrevious;
            TotalAmount = totalAmount;
            MonthPV = monthPV;
            MonthUV = monthUV;
            MonthNewUserAmount = monthNewUserAmount;
            YearPv = yearPv;
            YearUV = yearUV;
            YearNewUserAmount = yearNewUserAmount;
        }

        /// <summary>
        /// 累计总数
        /// </summary>
        public int TotalAmount { get; set; }
        /// <summary>
        /// 月访问次数
        /// </summary>
        public int MonthPV { get; set; }
      
        public double MonthPvTrend =>GetTrend(MonthPV,MonthPVPrevious);
        /// <summary>
        /// 月访问人数
        /// </summary>
        public int MonthUV { get; set; }
       
        public double MonthUVTrend => GetTrend(MonthUV, MonthUVPrevious);
        /// <summary>
        /// 月新增用户
        /// </summary>
        public int MonthNewUserAmount { get; set; }
       public double MonthNewUserAmountTrend => GetTrend(MonthNewUserAmount, MonthNewUserAmountPrevious);
        /// <summary>
        /// 年访问次数
        /// </summary>
        public int YearPv { get; set; }
        public double YearPvTrend => GetTrend(YearPv, YearPvPrevious);
        /// <summary>
        /// 年访问人数
        /// </summary>
        public int YearUV { get; set; }
        
        public double YearUvTrend => GetTrend(YearUV, YearUVPrevious);
        /// <summary>
        /// 年新增用户
        /// </summary>
        public int YearNewUserAmount { get; set; }
         
        public double YearNewUserAmountYearPvTrend => GetTrend(YearNewUserAmount, YearNewUserAmountPrevious);

        private double GetTrend(int current,int previous)
        { 
            if(previous==0)return 0;
            return Math.Round((double)(current-previous)/(double)previous,3);
            }
    }
}
