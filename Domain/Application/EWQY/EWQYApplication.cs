using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TourInfo.Domain.Base;
using TourInfo.Domain.EWQY.DomainModel;

namespace TourInfo.Domain.EWQY
{
    public class EWQYApplication : IEWQYApplication
    {
        UrlCreator urlCreator = null;
        IUrlFetcher urlFetcher;
        IImageLocalizer imageLocalizer;
        readonly List<string> apiUrls = new List<string> {
            "venue/findVenueList.action",
             "company/findCompanyList.action",
            "activity/findRegionActivityList.action" };
        readonly IList<string> areaCode = new List<string> { "370300" };
        static readonly string _dateVersion = DateTime.Now.ToString("yyyyMMddhhmmss");
        static int pageSize = 500;
        Random rm = new Random();

        IEWQYRepository eWQYRepository;
        public EWQYApplication(IUrlFetcher urlFetcher, IEWQYRepository eWQYRepository, IImageLocalizer imageLocalizer)
        {
            this.imageLocalizer=imageLocalizer;
            urlCreator = new UrlCreator();
            this.urlFetcher = urlFetcher;
            this.eWQYRepository = eWQYRepository;
            

        }
        public void Graspe(string _dateVersion)
        {

            foreach (var apiUrl in apiUrls)
            {
                if (apiUrl == "activity/findRegionActivityList.action")
                {
                    GraspePagedList<Activity>(apiUrl, 0, pageSize, type: PlaceType.Venue);
                    GraspePagedList<Activity>(apiUrl, 0, pageSize, type: PlaceType.Company);
                }
                else
                {
                    GraspePagedList<CompanyVenue>(apiUrl, 0, pageSize, order: 0);

                }
            }
        }

        public void GraspePagedList<T>(string basePageUrl
           , int pageIndex, int pageSize
           , PlaceType? type = null, int? order = null)
           where T : EWQYEntity
        {

            var pagedUrl = urlCreator.CreatePagedUrl(basePageUrl, pageIndex, pageSize, type, order);

            string result = urlFetcher.FetchEWQYAsync(pagedUrl).Result;
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
                string detailResult = urlFetcher.FetchEWQYAsync(detailUrl).Result;
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
                }
                //活动
                else if (type.HasValue)
                    {
                         
                            detail.data.PlaceType = type.Value;
                      
                   
                }
                eWQYRepository.SaveOrUpdate(detail.data, _dateVersion);
                //图片本地化

                string defaultUrl = "http://aaa.bbb";
                if (typeof(T) == typeof(CompanyVenue))
                {
                    var company =  detail.data as CompanyVenue;
                    List<string> newImageUrls = new List<string>();
                    foreach (string picUrl in company.pictureKeys)
                    {

                        string imageFullUrl = defaultUrl + picUrl;
                        string fileName = Guid.NewGuid() + ".jpg";
                        urlFetcher.FetchFile(imageFullUrl, fileName);
                        newImageUrls.Add(fileName);


                    }
                }
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
