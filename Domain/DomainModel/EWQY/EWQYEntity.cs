using TourInfo.Domain.Base;

namespace TourInfo.Domain
{
    public  abstract  class EWQYEntity:VersionedEntity
    {
     /// <summary>
     /// 信息类型 0： 场馆，1：企业
     /// </summary>
        public PlaceType PlaceType { get; set; }
        
    }

}

