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
            this.connectionString = "server=.;Integrated Security=true;database=ewqy;";
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
            
            //Conn.Insert(entity);
            if (entity is Activity)
            {
                var activity=(Activity)entity;
                var existed=Conn.Get<Activity>(entity.id);
                if(existed==null)
                {
                    activity.Version=version;
                    Conn.Insert(((Activity)entity).ConvertToEntity());
                }
                else
                { 
                    if(activity.HashCode==activity.GetHashCode())
                    { 
                         
                        }
                    else
                    { 
                       activity.Version=version;
                        Conn.Update(((Activity)entity).ConvertToEntity());
                        }
                    }
                

               
            }
            else if (entity is CompanyVenue)
            {
                var companyVenue = (CompanyVenue)entity;
                var existed = Conn.Get<CompanyVenue>(entity.id);
                if (existed == null)
                {
                    companyVenue.Version = version;
                    Conn.Insert(((CompanyVenue)entity).ConvertToEntity());
                }
                else
                {
                    if (companyVenue.HashCode == companyVenue.GetHashCode())
                    {

                    }
                    else
                    {
                        companyVenue.Version = version;
                        Conn.Update(((CompanyVenue)entity).ConvertToEntity());
                    }
                }

            }

        }
    }
}
