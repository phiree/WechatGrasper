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
        protected HomeCarousel() { }
        public HomeCarousel(string id, string title, HomeCarouselDataSourceType dataSourceType, string imageUrl,string date)
        {
            Id = id;
            Title = title;
            DataSourceType = dataSourceType;
            ImageUrl = imageUrl;
            this.Date=date;
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
        public HomeCarouselDataSourceType DataSourceType { get; protected set; }
        /// <summary>
        /// 图片Url
        /// </summary>
        public string ImageUrl { get;   set; }
        public string Date { get;protected set;}
    }
    /// <summary>
    /// 轮播图数据来源类型
    /// </summary>
    public enum HomeCarouselDataSourceType
    { 
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
