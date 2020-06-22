using System;
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
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.OpenApi.Models;
using System.IO;
using System.Reflection;
using Newtonsoft.Json.Converters;

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
            services.AddHttpClient();
            services.AddMvc(x => x.EnableEndpointRouting = false)
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                
                ; 
            services.AddAutoMapper(System.Reflection.Assembly.GetAssembly(typeof(TourinfoDomainAutoMapperProfile))
               , Assembly.GetAssembly(typeof(TourinfoApiAutoMapperProfile)));
            string connectionString = Configuration.GetConnectionString("TourinfoConnectionString");

            //swagger

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo() { Title = "淄博文旅小程序接口文档", Version = "v1" });
                options.CustomSchemaIds(type => type.FullName); // 解决相同类名会报错的问题
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(Directory.GetCurrentDirectory(), xmlFile)); // 标注要使用的 XML 文档
                                                                                                    //  options.IncludeXmlComments(Path.Combine(Directory.GetCurrentDirectory(), "Nokia.GenericExport.Domain.xml")); // 标注要使用的 XML 文档
               // options.DescribeAllEnumsAsStrings();
            });
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
            string whyNewsUrl = Configuration.GetValue<string>("WHY:whyNewsUrl");
            string whyActivityUrl = Configuration.GetValue<string>("WHY:whyActivityUrl");
            string whyImageClientPath = Configuration.GetValue<string>("WHY:whyImageClientPath");
            string whyImageBaseUrl = Configuration.GetValue<string>("WHY:whyImageBaseUrl");
            string rapiRootUrl = Configuration.GetValue<string>("WHY:rapiRootUrl");
            string ziboWechatNewsBaseUrl = Configuration.GetValue<string>("ZiboWechatNews:baseUrl");
            string ziboWechatNewsImageLocalSavedPath = Configuration.GetValue<string>("ZiboWechatNews:imageLocalSavedPath");
            string ziboWechatNewsImageClientPath = Configuration.GetValue<string>("ZiboWechatNews:imageClientPath");


            var containerBuilder = new Autofac.ContainerBuilder();
            containerBuilder.Populate(services);
            containerBuilder.RegisterModule(new TourInfo.Domain.TourInfoDomainAutofactModel
               (zbtaTitleImageBaseUrl, zbtaDetailImageBaseUrl, zbtaImageClientPath, zbtaLocalSavedPath,
             ewqyImageBaseUrl, ewqyImageClientPath, ewqyLocalSavedPath,
             rapiRootUrl, rapiImageClientPath, rapi_initurl, rapi_syncurl, rapi_tokenurl, rapi_appid, rapi_secret, RapiLocalSavedPath,
             video_baseurl,
             whyDetailRootUrl, whyImageSavedPath, whyListRootUrl,whyNewsUrl, whyActivityUrl, whyImageClientPath, whyImageBaseUrl,

             ziboWechatNewsBaseUrl, ziboWechatNewsImageLocalSavedPath, ziboWechatNewsImageClientPath
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
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger Test UI");
            });
        }
    }
}
