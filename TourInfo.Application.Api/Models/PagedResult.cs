using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TourInfo.Application.Api.Models
{
    public class PagedResult<T>
    {
        public IList<T> Data { get; set; }
        public int Total { get; set; }
    }
}
