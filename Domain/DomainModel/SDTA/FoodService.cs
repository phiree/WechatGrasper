using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace TourInfo.Domain.DomainModel.SDTA
{

    public class FoodService
    {
        string foodListUrl;
        int pageSize;
        IUrlFetcher urlFetcher;
        List<FoodDetail.Data> allFoods;
        public Task<IList<FoodDetail.Data>> FetchAsync()
        {
          var result= FetchPageAsync(0);
            throw new NotImplementedException();
             
        }
        public async Task FetchPageAsync(int pageIndex)
        {
            var requestWithPage = new HttpRequestMessage();
            string jsonResult = await urlFetcher.FetchAsync(requestWithPage);

            var pageFoods = JsonConvert.DeserializeObject<IList<FoodDetail.Data>>(jsonResult);
            if (pageFoods.Count > 0)
            {  
                allFoods.AddRange(pageFoods);
                 FetchPageAsync(pageIndex + 1);
            }

        }
    }
}
