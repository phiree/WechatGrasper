
using Autofac;
using System;
using System.Collections.Generic;
using System.Text;
using TourInfo.Domain;
using TourInfo.Domain.Application.Rapi;
using TourInfo.Domain.Base;
using TourInfo.Domain.DomainModel;
using TourInfo.Domain.DomainModel.DataSync;
using TourInfo.Domain.DomainModel.Rapi;
using TourInfo.Domain.DomainModel.ZBTA;
using TourInfo.Domain.EWQY;
using TourInfo.Domain.EWQY.DomainModel;
using TourInfo.Domain.TourNews;

namespace TourInfo.Domain
{

    public class TourInfoDomainAutofactModel_Web : Autofac.Module
    {

        string zbtaTitleImageBaseUrl;
        string zbtaDetailImageBaseUrl;
        string ewqyImageBaseUrl;
        string ewqyLocalSavedPath;
        string zbtaLocalSavedPath;
        string rapi_initurl, rapi_syncurl, rapi_tokenurl, rapi_appid, rapi_appsecret, rapi_localsavedpath;
        public TourInfoDomainAutofactModel_Web(string zbtaTitleImageBaseUrl, string zbtaDetailImageBaseUrl
            , string ewqyImageBaseUrl, string ewqyLocalSavedPath, string zbtaLocalSavedPath,
            string rapi_initurl, string rapi_syncurl, string rapi_tokenurl, string rapi_appid,
            string rapi_appsecret,string rapi_localsavedpath)
        {
            this.zbtaTitleImageBaseUrl = zbtaTitleImageBaseUrl;
            this.zbtaDetailImageBaseUrl = zbtaDetailImageBaseUrl;
            this.ewqyImageBaseUrl = ewqyImageBaseUrl;
            this.ewqyLocalSavedPath = ewqyLocalSavedPath;
            this.zbtaLocalSavedPath = zbtaLocalSavedPath;
            this.rapi_appid = rapi_appid;
            this.rapi_appsecret = rapi_appsecret;
            this.rapi_initurl = rapi_initurl;
            this.rapi_syncurl = rapi_syncurl;
            this.rapi_tokenurl = rapi_tokenurl;
            this.rapi_localsavedpath= rapi_localsavedpath;
        }
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ZBTAApplication>().As<IZBTAApplication>()
                .WithParameter("titleImageBaseUrl", zbtaTitleImageBaseUrl)
                 .WithParameter("localSavedPath", zbtaLocalSavedPath)
                 .InstancePerDependency()
                ;
            builder.RegisterType<DetailImageLocalizer>().As<IDetailImageLocalizer>()
                .WithParameter("detailImageBaseUrl", zbtaDetailImageBaseUrl)
                .WithParameter("localSavedPath", zbtaLocalSavedPath)
                .InstancePerDependency()
               ;

            builder.RegisterType<EWQYApplication>().As<IEWQYApplication>()
          .WithParameter("imageBaseUrl", ewqyImageBaseUrl)
          .WithParameter("localSavedPath", ewqyLocalSavedPath)
         .InstancePerDependency();
            builder.RegisterType<DataService>().As<IDataService>()
                 .WithParameter("imageBaseUrl_Ewqy", ewqyImageBaseUrl)
          .WithParameter("imageBaseUrl_Zbta", zbtaTitleImageBaseUrl).InstancePerDependency();

            builder.RegisterType<RapiApplication>().As<IRapiApplication>().InstancePerDependency();

            builder.RegisterType<RapiGraspeService>().As<IRapiGraspeService>()
                    .WithParameter("initUrl", rapi_initurl)
                    .WithParameter("syncUrl", rapi_syncurl)
                    .WithParameter("localSavedPath", rapi_localsavedpath)
                   .InstancePerDependency();
            builder.RegisterType<TokenManager>().As<ITokenManager>()
                   .WithParameter("appid", rapi_appid)
                   .WithParameter("appsecret", rapi_appsecret)
                    .WithParameter("tokenurl", rapi_tokenurl)
                   .InstancePerDependency();
            base.Load(builder);
        }
    }

}
