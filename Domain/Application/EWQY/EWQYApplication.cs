using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TourInfo.Domain.Base;
using TourInfo.Domain.DomainModel.EWQY;
using TourInfo.Domain.DomainModel.Rapi;
using TourInfo.Domain.EWQY.DomainModel;

namespace TourInfo.Domain.EWQY
{
    public class EWQYApplication : IEWQYApplication
    {
        UrlCreator urlCreator = null;
        IUrlFetcher urlFetcher;
        IImageLocalizer imageLocalizer;
        IInfoLocalizer<EWQYPlaceTypeEntity, string> infoLocalizer;
        readonly List<string> apiUrls = new List<string> {
            "venue/findVenueList.action",
             "company/findCompanyList.action",
            "activity/findRegionActivityList.action" };
        readonly IList<string> areaCode = new List<string> { "370300" };
        string _dateVersion;
        static int pageSize = 500;
        Random rm = new Random();

        IEWQYRepository eWQYRepository;
        string imageBaseUrl, localSavedPath,imageClientPath;
        ILoggerFactory loggerFactory;
        ILogger logger;
        ILogger<LocationStringJsonConverter> locationJsonConverterLogger;
        public EWQYApplication(ILoggerFactory loggerFactory,IUrlFetcher urlFetcher, IEWQYRepository eWQYRepository, ILogger<LocationStringJsonConverter> locationJsonConverterLogger
            , string imageBaseUrl, string localSavedPath,string imageClientPath, IImageLocalizer imageLocalizer, IInfoLocalizer<EWQYPlaceTypeEntity, string> infoLocalizer)
        {
            logger=loggerFactory.CreateLogger< EWQYApplication >();
            this.loggerFactory=loggerFactory;
            this.locationJsonConverterLogger=locationJsonConverterLogger;
            this.infoLocalizer = infoLocalizer;
            this.localSavedPath = localSavedPath;
            this.imageLocalizer = imageLocalizer;
            urlCreator = new UrlCreator();
            this.urlFetcher = urlFetcher;
            this.eWQYRepository = eWQYRepository;
            this.imageBaseUrl = imageBaseUrl;
            this.imageClientPath = imageClientPath;


        }
        public void Graspe(string _dateVersion)
        {
            this._dateVersion = _dateVersion; 
            GraspePagedList<CompanyVenue>("venue/findVenueList.action", true, 0, pageSize, order: 0, type: PlaceType.Venue);
            GraspePagedList<CompanyVenue>("company/findCompanyList.action", true, 0, pageSize, order: 0, type: PlaceType.Company);

            GraspePagedList<CompanyVenueType>("venue/findVenueTypeList.action", false, 0, pageSize, order: 0, type: PlaceType.Venue);
            GraspePagedList<CompanyVenueType>("company/findAllType.action", false, 0, pageSize, order: 0, type: PlaceType.Company);

            GraspePagedList<Activity>("activity/findRegionActivityList.action", true, 0, pageSize, type: PlaceType.Venue);
            GraspePagedList<Activity>("activity/findRegionActivityList.action", true, 0, pageSize, type: PlaceType.Company);

            

        }



        public void GraspePagedList<T>(string basePageUrl, bool hasDetailPage
           , int pageIndex, int pageSize
           , PlaceType? type = null, int? order = null)
           where T : EWQYPlaceTypeEntity
        {

            var pagedUrl = urlCreator.CreatePagedUrl(basePageUrl, pageIndex, pageSize, type, order);

            string result = urlFetcher.FetchEWQYAsync(pagedUrl).Result;



            //  contentHandler.HandlerList(result);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject<ListResultWrapper<T>>(result,
                new ImageUrlJsonConverter(), new LocationDoubleArrayJsonConverter(loggerFactory,true)
                );
            var status = jsonResult.status;// jsonResult["status"];
            if (status != 0)
            { throw new Exception("接口返回错误"); }
            var listData = jsonResult.data;
            foreach (var data in listData)
            {
                System.Threading.Thread.Sleep(500 + rm.Next(1, 100));
                if (!hasDetailPage)
                {data.Version=_dateVersion;
                    data.PlaceType=type.Value;
                    eWQYRepository.InsertOrUpdate(data);
                }
                else
                {
                   var existed=eWQYRepository.Get(data.id);
                    if (existed != null) { break;}
                    string detailUrl = urlCreator.CreateDetailUrl(basePageUrl, data.id);
                    string detailResult=string.Empty;
                    try
                    { 
                      detailResult = urlFetcher.FetchEWQYAsync(detailUrl).Result;
                    }
                    catch(Exception ex)
                    { 
                        logger.LogError("url获取失败:"+detailUrl);
                        }
                        var detail = JsonConvert.DeserializeObject<DetailResultWrapper<T>>(detailResult
                        , new ImageUrlJsonConverter(),
                       new LocationStringJsonConverter(locationJsonConverterLogger, true, ';')
                        );
                    CopyValues(detail.data, data);

                    detail.data.PlaceType = type.Value;
                    bool isExisted=false;
                   infoLocalizer.Localize(detail.data,imageBaseUrl,localSavedPath,imageClientPath,_dateVersion,out isExisted);
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
