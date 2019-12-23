using System;
using System.Collections.Generic;
using System.Text;
using TourInfo.Domain.Base;
using TourInfo.Domain.DomainModel.DataSync;
using TourInfo.Domain.EWQY;
using TourInfo.Domain.EWQY.DomainModel;
using System.Linq;
using TourInfo.Domain.TourNews;

namespace TourInfo.Domain.DomainModel
{
    public class DataService : IDataService

    {
        
        ISqliteDatabaseCreater sqliteDatabaseCreater;
        ISqliteTableCreater<SqliteActivity, Activity> sqliteActivityTableCreator;
        ISqliteTableCreater<SqliteCompanyVenue, CompanyVenue> sqliteCompanyVenueTableCreator;
        ISqliteTableCreater<SqliteZbtaNews, ZbtaNews> sqliteZbtaNewsTableCreator;
        IVersionedRepository<Activity, string> activityRepository;
        IVersionedRepository<CompanyVenue, string> companyVenueRepository;
        IVersionedRepository<ZbtaNews,string> zbtaNewsRepository;
        public DataService(IVersionedRepository<Activity, string> activityRepository
            , ISqliteDatabaseCreater sqliteDatabaseCreater,
             ISqliteTableCreater<SqliteCompanyVenue, CompanyVenue> sqliteCompanyVenueTableCreator,
        IVersionedRepository<CompanyVenue, string> companyVenueRepository,
        ISqliteTableCreater<SqliteActivity, Activity> sqliteActivityTableCreator
            , IVersionedRepository<ZbtaNews, string> zbtaNewsRepository 
        , ISqliteTableCreater<SqliteZbtaNews, ZbtaNews> sqliteZbtaNewsTableCreator 
            )
        {
            this.companyVenueRepository= companyVenueRepository;
            this.sqliteDatabaseCreater = sqliteDatabaseCreater;
            this.sqliteActivityTableCreator = sqliteActivityTableCreator;
            this.activityRepository = activityRepository;
            this.sqliteCompanyVenueTableCreator=sqliteCompanyVenueTableCreator;

            this.zbtaNewsRepository=zbtaNewsRepository;
            this.sqliteZbtaNewsTableCreator=sqliteZbtaNewsTableCreator;
        }
        public void CreateInitData()
        {


            
            var sqliteDbConn = sqliteDatabaseCreater.Create(Environment.CurrentDirectory+"\\TourInfo.db3");
            var allActivity = activityRepository.GetAll();
            sqliteActivityTableCreator.CreateTable(sqliteDbConn, allActivity.Select(x => (SqliteActivity)new SqliteActivity( ).UpdateFromEntity(x)).ToList());
            var allCompanyVenue=companyVenueRepository.GetAll();
            sqliteCompanyVenueTableCreator.CreateTable(sqliteDbConn,allCompanyVenue.Select(x=> (SqliteCompanyVenue)new SqliteCompanyVenue().UpdateFromEntity(x )).ToList());

            var allZbtaNews=zbtaNewsRepository.GetAll();
            sqliteZbtaNewsTableCreator.CreateTable(sqliteDbConn, allZbtaNews.Select(x => (SqliteZbtaNews)new SqliteZbtaNews( ).UpdateFromEntity(x)).ToList());

            //数据处理（图片下载）
            //创建图片压缩包
        }
        public dynamic CreateSyncData(string version)
        {
            var allActivity = activityRepository.GetAllAfterVersion(version).Select(x => (SqliteActivity) new SqliteActivity( ).UpdateFromEntity(x));
            var allCompanyVenue = companyVenueRepository.GetAllAfterVersion(version).Select(x => (SqliteCompanyVenue)new SqliteCompanyVenue( ).UpdateFromEntity(x));
            var allZbtaNews = zbtaNewsRepository.GetAllAfterVersion(version).Select(x => (SqliteZbtaNews)new SqliteZbtaNews().UpdateFromEntity(x));

           
            return new SyncDataModel { data=new SyncDataModelData { Activities = allActivity, CompanyVenues = allCompanyVenue, ZbtaNews = allZbtaNews } };
        }

        public class SyncDataModel
        { 
            public int code { get;set;} 
            public string msg { get;set;}=string.Empty;

            public SyncDataModelData data { get; set; }
        }
        public class SyncDataModelData
        {
            public IEnumerable<SqliteActivity> Activities { get; set; }
            public IEnumerable<SqliteCompanyVenue> CompanyVenues { get; set; }

            public IEnumerable<SqliteZbtaNews> ZbtaNews { get; set; }
        }
        
    }
}
