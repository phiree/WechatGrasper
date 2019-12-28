using System.Text;
using TourInfo.Domain.Base;

namespace TourInfo.Domain.TourNews
{
    /// <summary>
    /// zbta旅游资讯
    /// </summary>
    public class ZbtaNews: VersionedEntity<string>
    {
     
        /// <summary>
        /// 发布时间
        /// </summary>
        public string releaseTime { get; set; }
        /// <summary>
        /// 审核状态（暂时不用）
        /// </summary>
        public string checkState { get; set; }
      /// <summary>
      /// 标题
      /// </summary>
        public string titles { get; set; }
        /// <summary>
        /// 首图
        /// </summary>
        public ImageUrl image { get; set; }
        
        /// <summary>
        /// 信息创建时间
        /// </summary>
        public string created { get; set; }
        /// <summary>
        /// 概要
        /// </summary>
        public string back1 { get; set; }
        /// <summary>
        /// 详情（富文本）
        /// </summary>
        public string details { get; set; }
        public string localizedDetails { get; set; }
        /// <summary>
        /// 创建者（暂时无用）
        /// </summary>
        public string createUser { get; set; }

        public override string CalculateFingerprint(IMD5Helper mD5Helper)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(id)
                .Append(this.releaseTime)
                .Append(this.checkState)
                .Append(this.titles)
                .Append(this.image)
                .Append(this.created)
                .Append(this.back1)
                .Append(this.createUser)
                ;
            return mD5Helper.CalculateMD5Hash(sb.ToString());
        }
    }
}
