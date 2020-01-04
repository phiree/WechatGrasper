
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using TourInfo.Domain;
using TourInfo.Infrastracture;

namespace TourInfo.Infrastracture
{
    public class UrlFetcher : IUrlFetcher
    {
        ILogger<UrlFetcher> logger;
        public UrlFetcher(ILogger<UrlFetcher> logger)
        { 
            this.logger=logger;
            }
        public Task<string> FetchAsync(string url)
        {
            var webClient = new CookieAwareWebClient();
            
            return webClient.DownloadStringTaskAsync(url);
        }
        public string PostWithJsonAsync(string url,string postJson)
        {
            var cli = new WebClient();
            cli.Headers[HttpRequestHeader.ContentType] = "application/json";
            var response = cli.UploadString(url, postJson);
            return response;
        }
        public Task FetchFile(string url,string fileName)
        {
            var webClient = new CookieAwareWebClient();
            if(!string.IsNullOrEmpty(url)
                )
            {
                try { 
                webClient.DownloadFile(new Uri(url), fileName) ; 
                    }
                catch(System.Net.WebException webEx)
                { 
                    logger.LogError($"Web请求失败.url:[{url}],ex:[{webEx.Message}]");
                    }
                }

            return Task.FromResult(0);
        
           // return webClient.DownloadStringTaskAsync(url);
        }

        public async Task<string> FetchEWQYAsync(string url )
        {
            var webClient = new CookieAwareWebClient();
            var cookiesContainer = new CookieContainer();
            cookiesContainer.Add(new Cookie("JSESSIONID", "2AF06A3225C7E4D578C6C2749C79FAF8", "/", "w.culturedata.com.cn"));
            cookiesContainer.Add(new Cookie("showTip", "true", "/", "w.culturedata.com.cn"));
            webClient.CookieContainer = cookiesContainer;
            var result = await webClient.DownloadStringTaskAsync(new Uri(url));

            return result;
        }

        public async Task<string> FetchWithHeaderAsync(string url, IDictionary<string, string> header)
        {
            var webClient = new CookieAwareWebClient();
            foreach(var kvp in header)
            {
                webClient.Headers.Add(kvp.Key, kvp.Value);
            }
            var result = await webClient.DownloadStringTaskAsync(new Uri(url));
            return result;
        }
    }

}

