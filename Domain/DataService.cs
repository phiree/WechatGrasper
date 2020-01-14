using System;
using System.Collections.Generic;
using System.Text;
using TourInfo.Domain.Base;
using TourInfo.Domain.DomainModel.DataSync;
using TourInfo.Domain.EWQY;
using TourInfo.Domain.EWQY.DomainModel;
using System.Linq;
using TourInfo.Domain.TourNews;
using TourInfo.Domain.DomainModel.Rapi;
using AutoMapper;
using TourInfo.Domain.DomainModel.EWQY;
using Microsoft.Extensions.Logging;

namespace TourInfo.Domain.DomainModel
{
    public class DataService : IDataService

    {

        ISqliteDatabaseCreater sqliteDatabaseCreater;


        IVersionedRepository<Activity, string> activityRepository;
        IVersionedRepository<CompanyVenue, string> companyVenueRepository;
        IVersionedRepository<CompanyVenueType, string> companyVenueTypeRepository;
        IVersionedRepository<ZbtaNews, string> zbtaNewsRepository;
        IVersionedRepository<Projectinfo, int> projectinfoRepository;
        IVersionedRepository<Pubmediainfo, int> PubmediainfoRepository;
        IVersionedRepository<Pubinfounit, int> PubinfounitRepository;
        IVersionedRepository<Pubinfounitchild, int> PubinfounitchildRepository;
        IVersionedRepository<Pubunittag, int> PubunittagRepository;
        IVersionedRepository<Typefield, int> TypefieldRepository;
        IVersionedRepository<Typeinfo, int> TypeinfoRepository;
        IVersionedRepository<Typepic, int> TypepicRepository;
        IVersionedRepository<Typetag, int> TypetagRepository;
        IVersionedRepository<Video.Video, int> VideoRepository;


        ISqliteTableCreater<SqliteActivity> sqliteActivityTableCreator;
        ISqliteTableCreater<SqliteCompanyVenue> sqliteCompanyVenueTableCreator;
        ISqliteTableCreater<SqliteZbtaNews> sqliteZbtaNewsTableCreator;
        ISqliteTableCreater<SqliteProjectinfo> SqliteProjectinfoCreator;
        ISqliteTableCreater<SqlitePubinfounit> SqlitePubinfounitCreator;
        ISqliteTableCreater<SqlitePubinfounitchild> SqlitePubinfounitchildCreator;
        ISqliteTableCreater<SqlitePubmediainfo> SqlitePubmediainfoCreator;
        ISqliteTableCreater<SqlitePubunittag> SqlitePubunittagCreator;
        ISqliteTableCreater<SqliteTypefield> SqliteTypefieldCreator;
        ISqliteTableCreater<SqliteTypeinfo> SqliteTypeinfoCreator;
        ISqliteTableCreater<SqliteTypepic> SqliteTypepicCreator;
        ISqliteTableCreater<SqliteTypetag> SqliteTypetagCreator;
        ISqliteTableCreater<SqliteVideo> SqliteVideoCreator;
        ISqliteTableCreater<SystemSetting> SqliteSystemSettingCreator;

        IMapper _mapper;

