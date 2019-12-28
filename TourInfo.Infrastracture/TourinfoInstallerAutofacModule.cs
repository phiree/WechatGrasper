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
using TourInfo.Domain.DomainModel.Rapi;
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
            }).AsSelf().InstancePerRequest();
             
            ;
            builder.RegisterGeneric(typeof(BaseEFCoreRepository<,>)).As(typeof(IRepository<,>))
                .InstancePerRequest()
            ;
           // builder.RegisterGeneric(typeof(AdoNetRepository<,>)).As(typeof(IRepository<,>))
           //    .InstancePerLifetimeScope()
           //;
            builder.RegisterGeneric(typeof(VersionedDataEFCoreRepository<,>)).As(typeof(IVersionedRepository<,>))
                .InstancePerRequest()
            ;
            builder.RegisterType<EWQYEFCoreRepository>().As<IEWQYRepository>()
                .InstancePerRequest()
            ;
            builder.RegisterType<MD5Helper>().As<IMD5Helper>()
               .InstancePerRequest()
           ;
            builder.RegisterType<UrlFetcher>().As<IUrlFetcher>()
              .InstancePerLifetimeScope()
           ;
            builder.RegisterType<ImageLocalizer>().As<IImageLocalizer>()
             .InstancePerLifetimeScope()
         ;
            builder.RegisterGeneric(typeof(InfoLocalizer<,>)) .As(typeof(IInfoLocalizer<,>))
           .InstancePerRequest()
       ;
            builder.RegisterGeneric (typeof(SqliteTableCreater<>)).As( typeof(ISqliteTableCreater<>))
                .InstancePerRequest()
                ;
            builder.RegisterType<SqliteDatabaseCreater>().As<ISqliteDatabaseCreater>().InstancePerRequest();
          
            base.Load(builder);
        }
    }
   
}
