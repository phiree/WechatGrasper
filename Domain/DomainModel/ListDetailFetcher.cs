using System;
using System.Collections.Generic;
using System.Text;
using TourInfo.Domain.Base;

namespace TourInfo.Domain.DomainModel
{
    /// <summary>
    /// 抓取 list-detail 类型的接口  的数据.
    /// </summary>
    public class ListDetailFetcher<TList,TDetail>
    { 
        string listUrl;
        
        string detailUrlFormater;
        IUrlFetcher urlFetcher;
        public ListDetailFetcher(HttpMethod listMethod,HttpMethod detailMethod)
        { 
             
            }
        

        
        }
    
    public interface ListDetailUrlBuilder
    { 
        string BuildDetailUrl();
        }
    public enum HttpMethod
    { 
        Get,
        Post
        }
}
