using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using TourInfo.Domain.Base;

namespace TourInfo.Domain.DomainModel
{
    public interface IListData<DetailSummary, Key> where DetailSummary : IEntity<Key>
    {
        IList<DetailSummary> Details { get; }
    }

    public interface IDetailWrapper<TDetail>
    {
        TDetail Detail { get; }
    }

    public class PagingSetting
    {
        public bool NeedPaging { get; set; }
        public int StartIndex { get; set; }
    }
    /// <summary>
    /// 抓取 list-detail 类型的接口  的数据.
    /// </summary>
    public class ListDetailFetcher<ListData, DetailSummary, DetailWrapper, Detail, Key> : IListDetailFetcher where DetailSummary : Entity<Key>
        where Detail : VersionedEntity<Key>
        where DetailWrapper : IDetailWrapper<Detail>
        where ListData : IListData<DetailSummary, Key>
    {

        IListUrlBuilder listUrlBuilder;
        IDetailUrlBuilder<Key> detailUrlBuilder;
        IUrlFetcher urlFetcher;
        IRepository<Detail, Key> repositoryDetailItem;

        PagingSetting pagingSetting;
        InfoLocalizer<Detail, Key> infoLocalizer;
        string localSavedPath; string clientPath; string imageOriginalBaseUrl;
        string version;
        public ListDetailFetcher(IListUrlBuilder listUrlBuilder,
            IDetailUrlBuilder<Key> detailUrlBuilder, IUrlFetcher urlFetcher,
            IRepository<Detail, Key> repositoryDetailItem, PagingSetting pagingSetting, string localSavedPath, string clientPath, string imageOriginalBaseUrl, string version)
        {
            this.listUrlBuilder = listUrlBuilder;
            this.detailUrlBuilder = detailUrlBuilder;
            this.urlFetcher = urlFetcher;
            this.repositoryDetailItem = repositoryDetailItem;
            this.pagingSetting = pagingSetting;
            infoLocalizer = new InfoLocalizer<Detail, Key>(repositoryDetailItem, urlFetcher, localSavedPath, clientPath);
            this.localSavedPath = localSavedPath;
            this.clientPath = clientPath;
            this.version = version;
            this.imageOriginalBaseUrl = imageOriginalBaseUrl;
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
                string detailResult;
                try
                {
                    detailResult = urlFetcher.FetchAsync(detailUrl).Result;
                }
                catch (Exception ex)
                {

                    continue;
                }
                var detailWrapper = Newtonsoft.Json.JsonConvert.DeserializeObject<DetailWrapper>(detailResult, new ImageUrlJsonConverter());
                var detail = detailWrapper.Detail;
                detail.id = itemSummary.id;

                infoLocalizer.Localize(detail, imageOriginalBaseUrl, version, out bool isExisted);
                if (isExisted) { return; }

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
