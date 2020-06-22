using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections;
using System.Collections.Generic;
using TourInfo.Domain.Base;

namespace TourInfo.Domain.DomainModel
{
    public interface IListDetailFetcher
    {
        void Fetch();
    }

    public interface IRequestWithPaging
    {
        int PageIndex { get; set; }
        int PageSize { get; set; }
        IList<Parameter> CreateParameters();
        IRequestWithPaging BuildNextPageRequest();
    }
    public interface IData { }
    public interface IDataWrapper<T>
    {
        IEnumerable<T> Details { get; }
    }
    public class FetchWithPaging<TWrapper, T, Key> 
        where TWrapper : IDataWrapper<T>
        where T:VersionedEntity<Key>
    {

        string url;
        string imageBaseUrl;

        Func<bool> terminalPoint;
        IInfoLocalizer<T, Key> infoLocalizer;

        Method method;
        public FetchWithPaging(string url, string imageBaseUrl, Func<bool> terminalPoint, IInfoLocalizer<T, Key> infoLocalizer, string method)
        {
            this.url = url;
            this.imageBaseUrl = imageBaseUrl;
            this.terminalPoint = terminalPoint;
            this.infoLocalizer = infoLocalizer;
            this.method = (Method)Enum.Parse(typeof(Method), method);
        }

        public void GraspNews(string version, IRequestWithPaging requstData)
        {
            var client = new RestClient(url);
            var parameters = requstData.CreateParameters();
            var request = new RestRequest("");
            foreach (var p in parameters)
            {
                request.AddParameter(p);
            }

            var response = client.Execute(request, method);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var responseData = JsonConvert.DeserializeObject<TWrapper>(response.Content,
                    new UnixTimestampJsonconverter(), new ImageUrlJsonConverter());
                foreach (var news in responseData.Details)
                {
                    if (terminalPoint()) { return; }

                    infoLocalizer.Localize(news, imageBaseUrl, version, out bool isExisted);
                    if (isExisted) { return; }
                }
            }
            GraspNews(version, requstData.BuildNextPageRequest());

        }
    }
}