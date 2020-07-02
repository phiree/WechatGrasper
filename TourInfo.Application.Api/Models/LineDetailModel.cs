using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TourInfo.Domain.Base;

namespace TourInfo.Application.Api.Models
{
    public class LineDetailModel
    {
        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }

        public Location Location { get;set;}

        public string[] LineTags { get; set; }


        /// <summary>
        /// 行程概览
        /// </summary>
        public string TourSummary { get; set; }

        public IList<DayDetaill> Days {get;set; }
        /// <summary>
        /// 每日详情
        /// </summary>
        public class DayDetaill
        {
            public int DayIndex { get; set; }
            public List<Scenic> Scenics { get;set;}
            public class Scenic
            {
                public string Name { get; set; }
                /// <summary>
                /// 图片
                /// </summary>
                public string ImageUrl { get; set; }
                /// <summary>
                /// 建议游玩时间
                /// </summary>
                public int RecommentStayHour { get; set; }
            }


        }
    }

}
