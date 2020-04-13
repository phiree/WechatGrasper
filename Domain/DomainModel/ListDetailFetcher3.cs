using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using TourInfo.Domain.Base;

namespace TourInfo.Domain.DomainModel
{
   
    
    
    /// <summary>
    /// 抓取 list-detail 类型的接口  的数据.
    /// </summary>
    public class ListDetailFetcher3<
        ListData, DetailSummary,
        DetailWrapper, Detail, Key,
        DetailWrappepperr
        > 
        : IListDetailFetcher 
        where DetailSummary : Entity<Key>
        where Detail : Entity<Key>
        where DetailWrapper : IDetailWrapper<Detail>
        where ListData : IListData<DetailSummary, Key>
    {

        IListUrlBuilder listUrlBuilder;
        IDetailUrlBuilder<Key> detailUrlBuilder;
        IUrlFetcher urlFetcher;
        IRepository<Detail, Key> repositoryDetailItem;

        PagingSetting pagingSetting;


        public ListDetailFetcher3(IListUrlBuilder listUrlBuilder,
            IDetailUrlBuilder<Key> detailUrlBuilder,
            IUrlFetcher urlFetcher,
            IRepository<Detail, Key> repositoryDetailItem,
            PagingSetting pagingSetting)
        {
            this.listUrlBuilder = listUrlBuilder;
            this.detailUrlBuilder = detailUrlBuilder;
            this.urlFetcher = urlFetcher;
            this.repositoryDetailItem = repositoryDetailItem;
            this.pagingSetting = pagingSetting;
        }

        public void Fetch()
        {
            Fetch(0);
        }
        private void Fetch(int pageIndex)
        {
            string listUrl = listUrlBuilder.Build();
            string result = urlFetcher.FetchAsync(listUrl).Result;
            var list = Newtonsoft.Json.JsonConvert.DeserializeObject<ListData>(result);
            if (list == null || list.Details.Count == 0) { return; }
            foreach (var itemSummary in list.Details)
            {
                string detailUrl = detailUrlBuilder.Build(itemSummary.id);
                string detailResult = urlFetcher.FetchAsync(detailUrl).Result;
                var detailWrapper = Newtonsoft.Json.JsonConvert.DeserializeObject<DetailWrapper>(detailResult);
                var detail = detailWrapper.Detail;
                detail.id = itemSummary.id;
                repositoryDetailItem.InsertOrUpdate(detail);
            }
            if (pagingSetting.NeedPaging)
            {
                Fetch(pageIndex + 1);
            }
        }

    }
 
    
}
