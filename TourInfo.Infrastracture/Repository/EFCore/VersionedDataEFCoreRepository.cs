using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using TourInfo.Domain.Base;
using Dapper;
using TourInfo.Infrastracture.Repository.EFCore;
using TourInfo.Domain;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace TourInfo.Infrastracture.Repository.EFCore
{
    public class VersionedDataEFCoreRepository<T,Key>: BaseEFCoreRepository<T,Key>,IVersionedRepository<T,Key>
        where T: class,IEntity<Key>,IHasVersion
 
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
            try
            {
                Func<T, bool> predicate = x => x.Version.CompareTo(version) > 0;

                var result = FindList(predicate);
                logger.LogInformation("结果数据条数: " + result.Count);
                return result;
            }
            catch {
                string msg = $"获取新版本数据失败.目标类型:[{typeof(T)}].可能是该表对应的version为空";
                logger.LogError(msg);
                throw new Exception(msg);
            }
        }
        public IList<T> FindByFingerPrint(string fingerPrint)
        {
           
                Func<T, bool> predicate = x => x.Fingerprint==fingerPrint;

                var result = FindList(predicate);
                
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
