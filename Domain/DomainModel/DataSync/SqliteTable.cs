using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using TourInfo.Domain.Base;
using TourInfo.Domain.DomainModel.Rapi;
using TourInfo.Domain.TourNews;

namespace TourInfo.Domain.DomainModel.DataSync
{
    public abstract class SqliteTable<T> //where T:Entity<string>
    {
       // public string Id { get; set; }
       // public abstract SqliteTable<T> UpdateFromEntity(T t);

    }

    [Table("Activity")]
    public class SqliteActivity  
    {

        public string Version { get; set; }

        public PlaceType PlaceType { get; set; }
        public string startTime { get; set; }
        public string createTime { get; set; }
        public string thumbnailKey { get; set; }
        public string thumbnailKeyOriginal { get;set;}
        public string address { get; set; }
        public string name { get; set; }
        public string endTime { get; set; }

        public string detail { get; set; }


        public string pictureKeys { get; set; }
        public string pictureKeysOriginal { get; set; }

        public int credits { get; set; }
        public bool isShared { get; set; }
        public string Id { get;set;}
        


    }
    [Table("CompanyVenue")]
    public class SqliteCompanyVenue : SqliteTable<CompanyVenue>
    {

        public string Version { get; set; }

        public PlaceType PlaceType { get; set; }

        public string thumbnailKey { get; set; }
        public string thumbnailKeyOriginal { get; set; }
        public string location { get; set; }
        // public double[] location { get; set; }
        public string name { get; set; }
        public string satisfactionScore { get; set; }
        public string typeId { get; set; }
        public string introduction { get; set; }
        //public IsComment isComment { get; set; }

        public string pictureKeys { get; set; }
        public string pictureKeysOriginal { get; set; }
        //  public string[] pictureKeys { get; set; }
        public string address { get; set; }
        public string isFavorite { get; set; }

        #region 场馆独有属性
        public string serviceTimeStart { get; set; }

        public string serviceNote { get; set; }
        public string serviceTimeEnd { get; set; }
        #endregion

        public string telNumber { get; set; }
        public string Id { get; set; }
        


    }
    [Table("ZbtaNews")]
    public class SqliteZbtaNews : SqliteTable<ZbtaNews>
    {

        public string Version { get; set; }
        public string releaseTime { get; set; }
        public string checkState { get; set; }

        public string titles { get; set; }
        public string image { get; set; }
        public string imageOriginal { get; set; }
        public string created { get; set; }
        public string back1 { get; set; }
        public string details { get; set; }
        public string localizedDetails { get; set; }
        public string createUser { get; set; }
        public string Id { get; set; }
        


    }

    public class SqliteProjectinfo : SqliteTable<Projectinfo>
    {
        public int pid { get; set; }
        public string pname { get; set; }
        public string homeurl { get; set; }
        public string areacode { get; set; }
        public string desc { get; set; }
        public string topvideourl { get; set; }
        public string toppicurl { get; set; }
        public string topjumpurl { get; set; }
        public string detailhead { get; set; }
        public string detailfoot { get; set; }
        public string topresourceurl { get; set; }
        public string wapbgimg { get; set; }
        public string appid { get; set; }
        public string defaultlogo { get; set; }
        public int subpid { get; set; }
        public bool iscomment { get; set; }
        public DateTime crtdate { get; set; }
        public DateTime updatetime { get; set; }
        public bool deleteflag { get; set; }

       
    }
    public class SqliteTypeinfo
    {
        internal object wapshowimgOriginal;

        public int typeid { get; set; }
        public int pid { get; set; }
        public float orderno { get; set; }
        public string typename { get; set; }
        public string editurl { get; set; }
        public string showurl { get; set; }
        public string mobilememo { get; set; }
        public int ptypeid { get; set; }
        public bool isshow { get; set; }
        public bool existschild { get; set; }
        public bool existsroom { get; set; }
        public bool existsscenic { get; set; }
        public string wapshowimg { get; set; }
        public DateTime crtdate { get; set; }
        public DateTime updatetime { get; set; }
        public bool deleteflag { get; set; }
    }

    public class SqliteTypefield
    {
        public int id { get; set; }
        public int pid { get; set; }
        public int typeid { get; set; }
        public float orderno { get; set; }
        public string fieldname { get; set; }
        public string fieldtype { get; set; }
        public string groupname { get; set; }
        public string customname { get; set; }
        public bool isedit { get; set; }
        public bool isdisplay { get; set; }
        public int displayorder { get; set; }
        public DateTime crtdate { get; set; }
        public DateTime updatetime { get; set; }
        public bool deleteflag { get; set; }
    }

    public class SqliteTypetag
    {
        public int id { get; set; }
        public int pid { get; set; }
        public int typeid { get; set; }
        public float orderno { get; set; }
        public string groupname { get; set; }
        public string tagname { get; set; }
        public DateTime crtdate { get; set; }
        public DateTime updatetime { get; set; }
        public bool deleteflag { get; set; }
    }

