using System;
using System.Collections.Generic;
using System.Text;
using TourInfo.Domain.Base;

namespace TourInfo.Domain.DomainModel.SDTA
{

    public class LineDetail:Entity<string>,IDetailWrapper<LineDetail>
    {
      
        public string name { get; set; }
        public string thumb { get; set; }
        public string[] tags { get; set; }
        public string bestSeason { get; set; }
        public string[] city { get; set; }
        public List<Day> days { get; set; }
        public LineDetail Detail { get { return this;}  }

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
