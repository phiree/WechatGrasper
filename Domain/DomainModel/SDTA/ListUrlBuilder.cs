using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace TourInfo.Domain.DomainModel.SDTA
{
    public class LineListUrlBuilder : IListUrlBuilder
    {
        string lineListUrl = "https://www.sdta.cn/json/lines/list_370300.json?channel=zibo";

        public string Build()
        {
            return lineListUrl;
        }
    }
    public class CityGuideListUrlBuilder : IListUrlBuilder
    {
        string cityGuideListUrl = "https://www.sdta.cn/json/city-guide/370300.json?channel=zibo";

        public string Build()
        {
            return cityGuideListUrl;
        }
    }
    public class FoodListUrlBuilder : IListUrlBuilder
    {
        string cityGuideListUrl = "https://www.sdta.cn/searches/snack/snack/_search";

        public string Build()
        {
            return cityGuideListUrl;
        }
    }
    /// <summary>
    /// 详细资料 url 构建器
    /// </summary>
    /// <typeparam name="DetailKey"></typeparam>
    public interface IDetailHttpRequestMessageCreator<DetailSummary>  
    {
        HttpRequestMessage Create(DetailSummary detailKey);
    }
    public abstract class AbsHttpRequestMessageCreator<DetailSummary> : IDetailHttpRequestMessageCreator<DetailSummary >
    {
        public AbsHttpRequestMessageCreator(string url)
        { this.Url = url; }
        protected string Url { get; }

        public abstract HttpRequestMessage Create(DetailSummary detailSummary);
    }
    
    public class LineDetailHttpRequestMessage: AbsHttpRequestMessageCreator<Lines2>
    {
        public LineDetailHttpRequestMessage(string url) : base(url) { }

        public override HttpRequestMessage Create(Lines2 line2)
        {
            string detailUrl=Url+ line2.id;

            var request = new HttpRequestMessage(HttpMethod.Get, Url);

            return request;

        }
    }
    public class LineDetailScenicHttpRequestMessage  : AbsHttpRequestMessageCreator<LineDetail2.Day.Place>
    {
       
        public LineDetailScenicHttpRequestMessage(string url ):base(url)
        {
           
        }

        public override HttpRequestMessage Create(LineDetail2.Day.Place place )
        {
            var postData = new { ids=new string[]{ place.type+"_"+place.id } };

            var request = new HttpRequestMessage(HttpMethod.Post, Url);

            var httpContent = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(postData));
            request.Headers.Add("ContentType", "application/json");
            return request;

        }
    }
}
