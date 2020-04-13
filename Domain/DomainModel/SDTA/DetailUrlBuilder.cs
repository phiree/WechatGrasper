using System;
using System.Collections.Generic;
using System.Text;

namespace TourInfo.Domain.DomainModel.SDTA
{
    public class LineDetailUrlBuilder : IDetailUrlBuilder<string>
    {

        public string Build(string id)
        {

            return "https://www.sdta.cn/json/lines/" + id + ".json?channel=zibo";
        }
    }
    public class LineDetailScenicUrlBuilder : IDetailUrlBuilder<string>
    {

        public string Build(string id)
        {

            return "https://www.sdta.cn/searches/element/ele/_mget";
        }
    }
    public class CityGuideDetailUrlBuilder : IDetailUrlBuilder<string>
    {

        public string Build(string id)
        {

            return "https://www.sdta.cn/api/eledetail/geteledetailbyid.jsp?eleid="+id+"&eletype=article&channel=zibo";
        }
    }
    public class FoodDetailUrlBuilder : IDetailUrlBuilder<int>
    {

        public string Build(int id)
        {

            return "https://www.sdta.cn/api/eledetail/geteledetailbyid.jsp?eleid="+id+"&eletype=snack&channel=zibo";
        }
    }
}
