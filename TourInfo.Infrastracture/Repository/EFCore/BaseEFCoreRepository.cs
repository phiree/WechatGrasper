using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using TourInfo.Domain.Base;
using Dapper;
using TourInfo.Infrastracture.Repository.EFCore;
using System.Linq;
using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using TourInfo.Infrastracture.Repository.ADONET;

namespace TourInfo.Infrastracture.Repository.EFCore
{

    public class BaseEFCoreRepository<T, Key> : IRepository<T, Key>
        where T : class, IEntity<Key>
    {
        protected TourInfoDbContext tourInfoDbContext { get; }

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
        public void InsertOrUpdate(T entity)
        {
            var existed = tourInfoDbContext.Find<T>(entity.id);
            if (existed != null) { return; }
            tourInfoDbContext.Add(entity);
            tourInfoDbContext.SaveChanges();
        }
        public void InsertOrUpdate(IList<T> list)
        {
            foreach (var t in list)
            {
                InsertOrUpdate(t);
            }

        }
        public T Get(Key id)
        {
            return tourInfoDbContext.Find<T>(id);
        }

        public bool Update(T entity)
        {
            try
            {
                //tourInfoDbContext.Update(entity);
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
        public IList<T> FindList<OrderKey>(Func<T, bool> predicate, Func<T, OrderKey> order, bool orderDesc, int pageIndex, int pageSize)
        {
            var list = tourInfoDbContext.Set<T>().Where(predicate);
            if (orderDesc) {list= list.OrderByDescending(order); }
            else { list=list.OrderBy(order); }
            return list.Skip(pageIndex * pageSize).Take(pageSize).ToList();
        }

        public void SaveChanges()
        {
            tourInfoDbContext.SaveChanges();
        }



        public void BulkInsert(DataTable dataTable, string tableName)
        {
            throw new NotImplementedException();
        }

        public void BulkInsert(IList<T> list)
        {

            using (var connection = (SqlConnection)tourInfoDbContext.Database.GetDbConnection())
            {
                connection.Open();
                var bulkCopy = new SqlBulkCopy(connection.ConnectionString);
                bulkCopy.DestinationTableName = typeof(T).Name + "s";
                var tableData = list.ConvertGenericListToDataTable();
                tableData.Columns.Cast<DataColumn>().ToList().ForEach(x =>
     bulkCopy.ColumnMappings.Add(new SqlBulkCopyColumnMapping(x.ColumnName, x.ColumnName)));

                bulkCopy.WriteToServer(tableData);//.ConvertGenericListToDataTable());
                connection.Close();
            }
        }

        public void ExecuteRawSql(string sql)
        {
            tourInfoDbContext.Database.ExecuteSqlCommand(sql);

        }

        public void Delete(T entity)
        {
            tourInfoDbContext.Remove(entity);
        }

        public IList<T> GetList(int pageIndex, int pageSize)
        {
            return tourInfoDbContext.Set<T>().Skip(pageIndex * pageSize).Take(pageSize).ToList();
        }
        public IList<T> GetList(int pageIndex, int pageSize,Func<T,T> order)
        {
            return tourInfoDbContext.Set<T>().Skip(pageIndex * pageSize).OrderByDescending(order).Take(pageSize).ToList();
        }
    }
}
