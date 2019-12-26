using System;
using System.Collections.Generic;
using System.Text;

namespace TourInfo.Domain.DomainModel.Rapi
{

    public class TokenManager : ITokenManager
    {
        string appid, appsecret, tokenurl;
        IUrlFetcher urlFetcher;

        public TokenManager(string appid, string appsecret, string tokenurl, IUrlFetcher urlFetcher)
        {
            this.appid = appid;
            this.appsecret = appsecret;
            this.tokenurl = tokenurl;
            this.urlFetcher = urlFetcher;
        }

        public string GetToken()
        {
            try
            {
                string result = urlFetcher.PostWithJsonAsync(tokenurl
                    , Newtonsoft.Json.JsonConvert.SerializeObject(new { appid = appid, appsecret = appsecret }));
                var tokenResult = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(result);
                if (tokenResult.code != 0)
                {
                    throw new Exception("token 返回错误。" + tokenResult.message);
                }
                return tokenResult.data;
            }
            catch (Exception ex)
            {

                throw new Exception("访问Token 网址失败" + ex.ToString());
            }
            // return result;
        }
    }
}
