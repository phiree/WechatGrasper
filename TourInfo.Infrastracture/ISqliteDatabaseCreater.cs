using SQLite;

namespace TourInfo.Domain
{
    public interface ISqliteDatabaseCreater
    {

        SQLiteConnection Create(string fileName);
    }
}