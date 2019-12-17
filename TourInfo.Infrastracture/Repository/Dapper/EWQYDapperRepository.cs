using DapperExtensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using TourInfo.Domain;
using TourInfo.Domain.Base;
using TourInfo.Domain.EWQY.DomainModel;

namespace TourInfo.Infrastracture.Repository.Dapper
{
    public class EWQYDapperRepository : BaseDapperRepository<EWQYEntity,string> , IEWQYRepository
    {
        
        IMD5Helper mD5Helper;
        public EWQYDapperRepository(string connectionString, IMD5Helper mD5Helper)
            :base(connectionString)
        {
            // this.connectionString = "server=.;Integrated Security=true;database=ewqy;";
          //  this.connectionString =connectionString;// "server=114.55.59.143,1430;uid=sa;pwd=zyzlxxjs;database=yf;";
            DapperExtensions.DapperExtensions.SetMappingAssemblies(
                new[] { typeof(ActivityMapper).Assembly });
            this.mD5Helper = mD5Helper;
            

        }
 
        public void SaveOrUpdate(EWQYEntity entity,string newVersion )
        {

          var existedEntity= Conn.Get<EWQYEntity>(entity.id);
            string fingerprint = entity.CalculateFingerprint(mD5Helper);
            /**/
            if (existedEntity == null)
            {
                entity.UpdateVersion(fingerprint, newVersion);
                Conn.Insert(entity);
            }
            else
            {
               
                if (fingerprint != existedEntity.Fingerprint)
                {

                    existedEntity.UpdateVersion(fingerprint, newVersion);
                    Conn.Update(existedEntity);
                }
            }
            /**/

            //Conn.Insert(entity);
            //if (entity is Activity)
            //{
            //    var activity = (Activity)entity;
            //    var existed = Conn.Get<Activity>(entity.id);
            //    if (existed == null)
            //    {
            //        activity.Version = newVersion;
            //        Conn.Insert(activity);
            //    }
            //    else
            //    {
            //        string fingerprint = activity.CalculateFingerprint(mD5Helper);
            //        if (fingerprint != existed.Fingerprint)
            //        {

            //            activity.UpdateVersion(fingerprint, newVersion);
            //            Conn.Update(activity);
            //        }
            //    }



            //}
            //else if (entity is CompanyVenue)
            //{
            //    var companyVenue = (CompanyVenue)entityWithFingerprint;
            //    var existed = Conn.Get<CompanyVenue>(entity.id);
            //    if (existed == null)
            //    {
            //        companyVenue.Version = version;
            //        Conn.Insert(companyVenue);
            //    }
            //    else
            //    {
            //        if (companyVenue.Fingerprint == existed.Fingerprint)
            //        {

            //        }
            //        else
            //        {
            //            companyVenue.Version = version;
            //            Conn.Update(companyVenue);
            //        }
            //    }

            //}

        }
    }
}
