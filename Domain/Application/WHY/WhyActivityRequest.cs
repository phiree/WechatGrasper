using RestSharp;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;
using TourInfo.Domain.DomainModel;

namespace TourInfo.Domain.Application.WHY
{
    public class WhyActivityRequest : IRequestWithPaging
    {
        public WhyActivityRequest(int pageIndex, int pageSize)
        {
            this.PageIndex = pageIndex;
            this.PageSize = pageSize;
        }

        public int currentPage { get; set; }
        public string categoryId { get; set; }
        public string area { get; set; } = "全部区域";
        public int lineSize { get; set; }
        public int PageIndex { get => currentPage; set => currentPage = value; }
        public int PageSize { get => lineSize; set => lineSize = value; }

        public IRequestWithPaging BuildNextPageRequest()
        {
            currentPage += 1;
            return this;
        }
        public IList<Parameter> CreateParameters()
        {
            return new List<Parameter> {
                new Parameter("currentPage",currentPage, ParameterType.GetOrPost),

                new Parameter("area",area, ParameterType.GetOrPost),

                 new Parameter("lineSize",lineSize, ParameterType.GetOrPost),
                };
        }


    }
}
