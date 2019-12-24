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
        //insert new , update exists, no change.
        public VersionedDataUpdateType SaveOrUpdate(T entity, string newVersion)
        {
            var existedEntity = Get(entity.id);
            string fingerprint = entity.CalculateFingerprint(md5Helper);
            /**/
            if (existedEntity == null)
            {
                entity.UpdateVersion(fingerprint, newVersion);
                Insert(entity);
                return VersionedDataUpdateType.Added;
            }
            else
            {

                if (fingerprint != existedEntity.Fingerprint)
                {

                    existedEntity.UpdateVersion(fingerprint, newVersion);
                    Update(existedEntity);
                    return VersionedDataUpdateType.Updated;
                }
                else {
                    return VersionedDataUpdateType.NoChange;
                }
            }
        }
    }
}
