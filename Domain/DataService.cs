using System;
using System.Collections.Generic;
using System.Text;
using TourInfo.Domain.Base;
using TourInfo.Domain.DomainModel.DataSync;
using TourInfo.Domain.EWQY;
using TourInfo.Domain.EWQY.DomainModel;
using System.Linq;
namespace TourInfo.Domain.DomainModel
{
    public class DataService : IDataService

    {
        IEWQYRepository eWQYRepository;
        ISqliteDatabaseCreater sqliteDatabaseCreater;
        ISqliteTableCreater<SqliteTable<Activity>, Activity> sqliteActivityTableCreator;

        IRepository<Activity, string> activityRepository;
        public DataService(IEWQYRepository eWQYRepository, IRepository<Activity, string> activityRepository
            , ISqliteDatabaseCreater sqliteDatabaseCreater,
        ISqliteTableCreater<SqliteTable<Activity>, Activity> sqliteActivityTableCreator)
        {
            this.sqliteDatabaseCreater = sqliteDatabaseCreater;
            this.sqliteActivityTableCreator = sqliteActivityTableCreator;
            this.activityRepository = activityRepository;
            this.eWQYRepository = eWQYRepository;
        }
        public void CreateInitData()
        {


            var allActivity = activityRepository.GetAll();
            var sqliteDbConn = sqliteDatabaseCreater.Create(DateTime.Now.ToString("yyyyMMddHHmmss") + ".db3");
            sqliteActivityTableCreator.CreateTable(allActivity.Select(x => new SqliteActivity(x) as SqliteTable<Activity>).ToList());

            //数据处理（图片下载）
            //创建图片压缩包
        }
        public void CreateSyncData()
        {

        }
    }
}
