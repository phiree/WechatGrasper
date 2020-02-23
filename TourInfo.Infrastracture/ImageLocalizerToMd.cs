 
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using TourInfo.Domain;
using TourInfo.Infrastracture;
using System.IO;
namespace TourInfo.Infrastracture
{
    /// <summary>
    /// 图片到mdapi
    /// </summary>
    public class ImageLocalizerToMd : IImageLocalizer
    {
        IUrlFetcher urlFetcher;
        int sysId;
        string mdapiRootUrl= "https://mdapi.zjwist.com/mediainfo3";
        string mdDataRootUrl= "https://mdapi.zjwist.com/data";
        public ImageLocalizerToMd(IUrlFetcher urlFetcher, string mdapiRootUrl,int sysId)
        {
            this.mdapiRootUrl=mdapiRootUrl;
            this.urlFetcher = urlFetcher;
            this.sysId=sysId;
            
        }
   
        public string Localize( string remotePicUrl )
        {
             string url=mdapiRootUrl+ $"savebyurl?sysid={sysId}&url="+System.Web.HttpUtility.UrlEncode(remotePicUrl);
            var uploadResult= Newtonsoft.Json.JsonConvert.DeserializeObject<MdResponse>(
                urlFetcher.FetchAsync(url).Result);
            if(uploadResult.code!=0)
            { 
                throw new Exception($"上传到mdapi失败.url:[{remotePicUrl}]");
                }
            return uploadResult.results[0].filepath;
        }
        public class MdResponse
        { 
            public int code { get;set; }
            public IList<MdResponseData> results { get;set;}

            }
        public class MdResponseData
        { 
            public string filepath { get;set;}
            }
    }

}

