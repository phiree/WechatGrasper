using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using TourInfo.Domain.Base;

namespace TourInfo.Domain.DomainModel
{
    public interface IPostData { 
        int PageIndex { get;set;}
        int PageSize { get;set;}
        }

    public class ListDetailFetcherWithPostList<ListData, DetailSummary, DetailWrapper, Detail, Key> : IListDetailFetcher where DetailSummary : Entity<Key>
      where Detail : Entity<Key>
      where DetailWrapper : IDetailWrapper<Detail>
      where ListData : IListData<DetailSummary, Key>
    {

        IListUrlBuilder listUrlBuilder;
        IDetailUrlBuilder<Key> detailUrlBuilder;
        IUrlFetcher urlFetcher;
        IRepository<Detail, Key> repositoryDetailItem;
        ILogger<ListDetailFetcherWithPostList<ListData, DetailSummary, DetailWrapper, Detail, Key>>  logger;
        IPostData postData;



        public ListDetailFetcherWithPostList(IListUrlBuilder listUrlBuilder, IDetailUrlBuilder<Key> detailUrlBuilder, IUrlFetcher urlFetcher,
            IRepository<Detail, Key> repositoryDetailItem, IPostData postData ,
            ILogger<ListDetailFetcherWithPostList<ListData, DetailSummary, DetailWrapper, Detail, Key>>  logger)
        {
            this.logger=logger  ;
            this.listUrlBuilder = listUrlBuilder;
            this.detailUrlBuilder = detailUrlBuilder;
            this.urlFetcher = urlFetcher;
            this.repositoryDetailItem = repositoryDetailItem;
            this.postData = postData;
        }

        public void Fetch()
        {
            Fetch(postData.PageIndex);
        }
        private void Fetch(int pageIndex)
        {
            postData.PageIndex=pageIndex;
            string listUrl = listUrlBuilder.Build();
            string result = urlFetcher.PostWithJsonAsync(listUrl,Newtonsoft.Json.JsonConvert.SerializeObject(postData));
            var list = Newtonsoft.Json.JsonConvert.DeserializeObject<ListData>(result);
            if (list == null || list.Details.Count == 0) { return; }
            foreach (var itemSummary in list.Details)
            {
                string detailUrl = detailUrlBuilder.Build(itemSummary.id);
                string detailResult=string.Empty;
                try { 
                  detailResult = urlFetcher.FetchAsync(detailUrl).Result;
                }
                catch(Exception ex) { 
                    logger.LogError($"获取美食详情失败.[{detailUrl}]");
                    continue;
                    }
                var detailWrapper = Newtonsoft.Json.JsonConvert.DeserializeObject<DetailWrapper>(detailResult,new ImageUrlJsonConverter());
                var detail = detailWrapper.Detail;
                detail.id = itemSummary.id;
                repositoryDetailItem.InsertOrUpdate(detail);
            }
                Fetch( pageIndex+1);
             
        }



    }
}
