using DapperExtensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using TourInfo.Domain;
using TourInfo.Domain.Base;
using TourInfo.Domain.EWQY.DomainModel;

namespace TourInfo.Infrastracture.Repository.EFCore
{
    public class EWQYEFCoreRepository :BaseEFCoreRepository<EWQYEntity,string> , IEWQYRepository
    {
      
        IMD5Helper mD5Helper;
        public EWQYEFCoreRepository(TourInfoDbContext tourInfoDbContext, IMD5Helper mD5Helper)
            :base(tourInfoDbContext)
        {
              
            this.mD5Helper = mD5Helper;

        }
        public void SaveOrUpdate(EWQYEntity entity,string newVersion )
        {

          var existedEntity=Get(entity.id);
            string fingerprint = entity.CalculateFingerprint(mD5Helper);
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
