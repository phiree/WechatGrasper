using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TourInfo.Domain
{
    /// <summary>
    /// 文化场馆或企业
    /// </summary>
    public class CompanyVenue : EWQYEntity
    {

       /// <summary>
       /// 首图
       /// </summary>
       
       /// <summary>
       /// 坐标，第一个值是经度，第二个维度
       /// </summary>
        public  double[] location { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 满意度得分
        /// </summary>
        public string satisfactionScore { get; set; }
        /// <summary>
        /// 类型Id（暂时不用）
        /// </summary>
        public string typeId { get; set; }
        /// <summary>
        /// 介绍
        /// </summary>
        public string introduction { get; set; }
        //public IsComment isComment { get; set; }
       
       /// <summary>
        /// 地址
        /// </summary>
        public string address { get; set; }
        /// <summary>
        /// 是否收藏（暂时不用）
        /// </summary>
        public string isFavorite { get; set; }
        
        #region 场馆独有属性
        /// <summary>
        /// 场馆开门时间
        /// </summary>
        public string serviceTimeStart { get; set; }
        /// <summary>
        /// 场馆服务备注
        /// </summary>
        public string serviceNote { get; set; }
        /// <summary>
        /// 场馆打烊时间
        /// </summary>
        public string serviceTimeEnd { get; set; }
        #endregion
        /// <summary>
        /// 联系电话
        /// </summary>
        public string telNumber { get; set; }
        
        public  override string CalculateFingerprint(IMD5Helper mD5Helper)
        {
           StringBuilder sb=new StringBuilder();
            sb.Append(id)
                .Append(this.address)
                 
                .Append(this.introduction)
               
                .Append(this.isFavorite)
                .Append(location!=null? string.Join(",",this.location):"")
                .Append(this.name)
               
                .Append(this.satisfactionScore)
                .Append(this.serviceNote)
                .Append(this.serviceTimeEnd)
                .Append(this.serviceTimeStart)
                .Append(this.telNumber)
                .Append(this.thumbnailKey)
                .Append(this.typeId);
             
            return mD5Helper.CalculateMD5Hash(sb.ToString());
        }
    }

}

