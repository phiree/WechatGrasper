using System;
using System.Collections.Generic;
using System.Text;
using TourInfo.Domain.Base;

namespace TourInfo.Domain.DomainModel
{
    public interface IListData<DetailSummary,Key> where DetailSummary:Entity<Key>
    {
        IList<DetailSummary> Details { get; set; }
    }
    

    public class PagingSetting
    {
        public bool NeedPaging { get; set; }
        public int StartIndex { get; set; }
    }
    /// <summary>
    /// 抓取 list-detail 类型的接口  的数据.
    /// </summary>
    public class ListDetailFetcher<ListData,DetailSummary, Detail, Key> 
        where DetailSummary:Entity<Key>
        where Detail:Entity<Key> 
        where ListData:IListData<DetailSummary,Key>
    {

        IListUrlBuilder listUrlBuilder;
        IDetailUrlBuilder<Key> detailUrlBuilder;
        IUrlFetcher urlFetcher;
        IRepository<Detail, Key> repositoryDetailItem;

        PagingSetting pagingSetting;
        

        public ListDetailFetcher(IListUrlBuilder listUrlBuilder, IDetailUrlBuilder<Key> detailUrlBuilder, IUrlFetcher urlFetcher,
            IRepository<Detail, Key> repositoryDetailItem, PagingSetting pagingSetting)
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
            if (list==null|| list.Details.Count == 0) { return; }
            foreach (var itemSummary in list.Details)
            {
                string detailUrl = detailUrlBuilder.Build(itemSummary.id);
                string detailResult = urlFetcher.FetchAsync(detailUrl).Result;
                var detail = Newtonsoft.Json.JsonConvert.DeserializeObject<Detail>(detailResult);
                detail.id=itemSummary.id;
                repositoryDetailItem.InsertOrUpdate(detail);
            }
            if (pagingSetting.NeedPaging)
            {
                Fetch(pageIndex + 1);
            }
        }



    }
    public interface IListUrlBuilder
    {

        string Build();
    }
    public interface IDetailUrlBuilder<Key>
    {
        string Build(Key key);
    }
    
}
