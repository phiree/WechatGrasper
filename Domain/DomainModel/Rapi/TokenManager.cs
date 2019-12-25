using System;
using System.Collections.Generic;
using System.Text;

namespace TourInfo.Domain.DomainModel.Rapi
{
   
    public class TokenManager
    {
        string appkey, appsecret, tokenUrl;
        IUrlFetcher urlFetcher;
        public string GetToken()
        {
            try
            {
                string result = urlFetcher.PostWithJsonAsync(tokenUrl, @"{}");
            }
            catch (Exception ex)
            {

                throw new Exception("Token 获取失败"+ex.ToString());
            }
           // return result;
        }
    }
}
