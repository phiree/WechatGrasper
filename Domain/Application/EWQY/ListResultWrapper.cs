using System.Collections.Generic;

namespace TourInfo.Domain.EWQY
{
    public class ListResultWrapper<T> : ResultWrapper
    {
        public IList<T> data { get; set; }
    }

}

