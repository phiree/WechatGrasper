namespace TourInfo.Domain.Base
{
    public abstract class VersionedEntity:Entity<string>,IHasVersion
    {
        /// <summary>
        /// 数据版本，格式yyyyMMddHHmmss
        /// </summary>
        public string Version { get; set; }
        /// <summary>
        /// 数据指纹，用于判断内容是否变更
        /// </summary>
        public string Fingerprint { get; set; }

        public abstract string CalculateFingerprint(IMD5Helper mD5Helper);
        public void UpdateVersion(string newFingerprint, string newVersion)
        {
            this.Version = newVersion;
            this.Fingerprint = newFingerprint;
        }
    }

}

