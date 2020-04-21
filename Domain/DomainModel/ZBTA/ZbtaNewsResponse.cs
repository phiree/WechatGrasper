using System.Collections.Generic;
using Newtonsoft;

namespace TourInfo.Domain.ZBTA
{
    public class ZbtaNewsResponse
    {
        public bool success { get; set; }
        [Newtonsoft.Json.JsonProperty("object")]
        public IList<ZbtaNews> TourNews{ get; set; }
    }
}
