using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using TourInfo.Domain.DomainModel.DataSync;
using TourInfo.Domain.Base;

namespace TourInfo.Domain
{
    public class SqliteCreator
    {
        private SQLiteConnection database;
        public SqliteCreator(string fileName)
        {
            database = new SQLiteConnection(fileName);


        }
    }
    public class SqliteTableCreater<T> where T : Entity<string>
    {
        SQLiteConnection database;
        public SqliteTableCreater(SQLiteConnection database)
        {
            this.database = database;
        }
 
        public void CreateTable (IList<SqliteTable<T>> data)
        {
           
            database.CreateTable <SqliteTable<T>>( );
             
                foreach (var t in data)
                {
               
                t.UpdateFromEntity(t.);
               // var table =  t;  //ConvertFromEntity(t);
                database.Insert(sqliteTable);
                }
            
        }
         
    }
}
