namespace TourInfo.Domain.Base
{
    /// <summary>
    /// 基类
    /// </summary>
    public abstract class Entity
    {
        public string id { get; set; }
        /// <summary>
        /// 获取当前对象值的hashcode
        /// </summary>
        /// <returns></returns>
       
        
    }
    public abstract class VersionedEntity:Entity,IHasVersion
    {
        public string Version { get; set; }
        public string Fingerprint { get; set; }
        public abstract string CalculateFingerprint(IMD5Helper mD5Helper);

        public void UpdateVersion(string newFingerprint, string newVersion)
        {
            this.Version = newVersion;
            this.Fingerprint = newFingerprint;
        }
    }

}

