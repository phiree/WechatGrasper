using System;
using System.Collections.Generic;
using System.Text;
using TourInfo.Domain.Base;
using System.Linq;
namespace TourInfo.Domain.DomainModel.SDTA
{

    public class LineDetail : DetailWrapper<LineDetail.Day.Place,string>, IEntity<string>
    {

        public string name { get; set; }
        public string thumb { get; set; }
        public string[] tags { get; set; }
        public string bestSeason { get; set; }
        public string[] city { get; set; }
        public List<Day> days { get; set; }

        
        public override IEnumerable<Day.Place> DetailSummarys =>  days.SelectMany(x=>x.place);

        public override IDetailHttpRequestMessageCreator<Day.Place> DetailRequestBuilder =>new LineDetailScenicHttpRequestMessageCreator();

        public string id { get;set; }

       

        public class Day
        {
            public string name { get; set; }
            public string desc { get; set; }
            public List<Place> place { get; set; }
            public string hotelDesc { get; set; }

            public string foodDesc { get; set; }


            public class Place:Entity<string>
            {
                public string type { get; set; }
            
                public string time { get; set; }
                public string tag { get; set; }
            }

        }
    }
}
