using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;
using Newtonsoft;
using TourInfo.Domain.Base;
using TourInfo.Domain.DomainModel.Rapi;
using TourInfo.Domain.DomainModel.WHY;

namespace TourInfo.Domain.Application.WHY
{
    public class WHYApplication : IWHYApplication
    {
        IMD5Helper mD5Helper;
        IUrlFetcher urlFetcher;
        string listRootUrl;
        string detailRootUrl;
        
        IInfoLocalizer<WhyModel, string> infoLocalizer;
        string whyImageBaseUrl;
        string whyImageSavedPath;
        string whyImageClientPath;
        ILogger logger;
        ILoggerFactory loggerFactory;

        public WHYApplication(IMD5Helper mD5Helper,
            IUrlFetcher urlFetcher, 
            string listRootUrl, 
            string detailRootUrl, 
            
            IInfoLocalizer<WhyModel, string> infoLocalizer, 
            string whyImageBaseUrl, 
            string whyImageSavedPath, 
            string whyImageClientPath, ILoggerFactory loggerFactory)
        {
            this.mD5Helper = mD5Helper;
            this.urlFetcher = urlFetcher;
            this.listRootUrl = listRootUrl;
            this.detailRootUrl = detailRootUrl;
          
            this.infoLocalizer = infoLocalizer;
            this.whyImageBaseUrl = whyImageBaseUrl;
            this.whyImageSavedPath = whyImageSavedPath;
            this.whyImageClientPath = whyImageClientPath;
            this.loggerFactory = loggerFactory;
            this.logger = loggerFactory.CreateLogger<WHYApplication>();
        }

        public void Grasp(string dataVersion)
        {
            logger.LogInformation("开始抓取文化云数据");
            var result = urlFetcher.FetchAsync(listRootUrl).Result;

            var list = Newtonsoft.Json.JsonConvert.DeserializeObject<WHYListResponse>(result);
            foreach (var item in list.list)
            {
                string detailUrl = detailRootUrl + item.orgId;
                var detailResult = urlFetcher.FetchAsync(detailUrl).Result;

                var detail = Newtonsoft.Json.JsonConvert.DeserializeObject<WHYDetail>(detailResult
                    , new ImageUrlJsonConverter(), new LocationDoubleArrayJsonConverter(loggerFactory, true)
                    ).organizationT;
                bool isExistedInDb;
                infoLocalizer.Localize(detail, whyImageBaseUrl, whyImageSavedPath, whyImageClientPath, dataVersion, out isExistedInDb);
            }
            logger.LogInformation("文化云数据抓取完毕");
        }
    }
}
