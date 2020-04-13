using System;
using System.Collections.Generic;
using System.Text;
using TourInfo.Domain.Base;
using System.Linq;
namespace TourInfo.Domain.DomainModel.SDTA
{
    public class Lines:Entity<string>
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

    public class ResponseLines : DetailWrapper<Lines,string>, IEntity<string>
    {
        
        
      public  IList<Lines>  lines {get;set; }

       public string GetDetailRequestData(Lines lines2) { return lines2.id;}
        public override IEnumerable<Lines> DetailSummarys =>lines;
        public override IDetailHttpRequestMessageCreator<Lines> DetailRequestBuilder =>
            new LineDetailHttpRequestMessageCreator();

        public string id {get;set;}
    }
}
