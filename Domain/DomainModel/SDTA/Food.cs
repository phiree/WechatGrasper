using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Linq;
using TourInfo.Domain.Base;

namespace TourInfo.Domain.DomainModel.SDTA
{
    

  
   
    public class Food:IListData<Food.Hit.Source,int>
    {
        public int took { get; set; }
        public bool timed_out { get; set; }
        public Shards _shards { get; set; }
        public Hits hits { get; set; }

        public IList<Hit.Source> Details =>hits.hits.Select(x=>x._source).ToList();
        public class Hits
        {
            public int total { get; set; }
            public double max_score { get; set; }
            public List<Hit> hits { get; set; }
        }
        public class Shards
        {
            public int total { get; set; }
            public int successful { get; set; }
            public int failed { get; set; }
        }
        public class Hit
        {
            public string _index { get; set; }
            public string _type { get; set; }
            public string _id { get; set; }
            public double _score { get; set; }
            public Source _source { get; set; }
            public class Source : Entity<int>
            {

                public string res_type_rela { get; set; }
                public string snack_name { get; set; }
                public object address { get; set; }
                public string default_photo { get; set; }
                [JsonProperty("city.lvl1")]
                public string city_lvl1 { get; set; }
                [JsonProperty("city.lvl2")]
                public string city_lvl2 { get; set; }
                public int? rank { get; set; }
                public SnackFoodType snack_food_type { get; set; }
                public object full_name { get; set; }
                public string description { get; set; }
                public int date_for_order { get; set; }
                public int citycode { get; set; }
                public int areacode { get; set; }
                public int commentscore { get; set; }
                public int commentcount { get; set; }
                public int likescount { get; set; }
                public int collectscount { get; set; }
                public class SnackFoodType
                {
                    public string food_type_id { get; set; }
                    public object user_id { get; set; }
                    public object food_type_id_p { get; set; }
                    public string food_type_name { get; set; }
                    public object grade { get; set; }
                    public object updated_at { get; set; }
                    public object deleted_at { get; set; }
                    public object created_at { get; set; }
                    public int id { get; set; }
                }
            }
        }


    }
}
