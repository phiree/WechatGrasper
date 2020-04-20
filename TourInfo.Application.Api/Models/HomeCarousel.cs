using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TourInfo.Application.Api.Models
{
    /// <summary>
    /// 首页轮播图
    /// </summary>
    public class HomeCarousel
    {
        public HomeCarousel(string id, string title, DataSourceType dataSourceType, string imageUrl)
        {
            Id = id;
            Title = title;
            DataSourceType = dataSourceType;
            ImageUrl = imageUrl;
        }

        /// <summary>
        /// 对应详情数据的Id
        /// </summary>
        public string Id { get;protected set;}
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; protected set; }
        /// <summary>
        /// 数据源类型
        /// </summary>
        public DataSourceType DataSourceType { get; protected set; }
        /// <summary>
        /// 图片Url
        /// </summary>
        public string ImageUrl { get; protected set; }
    }
    public enum DataSourceType { 
        /// <summary>
        /// 微信公众号新闻
        /// </summary>
        WeChatNews=1,
        /// <summary>
        /// zbtanews网站
        /// </summary>
        ZbtaNews=2
        }
}
