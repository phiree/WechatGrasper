using System;
using System.Collections.Generic;
using System.Text;
using TourInfo.Domain.Base;

namespace TourInfo.Domain.DomainModel.Video
{

    public class GraspeService : IGraspeService
    {

        IUrlFetcher urlFetcher;
        IVersionedRepository<Video, int> videoRepository;
        string baseUrl = "https://websiteapi.zjwist.com/webshow/webContentList?mid=213&checkstate=3&pagesize=10&pageindex=";

        public GraspeService(IUrlFetcher urlFetcher, IVersionedRepository<Video, int> videoRepository, string baseUrl)
        {
            this.urlFetcher = urlFetcher;
            this.videoRepository = videoRepository;
            this.baseUrl = baseUrl;
        }

        public void Graspe(string version)
        {
            bool needContinue = true;
            int pageIndex = 1;
            while (needContinue)
            {
                string result = urlFetcher.FetchAsync(baseUrl + pageIndex).Result;

                //转换错误,可能是因为json的Id是int类型

                var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject<RootObject>(result);
                if (jsonResult.data.results.Count == 0)
                {
                    needContinue = false;
                    continue;
                }
                foreach (var video in jsonResult.data.results)
                {

                    var existedVideo = videoRepository.Get(video.id);
                    if (existedVideo != null)
                    {
                        needContinue = false;
                        break;
                    }
                    video.Version=version;
                    videoRepository.Insert(video);
                }
                //遍历 如果已经发现已经存在，则 needContinue=false,并跳过。
                pageIndex++;

                //
            }
        }
    }
}
