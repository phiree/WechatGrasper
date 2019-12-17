using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Text;
using Domain;
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

namespace WeChatGrasper
{
    class Program
    {
        
        static void Main(string[] args)
        {
            string environment= Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            environment=environment??"Development";
            IConfiguration config = new ConfigurationBuilder()
          .AddJsonFile("appsettings.json", true, true)
           .AddJsonFile($"appsettings.{environment}.json", true, true)
         .AddEnvironmentVariables()
          .Build();
            var serviceProvider = new ServiceCollection()
           .AddLogging()
           .AddSingleton<IEWQYApplication, EWQYApplication>()
             .AddSingleton<IZBTAApplication, ZBTAApplication > ()
           .AddDbContext<TourInfoDbContext>(options => options.UseSqlServer(config.GetConnectionString("TourInfoConnectionString")))
           .AddSingleton(typeof(IRepository<,>), typeof( BaseEFCoreRepository<,>))
           
            .AddSingleton<IEWQYRepository,EWQYEFCoreRepository>()
             .AddSingleton<IMD5Helper,  MD5Helper>()
              .AddSingleton<IUrlFetcher,  UrlFetcher>()
 
           .BuildServiceProvider();
           
            IEWQYApplication eWQYApplication=serviceProvider.GetService<IEWQYApplication>();
            var zBTAApplication = serviceProvider.GetService<IZBTAApplication>();
            Console.WriteLine("开始抓取EWQY数据");
            string _dateVersion = DateTime.Now.ToString("yyyyMMddhhmmss");
            zBTAApplication.Graspe(_dateVersion);
            //eWQYApplication.Graspe(_dateVersion);

            Console.WriteLine("抓取完毕");

        }
    }
   

}

