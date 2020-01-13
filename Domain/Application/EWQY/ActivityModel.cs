using System;
using System.Collections.Generic;
using System.Text;

namespace TourInfo.Domain.Application.EWQY
{
   public class ActivityModel
    {
        /// </summary>
        public string Version { get; set; }
        /// <summary>
        /// 数据指纹，用于判断内容是否变更
        /// </summary>
        public string Fingerprint { get; set; }
        public PlaceType PlaceType { get; set; }
        public string startTime { get; set; }
        /// <summary>
        /// 活动信息创建时间
        /// </summary>
        public string createTime { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        public string address { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 活动结束时间
        /// </summary>
        public string endTime { get; set; }
        /// <summary>
        /// 活动详情
        /// </summary>
        public string detail { get; set; }

        /// <summary>
        /// 分享积分（暂时不用）
        /// </summary>
        public int credits { get; set; }
        /// <summary>
        /// 是否已经被分享（暂时不用）, 0 表示 false, 1 表示true
        /// </summary>


        public bool isShared { get; set; }

    }
}
