﻿
using Autofac;
using System;
using System.Collections.Generic;
using System.Text;
using TourInfo.Domain;
using TourInfo.Domain.Application.Rapi;
using TourInfo.Domain.Application.SDTA;
using TourInfo.Domain.Application.WHY;
using TourInfo.Domain.Application.ZiBoWechatNews;
using TourInfo.Domain.Base;
using TourInfo.Domain.DomainModel;
using TourInfo.Domain.DomainModel.DataSync;
using TourInfo.Domain.DomainModel.Rapi;
using TourInfo.Domain.DomainModel.SDTA;
using TourInfo.Domain.DomainModel.Weather;
using TourInfo.Domain.DomainModel.WHY;
using TourInfo.Domain.EWQY;
using TourInfo.Domain.EWQY.DomainModel;
using TourInfo.Domain.TourNews;

namespace TourInfo.Domain
{

    public class TourInfoDomainAutofactModel : Autofac.Module
    {

        string zbtaTitleImageBaseUrl;
        string zbtaDetailImageBaseUrl;
        string ewqyImageBaseUrl;
        string zbtaImageClientPath, ewqyImageClientPath, rapiImageClientPath;
        string ewqyLocalSavedPath;
        string zbtaLocalSavedPath;
        string rapi_initurl, rapi_syncurl, rapi_tokenurl, rapi_appid, rapi_appsecret, rapi_localsavedpath;
        string video_baseurl;
        string whyDetailRootUrl;string whyImageSavedPath;string whyListRootUrl; 
            string whyImageClientPath; string whyImageBaseUrl;
        string rapiRootUrl;
        string ziboWechatNewsBaseUrl;

        public TourInfoDomainAutofactModel(string zbtaTitleImageBaseUrl, string zbtaDetailImageBaseUrl, string ewqyImageBaseUrl, string zbtaImageClientPath, string ewqyImageClientPath, string rapiImageClientPath, string ewqyLocalSavedPath, string zbtaLocalSavedPath, string rapi_initurl, string rapi_syncurl, string rapi_tokenurl, string rapi_appid, string rapi_appsecret, string rapi_localsavedpath, string video_baseurl, string whyDetailRootUrl, string whyImageSavedPath, string whyListRootUrl, string whyImageClientPath, string whyImageBaseUrl, string rapiRootUrl,string ziboWechatNewsBaseUrl)
        {
            
            this.zbtaTitleImageBaseUrl = zbtaTitleImageBaseUrl;
            this.zbtaDetailImageBaseUrl = zbtaDetailImageBaseUrl;
            this.ewqyImageBaseUrl = ewqyImageBaseUrl;
            this.zbtaImageClientPath = zbtaImageClientPath;
            this.ewqyImageClientPath = ewqyImageClientPath;
            this.rapiImageClientPath = rapiImageClientPath;
            this.ewqyLocalSavedPath = ewqyLocalSavedPath;
            this.zbtaLocalSavedPath = zbtaLocalSavedPath;
            this.rapi_initurl = rapi_initurl;
            this.rapi_syncurl = rapi_syncurl;
            this.rapi_tokenurl = rapi_tokenurl;
            this.rapi_appid = rapi_appid;
            this.rapi_appsecret = rapi_appsecret;
            this.rapi_localsavedpath = rapi_localsavedpath;
            this.video_baseurl = video_baseurl;
            this.whyDetailRootUrl = whyDetailRootUrl;
            this.whyImageSavedPath = whyImageSavedPath;
            this.whyListRootUrl = whyListRootUrl;
            this.whyImageClientPath = whyImageClientPath;
            this.whyImageBaseUrl = whyImageBaseUrl;
            this.rapiRootUrl = rapiRootUrl;
            this.ziboWechatNewsBaseUrl = ziboWechatNewsBaseUrl;
        }

