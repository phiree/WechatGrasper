using System;
using System.Collections.Generic;
using System.Text;
using TourInfo.Domain.Base;
using System.Linq;
namespace TourInfo.Domain.DomainModel.SDTA
{

    public class LineDetail2 : DetailWrapper< LineDetailScenic2, string>
    {
      
        public string name { get; set; }
        public string thumb { get; set; }
        public string[] tags { get; set; }
        public string bestSeason { get; set; }
        public string[] city { get; set; }
        public List<Day> days { get; set; }
       
        public override IList<string> DetailKeys => days.SelectMany(x=>x.place.Select(y=>y.type+"_"+y.id)).ToList();

         

        public class Day
        {
            public string name { get; set; }
            public string desc { get; set; }
            public List<Place> place { get; set; }
            public string hotelDesc { get; set; }
            
            public string foodDesc { get; set; }
            

            public class Place
            {
                public string type { get; set; }
                public string id { get; set; }
                public string time { get; set; }
                public string tag { get; set; }
            }
             
        }
    }
}
