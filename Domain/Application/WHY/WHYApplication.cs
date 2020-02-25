using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using CacheManager.Core;
using Microsoft.Extensions.Logging;
using Newtonsoft;
using TourInfo.Domain.Base;
using TourInfo.Domain.DomainModel.Rapi;
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
        IListMerger<WhyModel, string> listMerger;
        IRapiSync rapiSync;
        IImageLocalizer imageLocalizer;
        
        public WHYApplication(IMD5Helper mD5Helper, IUrlFetcher urlFetcher,
            string listRootUrl, string detailRootUrl,
            string whyImageBaseUrl, string whyImageSavedPath, string whyImageClientPath,
            ILoggerFactory loggerFactory, IMapper mapper, IRepository<WhyModel, string> repository,
            IListMerger<WhyModel, string> listMerger, IRapiSync rapiSync)
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
            this.listMerger = listMerger;
            this.rapiSync = rapiSync;
        }

        public void Grasp(string dataVersion)
        {
            logger.LogInformation("开始抓取文化云数据");
            var dataInResponse =GetDetails();


             
            var dataInDb = repository.GetAll();
            var mergeResult = listMerger.Merge(dataInDb, dataInResponse);
            foreach (var resultModel in mergeResult)
            {
                var rapiRequestModel = mapper.Map<RapiRequestModel>(resultModel.Item);
                switch (resultModel.MergeResultStatus)
                {
                    case MergeResultStatus.Updated:
                    case MergeResultStatus.Added:
                        string mdUrl =  imageLocalizer.Localize(whyImageBaseUrl + resultModel.Item.hposter.OriginalUrl);
                        resultModel.Item.hposter.UpdateLocalizedUrl(mdUrl);
                      //  int rapiId = rapiSync.AddOrUpdate(rapiRequestModel);
                       // resultModel.Item.RapiId = rapiId;
                        if (resultModel.MergeResultStatus == MergeResultStatus.Added)
                        {
                            repository.Insert(resultModel.Item);
                        }
                        else
                        {
                           var dataToUpdate= dataInDb.Single(x=>x.id==resultModel.Item.id);
                            dataToUpdate.hposter.UpdateLocalizedUrl(mdUrl);
                            repository.Update(dataToUpdate);
                        }
                        break;

                    case MergeResultStatus.Deleted:
                        repository.Delete(resultModel.Item);
                        rapiSync.Delete(resultModel.Item.RapiId);
                        break;
                    case MergeResultStatus.NoChanged: break;

                }




                switch (resultModel.MergeResultStatus)
                {
                    case MergeResultStatus.Added:
                    //新增数据
                    //调用rapi保存接口(id传0)
                    case MergeResultStatus.Updated:


                        break;

                    case MergeResultStatus.Deleted:

                        //删除数据
                        //调用rapi删除接口
                        break;
                    case MergeResultStatus.NoChanged:
                        //跳过
                        break;
                }

            }
            logger.LogInformation("文化云数据抓取完毕");
        }

        private IList<WhyModel> GetDetails()
        {
            //本地数据测试
            string cachevalue = System.IO.File.ReadAllText("WHYdetailResponseFileCache.txt");

            return Newtonsoft.Json.JsonConvert.DeserializeObject<IList<WhyModel>>(cachevalue);


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
