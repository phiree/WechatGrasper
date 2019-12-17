using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using TourInfo.Domain.Base;
using Dapper;
using DapperExtensions;
using TourInfo.Infrastracture.Repository.EFCore;
using TourInfo.Domain;

namespace TourInfo.Infrastracture.Repository.EFCore
{
    public class VersionedDataEFCoreRepository<T>: BaseEFCoreRepository<T,string>,IVersionedRepository<T,string>
        where T: Entity,IHasVersion
    {
        IMD5Helper md5Helper;


        public VersionedDataEFCoreRepository(TourInfoDbContext tourInfoDbContext, IMD5Helper md5Helper)
            :base(tourInfoDbContext)
        { 
            this.md5Helper=md5Helper;
        }

        public void SaveOrUpdate(T entity, string newVersion)
        {
            var existedEntity = Get(entity.id);
            string fingerprint = entity.CalculateFingerprint(md5Helper);
            /**/
            if (existedEntity == null)
            {
                entity.UpdateVersion(fingerprint, newVersion);
                Insert(entity);
            }
            else
            {

                if (fingerprint != existedEntity.Fingerprint)
                {

                    existedEntity.UpdateVersion(fingerprint, newVersion);
                    Update(existedEntity);
                }
            }
        }
    }
}
