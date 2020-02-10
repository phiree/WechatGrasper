using System;
using System.Collections.Generic;
using System.Text;

namespace TourInfo.Domain.Application.WHY
{
    public class WHYListItem
    {
        public string areaName { get; set; }
        public int attentionCount { get; set; }
        public string hposter { get; set; }
        public int isfollw { get; set; }
        public string name { get; set; }
        public string orgId { get; set; }
        public int pageSize { get; set; }
        public bool sucflag { get; set; }
        public string summary { get; set; }
        public int totalCount { get; set; }
        public int venueCount { get; set; }
        public int volumeCount { get; set; }
    }

    public class WHYListResponse
    {
        public int pageSize { get; set; }
        public bool sucflag { get; set; }
        public int totalCount { get; set; }
        public List<WHYListItem> list { get; set; }
    }
}
