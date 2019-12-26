using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using TourInfo.Domain.DomainModel.DataSync;
using TourInfo.Domain.Base;
using System.Linq;
namespace TourInfo.Domain
{
    public class SqliteTableCreater<T> : ISqliteTableCreater<T> 
    {
        

        public void CreateTable(SQLiteConnection sQLiteConnection, IList<T> data)
        {

            sQLiteConnection.CreateTable<T>();
            
            foreach (var t in data)
            {

              //  t.UpdateFromEntity();
                // var table =  t;  //ConvertFromEntity(t);
               
            }
            sQLiteConnection.InsertAll(data);

        }

        
    }
}
