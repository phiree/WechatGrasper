using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TourInfo.Application.Api.Models
{
    public class CityGuideListModel
    {
        public string CategoryName { get;set;}
        public IList<GuideLineTitle> Titles { get;set;}
        public class GuideLineTitle
        {
            public string Id { get; set; }
            public string Name { get;set;}
            public string Tag { get;set;}
            }
    }

}
