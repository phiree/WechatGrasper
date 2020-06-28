using System;
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
        IInfoLocalizer<ZiBoWechatNews,string> infoLocalizer;
        string baseUrl = "";
        int pageSize = 10;

        public Grasper(IUrlFetcher fetcher,
            IVersionedRepository<ZiBoWechatNews, string> repository,
            IMD5Helper mD5Helper, string baseUrl,string localSavedPath,string imageClientPath)
        {
            this.fetcher = fetcher;
            this.repository = repository;
            this.mD5Helper = mD5Helper;
            this.baseUrl = baseUrl;
            infoLocalizer=new  InfoLocalizer<ZiBoWechatNews,string>
                (repository,fetcher,localSavedPath,imageClientPath);
        }

        //如何判定结束
        //如何判定是否更新
        public void GraspeWithPage(int pageIndex, string dataVersion)
        {


            string result = fetcher.FetchAsync(BuildUrl(pageIndex)).Result;
            var data = Newtonsoft.Json.JsonConvert.DeserializeObject<ZiBoWechatNewsApiResponse>(result,new ImageUrlJsonConverter()).data;
            foreach (var news in data)
            {
                if (news.pubtime < new DateTime(2020, 1, 1)) { return; }
                //news.content =new ImageUrlsInText( fetcher.FetchAsync(news.url).Result);
                string calculatedFingerPrint = news.CalculateFingerprint(mD5Helper);
                news.UpdateVersion(calculatedFingerPrint, dataVersion);
                var existes = repository.Get(news.id);
                if (existes!=null)
                {
                    return;
                }
                bool isExistedInDb;
                infoLocalizer.Localize(news,string.Empty,dataVersion,out isExistedInDb);
               // repository.Insert(news);
               
            }
            GraspeWithPage(pageIndex+1, dataVersion);

        }
        private string BuildUrl(int pageIndex)
        {
            return baseUrl + $"?pageindex={pageIndex}&pagesize={pageSize}";
        }
    }



}
