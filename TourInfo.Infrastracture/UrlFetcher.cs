﻿ 
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
        
        public Task<string> FetchAsync(string url)
        {
            var webClient = new CookieAwareWebClient();
            return webClient.DownloadStringTaskAsync(url);
        }
        public Task FetchFile(string url,string fileName)
        {
            var webClient = new CookieAwareWebClient();
            webClient.DownloadFileAsync(new Uri(url), fileName);
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
    }

}

