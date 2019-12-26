using SQLite;
using System.Collections.Generic;
using TourInfo.Domain.Base;
using TourInfo.Domain.DomainModel.DataSync;


namespace TourInfo.Domain.DomainModel.DataSync
{
    public interface ISqliteTableCreater<T> 
    {
        void CreateTable(SQLiteConnection sqliteConn, IList<T> data);
    }
}