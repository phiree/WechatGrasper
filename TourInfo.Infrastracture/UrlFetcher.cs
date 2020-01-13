
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
        public UrlFetcher(ILoggerFactory loggerFactory)
        {
            this.logger = loggerFactory.CreateLogger<UrlFetcher>();
        }
        public Task<string> FetchAsync(string url)
        {
            logger.LogInformation("开始异步抓取:" + url);
            var webClient = new CookieAwareWebClient();

            return webClient.DownloadStringTaskAsync(url);
            //logger.LogInformation("抓取结果:" + result);
        }
        public string PostWithJsonAsync(string url, string postJson)
        {
            logger.LogInformation($"开始异步抓取.url[{url}],jsonParam[{postJson}]");
            var cli = new WebClient();
            cli.Headers[HttpRequestHeader.ContentType] = "application/json";
            var response = cli.UploadString(url, postJson);
            logger.LogInformation("抓取结果" + response);
            return response;
        }
        public Task FetchFile(string url, string fileName)
        {
            logger.LogInformation($"开始抓取文件.url[{url}],filename6[{fileName}]");
            var webClient = new CookieAwareWebClient();
            if (!string.IsNullOrEmpty(url)
                )
            {
                try
                {
                    webClient.DownloadFile(new Uri(url), fileName);
                    logger.LogInformation($"抓取完成");
                }
                catch (System.Net.WebException webEx)
                {
                    logger.LogError($"Web请求失败.url:[{url}],ex:[{webEx.Message}]");
                }
            }
           
            return Task.FromResult(0);

            // return webClient.DownloadStringTaskAsync(url);
        }

        public async Task<string> FetchEWQYAsync(string url)
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
            foreach (var kvp in header)
            {
                webClient.Headers.Add(kvp.Key, kvp.Value);
            }
            var result = await webClient.DownloadStringTaskAsync(new Uri(url));
            return result;
        }
    }

}

