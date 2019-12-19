using System;
using System.Collections.Generic;
using System.Text;

namespace TourInfo.Domain
{
    public interface IImageLocalizer
    {
        /// <summary>
        /// 图片本地化
        /// </summary>
        /// <param name="picUrl"></param>
        /// <returns>本地图片相对路径</returns>
        string Localize(string prefixUrl, string rawPicUrl);
    }
}
