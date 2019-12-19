using SQLite;

namespace TourInfo.Domain
{
    public class SqliteDatabaseCreater : ISqliteDatabaseCreater
    {
        
        public SQLiteConnection Create(string fileName)
        {
            return new SQLiteConnection(fileName);
        }
    }
}
