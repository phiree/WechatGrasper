using System;
using System.Collections.Generic;
using System.Text;
using TourInfo.Domain.Base;

namespace TourInfo.Domain.DomainModel.SDTA
{
   
    public class CityGuideDetail:IDetailWrapper<CityGuideDetail.Data>
    {
        public bool error { get; set; }
        public string message { get; set; }
        public Data data { get; set; }

        public Data Detail => data;

        public class Data:VersionedEntity<string>
        {
            public override string id { get{ return slug ;}set{ slug=value;} }

             public int detailid { get;set;}
            public string name { get; set; }
           
            public    string slug { get; set; }
            public string description { get; set; }
            public string content { get; set; }
            public int status { get; set; }
            public int user_id { get; set; }
            public string cms_user_id { get; set; }
            public int featured { get; set; }
            public int rank { get; set; }
            public int primary_category { get; set; }
            public ImageUrl image { get; set; }
            public int views { get; set; }
            public string author { get; set; }
            public string created_at { get; set; }
            public string updated_at { get; set; }
            public string commentscore { get; set; }
            public int commentcount { get; set; }
            public int likescount { get; set; }
            public int collectscount { get; set; }
           
        
            public Pics pics { get; set; }
            
           
           
            public class Pics
            {
                public int id { get; set; }
                public int content_id { get; set; }
                public List<Image> images { get; set; }
                public string reference { get; set; }
                public string created_at { get; set; }
                public string updated_at { get; set; }
                public string deleted_at { get; set; }
                public class Image
                {
                    public ImageUrl img { get; set; }
                    public string description { get; set; }
                }
            }
        }
    }
}
