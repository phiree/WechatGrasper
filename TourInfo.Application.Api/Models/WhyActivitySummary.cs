﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TourInfo.Application.Api.Models
{
    public   class ActivitySummary:Summary
    {
        
        public string   StartDate { get; set; }
        public string EndDate { get; set; }
    }
}
