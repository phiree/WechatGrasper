using System;
using System.Collections.Generic;
using System.Text;
using TourInfo.Domain.Base;

namespace TourInfo.Domain.DomainModel.ZiBoWechatNews
{
    /// <summary>
    /// 接口结构和数据库公用一个model
    /// </summary>
    public class ZiBoWechatNewsApiResponse
    {
        public IList<ZiBoWechatNews> data { get;set;}
    }
    public class ZiBoWechatNews:VersionedEntity<string>
    {
        public override string id { get; set; }

        public string title { get;set;}
        public ImageUrl img { get; set; }
        public string url { get; set; }
        public DateTime pubtime { get;set;}
        //public ImageUrlsInText content { get;set;}

        public override string CalculateFingerprint(IMD5Helper mD5Helper)
        {
            return   mD5Helper.CalculateMD5Hash($"{title}{img}{url}{pubtime}");
        }



    }
}
