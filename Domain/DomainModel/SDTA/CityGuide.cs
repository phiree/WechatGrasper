using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using TourInfo.Domain.Base;
using Newtonsoft.Json;

namespace TourInfo.Domain.DomainModel.SDTA
{

    public class CityGuide : VersionedEntity<string>, IListData<CityGuide.Category.List, string>
    {
        public   override string id { get => name; set => name = value; }
        public string name { get; set; }
        public string nameEn { get; set; }
        public string thumb { get; set; }
        public string cover { get; set; }
        public List<Category> category { get; set; }
        public IList<Category.List> Details
        {
            get
            {
                return category.SelectMany(x => x.list).ToList();
            }
        }

        public class Category
        {
            
            public string name { get; set; }
            public List<List> list { get; set; }
            public class List : IEntity<string>
            {

                public   string id { get=>slug;set=>slug=value;}
                public string slug { get;set; }

                public string title { get; set; }
                public bool isShow { get; set; }
                public string tag { get; set; }
                public string color { get; set; }
            }
        }
    }
}
