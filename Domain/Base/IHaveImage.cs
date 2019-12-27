using System;
using System.Collections.Generic;
using System.Text;

namespace TourInfo.Domain.Base
{
    public interface IHaveImage
    {
         /// <summary>
         /// 图片源路径属性 和  本地化路径 属性对应关系
         /// 如果不需要保存源地址，则key和value可以设置到同一个字段。
         /// </summary>
        IDictionary<string, string> ImageUrlPropertyMap { get; }
    }
    public class ImageUrl
    {
        public ImageUrl(string originalUrl) : this(originalUrl, string.Empty) { }
        public ImageUrl(string originalUrl, string localizedUrl)
        {
            OriginalUrl = originalUrl;
            LocalizedUrl = localizedUrl;
        }
        public void UpdateLocalizedUrl(string localizedUrl)
        { 
            this.LocalizedUrl=localizedUrl;
            }
        public string OriginalUrl { get; protected  set; }
        public string LocalizedUrl { get; protected set; }
        
    }
}
