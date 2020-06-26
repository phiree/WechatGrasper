using System;
using System.Collections.Generic;
using System.Text;
using TourInfo.Domain.Base;
using TourInfo.Domain.DomainModel.SDTA;

namespace TourInfo.Domain.Services.SDTA
{
   public  class CityGuideGraspeService
    {
        IUrlFetcher urlFetcher;
        string cityGuideUrl;
        IRepository<CityGuide,string > repository;
        public void Graspe()
        {
            string result = urlFetcher.FetchAsync(cityGuideUrl).Result;
            var root = Newtonsoft.Json.JsonConvert.DeserializeObject<CityGuide>(result);
            
        }
    }
}
