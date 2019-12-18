using TourInfo.Domain.Base;

namespace TourInfo.Domain
{
    public  abstract  class EWQYEntity:VersionedEntity
    {
        

        /// <summary>
        /// 当前对象值的hashcode，用于比较是否改动
        /// </summary>
      
        /// 信息类型
        /// </summary>
        public PlaceType PlaceType { get; set; }
        
    }

}

