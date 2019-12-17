using System.Collections.Generic;

namespace TourInfo.Domain.TourNews
{
    public class ZbtaNewsResponse
    {
        public bool success { get; set; }
        public IList<ZbtaNews> TourNews{ get; set; }
    }
}
