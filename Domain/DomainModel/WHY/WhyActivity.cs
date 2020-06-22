using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TourInfo.Domain.Base;

namespace TourInfo.Domain.DomainModel.WHY
{
    public class WhyActivity:VersionedEntity<string>
    {
        public override string id { get; set; }
        public int accessNumber { get; set; }
        public DateTime actSessionSTime { get; set; }
        public string activityCategoryId { get; set; }
        public string ageTagId { get; set; }
        public string area { get; set; }
        public int areaCheckStatus { get; set; }
        public string areaId { get; set; }
        public int back { get; set; }
        public string cashType { get; set; }
        public int cityCheckStatus { get; set; }
        public int commentScope { get; set; }
        public int commentStatus { get; set; }
        public string content { get; set; }
        public DateTime createTime { get; set; }
        public string fPoster { get; set; }
        public bool grabStatus { get; set; }
        public int grade { get; set; }
        public int gradeNum { get; set; }
        public string hPoster { get; set; }
        public bool hasSession { get; set; }
     
        public int isTop { get; set; }
        public string keywords { get; set; }
        public int limit { get; set; }
        public int maxCount { get; set; }
        public string name { get; set; }
        [Newtonsoft.Json.JsonProperty("operator")]
        public string _operator { get; set; }
    public string organizationId { get; set; }
    public string organizationtypeId { get; set; }
    public int previewNumber { get; set; }
    public int price { get; set; }
    public int rate { get; set; }
    public DateTime recentHoldEndTime { get; set; }
    public DateTime recentHoldStartTime { get; set; }
    public bool removed { get; set; }
    public int reportNum { get; set; }
    public int reservationMode { get; set; }
    public int sort { get; set; }
    public int status { get; set; }
    public string summary { get; set; }
    public int ticketNumber { get; set; }
    public int type { get; set; }
    public DateTime updateTime { get; set; }

}
public class ActivityFrontLists
{
    public WhyActivity activityT { get; set; }
    public int collectionNum { get; set; }
    public string endTime { get; set; }
    public string fieldname { get; set; }
    public string startTime { get; set; }

}
public class WhyActivityWrapper:IDataWrapper<WhyActivity>
{
    public string msg { get; set; }
    public IList<ActivityFrontLists> activityFrontLists { get; set; }
    public int pageSize { get; set; }
    public bool sucflag { get; set; }
    public int totalCount { get; set; }
    public IEnumerable<WhyActivity> Details { get => activityFrontLists.Select(x=>x.activityT); }
    }


}
