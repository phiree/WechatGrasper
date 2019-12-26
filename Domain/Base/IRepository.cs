
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace TourInfo.Domain.Base
{
    public interface IRepository<T, Key>
    {

        void Insert(T entity);
        bool Update(T entity);
        T Get(Key id);
        IList<T> GetAll();
        void SaveChanges();
          void BulkInsert(DataTable dataTable, string tableName);
        void BulkInsert(IList<T> list);
        void ExecuteRawSql(string sql);




    }

}
