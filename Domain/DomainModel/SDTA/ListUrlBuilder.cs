using System;
using System.Collections.Generic;
using System.Text;

namespace TourInfo.Domain.DomainModel.SDTA
{
    public class LineListUrlBuilder : IListUrlBuilder
    {
        string lineListUrl="https://www.sdta.cn/json/lines/list_370300.json?channel=zibo";

        public string Build()
        {
          return lineListUrl;
        }
    }
    public class CityGuideListUrlBuilder : IListUrlBuilder
    {
        string cityGuideListUrl = "https://www.sdta.cn/json/city-guide/370300.json?channel=zibo";

        public string Build()
        {
            return cityGuideListUrl;
        }
    }
}
