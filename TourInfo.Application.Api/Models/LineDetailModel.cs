using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TourInfo.Domain.Base;

namespace TourInfo.Application.Api.Models
{
    public class LineDetailModel
    {
         

        public List<Double> Location
        {
            get
            {
                var scenicLocations = Days.SelectMany(x => x.Scenics).Select(x => x.Location);
                if (scenicLocations.Count() > 0)
                { return scenicLocations.First(); }
                else {return new List<double>();}
            }
        }

        public string[] LineTags { get; set; }

        public string Description=>string.Concat(Days.Select(x=>x.Description));
        /// <summary>
        /// 行程概览
        /// </summary>
        public string TourSummary { get; set; }

        public IList<DayDetaill> Days { get; set; } = new List<DayDetaill>();
        /// <summary>
        /// 每日详情
        /// </summary>
        public class DayDetaill
        {
            public string Description { get;set;}
            public int DayIndex { get; set; }
            public List<Scenic> Scenics { get; set; } = new List<Scenic>();
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
                public List<double> Location { get; set; }
                public string Description { get;set;}
            }


        }
    }

}
