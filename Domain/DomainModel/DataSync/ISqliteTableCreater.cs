using System.Collections.Generic;
using TourInfo.Domain.Base;
using TourInfo.Domain.DomainModel.DataSync;


namespace TourInfo.Domain.DomainModel.DataSync
{
    public interface ISqliteTableCreater<T, T2>
        where T : SqliteTable<T2>
        where T2 : Entity<string>
    {
        void CreateTable(IList<T> data);
    }
}