using System;
using System.Collections.Generic;

using System.Text;

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
