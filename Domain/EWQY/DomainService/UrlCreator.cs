﻿using System.Collections.Generic;

namespace TourInfo.Domain.EWQY
{
    public class UrlCreator  
    {
        readonly string baseUrl = "https://w.culturedata.com.cn/";
        /// <summary>
        /// 
        /// </summary>
        readonly IDictionary<string, string> PagedDetailUrlMap = new Dictionary<string, string> {
            {"venue/findVenueList.action","venue/findVenueDetail.action" },
            {"company/findCompanyList.action","company/findCompanyDetail.action" },
            
            {"activity/findRegionActivityList.action","activity/findActivityDetail.action" }};
        public IList<string> CreateSeeds()
        {
            return new List<string> { "https://w.culturedata.com.cn/activity/findRegionActivityList.action?type=0&gotCount=0&number=5&regionCode=370300" };
        }
        public string CreatePagedUrl(string pagedBaseUrl, int pageIndex, int pageSize, PlaceType? type = null, int? order = null)
        {
            string typeParam = type.HasValue ? $"&type={(int)type.Value}" : string.Empty;
            string orderParam = order.HasValue ? $"&order={(int)order.Value}" : string.Empty;

            return $"{baseUrl}{pagedBaseUrl}?gotCount={pageIndex}&number={pageSize}&regionCode=370300{typeParam}{orderParam}";
        }
        public string CreateDetailUrl(string pagedBaseUrl, string detailId)
        {

            return $"{baseUrl}{PagedDetailUrlMap[pagedBaseUrl]}?id={detailId}";
        }
    }

}

