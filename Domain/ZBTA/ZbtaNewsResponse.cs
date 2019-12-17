using System.Collections.Generic;

namespace TourInfo.Domain.TourNews
{
    public class ZbtaNewsResponse
    {
        public bool success { get; set; }
        public List<ZbtaNews> TourNews{ get; set; }
    }
}
