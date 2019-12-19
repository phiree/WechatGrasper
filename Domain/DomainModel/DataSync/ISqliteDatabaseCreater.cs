using SQLite;

namespace TourInfo.Domain.DomainModel.DataSync
{
    public interface ISqliteDatabaseCreater
    {
        
        SQLiteConnection Create(string fileName);
    }
}