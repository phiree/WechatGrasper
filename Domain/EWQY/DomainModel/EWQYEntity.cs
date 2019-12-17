using TourInfo.Domain.Base;

namespace TourInfo.Domain
{
    public abstract  class EWQYEntity:Entity
    {
               /// <summary>
        /// 信息类型
        /// </summary>
        public PlaceType PlaceType { get; set; }
      
         public abstract EWQYEntity AppendFingerprint();
       
    }

}

