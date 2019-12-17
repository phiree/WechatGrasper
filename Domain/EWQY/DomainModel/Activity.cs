using System.Collections.Generic;
using System.Linq;
using System.Text;
using TourInfo.Domain.Base;

namespace TourInfo.Domain
{
    /// <summary>
    /// 活动列表项
    /// </summary>
    public class Activity : EWQYEntity 
    {

        public string startTime { get; set; }
        public string createTime { get; set; }
        public string thumbnailKey { get; set; }
        public string address { get; set; }
        public string name { get; set; }
        public string endTime { get; set; }

        public string detail { get; set; }
       
        public string[] pictureKeys { get; set; }

        public int credits { get; set; }
        public bool isShared { get; set; }
         
        public override string CalculateFingerprint(IMD5Helper mD5Helper)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(id)
                .Append(this.address)
                .Append(this.createTime)
                .Append(this.credits)
                .Append(this.detail)
                .Append(this.endTime)
                .Append(this.isShared)
                .Append(this.name)
               .Append(string.Join(",", this.pictureKeys))
                .Append(this.startTime)
                .Append(this.thumbnailKey);

            return mD5Helper.CalculateMD5Hash(sb.ToString());
        }

        
    }
}