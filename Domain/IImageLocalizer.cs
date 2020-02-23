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
        /// <param name="remotePicUrl">远程图片地址</param>
        /// <param name="localSavedPath">本地保存的相对(执行文件)路径</param>
        /// <param name="clientPath">客户端使用的相对路径</param>
        /// <returns>本地图片相对地址</returns>
        string Localize(  string remotePicUrl );
    }
}
