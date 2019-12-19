using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
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
        public void ConfigureServices(IServiceCollection services)
        {
            //new TourInfo.Infrastracture.Installer().Install(services
            //    , Configuration.GetConnectionString("TourInfoConnectionString"));
            string connectionString = Configuration.GetConnectionString("TourInfoConnectionString");
            services
            .AddLogging();
              services
           .AddSingleton<IEWQYApplication, EWQYApplication>()
            ;
            services.AddScoped<IZBTAApplication, ZBTAApplication>()
            ;
            services.AddDbContext<TourInfoDbContext>(options
                  => options.UseSqlServer(connectionString), ServiceLifetime.Transient)

            ;
            services.AddScoped(typeof(IRepository<,>), typeof(BaseEFCoreRepository<,>))
            ;
            services.AddScoped(typeof(IVersionedRepository<,>), typeof(VersionedDataEFCoreRepository<,>))


            ;
            services.AddScoped<IEWQYRepository, EWQYEFCoreRepository>()
             ;
            services.AddSingleton<IMD5Helper, MD5Helper>()
               ;
            services.AddSingleton<IUrlFetcher, UrlFetcher>()
               ;
            services.AddSingleton(typeof(ISqliteTableCreater<,>), typeof(SqliteTableCreater<,>))
                ;
            services.AddSingleton<ISqliteDatabaseCreater, SqliteDatabaseCreater>()
               ;
            services.AddScoped<IDataService, DataService>();
            services.AddMvc(x => x.EnableEndpointRouting = false).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            var dataService = services.BuildServiceProvider().GetService<ISqliteDatabaseCreater>();
            var dataService2 = services.BuildServiceProvider().GetService<IDataService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
