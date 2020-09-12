using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TourInfo.Application.Api.Models
{
    public class SpecialLocalProductSummary 
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string Date { get; set; }
        public string Tag { get; set; }
        public string Introduction { get; set; }
        
    }

    public class SpecialLocalProductDetailModel : SpecialLocalProductSummary
    {
        public string Content { get; set; }
        public IList<string> Images { get; set; }


    }
}
