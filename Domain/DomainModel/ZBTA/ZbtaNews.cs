using System.Text;
using TourInfo.Domain.Base;

namespace TourInfo.Domain.TourNews
{
    public class ZbtaNews: VersionedEntity
    {
        public string releaseTime { get; set; }
        public string checkState { get; set; }
      
        public string titles { get; set; }
        public string image { get; set; }
        public string created { get; set; }
        public string back1 { get; set; }
        public string details { get; set; }
        public string createUser { get; set; }

        public override string CalculateFingerprint(IMD5Helper mD5Helper)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(id)
                .Append(this.releaseTime)
                .Append(this.checkState)
                .Append(this.titles)
                .Append(this.image)
                .Append(this.created)
                .Append(this.back1)
                .Append(this.createUser)
                ;
            return mD5Helper.CalculateMD5Hash(sb.ToString());
        }
    }
}
