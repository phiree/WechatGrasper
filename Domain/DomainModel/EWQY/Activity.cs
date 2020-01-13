using System.Collections.Generic;
using System.Linq;
using System.Text;
using TourInfo.Domain.Base;

namespace TourInfo.Domain
{
    /// <summary>
    /// 活动列表项
    /// </summary>
    public class Activity : EWQYEntity 
    {
        public Activity() { }
        /// <summary>
        /// 活动开始时间
        /// </summary>
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
         
        public override string CalculateFingerprint(IMD5Helper mD5Helper)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(id)
                .Append(this.address)
                .Append(this.createTime)
                .Append(this.credits)
                .Append(this.detail)
                .Append(this.endTime)
                .Append(this.isShared)
                .Append(this.name)
              
                .Append(this.startTime)
                .Append(this.thumbnailKey);

            return mD5Helper.CalculateMD5Hash(sb.ToString());
        }

        
    }
}