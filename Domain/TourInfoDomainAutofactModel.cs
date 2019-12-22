
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
        
        string zbtaImageBaseUrl;
        string ewqyImageBaseUrl;
        public TourInfoDomainAutofactModel(string zbtaImageBaseUrl,string ewqyImageBaseUrl)
        {
           this.zbtaImageBaseUrl = zbtaImageBaseUrl;
            this.ewqyImageBaseUrl = ewqyImageBaseUrl;
        }
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ZBTAApplication>().As<IZBTAApplication>()
                .WithParameter("ZbtaImageBaseUrl", zbtaImageBaseUrl);


            builder.RegisterType<EWQYApplication>().As<IEWQYApplication>()
          .WithParameter("EwqyImageBaseUrl", ewqyImageBaseUrl);
            builder.RegisterType<DataService>().As<IDataService>();

            base.Load(builder);
        }
    }
   
}
