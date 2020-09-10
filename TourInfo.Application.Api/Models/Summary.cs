using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TourInfo.Application.Api.Models
{
    public   class Summary
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string Date { get; set; }
    }
    public class SpecialLocalProductSummar:Summary
    { 
        public string Tag { get;set;}
        public string Introduction { get;set;}
        }
 
}
