using System;
using System.Collections.Generic;
using System.Text;
using TourInfo.Domain.Base;
using System.Data;
using System.Data.SqlClient;
namespace TourInfo.Infrastracture.Repository.ADONET
{
    public class AdoNetRepository<T, K> : IRepository<T, K>
    {
        string connectionString;
        IDbConnection Connection {
            get {
                return new SqlConnection(connectionString);
            }
        }
        public AdoNetRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public void BulkInsert(DataTable dataTable,string tableName)
        {
            using (Connection)
            {
                var bulkCopy = new SqlBulkCopy((SqlConnection)Connection);
                bulkCopy.DestinationTableName = tableName;
                bulkCopy.WriteToServer(dataTable);
            }
            
        }
        public void BulkInsert(IList<T> list )
        {
            using (Connection)
            {
                var bulkCopy = new SqlBulkCopy((SqlConnection)Connection);
                
                bulkCopy.WriteToServer(list.ConvertGenericListToDataTable());
            }

        }

        public T Get(K id)
        {
            throw new NotImplementedException();
        }

        public IList<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Insert(T entity)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public bool Update(T entity)
        {
            throw new NotImplementedException();
        }

        
    }
}
