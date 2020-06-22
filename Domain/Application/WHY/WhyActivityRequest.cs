using RestSharp;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;
using TourInfo.Domain.DomainModel;

namespace TourInfo.Domain.Application.WHY
{
    public class WhyActivityRequest:IRequestWithPaging
    {
        
        public int currentPage { get; set; }
        public string categoryId { get; set; }
        public string areaId { get; set; }
        public string villageId { get; set; }
        public int lineSize { get; set; }
        public int PageIndex { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int PageSize { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public IRequestWithPaging BuildNextPageRequest()
        { 
             currentPage+=1;
            return this;
            }
        public IList<Parameter> CreateParameters()
        { 
            return new List<Parameter> { 
                new Parameter("currentPage",currentPage, ParameterType.GetOrPost),
                new Parameter("categoryId",categoryId, ParameterType.GetOrPost),
                new Parameter("areaId",areaId, ParameterType.GetOrPost),
                new Parameter("villageId",villageId, ParameterType.GetOrPost),
                 new Parameter("lineSize",lineSize, ParameterType.GetOrPost),
                };
            }

        
    }
}