        string imageBaseUrl_Ewqy, imageBaseUrl_Zbta;
        Weather.IWeatherApplication weatherApplication;
        ILogger logger;
        public DataService(
            ILoggerFactory loggerFactory,
            Weather.IWeatherApplication weatherApplication,
            string imageBaseUrl_Ewqy,string imageBaseUrl_Zbta,
        IVersionedRepository<Projectinfo, int> projectinfoRepository,
        IVersionedRepository<Pubmediainfo, int> PubmediainfoRepository,
        IVersionedRepository<Pubinfounit, int> PubinfounitRepository,
        IVersionedRepository<Pubinfounitchild, int> PubinfounitchildRepository,
        IVersionedRepository<Pubunittag, int> PubunittagRepository,
        IVersionedRepository<Typefield, int> TypefieldRepository,
        IVersionedRepository<Typeinfo, int> TypeinfoRepository,
        IVersionedRepository<Typepic, int> TypepicRepository,
        IVersionedRepository<Typetag, int> TypetagRepository,
        IVersionedRepository<Video.Video, int> VideoRepository,

        IVersionedRepository<Activity, string> activityRepository,
            IVersionedRepository<CompanyVenueType, string> companyVenueTypeRepository
            , ISqliteDatabaseCreater sqliteDatabaseCreater,
             ISqliteTableCreater<SqliteCompanyVenue> sqliteCompanyVenueTableCreator,
        IVersionedRepository<CompanyVenue, string> companyVenueRepository,
        ISqliteTableCreater<SqliteActivity> sqliteActivityTableCreator
            , IVersionedRepository<ZbtaNews, string> zbtaNewsRepository
        , ISqliteTableCreater<SqliteZbtaNews> sqliteZbtaNewsTableCreator,
            ISqliteTableCreater<SqliteProjectinfo> SqliteProjectinfoCreator,
        ISqliteTableCreater<SqlitePubinfounit> SqlitePubinfounitCreator,
        ISqliteTableCreater<SqlitePubinfounitchild> SqlitePubinfounitchildCreator,
        ISqliteTableCreater<SqlitePubmediainfo> SqlitePubmediainfoCreator,
        ISqliteTableCreater<SqlitePubunittag> SqlitePubunittagCreator,
        ISqliteTableCreater<SqliteTypefield> SqliteTypefieldCreator,
        ISqliteTableCreater<SqliteTypeinfo> SqliteTypeinfoCreator,
        ISqliteTableCreater<SqliteTypepic> SqliteTypepicCreator,
        ISqliteTableCreater<SqliteTypetag> SqliteTypetagCreator,
        ISqliteTableCreater<SqliteVideo> SqliteVideoCreator,
        ISqliteTableCreater<SystemSetting> SqliteSystemSettingCreator
            , IMapper _mapper
            )
        {
            this.logger = loggerFactory.CreateLogger<DataService>();
            this.weatherApplication=weatherApplication;
            this.imageBaseUrl_Ewqy=imageBaseUrl_Ewqy;
            this.imageBaseUrl_Zbta=imageBaseUrl_Zbta;
            this._mapper = _mapper;
            this.companyVenueRepository = companyVenueRepository;
            this.companyVenueTypeRepository=companyVenueTypeRepository;
            this.sqliteDatabaseCreater = sqliteDatabaseCreater;
            this.sqliteActivityTableCreator = sqliteActivityTableCreator;
            this.activityRepository = activityRepository;
            this.sqliteCompanyVenueTableCreator = sqliteCompanyVenueTableCreator;

            this.zbtaNewsRepository = zbtaNewsRepository;
            this.sqliteZbtaNewsTableCreator = sqliteZbtaNewsTableCreator;
            this.projectinfoRepository = projectinfoRepository;
            this.PubmediainfoRepository = PubmediainfoRepository;
            this.PubinfounitRepository = PubinfounitRepository;
            this.PubinfounitchildRepository = PubinfounitchildRepository;
            this.PubunittagRepository = PubunittagRepository;
            this.TypefieldRepository = TypefieldRepository;
            this.TypeinfoRepository = TypeinfoRepository;
            this.TypepicRepository = TypepicRepository;
            this.TypetagRepository = TypetagRepository;
           this. VideoRepository=VideoRepository;


            this.SqliteProjectinfoCreator = SqliteProjectinfoCreator;
            this.SqlitePubinfounitCreator = SqlitePubinfounitCreator;
            this.SqlitePubinfounitchildCreator = SqlitePubinfounitchildCreator;
            this.SqlitePubmediainfoCreator = SqlitePubmediainfoCreator;
            this.SqlitePubunittagCreator = SqlitePubunittagCreator;
            this.SqliteTypefieldCreator = SqliteTypefieldCreator;
            this.SqliteTypeinfoCreator = SqliteTypeinfoCreator;
            this.SqliteTypepicCreator = SqliteTypepicCreator;
            this.SqliteTypetagCreator = SqliteTypetagCreator;
            this.SqliteVideoCreator = SqliteVideoCreator;
            this.SqliteSystemSettingCreator = SqliteSystemSettingCreator;
        }
        public void CreateInitData(string version)
        {


            var sqliteDirectory=new System.IO.DirectoryInfo(Environment.CurrentDirectory).Parent;
           using( var sqliteDbConn = sqliteDatabaseCreater.Create( sqliteDirectory.FullName + "\\TourInfo.db3"))
            { 
            var allCompanyVenues=companyVenueRepository.GetAll();
            sqliteActivityTableCreator.CreateTable(sqliteDbConn, _mapper.Map<IList<SqliteActivity>>(activityRepository.GetAll()));
            sqliteCompanyVenueTableCreator.CreateTable(sqliteDbConn, _mapper.Map<IList<SqliteCompanyVenue>>(allCompanyVenues));
            sqliteZbtaNewsTableCreator.CreateTable(sqliteDbConn, _mapper.Map<IList<SqliteZbtaNews>>(zbtaNewsRepository.GetAll()));

            SqliteProjectinfoCreator.CreateTable(sqliteDbConn, _mapper.Map<IList<SqliteProjectinfo>>(projectinfoRepository.GetAll()));
            SqlitePubinfounitchildCreator.CreateTable(sqliteDbConn, _mapper.Map<IList<SqlitePubinfounitchild>>(PubinfounitchildRepository.GetAll()));
            SqlitePubinfounitCreator.CreateTable(sqliteDbConn, _mapper.Map<IList<SqlitePubinfounit>>(PubinfounitRepository.GetAll()));
            SqlitePubmediainfoCreator.CreateTable(sqliteDbConn, _mapper.Map<IList<SqlitePubmediainfo>>(PubmediainfoRepository.GetAll()));
            SqlitePubunittagCreator.CreateTable(sqliteDbConn, _mapper.Map<IList<SqlitePubunittag>>(PubunittagRepository.GetAll()));
            SqliteTypefieldCreator.CreateTable(sqliteDbConn, _mapper.Map<IList<SqliteTypefield>>(TypefieldRepository.GetAll()));
            SqliteTypeinfoCreator.CreateTable(sqliteDbConn, _mapper.Map<IList<SqliteTypeinfo>>(TypeinfoRepository.GetAll()));
            SqliteTypepicCreator.CreateTable(sqliteDbConn, _mapper.Map<IList<SqliteTypepic>>(TypepicRepository.GetAll()));
            SqliteTypetagCreator.CreateTable(sqliteDbConn, _mapper.Map<IList<SqliteTypetag>>(TypetagRepository.GetAll()));
            SqliteVideoCreator.CreateTable(sqliteDbConn, _mapper.Map<IList<SqliteVideo>>(VideoRepository.GetAll()));
            SqliteSystemSettingCreator.CreateTable(sqliteDbConn, _mapper.Map<IList<SystemSetting>>(new List<SystemSetting> { new SystemSetting{LatestVersion=version } }));
            }
        }
        public dynamic CreateSyncData(string version)
        {

            logger.LogInformation("开始获取活动信息");
            var allActivity = activityRepository.GetAllAfterVersion(version).Select(x =>_mapper.Map<SqliteActivity>(x)  );
            logger.LogInformation("活动信息获得"+allActivity.Count()+"条");
            //如果是同步 则需要加上图片跟路径
            allActivity = allActivity.Select(x=>{x.thumbnailKey=imageBaseUrl_Ewqy+x.thumbnailKey; return x;});
            var allCompanyVenue = companyVenueRepository.GetAllAfterVersion(version).Select(x => _mapper.Map<SqliteCompanyVenue>(x));
            allCompanyVenue = allCompanyVenue.Select(x => { x.thumbnailKey = imageBaseUrl_Ewqy + x.thumbnailKey; return x; });
            var allZbtaNews = zbtaNewsRepository.GetAllAfterVersion(version).Select(x => _mapper.Map<SqliteZbtaNews>(x) );
            var allCompanyVenueType = companyVenueTypeRepository.GetAllAfterVersion(version).Select(x => _mapper.Map<SqliteCompanyVenueType>(x));


            allZbtaNews = allZbtaNews.Select(x => { x.imageOriginal = imageBaseUrl_Zbta + x.imageOriginal; return x; });
            var weather=weatherApplication.GetWeather();
            
            return new SyncDataModel
            {
                data = new SyncDataModelData
                {
                    Activities = allActivity,
                    CompanyVenues = allCompanyVenue,
                    CompanyVenueTypes= allCompanyVenueType,
                    ZbtaNews = allZbtaNews,
                    Weather=weather,
                    Projectinfos = _mapper.Map<IEnumerable<SqliteProjectinfo>>(projectinfoRepository.GetAllAfterVersion(version)),

                    Pubinfounitchilds = _mapper.Map<IList<SqlitePubinfounitchild>>(PubinfounitchildRepository.GetAllAfterVersion(version)),
                    Pubinfounits = _mapper.Map<IList<SqlitePubinfounit>>(PubinfounitRepository.GetAllAfterVersion(version)),
                    Pubmediainfos = _mapper.Map<IList<SqlitePubmediainfo>>(PubmediainfoRepository.GetAllAfterVersion(version)),
                    Pubunittags = _mapper.Map<IList<SqlitePubunittag>>(PubunittagRepository.GetAllAfterVersion(version)),
                    Typefields = _mapper.Map<IList<SqliteTypefield>>(TypefieldRepository.GetAllAfterVersion(version)),
                    Typeinfos = _mapper.Map<IList<SqliteTypeinfo>>(TypeinfoRepository.GetAllAfterVersion(version)),
                    Typepics = _mapper.Map<IList<SqliteTypepic>>(TypepicRepository.GetAllAfterVersion(version)),
                    Typetags = _mapper.Map<IList<SqliteTypetag>>(TypetagRepository.GetAllAfterVersion(version)),
                    Videos = _mapper.Map<IList<SqliteVideo>>(VideoRepository.GetAllAfterVersion(version))
                }
            };
        }
        public dynamic CreateSyncDataForTest()
        {
            var allActivity = activityRepository.GetAll().Take(2).Select(x => _mapper.Map<SqliteActivity>(x));

            //如果是同步 则需要加上图片跟路径
            allActivity = allActivity.Select(x => { x.thumbnailKey = imageBaseUrl_Ewqy + x.thumbnailKey; return x; });
            var allCompanyVenue = companyVenueRepository.GetAll().Take(2).Select(x => _mapper.Map<SqliteCompanyVenue>(x));
            allCompanyVenue = allCompanyVenue.Select(x => { x.thumbnailKey = imageBaseUrl_Ewqy + x.thumbnailKey; return x; });
            var allZbtaNews = zbtaNewsRepository.GetAll().Take(2).Select(x => _mapper.Map<SqliteZbtaNews>(x));
            var allCompanyVenueType = companyVenueTypeRepository.GetAll().Take(2).Select(x => _mapper.Map<SqliteCompanyVenueType>(x));


            allZbtaNews = allZbtaNews.Select(x => { x.imageOriginal = imageBaseUrl_Zbta + x.imageOriginal; return x; });
            var weather = weatherApplication.GetWeather();

            return new SyncDataModel
            {
                data = new SyncDataModelData
                {
                    Activities = allActivity,
                    CompanyVenues = allCompanyVenue,
                    CompanyVenueTypes = allCompanyVenueType,
                    ZbtaNews = allZbtaNews,
                    Weather = weather,
                    Projectinfos = _mapper.Map<IEnumerable<SqliteProjectinfo>>(projectinfoRepository.GetAll().Take(2)),

                    Pubinfounitchilds = _mapper.Map<IList<SqlitePubinfounitchild>>(PubinfounitchildRepository.GetAll().Take(2)),
                    Pubinfounits = _mapper.Map<IList<SqlitePubinfounit>>(PubinfounitRepository.GetAll().Take(2)),
                    Pubmediainfos = _mapper.Map<IList<SqlitePubmediainfo>>(PubmediainfoRepository.GetAll().Take(2)),
                    Pubunittags = _mapper.Map<IList<SqlitePubunittag>>(PubunittagRepository.GetAll().Take(2)),
                    Typefields = _mapper.Map<IList<SqliteTypefield>>(TypefieldRepository.GetAll().Take(2)),
                    Typeinfos = _mapper.Map<IList<SqliteTypeinfo>>(TypeinfoRepository.GetAll().Take(2)),
                    Typepics = _mapper.Map<IList<SqliteTypepic>>(TypepicRepository.GetAll().Take(2)),
                    Typetags = _mapper.Map<IList<SqliteTypetag>>(TypetagRepository.GetAll().Take(2)),
                    Videos = _mapper.Map<IList<SqliteVideo>>(VideoRepository.GetAll().Take(2))
                }
            };
        }
        public class SyncDataModel
        {
            public int code { get; set; }
            public string msg { get; set; } = string.Empty;

