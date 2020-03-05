using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using TourInfo.Domain.Base;

namespace TourInfo.Domain.DomainModel.WHY
{
    public class RapiSync : IRapiSync
    {
        IUrlFetcher urlFetcher;
        string rapiRootUrl;
        IRepository<WhyModel, string> repository;
        ILogger logger;

        public RapiSync(IUrlFetcher urlFetcher, string rapiRootUrl,
            ILoggerFactory loggerFactory, IRepository<WhyModel, string> repository)
        {
            this.urlFetcher = urlFetcher;
            this.rapiRootUrl = rapiRootUrl;
            this.repository = repository;
            this.logger = loggerFactory.CreateLogger<RapiSync>();
        }

        public int AddOrUpdate(RapiRequestModel request)
        {
            var apiResponse = JsonConvert.DeserializeObject<RapiResponse>(
                urlFetcher.PostWithJsonAsync(rapiRootUrl + "/zb/ccsave", JsonConvert.SerializeObject(request))
                );
            if (apiResponse.code != 0)
            {
                throw new Exception(apiResponse.msg);
            }
            return apiResponse.data;



        }

        public void Delete(int unitId)
        {
            var response = urlFetcher.FetchAsync(rapiRootUrl + "/zb/delete?unitid=" + unitId).Result;
            var apiResponse = JsonConvert.DeserializeObject<RapiResponse>(response
                );
            if (apiResponse.code != 0)
            {
                string err = $"rapi接口返回错误.unitId:{unitId}.response:[{response}]";
                logger.LogError(err);
                throw new Exception(err);
            }
        }
    }
    public class RapiRequestModel
    {
        public int unitid { get; set; }
        public string unitname { get; set; }

        public string address { get; set; }

        public string telephone { get; set; }

        /// <summary>
        /// 去除区号的号码.
        /// </summary>
        

        public string flagpic { get; set; }

        public string url { get; set; }

        public string desc { get; set; }

        public string gpsbd { get; set; }
        public string tagvalue
        {
            get
            {
                string[] rapiTags = new string[] { "图书馆", "博物馆", "文化馆", "文化站", "文化中心" };
                if (unitname.IndexOf("文化服务中心") >= 0)
                {
                    return "文化中心";
                }
                foreach (string tag in rapiTags)
                {
                    if (unitname.IndexOf(tag) >= 0)
                    {
                        return tag;
                    }

                }
                return "其他";
            }
        }

        }
        public class RapiResponse
        {
            public int code { get; set; }
            public string msg { get; set; }
            public int data { get; set; }
        }


    }
