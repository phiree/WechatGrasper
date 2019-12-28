using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using TourInfo.Domain.Base;
using Dapper;
using TourInfo.Infrastracture.Repository.EFCore;
using TourInfo.Domain;

namespace TourInfo.Infrastracture.Repository.EFCore
{
    public class VersionedDataEFCoreRepository<T,Key>: BaseEFCoreRepository<T,Key>,IVersionedRepository<T,Key>
        where T: Entity<Key>,IHasVersion
 
    {
        IMD5Helper md5Helper;


        public VersionedDataEFCoreRepository(TourInfoDbContext tourInfoDbContext, IMD5Helper md5Helper)
            :base(tourInfoDbContext)
        { 
            this.md5Helper=md5Helper;
        }

        public IList<T> GetAllAfterVersion(string version)
        {
            Func<T, bool> predicate = x => x.Version.CompareTo(version) > 0;
            return FindList(predicate);
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
