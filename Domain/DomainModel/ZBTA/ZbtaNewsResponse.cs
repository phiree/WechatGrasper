using System.Collections.Generic;
using Newtonsoft;
namespace TourInfo.Domain.TourNews
{
    public class ZbtaNewsResponse
    {
        public bool success { get; set; }
        [Newtonsoft.Json.JsonProperty("object")]
        public IList<ZbtaNews> TourNews{ get; set; }
    }
}
