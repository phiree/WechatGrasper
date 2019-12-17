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
        public abstract  string CalculateFingerprint(IMD5Helper mD5Helper);

        public void UpdateVersion(string newFingerprint, string newVersion)
        {
            this.Fingerprint = newFingerprint;
            this.Version = newVersion;
        }
        /// <summary>
        /// 当前对象值的hashcode，用于比较是否改动
        /// </summary>
        public string Fingerprint { get;  protected set; }
        public string Version { get; protected set; }
    }

}

