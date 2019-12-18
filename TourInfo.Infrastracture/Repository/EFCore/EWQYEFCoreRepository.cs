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
    public class EWQYEFCoreRepository : VersionedDataEFCoreRepository<EWQYEntity,string>  , IEWQYRepository
    {
      
        IMD5Helper mD5Helper;
        public EWQYEFCoreRepository(TourInfoDbContext tourInfoDbContext, IMD5Helper mD5Helper)
            :base(tourInfoDbContext, mD5Helper)
        {
              
         

        }

      
    }
}
