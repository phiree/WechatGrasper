using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using TourInfo.Domain.Base;

namespace TourInfo.Domain.DomainModel.SDTA
{

    public class CityGuide:IListData<CityGuide.Category.List,string>
    {
        public string name { get; set; }
        public string nameEn { get; set; }
        public string thumb { get; set; }
        public string cover { get; set; }
        public List<Category> category { get; set; }
        public IList<Category.List> Details { get { 
                return category.SelectMany(x=>x.list).ToList();
                } }

        public class Category
        {
            public string name { get; set; }
            public List<List> list { get; set; }
            public class List:Entity<string>
            {
                
                public    string slug {get{ return id;}set{ id=value;} }

                public string title { get; set; }
                public bool isShow { get; set; }
                public string tag { get; set; }
                public string color { get; set; }
            }
    }
        }
}
