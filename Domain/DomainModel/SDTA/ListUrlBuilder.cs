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
    public class SpecialProductListUrlBuilder : IListUrlBuilder
    {
        string specialProductListUrl = "https://www.sdta.cn/searches/commodity/commodity/_search";

        public string Build()
        {
            return specialProductListUrl;
        }
    }
 
    public class FoodListUrlBuilder : IListUrlBuilder
    {
        string foodListUrl = "https://www.sdta.cn/searches/snack/snack/_search";

        public string Build()
        {
            return foodListUrl;
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
 
    public class LineDetailHttpRequestMessageCreator: IDetailHttpRequestMessageCreator<Lines>
    {
      
        public   HttpRequestMessage Create(Lines line2)
        {
            string detailUrl = $"https://www.sdta.cn/json/lines/{line2.id}.json?channel=zibo";
            var request = new HttpRequestMessage(HttpMethod.Get, detailUrl);
            return request;
        }
    }
    public class LineDetailScenicHttpRequestMessageCreator : IDetailHttpRequestMessageCreator<LineDetail.Day.Place>
    {
       
        

        public   HttpRequestMessage Create(LineDetail.Day.Place place )
        {
            string url= "https://www.sdta.cn/searches/element/ele/_mget";

            var postData = new { ids=new string[]{ place.type+"_"+place.id } };

            var request = new HttpRequestMessage(HttpMethod.Post, url);

            var httpContent = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(postData));
            request.Headers.Add("ContentType", "application/json");
            request.Content=httpContent;
            return request;

        }
    }
}
