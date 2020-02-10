using System;
using System.Collections.Generic;
using System.Text;
using TourInfo.Domain.Base;
using TourInfo.Domain.DomainModel.Rapi;

namespace TourInfo.Domain.DomainModel.WHY
{
    /// <summary>
    /// 文化云模型
    /// </summary>
    public class WhyModel : VersionedEntity<string>
    {
        public string contact { get; set; }
        public ImageUrl hposter { get; set; }
        public string addressInfo { get; set; }

        public Location location { get; set; }
        public string name { get; set; }

        public string summary { get; set; }

        public string website { get; set; }

        public override string CalculateFingerprint(IMD5Helper mD5Helper)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(this.id)

            .Append(this.addressInfo)

            .Append(this.contact)

            .Append(this.hposter)

            .Append(string.Join(",", location))
            .Append(this.name)

            .Append(summary)

            .Append(this.website)
                ;

            return mD5Helper.CalculateMD5Hash(sb.ToString());
        }

    }
}
