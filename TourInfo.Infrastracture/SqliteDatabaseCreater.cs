using SQLite;
using TourInfo.Domain.DomainModel.DataSync;
using System.IO;
namespace TourInfo.Domain
{
    public class SqliteDatabaseCreater : ISqliteDatabaseCreater
    {
        
        public SQLiteConnection Create(string fileName)
        {
            if(File.Exists(fileName))
            { 
                File.Delete(fileName);
                }
            return new SQLiteConnection(fileName);
        }
    }
}
