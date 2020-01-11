using System;
using System.Collections.Generic;
using System.Text;
using TourInfo.Domain.Base;

namespace TourInfo.Domain.DomainModel
{
    /// <summary>
    /// 抓取一个接口的数据, 并判断其是否过期
    /// </summary>
    
    public class PagedDataFetcher<T,Key> where T:VersionedEntity<T>
    {
        IVersionedRepository<T,Key> versionedRepository;
        IUrlFetcher urlFetcher;
        int pageIndex,  pageSize;
        string baseUrl;
        Func<int,string> urlBuilder;
        bool needContinue=true;
        public IList<T> Fetch(string url,int pageIndex,int pageSize)
        {
            throw new NotImplementedException();
            while(needContinue)
            { 
             url= urlBuilder(pageIndex);
            string version = "";
            string fetchResult= urlFetcher.FetchAsync(url).Result;
            var result=Newtonsoft.Json.JsonConvert.DeserializeObject<IList<T>>(fetchResult);
                foreach(var t in result)
                { 
                 //  var existed= versionedRepository.Get(t.);
                    }
            }
        }
    }
}
