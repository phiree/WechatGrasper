using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using CacheManager.Core;
using Microsoft.Extensions.Logging;
using Newtonsoft;
using TourInfo.Domain.Base;
using TourInfo.Domain.DomainModel ;
using TourInfo.Domain.DomainModel.WHY;
using System.Linq;
namespace TourInfo.Domain.Application.WHY
{
    public class WHYApplication : IWHYApplication
    {
        IMD5Helper mD5Helper;
        IUrlFetcher urlFetcher;
        string listRootUrl;
        string detailRootUrl;

        string whyImageBaseUrl;

        ILogger logger;

        ILoggerFactory loggerFactory;
        IMapper mapper;
        IRepository<WhyModel, string> repository;
        IWhyModelMerger whyMerger;

        IRapiSync rapiSync;
        IImageLocalizer imageLocalizer;

        public WHYApplication(IMD5Helper mD5Helper, IUrlFetcher urlFetcher,
            string listRootUrl, string detailRootUrl,
            string whyImageBaseUrl, string whyImageSavedPath, string whyImageClientPath,
            ILoggerFactory loggerFactory, IMapper mapper, IRepository<WhyModel, string> repository,
            IWhyModelMerger whyMerger, IRapiSync rapiSync)
        {
            this.imageLocalizer = new ImageLocalizerToMd(urlFetcher);
            this.mD5Helper = mD5Helper;
            this.urlFetcher = urlFetcher;
            this.listRootUrl = listRootUrl;
            this.detailRootUrl = detailRootUrl;
            this.whyImageBaseUrl = whyImageBaseUrl;

            this.logger = loggerFactory.CreateLogger<WHYApplication>();
            this.loggerFactory = loggerFactory;
            this.mapper = mapper;
            this.repository = repository;
            this.whyMerger = whyMerger;
            this.rapiSync = rapiSync;
        }

        public void Grasp(string dataVersion)
        {
            logger.LogInformation("开始抓取文化云数据");
            var dataInResponse = GetDetails();
            var dataInDb = repository.GetAll();
            var mergeResult = whyMerger.Merge(dataInDb, dataInResponse);
            foreach (var resultModel in mergeResult)
            {

                switch (resultModel.MergeResultStatus)
                {
                    case MergeResultStatus.Updated:
                    case MergeResultStatus.Added:

                        //是否上传图片到mdapi
                        if (resultModel.MergeResultStatus == MergeResultStatus.Added || resultModel.ImageChanged)
                        {
                            try
                            {

                                string mdUrl = imageLocalizer.Localize(whyImageBaseUrl + resultModel.Item.hposter.OriginalUrl);
                                resultModel.Item.hposter.UpdateLocalizedUrl(mdUrl);
                            }
                            catch (Exception ex)
                            {
                                logger.LogWarning($"图片上传到md失败.id:[{resultModel.Item.id}],imageurl:[{resultModel.Item.hposter.OriginalUrl}]");
                            }
                        }

                        var rapiRequestModel = mapper.Map<RapiRequestModel>(resultModel.Item);
                        int rapiId = rapiSync.AddOrUpdate(rapiRequestModel);
                        resultModel.Item.RapiId = rapiId;
                        if (resultModel.MergeResultStatus == MergeResultStatus.Added)
                        {
                            repository.Insert(resultModel.Item);
                        }
                        else
                        {
                            var dataToUpdate = dataInDb.Single(x => x.id == resultModel.Item.id);
                           dataToUpdate.UpdateDbModelFromApi(resultModel.Item);
;
                            repository.Update(dataToUpdate);
                        }
                        break;

                    case MergeResultStatus.Deleted:
                        repository.Delete(resultModel.Item);
                        rapiSync.Delete(resultModel.Item.RapiId);
                        break;
                    case MergeResultStatus.NoChanged: break;

                }


            }
            logger.LogInformation("文化云数据抓取完毕");
        }

        private IList<WhyModel> GetDetails()
        {
            //本地数据测试
            //string cachevalue = System.IO.File.ReadAllText("WHYdetailResponseFileCache.txt");

            //return Newtonsoft.Json.JsonConvert.DeserializeObject<IList<WhyModel>>(cachevalue);


            var dataInResponse = new List<WhyModel>();

            var result = urlFetcher.FetchAsync(listRootUrl).Result;
            var list = Newtonsoft.Json.JsonConvert.DeserializeObject<WHYListResponse>(result);
            //数据库数据

            //当前返回数据

            foreach (var item in list.list)
            {
                System.Threading.Thread.Sleep(400);
                string detailUrl = detailRootUrl + item.orgId;
                var detailResult = urlFetcher.FetchAsync(detailUrl).Result;

                var detail = Newtonsoft.Json.JsonConvert.DeserializeObject<WHYDetail>(detailResult
                    , new ImageUrlJsonConverter(), new LocationDoubleArrayJsonConverter(loggerFactory, true)
                    ).organizationT;
                dataInResponse.Add(mapper.Map<WhyModel>(detail));
            }
            return dataInResponse;
        }

    }
}
