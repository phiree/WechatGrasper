using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using TourInfo.Domain.Base;

namespace TourInfo.Domain.DomainModel.SDTA
{

    
    public class SpecialLocalProduct: IListData<SpecialLocalProduct.Hits.Hit , string>
    {
        public int took { get; set; }
        public bool timed_out { get; set; }
      
        public Hits hits { get; set; }

        public IList<Hits.Hit> Details => hits.hits;

        public class Shards
        {
            public int total { get; set; }
            public int successful { get; set; }
            public int failed { get; set; }
        }

        public class Hits
        {
            public int total { get; set; }
            public double max_score { get; set; }
            public List<Hit> hits { get; set; }
            public class Hit: Entity<string>
            {
                public string _index { get; set; }
                public string _type { get; set; }
                public string _id { get { return id; } set { id = value; } }
                public double _score { get; set; }
                public Source _source { get; set; }
                public class Source
                {
                    public int id { get; set; }
                    public string commodity_id { get; set; }
                    public string name_cn { get; set; }
                    public string address { get; set; }
                    public string default_photo { get; set; }
                    [JsonProperty("city.lvl1")]
                    public string city_lvl1 { get; set; }
                    [JsonProperty("city.lvl2")]
                    public string city_lvl2 { get; set; }
                    public int rank { get; set; }
                    
                    public string full_name { get; set; }
                    public string description { get; set; }
                    public int date_for_order { get; set; }
                    public int citycode { get; set; }
                    public int areacode { get; set; }
                    public int commentscore { get; set; }
                    public int commentcount { get; set; }
                    public int likescount { get; set; }
                    public int collectscount { get; set; }
                     






                }
            }
        }
    }
}
