using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Text;

using TourInfo.Domain.EWQY;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TourInfo.Domain.Base;
using TourInfo.Infrastracture.Repository.EFCore;
using TourInfo.Domain.EWQY.DomainModel;
using TourInfo.Domain;
using TourInfo.Infrastracture;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TourInfo.Domain.TourNews;
using System.Threading;
using System.ComponentModel;
using Autofac.Extensions.DependencyInjection;
using Autofac;

namespace WeChatGrasper
{
    class Program
    {
        static IServiceProvider serviceProvider;
        static void Main(string[] args)
        {
            string environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            environment = environment ?? "Development";
            IConfiguration Configuration = new ConfigurationBuilder()
          .AddJsonFile("appsettings.json", true, true)
           .AddJsonFile($"appsettings.{environment}.json", true, true)
         .AddEnvironmentVariables()
          .Build();
            ServiceCollection services = new ServiceCollection();

            string connectionString = Configuration.GetConnectionString("TourinfoConnectionString");
            string zbtaTitleImageBaseUrl = Configuration.GetValue<string>("ImageLocalizer:ZbtaTitleImageBaseUrl");
            string zbtaDetailImageBaseUrl= Configuration.GetValue<string>("ImageLocalizer:ZbtaDetailImageBaseUrl");
            string  ewqyImageBaseUrl = Configuration.GetValue<string>("ImageLocalizer:EwqyImageBaseUrl");
            string zbtaLocalSavedPath = Configuration.GetValue<string>("ImageLocalizer:ZbtaLocalSavedPath");
            string ewqyLocalSavedPath = Configuration.GetValue<string>("ImageLocalizer:EwqyLocalSavedPath");
           
            var containerBuilder = new Autofac.ContainerBuilder();
            containerBuilder.Populate(services);
            containerBuilder.RegisterModule(new TourInfo.Domain.TourInfoDomainAutofactModel
                ( zbtaTitleImageBaseUrl,zbtaDetailImageBaseUrl, ewqyImageBaseUrl,ewqyLocalSavedPath,zbtaLocalSavedPath));
            containerBuilder.RegisterModule(new TourInfo.Infrastracture.TourinfoInstallerAutofacModule
               (connectionString));
            var container = containerBuilder.Build();
            serviceProvider = new AutofacServiceProvider(container);


            Console.WriteLine("开始抓取EWQY数据");
            string _dateVersion = DateTime.Now.ToString("yyyyMMddhhmmss");
            BackgroundWorker ewqyWorker = new BackgroundWorker();
            ewqyWorker.DoWork += (obj, e) => EwqyWorker_DoWork(_dateVersion);
            ewqyWorker.RunWorkerCompleted += EwqyWorker_RunWorkerCompleted;
            ewqyWorker.RunWorkerAsync();
            BackgroundWorker zbtaWorker = new BackgroundWorker();
            zbtaWorker.DoWork += (obj, e) => ZbtaWorker_DoWork(_dateVersion);
            zbtaWorker.RunWorkerCompleted += ZbtaWorker_RunWorkerCompleted;
            zbtaWorker.RunWorkerAsync(argument: _dateVersion);

            while (true)
            {
                Console.WriteLine("正在抓取");
                Console.Read();
            }


        }

        private static void ZbtaWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Console.WriteLine("zbta抓取完毕");
        }

        private static void ZbtaWorker_DoWork(string dateVersion)
        {
            var zBTAApplication = serviceProvider.GetService<IZBTAApplication>();
            zBTAApplication.Graspe(dateVersion);

        }

        private static void EwqyWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Console.WriteLine("ewqy抓取完毕");
        }

        private static void EwqyWorker_DoWork(string dateVersion)
        {
            var eWQYApplication = serviceProvider.GetService<IEWQYApplication>();

            eWQYApplication.Graspe(dateVersion);
        }
    }


}

