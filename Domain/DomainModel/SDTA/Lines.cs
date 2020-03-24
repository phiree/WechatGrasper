using System;
using System.Collections.Generic;
using System.Text;

namespace TourInfo.Domain.DomainModel.SDTA
{
    public class Lines
    {
        public string name { get; set; }
        public string thumb { get; set; }
        public List<string> tags { get; set; }
        public string bestSeason { get; set; }
        public List<string> city { get; set; }
        public int days { get; set; }
        public string search { get; set; }
        public string id { get; set; }
        public int placeNum { get; set; }
    }

    public class ResponseLines
    {
        public IList<Lines> lines { get; set; }
    }
}
