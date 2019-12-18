using TourInfo.Domain.Base;

namespace TourInfo.Domain
{
    public  abstract  class EWQYEntity:VersionedEntity
    {
  
        /// 信息类型
        /// </summary>
        public PlaceType PlaceType { get; set; }
        
    }

}

