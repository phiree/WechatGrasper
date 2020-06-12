using RestSharp;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace TourInfo.Domain.Application.WHY
{
    public class WhyNewsRequest
    {
        
        public int currentPage { get; set; }
        public string categoryId { get; set; }
        public string areaId { get; set; }
        public string villageId { get; set; }
        public int lineSize { get; set; }
        public WhyNewsRequest BuildNextPageRequest()
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
