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
    public interface IHttpRequestMessageCreator
    {

        HttpRequestMessage Create(string url, HttpMethod method);
    }
    public class HttpRequestMessageWithGet
    { }
    public class LineHttpRequestMessageCreator : IHttpRequestMessageCreator
    {

        public HttpRequestMessage Create(string url, HttpMethod method)
        {
            var request = new HttpRequestMessage(method, url);

            return request;

        }
    }
    public class LineDetailHttpRequestMessageCreator : IHttpRequestMessageCreator
    {
        string content = string.Empty;
        public LineDetailHttpRequestMessageCreator(string content)
        {
            this.content = content;
        }
        public HttpRequestMessage Create(string url, HttpMethod method)
        {
            var request = new HttpRequestMessage(method, url);

            var httpContent = new StringContent(content);
            request.Headers.Add("ContentType", "application/json");
            return request;

        }
    }
    public class LineDetailScenicHttpRequestMessageCreator : IHttpRequestMessageCreator
    {
        string content = string.Empty;
        public LineDetailScenicHttpRequestMessageCreator(string content)
        {
            this.content = content;
        }
        public HttpRequestMessage Create(string url, HttpMethod method)
        {
            var request = new HttpRequestMessage(method, url);

            var httpContent = new StringContent(content);
            request.Headers.Add("ContentType", "application/json");
            return request;

        }
    }
}
