using System;
using System.Collections.Generic;
using System.Text;
using TourInfo.Domain.DomainModel.WHY;

namespace TourInfo.Domain.Application.WHY
{
   
    [Obsolete("已使用 DomainModel.WHY.WHYModel")]
    public class WHYDetailOrganization
    {
        public string addressCity { get; set; }
        public string addressCounty { get; set; }
        public string addressInfo { get; set; }
        public string addressProvince { get; set; }
        public string addressarea { get; set; }
        public int areaCheckStatus { get; set; }
        public string areaId { get; set; }
        public string businessLicense { get; set; }
        public int checkstatus { get; set; }
        public int cityCheckStatus { get; set; }
        public string contact { get; set; }
        public long createTime { get; set; }
        public string email { get; set; }
        public bool grabStatus { get; set; }
        public string hposter { get; set; }
        public string id { get; set; }
        public int isTop { get; set; }
        public string keywords { get; set; }
        public List<double> location { get; set; }
        public string name { get; set; }
        public string organizationTypeId { get; set; }
        public string qq { get; set; }
        public bool removed { get; set; }
        public string summary { get; set; }
        public long updateTime { get; set; }
        public string userId { get; set; }
        public int volumeCount { get; set; }
        public string website { get; set; }
    }

    public class WHYDetail
    {
        public int follow { get; set; }
        public string msg { get; set; }
        public WhyModel organizationT { get; set; }
        public int orifoolernumber { get; set; }
        public string oriname { get; set; }
        public string oristatus { get; set; }
        public int pageSize { get; set; }
        public bool sucflag { get; set; }
        public int totalCount { get; set; }
    }
}
