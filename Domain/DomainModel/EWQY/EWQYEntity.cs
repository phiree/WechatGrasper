using System.Collections.Generic;
using TourInfo.Domain.Base;

namespace TourInfo.Domain
{
    public  abstract  class EWQYEntity:VersionedEntity<string>
    {
     /// <summary>
     /// 信息类型 0： 场馆，1：企业
     /// </summary>
        public PlaceType PlaceType { get; set; }
   
        /// <summary>
        /// 活动标题图片
        /// </summary>
        public ImageUrl thumbnailKey { get; set; }
        
        /// <summary>
        /// 图片
        /// </summary>
        public IList<ImageUrl> pictureKeys { get; set; }
        


    }

}

