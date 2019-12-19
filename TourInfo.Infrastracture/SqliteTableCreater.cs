using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using TourInfo.Domain.DomainModel.DataSync;
using TourInfo.Domain.Base;

namespace TourInfo.Domain
{
    public class SqliteTableCreater<T, T2> : ISqliteTableCreater<T, T2> where T : SqliteTable<T2> where T2 : Entity<string>
    {
        SQLiteConnection database;
        public SqliteTableCreater(SQLiteConnection database)
        {
            this.database = database;
        }

        public void CreateTable(IList<T> data)
        {

            database.CreateTable<T>();

            foreach (var t in data)
            {

                t.UpdateFromEntity();
                // var table =  t;  //ConvertFromEntity(t);
                database.Insert(t);
            }

        }

    }
}
