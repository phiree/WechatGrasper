﻿using System;
using System.Collections.Generic;
using System.Text;
using TourInfo.Domain.Base;

namespace TourInfo.Domain.DomainModel.ZiBoWechatNews
{
    public class Grasper : IGrasper
    {
        IUrlFetcher fetcher;
        IVersionedRepository<ZiBoWechatNews, string> repository;
        IMD5Helper mD5Helper;
        string baseUrl = "";
        int pageSize = 10;

        public Grasper(IUrlFetcher fetcher, IVersionedRepository<ZiBoWechatNews, string> repository, IMD5Helper mD5Helper, string baseUrl)
        {
            this.fetcher = fetcher;
            this.repository = repository;
            this.mD5Helper = mD5Helper;
            this.baseUrl = baseUrl;
        }

        //如何判定结束
        //如何判定是否更新
        public void GraspeWithPage(int pageIndex, string dataVersion)
        {


            string result = fetcher.FetchAsync(BuildUrl(pageIndex)).Result;
            var data = Newtonsoft.Json.JsonConvert.DeserializeObject<ZiBoWechatNewsApiResponse>(result).data;
            foreach (var news in data)
            {
                if(news.pubtime<new DateTime(2020, 1, 1)) { return;}
                string calculatedFingerPrint = news.CalculateFingerprint(mD5Helper);
                news.UpdateVersion(calculatedFingerPrint, dataVersion);
                var existes = repository.FindByFingerPrint(calculatedFingerPrint);
                if (existes.Count >= 1)
                {
                    return;
                }
                repository.Insert(news);
               
            }
            GraspeWithPage(pageIndex+1, dataVersion);

        }
        private string BuildUrl(int pageIndex)
        {
            return baseUrl + $"?pageindex={pageIndex}&pagesize={pageSize}";
        }
    }



}