
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        void InsertOrUpdate(T entity);
        void InsertOrUpdate(IList<T> list);
        void Delete(T entity);
        


    }
    public class DbModelCheckResult<T>
    {
        public T DbModel { get; set; }
        public DbModelStatus DbModelStatus { get; set; }
    }
    public enum DbModelStatus
    {
        [Description("新增")]
        Added,
        [Description("更新")]
        Updated,
        [Description("删除")]
        Deleted,
        [Description("未修改")]
        UnChanged
    }

}
