 
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using TourInfo.Domain;
 
using System.IO;
namespace TourInfo.Domain
{
    /// <summary>
    /// 图片到mdapi
    /// </summary>
    public class ImageLocalizerToMd : IImageLocalizer
    {
        IUrlFetcher urlFetcher;
        int sysId=5;
        string mdapiRootUrl= "https://mdapi.zjwist.com/mediainfo3";
       
        public ImageLocalizerToMd(IUrlFetcher urlFetcher )
        {
            
            this.urlFetcher = urlFetcher;
           
            
        }
   
        public string Localize( string remotePicUrl )
        {
             string url=mdapiRootUrl+ $"/savebyurl?sysid={sysId}&url="+System.Web.HttpUtility.UrlEncode(remotePicUrl);
            string apiResult= urlFetcher.FetchAsync(url).Result;
            var uploadResult= Newtonsoft.Json.JsonConvert.DeserializeObject<MdResponse>(apiResult
                );
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

