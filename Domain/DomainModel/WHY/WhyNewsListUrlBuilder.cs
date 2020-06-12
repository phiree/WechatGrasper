using System;
using System.Collections.Generic;
using System.Text;

namespace TourInfo.Domain.DomainModel.WHY
{
    public class WhyNewsListUrlBuilder : IListUrlBuilder
    {
        string specialProductListUrl = "https://www.sdta.cn/searches/commodity/commodity/_search";

        public string Build()
        {
            return specialProductListUrl;
        }
    }
    public class WhyNewsDetailUrlBuilder : IDetailUrlBuilder<string>
    {

        public string Build(string id)
        {

            return "https://www.sdta.cn/searches/element/ele/_mget";
        }

    }
}
