
using Autofac;
using System;
using System.Collections.Generic;
using System.Text;
using TourInfo.Domain;
using TourInfo.Domain.Base;
using TourInfo.Domain.DomainModel;
using TourInfo.Domain.DomainModel.DataSync;
using TourInfo.Domain.EWQY;
using TourInfo.Domain.EWQY.DomainModel;
using TourInfo.Domain.TourNews;

namespace TourInfo.Domain
{
   
    public class TourInfoDomainAutofactModel : Autofac.Module {
        
        string zbtaTitleImageBaseUrl;
        string zbtaDetailImageBaseUrl;
        string ewqyImageBaseUrl;
        string ewqyLocalSavedPath;
        string zbtaLocalSavedPath;
        public TourInfoDomainAutofactModel(string zbtaTitleImageBaseUrl,string zbtaDetailImageBaseUrl
            ,string ewqyImageBaseUrl,string ewqyLocalSavedPath,string zbtaLocalSavedPath)
        {
           this.zbtaTitleImageBaseUrl = zbtaTitleImageBaseUrl;
            this.zbtaDetailImageBaseUrl = zbtaDetailImageBaseUrl;
            this.ewqyImageBaseUrl = ewqyImageBaseUrl;
            this.ewqyLocalSavedPath = ewqyLocalSavedPath;
            this.zbtaLocalSavedPath = zbtaLocalSavedPath;
        }
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ZBTAApplication>().As<IZBTAApplication>()
                .WithParameter("titleImageBaseUrl", zbtaTitleImageBaseUrl)
                 .WithParameter("detailImageBaseUrl", zbtaDetailImageBaseUrl)
                 .WithParameter("localSavedPath", zbtaLocalSavedPath)
                ;


            builder.RegisterType<EWQYApplication>().As<IEWQYApplication>()
          .WithParameter("imageBaseUrl", ewqyImageBaseUrl)
          .WithParameter("localSavedPath", ewqyLocalSavedPath)
        
          ;
            builder.RegisterType<DataService>().As<IDataService>();

            base.Load(builder);
        }
    }
   
}
