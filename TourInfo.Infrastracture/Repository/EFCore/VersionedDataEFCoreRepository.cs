﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using TourInfo.Domain.Base;
using Dapper;
using TourInfo.Infrastracture.Repository.EFCore;
using TourInfo.Domain;
using Microsoft.Extensions.Logging;

namespace TourInfo.Infrastracture.Repository.EFCore
{
    public class VersionedDataEFCoreRepository<T,Key>: BaseEFCoreRepository<T,Key>,IVersionedRepository<T,Key>
        where T: Entity<Key>,IHasVersion
 
    {
        IMD5Helper md5Helper;
        ILogger logger;

        public VersionedDataEFCoreRepository(TourInfoDbContext tourInfoDbContext, IMD5Helper md5Helper,ILoggerFactory loggerFactory)
            :base(tourInfoDbContext)
        {
            this.logger = loggerFactory.CreateLogger<VersionedDataEFCoreRepository<T,Key>>();
            this.md5Helper=md5Helper;
        }

        public IList<T> GetAllAfterVersion(string version)
        {
            logger.LogInformation("开始获取 " + typeof(T));
            Func<T, bool> predicate = x => x.Version.CompareTo(version) > 0;
            var result= FindList(predicate);
            logger.LogInformation("结果数据条数: " + result.Count);
            return result;
        }

        public void SaveOrUpdate(T entity, string newVersion)
        {
            var existedEntity = Get(entity.id);
            
            if (existedEntity != null) { return;}
             //不再计算fingerprint,直接判断id是否存在
                entity.UpdateVersion(string.Empty, newVersion);
                Insert(entity);
            
        }
    }
}
