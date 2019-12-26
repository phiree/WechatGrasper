using Autofac;
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
using TourInfo.Infrastracture.Repository.ADONET;
using TourInfo.Infrastracture.Repository.EFCore;

namespace TourInfo.Infrastracture
{

    public class TourinfoInstallerAutofacModule : Module {
        string connectionString;
         public TourinfoInstallerAutofacModule(string connectionString)
        {
            this.connectionString = connectionString;
            
        }
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c =>
            {
                 var opt = new DbContextOptionsBuilder<TourInfoDbContext>();
                opt.UseSqlServer(connectionString);
                return new TourInfoDbContext(opt.Options);
            }).AsSelf().InstancePerDependency();
             
            ;
            builder.RegisterGeneric(typeof(BaseEFCoreRepository<,>)).As(typeof(IRepository<,>))
                .InstancePerLifetimeScope()
            ;
           // builder.RegisterGeneric(typeof(AdoNetRepository<,>)).As(typeof(IRepository<,>))
           //    .InstancePerLifetimeScope()
           //;
            builder.RegisterGeneric(typeof(VersionedDataEFCoreRepository<,>)).As(typeof(IVersionedRepository<,>))
                .InstancePerLifetimeScope()
            ;
            builder.RegisterType<EWQYEFCoreRepository>().As<IEWQYRepository>()
                .InstancePerLifetimeScope()
            ;
            builder.RegisterType<MD5Helper>().As<IMD5Helper>()
               .SingleInstance()
           ;
            builder.RegisterType<UrlFetcher>().As<IUrlFetcher>()
               .SingleInstance()
           ;
            builder.RegisterType<ImageLocalizer>().As<IImageLocalizer>()
             .SingleInstance()
         ;

            builder.RegisterGeneric (typeof(SqliteTableCreater<>)).As( typeof(ISqliteTableCreater<>))
                .SingleInstance()
                ;
            builder.RegisterType<SqliteDatabaseCreater>().As<ISqliteDatabaseCreater>();
          
            base.Load(builder);
        }
    }
   
}
