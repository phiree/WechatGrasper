using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TourInfo.Application.Api.Models
{
    public class SpecialProductModel : Detail
    {
        public IList<string> Images{ get;set;}
    }
}
