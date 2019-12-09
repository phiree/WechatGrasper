using Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Dapper;
using DapperExtensions;
using Dapper.Contrib;

namespace DataAccess
{
    public class DapperRepository : IRepository
    {
        string connectionString;
        public DapperRepository( )
        {
           // this.connectionString = "server=.;Integrated Security=true;database=ewqy;";
            this.connectionString = "server=114.55.59.143,1430;uid=sa;pwd=zyzlxxjs;database=yf;";
           DapperExtensions.DapperExtensions.SetMappingAssemblies(
               new[] { typeof(ActivityMapper).Assembly });

        }
        IDbConnection conn;


        protected IDbConnection Conn
        {
            get
            {
                conn = conn ?? new SqlConnection(connectionString);

                return conn;
            }
        }
        public IList<Entity> DownloadData(DateTime dateTime)
        {
            throw new NotImplementedException();
        }
        string[] allIds;
        public string[] GetAllIds()
        {
           if(allIds==null)
            { 
                
                }
           return allIds;
        }

        public void Save(Entity entity,string version)
        {
            var entityed=entity.ConvertToEntity();
            //Conn.Insert(entity);
            if (entity is Activity)
            {
                var activity=(Activity)entityed;
                var existed=Conn.Get<Activity>(entity.id);
                if(existed==null)
                {
                    activity.Version=version;
                    Conn.Insert(activity);
                }
                else
                { 
                    if(activity.HashCode== existed.HashCode)
                    { 
                         
                        }
                    else
                    { 
                       activity.Version=version;
                        Conn.Update((Activity)entityed);
                        }
                    }
                

               
            }
            else if (entity is CompanyVenue)
            {
                var companyVenue = (CompanyVenue)entityed;
                var existed = Conn.Get<CompanyVenue>(entity.id);
                if (existed == null)
                {
                    companyVenue.Version = version;
                    Conn.Insert(companyVenue);
                }
                else
                {
                    if (companyVenue.HashCode == existed.HashCode)
                    {

                    }
                    else
                    {
                        companyVenue.Version = version;
                        Conn.Update(companyVenue);
                    }
                }

            }

        }
    }
}
