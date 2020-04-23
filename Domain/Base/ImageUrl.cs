namespace TourInfo.Domain.Base
{
    /// <summary>
    /// 图片url
    /// </summary>
    public class ImageUrl
    {
        public ImageUrl() { }
        public static ImageUrl Null {get{ return new ImageUrl(string.Empty); } }
        public ImageUrl(string originalUrl) : this(originalUrl, string.Empty) { }

        [Newtonsoft.Json.JsonConstructor]
        public ImageUrl(string originalUrl, string localizedUrl)
        {
            OriginalUrl = originalUrl;
            LocalizedUrl = localizedUrl;
        }
        public void Localize(IImageLocalizer localizer,string imageBaseUrl)
        { 
           LocalizedUrl= localizer.Localize(imageBaseUrl+OriginalUrl);
            }
        public void UpdateLocalizedUrl(string localizedUrl)
        { 
            this.LocalizedUrl=localizedUrl;
            }
        /// <summary>
        /// 原始地址
        /// </summary>
        public string OriginalUrl { get; protected  set; }
        /// <summary>
        /// 下载到本地的地址.
        /// </summary>
        public string LocalizedUrl { get; protected set; }
        
    }
}
