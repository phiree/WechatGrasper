using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TourInfo.Application.Api.Models
{
    public class LineListModel
    {
        public string Id { get;set;}
        public string Name { get;set;}
        public string ImageUrl { get;set;}
      
        /// <summary>
        /// 包含的景区的标签
        /// </summary>
        public string[] ScenicTags { get;set;}
        /// <summary>
        /// 路线的标签
        /// </summary>
        public string[] LineTags { get;set;}
        /// <summary>
        /// 游玩天数
        /// </summary>
        public int DaysAmount { get;set;}
        /// <summary>
        /// 包含景区数量
        /// </summary>
        public int ScenicsAmount { get;set;}
    }
}
