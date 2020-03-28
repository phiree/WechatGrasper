using System;
using System.Collections.Generic;
using System.Text;

namespace TourInfo.Domain.DomainModel.SDTA
{

    public class CityGuide
    {
        public string name { get; set; }
        public string nameEn { get; set; }
        public string thumb { get; set; }
        public string cover { get; set; }
        public List<Category> category { get; set; }
        public class Category
        {
            public string name { get; set; }
            public List<List> list { get; set; }
            public class List
            {
                public string slug { get; set; }
                public string title { get; set; }
                public bool isShow { get; set; }
                public string tag { get; set; }
                public string color { get; set; }
            }
    }
        }
}
