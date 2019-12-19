using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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
using TourInfo.Infrastracture.Repository.EFCore;

namespace TourInfo.Infrastracture
{
    public class Installer
    {
        public void Install(IServiceCollection services, string connectionString)
        {

            services
              .AddLogging()
              .AddSingleton<IEWQYApplication, EWQYApplication>()
                .AddSingleton<IZBTAApplication, ZBTAApplication>()
              .AddDbContext<TourInfoDbContext>(options
                   => options.UseSqlServer(connectionString), ServiceLifetime.Transient)

              .AddSingleton(typeof(IRepository<,>), typeof(BaseEFCoreRepository<,>))
               .AddSingleton(typeof(IVersionedRepository<,>), typeof(VersionedDataEFCoreRepository<,>))


               .AddSingleton<IEWQYRepository, EWQYEFCoreRepository>()
                .AddSingleton<IMD5Helper, MD5Helper>()
                 .AddSingleton<IUrlFetcher, UrlFetcher>()
                    .AddSingleton(typeof(ISqliteTableCreater<,>), typeof(SqliteTableCreater<,>))
                     .AddSingleton<ISqliteDatabaseCreater, SqliteDatabaseCreater>()
                      .AddSingleton<IDataService, DataService>();

        }
    }
}
