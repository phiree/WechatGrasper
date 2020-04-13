
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using TourInfo.Domain;
using TourInfo.Infrastracture;

namespace TourInfo.Infrastracture
{
    public class UrlFetcher : IUrlFetcher
    {
        ILogger<UrlFetcher> logger;
        IHttpClientFactory httpClientFactory;
        public UrlFetcher(IHttpClientFactory httpClientFactory, ILoggerFactory loggerFactory)
        {
            this.httpClientFactory=httpClientFactory;
            this.logger = loggerFactory.CreateLogger<UrlFetcher>();
        }
        public Task<string> FetchAsync(string url)
        {
            logger.LogInformation("开始异步抓取:" + url);
            var webClient = new CookieAwareWebClient();

            return webClient.DownloadStringTaskAsync(url);
            //logger.LogInformation("抓取结果:" + result);
        }
        public Task<string> FetchAsync2(string url)
        {
            logger.LogInformation("开始异步抓取:" + url);
            var webClient = new HttpClient();
            var webClient2 = new CookieAwareWebClient();
            webClient2.Headers.Add(HttpRequestHeader.UserAgent, "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/80.0.3987.149 Safari/537.36");

            return webClient2.DownloadStringTaskAsync(url);
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

        public async Task<string> FetchAsync(HttpRequestMessage request)
        {
            logger.LogInformation($"开始异步抓取.url[{request.RequestUri}]");
            var cli = httpClientFactory.CreateClient();
            var response = await cli.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                logger.LogError($"抓取失败.statuscode为[{response.StatusCode}]");
                return string.Empty;
            }
        }
    }
    public class Fetcher2 : IUrlFetcher
    {
        ILogger<Fetcher2> logger;
        IHttpClientFactory httpClientFactory;
        
        public Fetcher2(  IHttpClientFactory httpClientFactory, ILogger<Fetcher2> logger)
        {
            this.httpClientFactory = httpClientFactory;
            
            this.logger = logger;
        }
        public async Task<string> FetchAsync(HttpRequestMessage request) {
            logger.LogInformation($"开始异步抓取.url[{request.RequestUri}],jsonParam[{request.Content.ReadAsStringAsync().Result}]");
            var cli = httpClientFactory.CreateClient();
            var response = await cli.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                logger.LogError($"抓取失败.statuscode为[{response.StatusCode}]");
                return string.Empty;
            }
        }
        public async Task<string> FetchAsync(string url)
        {
            logger.LogInformation($"开始异步抓取.url[{url}]" );
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add(HttpRequestHeader.ContentType.ToString(), "application/json");
            var cli = httpClientFactory.CreateClient();
            var response = await cli.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                logger.LogError($"抓取失败.statuscode为[{response.StatusCode}]");
                return string.Empty;
            }

        }

        public Task<string> FetchAsync2(string url)
        {
            throw new NotImplementedException();
        }

        public Task<string> FetchEWQYAsync(string url)
        {
            throw new NotImplementedException();
        }

        public Task FetchFile(string url, string fileName)
        {
            throw new NotImplementedException();
        }

        public Task<string> FetchWithHeaderAsync(string url, IDictionary<string, string> header)
        {
            throw new NotImplementedException();
        }

        public string PostWithJsonAsync(string url, string postJson)
        {
            throw new NotImplementedException();
        }
    }
}