    public class SqliteTypepic
    {
        public int id { get; set; }
        public int pid { get; set; }
        public int typeid { get; set; }
        public float orderno { get; set; }
        public string groupname { get; set; }
        public int mediatypeid { get; set; }
        public string mediatypename { get; set; }
        public DateTime crtdate { get; set; }
        public DateTime updatetime { get; set; }
        public bool deleteflag { get; set; }
    }

    public class SqlitePubinfounit
    {
        public int unitid { get; set; }
        public int pid { get; set; }
        public int typeid { get; set; }
        public string areacode { get; set; }
        public string areaname { get; set; }
        public string unitname { get; set; }
        public string shortname { get; set; }
        public float orderno { get; set; }
        public string gpsbd { get; set; }
        public string gps { get; set; }
        public string gpsgd { get; set; }
        public string address { get; set; }
        public string postcode { get; set; }
        public string zonecode { get; set; }
        public string telephone { get; set; }
        public string infotel { get; set; }
        public string booktel { get; set; }
        public string complainttel { get; set; }
        public string fax { get; set; }
        public string url { get; set; }
        public string url360 { get; set; }
        public string logopic { get; set; }
        public string flagpic { get; set; }
        public string flagpicOriginal { get; set; }
        public string publictrafic { get; set; }
        public string memo { get; set; }
        public string desc { get; set; }
        public string manager { get; set; }
        public string managertel { get; set; }
        public string businesslicense { get; set; }
        public string businesstime { get; set; }
        public int level { get; set; }
        public int sourcefrom { get; set; }
        public string opentime { get; set; }
        public string decorationtime { get; set; }
        public string tips { get; set; }
        public string favouredpolicy { get; set; }
        public string innertrafic { get; set; }
        public int maxcapacity { get; set; }
        public float ticketprice { get; set; }
        public string pricedesc { get; set; }
        public int id5a { get; set; }
        public string name5a { get; set; }
        public int roomcount { get; set; }
        public int bedcount { get; set; }
        public float roomprice { get; set; }
        public int boxcount { get; set; }
        public int seatcount { get; set; }
        public float personprice { get; set; }
        public string licenseno { get; set; }
        public string mainline { get; set; }
        public string poitypename { get; set; }
        public string poitypetag { get; set; }
        public string detailurl { get; set; }
        public string overallrating { get; set; }
        public string servicerating { get; set; }
        public string environmentrating { get; set; }
        public string facilityrating { get; set; }
        public string hygienerating { get; set; }
        public int imgnum { get; set; }
        public int commentnum { get; set; }
        public string reservefield1 { get; set; }
        public string reservefield2 { get; set; }
        public string reservefield3 { get; set; }
        public string reservefield4 { get; set; }
        public string reservefield5 { get; set; }
        public string reservefield6 { get; set; }
        public string reservefield7 { get; set; }
        public string reservefield8 { get; set; }
        public string reservefield9 { get; set; }
        public int state { get; set; }
        public DateTime crtdate { get; set; }
        public DateTime updatetime { get; set; }
        public bool deleteflag { get; set; }
    }

    public class SqlitePubunittag
    {
        public int unittagid { get; set; }
        public int pid { get; set; }
        public int unitid { get; set; }
        public int tagid { get; set; }
        public string tagvalue { get; set; }
    }

    public class SqlitePubmediainfo
    {
        public int mediaid { get; set; }
        public bool topshow { get; set; }
        public int unitid { get; set; }
        public int typepicid { get; set; }
        public int pid { get; set; }
        public float orderno { get; set; }
        public string medianame { get; set; }
        public string desc { get; set; }
        public string memo { get; set; }
        public string mediaurl { get; set; }
        public string mediaurlOriginal { get; set; }
        public string videourl { get; set; }
        public bool isshow { get; set; }
        public int mediatypeid { get; set; }
        public DateTime crtdate { get; set; }
        public DateTime updatetime { get; set; }
        public bool deleteflag { get; set; }
    }

    public class SqlitePubinfounitchild
    {
        public int childid { get; set; }
        public int pid { get; set; }
        public int unitid { get; set; }
        public string childname { get; set; }
        public float orderno { get; set; }
        public string flagurl { get; set; }
        public string flagurlOriginal { get; set; }
        public string price { get; set; }
        public string desc { get; set; }
        public string memo { get; set; }
        public string guidevoice { get; set; }
        public string guidetext { get; set; }
        public string gpsbd { get; set; }
        public string gps { get; set; }
        public string gpsgd { get; set; }
        public bool isshow { get; set; }
        public DateTime crtdate { get; set; }
        public DateTime updatetime { get; set; }
        public bool deleteflag { get; set; }
    }


}


