using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TourInfo.Application.Api.Models
{
    public class VisitLogModel
    {
        /// <summary>
        /// 累计总数
        /// </summary>
        public int TotalAmount { get; set; }
        /// <summary>
        /// 月访问次数
        /// </summary>
        public int MonthPV { get; set; }
        /// <summary>
        /// 月访问人数
        /// </summary>
        public int MonthUV { get; set; }
        /// <summary>
        /// 月新增用户
        /// </summary>
        public int MonthNewUserAmount { get; set; }
        /// <summary>
        /// 年访问次数
        /// </summary>
        public int YearPv { get; set; }
        /// <summary>
        /// 年访问人数
        /// </summary>
        public int YearUV { get; set; }
        /// <summary>
        /// 年新增用户
        /// </summary>
        public int YearNewUserAmount { get; set; }
    }
}
