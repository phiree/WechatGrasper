using System;
using System.Collections.Generic;
using System.Text;
using TourInfo.Domain.Base;

namespace TourInfo.Domain.DomainModel.WHY
{
    public class WHYNews: VersionedEntity<string>
    {
        public override string id { get; set; }
        public string area2 { get; set; }
        public int areaCheckStatus { get; set; }
        public string areaId { get; set; }
        public string author { get; set; }
        public int cityCheckStatus { get; set; }
        public string content { get; set; }
        public DateTime createTime { get; set; }
        public bool grabStatus { get; set; }
     
        public ImageUrl imagepath { get; set; }
        public string informationCategoryId { get; set; }
        public int isTop { get; set; }
        public string noHtmlContent { get; set; }
        public int redCount { get; set; }
        public bool removed { get; set; }
        public int sort { get; set; }
        public DateTime startTime { get; set; }
        public string title { get; set; }
        public int type { get; set; }
        public DateTime updateTime { get; set; }
        public DateTime  endTime { get; set; }
        public string source { get; set; }
    }

    public class WHYNewsRoot
    {
        public int pageSize { get; set; }
        public bool sucflag { get; set; }
        public IList<WHYNews> list { get; set; }
        public int totalCount { get; set; }
    }
}
