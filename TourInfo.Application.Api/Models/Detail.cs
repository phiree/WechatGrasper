using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TourInfo.Application.Api.Models
{
    public class Detail:Summary
    {
        public string Content { get;set;}
    }
    public class SpecialLocalProductSummary:Summary
    { 
        public string Tag { get;set;}
        public string Introduction { get;set;}
        }
}
