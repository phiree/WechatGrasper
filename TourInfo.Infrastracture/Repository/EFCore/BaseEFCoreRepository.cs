using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using TourInfo.Domain.Base;
using Dapper;
using TourInfo.Infrastracture.Repository.EFCore;
using System.Linq;
namespace TourInfo.Infrastracture.Repository.EFCore
{
    public class BaseEFCoreRepository<T, Key> : IRepository<T, Key>
        where T : class  
    {
        TourInfoDbContext tourInfoDbContext { get; }

        public BaseEFCoreRepository(TourInfoDbContext tourInfoDbContext)
        {
            // this.connectionString = "server=.;Integrated Security=true;database=ewqy;";
            this.tourInfoDbContext = tourInfoDbContext;// "server=114.55.59.143,1430;uid=sa;pwd=zyzlxxjs;database=yf;";


        }

        public void Insert(T entity)
        {
            tourInfoDbContext.Add(entity);
            tourInfoDbContext.SaveChanges();
        }

        public T Get(Key id)
        {
            return tourInfoDbContext.Find<T>(id);
        }

        public bool Update(T entity)
        {
            try
            {
                tourInfoDbContext.Update(entity);
                tourInfoDbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("update failed." + ex.ToString());
            }
        }

        public IList<T> GetAll()
        {
            return tourInfoDbContext.Set<T>().AsList();
        }
        public IList<T> FindList(Func<T, bool> predicate)
        {
            return tourInfoDbContext.Set<T>().Where(predicate).ToList();
        }
    }
}
