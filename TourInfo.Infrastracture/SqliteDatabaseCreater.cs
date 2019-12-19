using SQLite;
using TourInfo.Domain.DomainModel.DataSync;

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
