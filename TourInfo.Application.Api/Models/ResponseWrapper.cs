using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TourInfo.Application.Api.Models
{
    public class ResponseWrapper<T>
    {
        
        public int code { get;set;}=0;
        public string message { get;set;}
        public T data { get;set;}
    }
    public class ResponseWrapperWithList<T>
    {

        public int code { get; set; } = 0;
        public string message { get; set; }
        public List<T> data { get; set; }
    }
}
