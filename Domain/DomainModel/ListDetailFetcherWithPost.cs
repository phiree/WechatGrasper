using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using TourInfo.Domain.Base;

namespace TourInfo.Domain.DomainModel
{
    public interface IPagingData { 
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
         
        IPagingData postData;



        public ListDetailFetcherWithPostList(IListUrlBuilder listUrlBuilder, IDetailUrlBuilder<Key> detailUrlBuilder, IUrlFetcher urlFetcher,
            IRepository<Detail, Key> repositoryDetailItem, IPagingData postData 
            )
        {
           
            this.listUrlBuilder = listUrlBuilder;
            this.detailUrlBuilder = detailUrlBuilder;
            this.urlFetcher = urlFetcher;
            this.repositoryDetailItem = repositoryDetailItem;
            this.postData = postData;
        }

        public async void Fetch()
        {
            FetchSync(postData.PageIndex);
        }
        private async void  FetchSync(int pageIndex)
        {
            postData.PageIndex=pageIndex;
            string listUrl = listUrlBuilder.Build();
            string result = urlFetcher.PostWithJsonAsync(listUrl,Newtonsoft.Json.JsonConvert.SerializeObject(postData));
            var list = Newtonsoft.Json.JsonConvert.DeserializeObject<ListData>(result);
            if (list == null || list.Details.Count == 0) { return; }
            foreach (var itemSummary in list.Details)
            {
                string detailUrl = detailUrlBuilder.Build(itemSummary.id);
                 
               
                 var detailResult =await urlFetcher.FetchAsync(detailUrl);
                
                 
                var detailWrapper = Newtonsoft.Json.JsonConvert.DeserializeObject<DetailWrapper>(detailResult);
                var detail = detailWrapper.Detail;
                detail.id = itemSummary.id;
                repositoryDetailItem.InsertOrUpdate(detail);
            }
            FetchSync( pageIndex+1);
             
        }



    }
}
