using TourInfo.Domain.Base;

namespace TourInfo.Domain
{
    public  abstract  class EWQYEntity:Entity ,IHasVersion
    {
        public abstract string CalculateFingerprint(IMD5Helper mD5Helper);


        /// <summary>
        /// 当前对象值的hashcode，用于比较是否改动
        /// </summary>
        public string Fingerprint { get;   set; }
        /// <summary>
        /// 信息类型
        /// </summary>
        public PlaceType PlaceType { get; set; }
        public string Version { get ;  set  ; }

        public void UpdateVersion(string newFingerprint, string newVersion)
        {
            this.Version = newVersion;
            this.Fingerprint = newFingerprint;
        }
    }

}

