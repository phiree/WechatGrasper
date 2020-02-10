using System;
using System.Collections.Generic;
using System.Text;
using TourInfo.Domain.Base;

namespace TourInfo.Domain.DomainModel.Rapi
{
    public class Projectinfo :VersionedEntity<int>
    {
        public int pid { get{ return id;}set{ id=value;} }
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

    public class Typeinfo : VersionedEntity<int>
    {
        public int typeid { get { return id; } set { id = value; } }
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
        public ImageUrl wapshowimg { get; set; }
        public DateTime crtdate { get; set; }
        public DateTime updatetime { get; set; }
        public bool deleteflag { get; set; }
    }

    public class Typefield : VersionedEntity<int>
    {
     
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

    public class Typetag : VersionedEntity<int>
    {
        
        public int pid { get; set; }
        public int typeid { get; set; }
        public float orderno { get; set; }
        public string groupname { get; set; }
        public string tagname { get; set; }
        public DateTime crtdate { get; set; }
        public DateTime updatetime { get; set; }
        public bool deleteflag { get; set; }
    }

    public class Typepic : VersionedEntity<int>
    {
       
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

    public class Pubinfounit :VersionedEntity<int>
    {
        public int unitid { get { return id; } set { id = value; } }
        public int pid { get; set; }
        public int typeid { get; set; }
        public string areacode { get; set; }
        public string areaname { get; set; }
        public string unitname { get; set; }
        public string shortname { get; set; }
        public float orderno { get; set; }
        public Location gpsbd { get; set; }
          
        public Location gps { get; set; }
        public Location gpsgd { get; set; }
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
        public ImageUrl flagpic { get; set; }
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

    public class Pubunittag :VersionedEntity<int>
    {
        public int unittagid { get { return id; } set { id = value; } }
        public int pid { get; set; }
        public int unitid { get; set; }
        public int tagid { get; set; }
        public string tagvalue { get; set; }
    }

    public class Pubmediainfo : VersionedEntity<int>
    {
        public int mediaid { get { return id; } set { id = value; } }
        public bool topshow { get; set; }
        public int unitid { get; set; }
        public int typepicid { get; set; }
        public int pid { get; set; }
        public float orderno { get; set; }
        public string medianame { get; set; }
        public string desc { get; set; }
        public string memo { get; set; }
        public ImageUrl mediaurl { get; set; }
        public string videourl { get; set; }
        public bool isshow { get; set; }
        public int mediatypeid { get; set; }
        public DateTime crtdate { get; set; }
        public DateTime updatetime { get; set; }
        public bool deleteflag { get; set; }
        
    }

    public class Pubinfounitchild : VersionedEntity<int>
    {
        public int childid { get { return id; } set { id = value; } }
        public int pid { get; set; }
        public int unitid { get; set; }
        public string childname { get; set; }
        public float orderno { get; set; }
        public ImageUrl flagurl { get; set; }
        public string price { get; set; }
        public string desc { get; set; }
        public string memo { get; set; }
        public string guidevoice { get; set; }
        public string guidetext { get; set; }
        public Location gpsbd { get; set; }
        public Location gps { get; set; }
        public Location gpsgd { get; set; }
        public bool isshow { get; set; }
        public DateTime crtdate { get; set; }
        public DateTime updatetime { get; set; }
        public bool deleteflag { get; set; }
    }

    
    

}
