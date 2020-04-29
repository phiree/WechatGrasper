using System;
using System.Collections.Generic;

using System.Text;
using System.Text.RegularExpressions;

namespace TourInfo.Domain.Base
{
    
    /// <summary>
    /// 包含图片连接的文本
    /// </summary>
    public class ImageUrlsInText
    {
        public ImageUrlsInText(string originaText):this(originaText,string.Empty,string.Empty)
        {
        }
        public ImageUrlsInText(string originaText, string imageLocalizedText,string imageBaseUrl)
        {
            OriginaText = originaText;
            ImageLocalizedText = imageLocalizedText;
            this.ImageBaseUrl = imageBaseUrl;
        }
        public void UpdateImageLocalizedText(string imageLocalizedText)
        {
            this.ImageLocalizedText = imageLocalizedText;
        }
        public void Localize(IImageLocalizer imageLocalizer,string originalImageRootUrl)
        {
            var imageUrl =this;
            string pattern = "(?<=<img[^>]+src=\")[^\">]+(?=\")";
            var matches = Regex.Matches(imageUrl.OriginaText, pattern);
            var textWithLocalizedImageUrl = imageUrl.OriginaText;
            //特殊判断:  对象自己定义的根路径 优先.
            //原因: zbtanews 的 标题图片的根路径 不带 ziboback/ 这一节, 但是内容里面的图片地址带.
            string imageBaseUrl = string.IsNullOrEmpty(imageUrl.ImageBaseUrl) ? originalImageRootUrl : imageUrl.ImageBaseUrl;
            foreach (Match m in matches)
            {
                var localizedImage = imageLocalizer.Localize(imageBaseUrl + m.Value);
                textWithLocalizedImageUrl = textWithLocalizedImageUrl.Replace(m.Value, localizedImage);
            }
             this.ImageLocalizedText = textWithLocalizedImageUrl;
            
        }

        public void UpdateOriginalText(string originalText)
        {
            this.OriginaText = originalText;
        }
        /// <summary>
        /// 原始文本
        /// </summary>
        public string OriginaText { get; protected set; }
        /// <summary>
        /// 其中的文本本地化之后的文本
        /// </summary>
        public string ImageLocalizedText { get; protected set; }
        /// <summary>
        /// 图片跟路径
        /// </summary>
       
        public string ImageBaseUrl { get; protected set; }
    }
}