        protected override void Load(ContainerBuilder builder )
        {
            builder.RegisterType<WeatherApplication>().As<IWeatherApplication>()
                 ;
            builder.RegisterType<ZBTAApplication>().As<IZBTAApplication>().WithParameter("imageClientPath", zbtaImageClientPath)
                .WithParameter("titleImageBaseUrl", zbtaTitleImageBaseUrl)
                .WithParameter("detailImageBaseUrl", zbtaDetailImageBaseUrl)
                 .WithParameter("localSavedPath", zbtaLocalSavedPath)
                ;
            //builder.RegisterType<DetailImageLocalizer>().As<IDetailImageLocalizer>()
            //    .WithParameter("detailImageBaseUrl", zbtaDetailImageBaseUrl)
            //    .WithParameter("localSavedPath", zbtaLocalSavedPath)
            //   ;

            builder.RegisterType<EWQYApplication>().As<IEWQYApplication>()
          .WithParameter("imageBaseUrl", ewqyImageBaseUrl).WithParameter("imageClientPath", ewqyImageClientPath)
          .WithParameter("localSavedPath", ewqyLocalSavedPath)
          ;

            builder.RegisterType<TourInfo.Domain.Application.WHY.WHYApplication>().As<IWHYApplication>()
         .WithParameter("imageBaseUrl", ewqyImageBaseUrl)
         .WithParameter("imageClientPath", ewqyImageClientPath)
         .WithParameter("localSavedPath", ewqyLocalSavedPath)
         ;
      

            builder.RegisterType<DataService>().As<IDataService>()
                 .WithParameter("imageBaseUrl_Ewqy", ewqyImageBaseUrl)
          .WithParameter("imageBaseUrl_Zbta", zbtaTitleImageBaseUrl);

            builder.RegisterType<RapiApplication>().As<IRapiApplication>();

            builder.RegisterType<RapiGraspeService>().As<IRapiGraspeService>()
                    .WithParameter("initUrl", rapi_initurl)
                    .WithParameter("syncUrl", rapi_syncurl)
                    .WithParameter("localSavedPath", rapi_localsavedpath)
                     .WithParameter("imageClientPath", rapiImageClientPath)
                    ;
            builder.RegisterType<TokenManager>().As<ITokenManager>()
                   .WithParameter("appid", rapi_appid)
                   .WithParameter("appsecret", rapi_appsecret)
                    .WithParameter("tokenurl", rapi_tokenurl)
                   ;
            //Video 
            builder.RegisterType<Application.Video.VideoApplication>().As<Application.Video.IVideoApplication>()
                   ;
            builder.RegisterType<DomainModel.Video.GraspeService>().As<DomainModel.Video.IGraspeService>()
                   .WithParameter("baseUrl",   video_baseurl)
                  
                   ;
            //why
            builder.RegisterType<WHYApplication>().As<IWHYApplication>()
                .WithParameter("whyImageBaseUrl",whyImageBaseUrl)
                .WithParameter("whyImageSavedPath", whyImageSavedPath)
                .WithParameter("whyImageClientPath", whyImageClientPath)
                .WithParameter("listRootUrl", whyListRootUrl)
                .WithParameter("detailRootUrl",whyDetailRootUrl)
                ;
            builder.RegisterGeneric(typeof(ListMerger<,>)) .As(typeof(IListMerger<,>)) ; 
            builder.RegisterType<WhyModelMerger>().As<IWhyModelMerger>();
            builder.RegisterType<RapiSync>().As<IRapiSync>()
               .WithParameter("rapiRootUrl", rapiRootUrl)
              
               ;
            //淄博微信数据
            builder.RegisterType<TourInfo.Domain.Application.ZiBoWechatNews.ZiBoWechatNewsApplication>().As<IZiBoWechatNewsApplication>()
;
            builder.RegisterType<TourInfo.Domain.DomainModel.ZiBoWechatNews.Grasper>().As<TourInfo.Domain.DomainModel.ZiBoWechatNews.IGrasper>()
     .WithParameter("baseUrl", ziboWechatNewsBaseUrl)
                ;

            /*sdta*/
                 builder.RegisterType< SDTAApplication>().As<ISDTAApplication>()
;

            base.Load(builder);
        }
    }

}
