using System;
using System.Collections.Generic;
using System.Text;
using TourInfo.Domain.Base;

namespace TourInfo.Domain.DomainModel.SDTA
{


    public class LineDetailScenic : VersionedEntity<string>
    {
        public override string id { get; set; }

        public List<Doc> docs { get; set; }
        public class Doc
        {
            public string _index { get; set; }
            public string _type { get; set; }
            public string _id { get; set; }
            public int _version { get; set; }
            public bool found { get; set; }
            public Source _source { get; set; }
            public class Source : VersionedEntity<string>
            {
                public override string id
                {
                    get { return ele_type + "_" + ele_id; }

                    set { ele_id = value.Split('_')[1]; ele_type = value.Split('_')[0]; }
                }
                public string ele_id { get; set; }
                public string ele_type { get; set; }
                public string ele_type_name { get; set; }
                public string name_cn { get; set; }
                public string address { get; set; }
                public ImageUrl default_photo { get; set; }
                public string description { get; set; }
                public string contact { get; set; }
                public int level { get; set; }
                public int city { get; set; }
                public string area { get; set; }
                public int rank { get; set; }
                public List<Eletype> eletype { get; set; }
                public string ele_type_name_en { get; set; }
                public string lvl1 { get; set; }
                public int city_order { get; set; }
                public string level_name { get; set; }
                public int date_for_order { get; set; }
                public List<double> location { get; set; }
                public string buyable { get; set; }
                public double lowest_price { get; set; }


                public class Eletype : GuidEntity
                {
                    public int level { get; set; }
                    public string value { get; set; }
                    public string[] ancestors { get; set; }
                }
            }
        }
    }
}
