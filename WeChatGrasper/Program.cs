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
using TourInfo.Domain.Application.Rapi;
using NLog;
using ILogger = NLog.ILogger;

namespace TourInfo.Application.DataGrasperConsole
{
    class Program
    {

      static  ILogger    logger = LogManager.GetCurrentClassLogger();
        static void Main(string[] args)
        {
           
            string environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            environment = environment ?? "Development";
            IConfigurationBuilder ConfigurationBuilder = new ConfigurationBuilder()
           .SetBasePath(System.IO.Directory.GetCurrentDirectory()) //From NuGet Package Microsoft.Extensions.Configuration.Json
          .AddJsonFile("appsettings.json", true, true)
         .AddEnvironmentVariables();
            Console.WriteLine("是否更新到远程?是=1,否=0");
          if(Console.ReadLine()=="0")
            {
                ConfigurationBuilder= ConfigurationBuilder.AddJsonFile($"appsettings.{environment}.json", true, true);

           }
            var  Configuration = ConfigurationBuilder
          .Build();
            
            logger.Info("开始抓取EWQY数据");
            string _dateVersion = DateTime.Now.ToString("yyyyMMddhhmmss");
            BackgroundWorker ewqyWorker = new BackgroundWorker();
            ewqyWorker.DoWork += (obj, e) => EwqyWorker_DoWork(_dateVersion);
            ewqyWorker.RunWorkerCompleted += EwqyWorker_RunWorkerCompleted;
            ewqyWorker.RunWorkerAsync();
            BackgroundWorker zbtaWorker = new BackgroundWorker();
            zbtaWorker.DoWork += (obj, e) => ZbtaWorker_DoWork(_dateVersion);
            zbtaWorker.RunWorkerCompleted += ZbtaWorker_RunWorkerCompleted;
            zbtaWorker.RunWorkerAsync(argument: _dateVersion);

            BackgroundWorker rapiWorker = new BackgroundWorker();
            rapiWorker.DoWork += (obj, e) => RapiWorker_DoWork(_dateVersion);
            rapiWorker.RunWorkerCompleted += RapiWorker_RunWorkerCompleted;
            rapiWorker.RunWorkerAsync(argument: _dateVersion);

            while (true)
            {
                logger.Info("正在抓取");
                Console.Read();
            }


        }


        
        private static void RapiWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
           logger.Info("rapi抓取完毕");
        }

        private static void RapiWorker_DoWork(string dataVersion)
        {
            var rapiApplication =BootStrap. serviceProvider.GetService<IRapiApplication>();
            rapiApplication.Graspe(dataVersion,true);
        }

        private static void ZbtaWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            logger.Info("zbta抓取完毕");
        }

        private static void ZbtaWorker_DoWork(string dateVersion)
        {
            var zBTAApplication = BootStrap.serviceProvider.GetService<IZBTAApplication>();
            zBTAApplication.Graspe(dateVersion);

        }

        private static void EwqyWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            logger.Info("ewqy抓取完毕");
        }

        private static void EwqyWorker_DoWork(string dateVersion)
        {
            var eWQYApplication = BootStrap.serviceProvider.GetService<IEWQYApplication>();

            eWQYApplication.Graspe(dateVersion);
        }
    }


}

