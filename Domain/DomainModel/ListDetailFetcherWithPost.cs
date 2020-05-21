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

    public class ListDetailFetcherWithPostList<ListData, DetailSummary, DetailWrapper, Detail, Key> : IListDetailFetcher
        where DetailSummary : IEntity<Key>
      where Detail : VersionedEntity<Key>
      where DetailWrapper : IDetailWrapper<Detail>
      where ListData : IListData<DetailSummary, Key>
    {

        IListUrlBuilder listUrlBuilder;
        IDetailUrlBuilder<Key> detailUrlBuilder;
        IUrlFetcher urlFetcher;
        IRepository<Detail, Key> repositoryDetailItem;
         
        IPagingData postData;

        InfoLocalizer<Detail,Key> infoLocalizer;
        string imageOriginalBaseUrl ;
        string version;

        public ListDetailFetcherWithPostList(IListUrlBuilder listUrlBuilder, IDetailUrlBuilder<Key> detailUrlBuilder, IUrlFetcher urlFetcher,
            IRepository<Detail, Key> repositoryDetailItem, IPagingData postData 
            ,string imageLocalSavePath,string imageClientPath, string imageOriginalBaseUrl,string version
            )
        {
            this.version=version;
           this.imageOriginalBaseUrl=imageOriginalBaseUrl;
            this.listUrlBuilder = listUrlBuilder;
            this.detailUrlBuilder = detailUrlBuilder;
            this.urlFetcher = urlFetcher;
            this.repositoryDetailItem = repositoryDetailItem;
            this.postData = postData;
            infoLocalizer=new InfoLocalizer<Detail, Key>(repositoryDetailItem,urlFetcher,imageLocalSavePath,imageClientPath);
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


               string detailResult;
                try{detailResult =  urlFetcher.FetchAsync(detailUrl).Result; }
                catch(Exception ex)
                { 
                  continue;
                    }
                 


                var detailWrapper = Newtonsoft.Json.JsonConvert.DeserializeObject<DetailWrapper>(detailResult,
                    new ImageUrlJsonConverter());
                var detail = detailWrapper.Detail;
                detail.id = itemSummary.id;
                bool isexisted;
                infoLocalizer.Localize(detail,imageOriginalBaseUrl,version,out isexisted);
                //repositoryDetailItem.InsertOrUpdate(detail);
            }
            FetchSync( pageIndex+1);
             
        }



    }
}
