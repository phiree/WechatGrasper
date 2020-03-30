using System;
using System.Collections.Generic;
using System.Text;
using TourInfo.Domain.Base;

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

    public class ResponseLines:IListData<Lines,string>
    {
        //public IList<Lines> lines { get; set; }
        [Newtonsoft.Json.JsonProperty("lines")]
        
      public  IList<Lines>  Details {get;set; }
    }
}
