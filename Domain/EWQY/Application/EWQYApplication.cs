using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TourInfo.Domain.Base;

namespace TourInfo.Domain.EWQY
{
    public class EWQYApplication
    {
        UrlCreator urlCreator = null;
        IUrlFetcher urlFetcher;
        readonly List<string> apiUrls = new List<string> {
            "venue/findVenueList.action",
             "company/findCompanyList.action",
            "activity/findRegionActivityList.action" };
        readonly IList<string> areaCode = new List<string> { "370300" };
        static readonly string _dateVersion = DateTime.Now.ToString("yyyyMMddhhmmss");
        static int pageSize = 500;
        Random rm = new Random();

        IRepository<EWQYEntity> repository;
        public EWQYApplication(IUrlFetcher urlFetcher, IRepository<EWQYEntity> repository)
        {
            urlCreator = new UrlCreator();
            this.urlFetcher = urlFetcher;
            this.repository = repository;
           
        }
        public void Graspe()
        {
           
            foreach (var apiUrl in apiUrls)
            {
                if (apiUrl == "activity/findRegionActivityList.action")
                {
                    GraspePagedList<Activity>(apiUrl, 0, pageSize, type: 0);
                    GraspePagedList<Activity>(apiUrl, 0, pageSize, type: 1);
                }
                else
                {
                    GraspePagedList<CompanyVenue>(apiUrl, 0, pageSize, order: 0);

                }
            }
        }

        public void GraspePagedList<T>(string basePageUrl
           , int pageIndex, int pageSize
           , int? type = null, int? order = null)
           where T : EWQYEntity
        {

            var pagedUrl = urlCreator.CreatePagedUrl(basePageUrl, pageIndex, pageSize, type, order);

            string result = urlFetcher.FetchAsync(pagedUrl).Result;
            //  contentHandler.HandlerList(result);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject<ListResultWrapper<T>>(result);
            var status = jsonResult.status;// jsonResult["status"];
            if (status != 0)
            { throw new Exception("接口返回错误"); }
            var listData = jsonResult.data;
            foreach (var data in listData)
            {
                System.Threading.Thread.Sleep(500 + rm.Next(1, 100));
                string detailUrl = urlCreator.CreateDetailUrl(basePageUrl, data.id);
                string detailResult = urlFetcher.FetchAsync(detailUrl).Result;
                var detail = JsonConvert.DeserializeObject<DetailResultWrapper<T>>(detailResult);
                CopyValues(detail.data, data);
                if (typeof(T) == typeof(CompanyVenue))
                {
                    if (basePageUrl == "venue/findVenueList.action")
                    { detail.data.PlaceType = PlaceType.Venue; }
                    else if (basePageUrl == "company/findCompanyList.action")
                    {
                        detail.data.PlaceType = PlaceType.Company;
                    }
                    //活动
                    else if (type.HasValue)
                    {
                        if (type.Value == 1)
                        {
                            detail.data.PlaceType = PlaceType.Company;
                        }
                        else
                        {
                            detail.data.PlaceType = PlaceType.Venue;
                        }
                    }
                }
                repository.SaveOrUpdate(detail.data, _dateVersion);
                //  contentHandler.HandlerDetail(data.id, detail);
            }
             




        }
        public void CopyValues<T>(T target, T source)
        {
            Type t = typeof(T);

            var properties = t.GetProperties().Where(prop => prop.CanRead && prop.CanWrite);

            foreach (var prop in properties)
            {
                var value = prop.GetValue(source, null);
                if (value != null)
                    prop.SetValue(target, value, null);
            }
        }

    }
}
