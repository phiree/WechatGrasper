using System;
using System.Collections.Generic;
using System.Text;
using TourInfo.Domain.Base;

namespace TourInfo.Domain.DomainModel
{
    /// <summary>
    /// 抓取一个接口的数据, 判断其是否过期
    /// </summary>
    
    public class SimpleDataFetcher<T,Key>
    {
        IVersionedRepository<T,Key> versionedRepository;
        IUrlFetcher urlFetcher;
        public IList<T> Fetch(string url)
        {
            string version = "";
            string fetchResult= urlFetcher.FetchAsync(url).Result;
            
        }
    }
}
