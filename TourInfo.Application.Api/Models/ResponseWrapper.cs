using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TourInfo.Application.Api.Models
{
    public class ResponseWrapper<T>
    {
        public ResponseWrapper(T data)
        {
            this.data = data;
        }
        public int code { get;set;}=0;
        public string message { get;set;}
        public T data { get;set;}
    }
    public class ResponseWrapperWithList<T>
    {
        public ResponseWrapperWithList(IList<T> data)
        { 
            this.data=data;
            }
        public int code { get; set; } = 0;
        public string message { get; set; }
        public IList<T> data { get; set; }
    }
}
