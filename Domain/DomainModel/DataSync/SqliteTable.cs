using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using TourInfo.Domain.Base;
using TourInfo.Domain.DomainModel.EWQY;
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
       /// <summary>
       /// 版本号
       /// </summary>
        public string Version { get; set; }
        /// <summary>
        /// 活动类型 0:文化场馆活动  1: 文化企业活动.
        /// </summary>
        public PlaceType PlaceType { get; set; }
        /// <summary>
        /// 活动开始时间
        /// </summary>
        public string startTime { get; set; }
        /// <summary>
        /// 信息创建时间
        /// </summary>
        public string createTime { get; set; }
        /// <summary>
        /// 本地图片路径:活动缩略图.
        /// </summary>
        public string thumbnailKey { get; set; }
        /// <summary>
        /// 远程图片绝对路径.
        /// </summary>
        public string thumbnailKeyOriginal { get;set;}
        /// <summary>
        /// 活动举办地址
        /// </summary>
        public string address { get; set; }
        /// <summary>
        /// 活动名称
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 活动结束时间
        /// </summary>
        public string endTime { get; set; }
        /// <summary>
        /// 活动详情,
        /// </summary>
        public string detail { get; set; }

        /// <summary>
        /// 本地图片:活动相关图片, 多张图片用分号分隔
        /// </summary>
        public string pictureKeys { get; set; }
        /// <summary>
        /// 远程图片: 多张图片用分号分隔
        /// </summary>
        public string pictureKeysOriginal { get; set; }
        /// <summary>
        /// (暂时忽略)信用点
        /// </summary>
        public int credits { get; set; }
        /// <summary>
        /// (暂时忽略)是否已分享
        /// </summary>
        public bool isShared { get; set; }
        /// <summary>
        /// 活动Id
        /// </summary>
        public string Id { get;set;}
        


    }
    [Table("CompanyVenue")]
    public class SqliteCompanyVenue : SqliteTable<CompanyVenue>
    {
        /// <summary>
        /// 数据版本号
        /// </summary>
        public string Version { get; set; }
        /// <summary>
        /// 类型 0:文化场馆  1: 文化企业.
        /// </summary>
        public PlaceType PlaceType { get; set; }
        /// <summary>
        /// 本地图片路径:活动缩略图.
        /// </summary>
        public string thumbnailKey { get; set; }
        /// <summary>
        /// 远程图片绝对路径.
        /// </summary>
        public string thumbnailKeyOriginal { get; set; }
        /// <summary>
        /// 长度为2的数组, 表示经纬度, 第一个是经度,第二个维度
        /// </summary>
        public string location { get; set; }
        
        /// <summary>
        /// 名称
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 满意度得分
        /// </summary>
        public string satisfactionScore { get; set; }
        /// <summary>
        /// 类型id, 等于企业场馆类型表(CompanyVenueType)里的typeid
        /// </summary>
        public string typeId { get; set; }
        /// <summary>
        /// 介绍
        /// </summary>
        public string introduction { get; set; }
        //public IsComment isComment { get; set; }
        /// <summary>
        /// 相关图片,本地路径,多个图片分号分隔.
        /// </summary>
        public string pictureKeys { get; set; }
        /// <summary>
        /// 相关图片, 远程绝对路径,多个图片分号分隔
        /// </summary>
        public string pictureKeysOriginal { get; set; }
        //  public string[] pictureKeys { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public string address { get; set; }
        /// <summary>
        /// (暂时无用)
        /// </summary>
        public string isFavorite { get; set; }

        #region 场馆独有属性
        /// <summary>
        /// 服务开始时间.
        /// </summary>
        public string serviceTimeStart { get; set; }
        /// <summary>
        /// 服务说明
        /// </summary>
        public string serviceNote { get; set; }
        /// <summary>
        /// 服务结束时间
        /// </summary>
        public string serviceTimeEnd { get; set; }
        #endregion
        /// <summary>
        /// 电话号码
        /// </summary>
        public string telNumber { get; set; }
        /// <summary>
        /// Id
        /// </summary>
        public string Id { get; set; }
        
        


    }


    /// <summary>
    /// 企业/场馆类型
    /// </summary>
    [Table("CompanyVenueType")]
    public class SqliteCompanyVenueType : SqliteTable<CompanyVenueType>
    {
        /// <summary>
        /// 分类名称
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 分类Id
        /// </summary>
        public string id { get;set;}

        

    }
    /// <summary>
    /// zbta网站的旅游资讯
    /// </summary>
    [Table("ZbtaNews")]
    public class SqliteZbtaNews : SqliteTable<ZbtaNews>
    {
        /// <summary>
        /// 数据版本
        /// </summary>

        public string Version { get; set; }
        /// <summary>
        /// 发布时间
        /// </summary>
        public string releaseTime { get; set; }
        /// <summary>
        /// (暂时无用)
        /// </summary>
        public string checkState { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string titles { get; set; }
        /// <summary>
        /// 标题图片,本地路路径
        /// </summary>
        public string image { get; set; }
        /// <summary>
        /// 标题图片,远程绝对路径
        /// </summary>
        public string imageOriginal { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        public string created { get; set; }
        /// <summary>
        /// 概要
        /// </summary>
        public string back1 { get; set; }
        /// <summary>
        /// 富文本详情, 其中的图片地址是远程绝对路径
        /// </summary>
        public string details { get; set; }
        /// <summary>
        /// 富文本详情,其中的图片地址是本地相对路径
        /// </summary>
        public string localizedDetails { get; set; }
        /// <summary>
        /// 创建者
        /// </summary>
        public string createUser { get; set; }
        /// <summary>
        /// id
        /// </summary>
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


