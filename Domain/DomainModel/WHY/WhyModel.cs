using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using TourInfo.Domain.Base;
using TourInfo.Domain.DomainModel.Rapi;

namespace TourInfo.Domain.DomainModel.WHY
{
    /// <summary>
    /// 文化云模型
    /// </summary>
    public class WhyModel : VersionedEntity<string>
    {
        /// <summary>
        /// rapi对应的Id
        /// </summary>
        public int RapiId { get;set;}
        public string contact { get; set; }
        public ImageUrl hposter { get; set; }
        public string addressInfo { get; set; }

        public Location location { get; set; }
        public string name { get; set; }

        public string summary { get; set; }

        public string website { get; set; }
        public string telephoneWithoutAreaCode
        {
            get
            {
                Regex regMobilePhone = new Regex(@"1\d{10}");
                if (regMobilePhone.IsMatch(this.contact)) { return contact; }
                Regex areaCode = new Regex(@"\(?(0533)(-{0,2}|\)?){0,2}");
                return areaCode.Replace(contact, string.Empty);

            }
        }
        public override string CalculateFingerprint(IMD5Helper mD5Helper)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(this.id)

            .Append(this.addressInfo)

            .Append(this.contact)

            .Append(this.hposter.OriginalUrl)

            .Append(string.Join(",", location))
            .Append(this.name)

            .Append(summary)

            .Append(this.website)
                ;

            return mD5Helper.CalculateMD5Hash(sb.ToString());
        }
        /// <summary>
        /// 使用api结果 更新数据库对象
        /// </summary>
        /// <param name="otherModel"></param>
        public void UpdateDbModelFromApi(WhyModel otherModel)
        { 
            this.addressInfo=otherModel.addressInfo;
            this.contact=otherModel.contact;
            this.hposter=new ImageUrl(otherModel.hposter.OriginalUrl,otherModel.hposter.LocalizedUrl);
            this.location=new Location(otherModel.location.Longitude,otherModel.location.Latitude);
            this.name=otherModel.name;
            this.summary=otherModel.summary;
            this.website=otherModel.website;
            }

    }
}
