using System;
using System.Collections.Generic;
using System.Text;

namespace TourInfo.Domain.DomainModel.SDTA
{

    public class ListPostData:IPagingData
    {
        public int from {get{ return PageIndex*PageSize;} }
        public int size { get{ return PageSize;} }
        
        public PostFilter post_filter { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        public int PageIndex { get;set; }
        [Newtonsoft.Json.JsonIgnore]
        public int PageSize {get;set; }

        public class PostFilter
        {
            public Bool @bool { get; set; }
            public class Bool
            {
                public List<Must> must { get; set; }
                public class Must
                {
                    public Term term { get; set; }
                    public class Term
                    {
                        public string citycode { get; set; }
                    }
                }
            }
        }
    }
}
