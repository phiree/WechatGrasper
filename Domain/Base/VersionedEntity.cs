using System.Text;

namespace TourInfo.Domain.Base
{
    public abstract class VersionedEntity :Entity<string>,IHasVersion
    {
        /// <summary>
        /// 数据版本，格式yyyyMMddHHmmss
        /// </summary>
        public string Version { get; set; }
        /// <summary>
        /// 数据指纹，用于判断内容是否变更
        /// </summary>
        public string Fingerprint { get; set; }

        public virtual string CalculateFingerprint(IMD5Helper mD5Helper){
            StringBuilder sb = new StringBuilder();
            sb.Append(id);
            return mD5Helper.CalculateMD5Hash(sb.ToString());
        }
        public void UpdateVersion(string newFingerprint, string newVersion)
        {
            this.Version = newVersion;
            this.Fingerprint = newFingerprint;
        }
    }

}

