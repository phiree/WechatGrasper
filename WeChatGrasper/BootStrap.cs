﻿using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace TourInfo.Application.DataGrasperConsole
{
    public class BootStrap
    {
        public static IServiceProvider serviceProvider { get; private set; }
        public static void Boot(IConfiguration Configuration)
        {
            ServiceCollection services = new ServiceCollection();
            services.AddLogging(loggingBuilder =>
            {
                // configure Logging with NLog
                loggingBuilder.ClearProviders();
                loggingBuilder.SetMinimumLevel(LogLevel.Trace);
                loggingBuilder.AddNLog(Configuration);
            });

           
            var containerBuilder = new Autofac.ContainerBuilder();
            containerBuilder.Populate(services);
            //register modules
            string connectionString = Configuration.GetConnectionString("TourinfoConnectionString");
            string zbtaTitleImageBaseUrl = Configuration.GetValue<string>("ImageLocalizer:ZbtaTitleImageBaseUrl");
            string zbtaDetailImageBaseUrl = Configuration.GetValue<string>("ImageLocalizer:ZbtaDetailImageBaseUrl");
            string ewqyImageBaseUrl = Configuration.GetValue<string>("ImageLocalizer:EwqyImageBaseUrl");
            string zbtaLocalSavedPath = Configuration.GetValue<string>("ImageLocalizer:ZbtaLocalSavedPath");
            string ewqyLocalSavedPath = Configuration.GetValue<string>("ImageLocalizer:EwqyLocalSavedPath");
            string zbtaImageClientPath = Configuration.GetValue<string>("ImageLocalizer:ZbtaImageClientPath");
            string ewqyImageClientPath = Configuration.GetValue<string>("ImageLocalizer:EwqyImageClientPath");
            string rapiImageClientPath = Configuration.GetValue<string>("Rapi:RapiImageClientPath");

            string rapi_appid = Configuration.GetValue<string>("Rapi:appid");
            string rapi_secret = Configuration.GetValue<string>("Rapi:appsecret");
            string rapi_tokenurl = Configuration.GetValue<string>("Rapi:tokenurl");
            string rapi_initurl = Configuration.GetValue<string>("Rapi:initurl");
            string rapi_syncurl = Configuration.GetValue<string>("Rapi:syncurl");
            string RapiLocalSavedPath = Configuration.GetValue<string>("Rapi:RapiLocalSavedPath");
            string video_baseurl = Configuration.GetValue<string>("Video:baseUrl");
            string whyDetailRootUrl = Configuration.GetValue<string>("WHY:whyDetailRootUrl");
            string whyImageSavedPath = Configuration.GetValue<string>("WHY:whyImageSavedPath");
            string whyListRootUrl = Configuration.GetValue<string>("WHY:whyListRootUrl");
            string whyImageClientPath = Configuration.GetValue<string>("WHY:whyImageClientPath");
            string whyImageBaseUrl = Configuration.GetValue<string>("WHY:whyImageBaseUrl");
            containerBuilder.RegisterModule(new TourInfo.Domain.TourInfoDomainAutofactModel
                (zbtaTitleImageBaseUrl, zbtaDetailImageBaseUrl, ewqyImageBaseUrl, ewqyLocalSavedPath, zbtaLocalSavedPath, zbtaImageClientPath
                , ewqyImageClientPath, rapiImageClientPath
                 , rapi_initurl, rapi_syncurl, rapi_tokenurl, rapi_appid, rapi_secret, RapiLocalSavedPath, video_baseurl
                 , whyDetailRootUrl, whyImageSavedPath, whyListRootUrl, whyImageClientPath, whyImageBaseUrl));
            containerBuilder.RegisterModule(new  Infrastracture.TourinfoInstallerAutofacModule
               (connectionString));
            var container = containerBuilder.Build();


            serviceProvider = new AutofacServiceProvider(container);
        }
    }
}
