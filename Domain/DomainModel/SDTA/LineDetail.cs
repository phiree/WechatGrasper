using System;
using System.Collections.Generic;
using System.Text;

namespace TourInfo.Domain.DomainModel.SDTA
{
   

   

   

    public class LineDetail
    {
        public string name { get; set; }
        public string thumb { get; set; }
        public List<string> tags { get; set; }
        public string bestSeason { get; set; }
        public List<string> city { get; set; }
        public List<Day> days { get; set; }
        public class Day
        {
            public string name { get; set; }
            public string desc { get; set; }
            public List<Place> place { get; set; }
            public string hotelDesc { get; set; }
            public List<Hotel> hotels { get; set; }
            public string foodDesc { get; set; }
            public List<Food> foods { get; set; }

            public class Place
            {
                public string type { get; set; }
                public string id { get; set; }
                public string time { get; set; }
                public string tag { get; set; }
            }
            public class Hotel
            {
            }

            public class Food
            {
            }
        }
    }
}