            public SyncDataModelData data { get; set; }
        }
        public class SyncDataModelData
        {
            public Weather.WeatherModel Weather { get;set;}
            public IEnumerable<SqliteActivity> Activities { get; set; }
            public IEnumerable<SqliteCompanyVenue> CompanyVenues { get; set; }
            public IEnumerable<SqliteCompanyVenueType> CompanyVenueTypes { get; set; }
            public IEnumerable<SqliteZbtaNews> ZbtaNews { get; set; }

            public IEnumerable<SqliteProjectinfo> Projectinfos { get; set; }
            public IEnumerable<SqlitePubinfounit> Pubinfounits { get; set; }
            public IEnumerable<SqlitePubinfounitchild> Pubinfounitchilds { get; set; }
            public IEnumerable<SqlitePubmediainfo> Pubmediainfos { get; set; }
            public IEnumerable<SqlitePubunittag> Pubunittags { get; set; }
            public IEnumerable<SqliteTypepic> Typepics { get; set; }
            public IEnumerable<SqliteTypefield> Typefields { get; set; }
            public IEnumerable<SqliteTypetag> Typetags { get; set; }
            public IEnumerable<SqliteTypeinfo> Typeinfos { get; set; }
            public IEnumerable<SqliteVideo> Videos { get; set; }
        }

    }
}
