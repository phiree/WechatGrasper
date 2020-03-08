﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NLog.Extensions.Logging;
using NLog.Web;
using TourInfo.Domain;
using TourInfo.Domain.Base;
using TourInfo.Domain.DomainModel;
using TourInfo.Domain.DomainModel.DataSync;
using TourInfo.Domain.EWQY;
using TourInfo.Domain.EWQY.DomainModel;
using TourInfo.Domain.TourNews;
using TourInfo.Infrastracture;
using TourInfo.Infrastracture.Repository.EFCore;

namespace TourInfo.Application.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            
            services.AddMvc(x => x.EnableEndpointRouting = false).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddAutoMapper(System.Reflection.Assembly.GetAssembly(typeof(TourinfoDomainAutoMapperProfile)));
            string connectionString = Configuration.GetConnectionString("TourinfoConnectionString");
            //services.AddDbContext<TourInfoDbContext>(options =>
            //   options.UseSqlServer(connectionString),

           
          
            //   // By registering the DbContext as transient, we can get unique instances
            //   // for each thread worker (even within a single scope), as demonstrated in
            //   // Fix #1 in BooksController.cs.
            //   ServiceLifetime.Transient);
              services.AddLogging(loggingBuilder =>
            {
                // configure Logging with NLog
                loggingBuilder.ClearProviders();
                loggingBuilder.SetMinimumLevel(LogLevel.Trace);
                loggingBuilder.AddNLog(Configuration);
            });


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
            string rapiRootUrl = Configuration.GetValue<string>("WHY:rapiRootUrl");
            string ziboWechatNewsBaseUrl = Configuration.GetValue<string>("ZiboWechatNews:baseUrl");
            var containerBuilder = new Autofac.ContainerBuilder();
            containerBuilder.Populate(services);
            containerBuilder.RegisterModule(new TourInfo.Domain.TourInfoDomainAutofactModel
               (zbtaTitleImageBaseUrl, zbtaDetailImageBaseUrl, ewqyImageBaseUrl, ewqyLocalSavedPath, zbtaLocalSavedPath,zbtaImageClientPath
               ,ewqyImageClientPath,rapiImageClientPath
                , rapi_initurl, rapi_syncurl, rapi_tokenurl, rapi_appid, rapi_secret, RapiLocalSavedPath, video_baseurl
                ,whyDetailRootUrl,whyImageSavedPath,whyListRootUrl, whyImageClientPath,whyImageBaseUrl,rapiRootUrl,
                ziboWechatNewsBaseUrl
                ));
            containerBuilder.RegisterModule(new TourInfo.Infrastracture.TourinfoInstallerAutofacModule
               (connectionString));
            var container = containerBuilder.Build();
            var serviceProvider = new AutofacServiceProvider(container);
            return serviceProvider;




        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
                 app.UseDeveloperExceptionPage();
            //}

            app.UseMvc();
        }
    }
}
