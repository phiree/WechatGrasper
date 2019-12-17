namespace TourInfo.Domain.Base
{
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

