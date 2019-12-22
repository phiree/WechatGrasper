using TourInfo.Domain.Base;

namespace TourInfo.Domain
{
    public  abstract  class EWQYEntity:VersionedEntity
    {
     /// <summary>
     /// 信息类型 0： 场馆，1：企业
     /// </summary>
        public PlaceType PlaceType { get; set; }
   
        /// <summary>
        /// 活动标题图片
        /// </summary>
        public string thumbnailKey { get; set; }
        /// <summary>
        /// 本地存储后的图片路径
        /// </summary>
        public string localizedThumbnailKey { get; set; }
        /// <summary>
        /// 图片
        /// </summary>
        public string[] pictureKeys { get; set; }
        /// <summary>
        /// 活动图片
        /// </summary>
        public string[] localizedPictureKeys { get; set; }


    }

}

