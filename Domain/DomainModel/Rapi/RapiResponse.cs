using System;
using System.Collections.Generic;
using System.Text;
using TourInfo.Domain.DomainModel.Rapi;

namespace TourInfo.Domain.DomainModel.Rapi
{
    public class RapiResponse 
    { 
        public RapiResponseData data {get;set; }
        public int code { get; set; }
        public string message { get; set; }
        }
    public class RapiResponseData
    {
        public Projectinfo projectinfo { get; set; }
        public List<Typeinfo> typeinfoes { get; set; }
        public List<Typefield> typefields { get; set; }
        public List<Typetag> typetags { get; set; }
        public List<Typepic> typepics { get; set; }
        public List<Pubinfounit> pubinfounits { get; set; }
        public List<Pubunittag> pubunittags { get; set; }
        public List<Pubmediainfo> pubmediainfoes { get; set; }
        public List<Pubinfounitchild> pubinfounitchilds { get; set; }
    }
}
