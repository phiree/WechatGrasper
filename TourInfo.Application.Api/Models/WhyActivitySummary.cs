using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TourInfo.Application.Api.Models
{
    public   class WhyActivitySummary:Summary
    {
        
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
