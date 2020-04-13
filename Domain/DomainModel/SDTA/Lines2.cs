using System;
using System.Collections.Generic;
using System.Text;
using TourInfo.Domain.Base;
using System.Linq;
namespace TourInfo.Domain.DomainModel.SDTA
{
    public class Lines2:Entity<string>
    {
        public string name { get; set; }
        public string thumb { get; set; }
        public List<string> tags { get; set; }
        public string bestSeason { get; set; }
        public List<string> city { get; set; }
        public int days { get; set; }
        public string search { get; set; }
        
        public int placeNum { get; set; }

       
    }

    public class ResponseLines2 : DetailWrapper<LineDetail2, string>
    {
        
        
      public  IList<Lines2>  lines {get;set; }

       public string GetDetailRequestData(Lines2 lines2) { return lines2.id;}

        public override IList<string> DetailKeys => lines.Select(x=>x.id).ToList();

    }
}
