using System;
using System.Collections.Generic;
using System.Text;

namespace TourInfo.Domain.DomainModel.Rapi
{
    public class Projectinfo
    {
        public int pid { get; set; }
        public string pname { get; set; }
        public object homeurl { get; set; }
        public string areacode { get; set; }
        public object desc { get; set; }
        public string topvideourl { get; set; }
        public string toppicurl { get; set; }
        public string topjumpurl { get; set; }
        public string detailhead { get; set; }
        public string detailfoot { get; set; }
        public string topresourceurl { get; set; }
        public object wapbgimg { get; set; }
        public object appid { get; set; }
        public object defaultlogo { get; set; }
        public int subpid { get; set; }
        public bool iscomment { get; set; }
        public DateTime crtdate { get; set; }
        public DateTime updatetime { get; set; }
        public bool deleteflag { get; set; }
    }

    public class Typeinfo
    {
        public int typeid { get; set; }
        public int pid { get; set; }
        public int orderno { get; set; }
        public string typename { get; set; }
        public object editurl { get; set; }
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

    public class Typefield
    {
        public int id { get; set; }
        public int pid { get; set; }
        public int typeid { get; set; }
        public int orderno { get; set; }
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

    public class Typetag
    {
        public int id { get; set; }
        public int pid { get; set; }
        public int typeid { get; set; }
        public int orderno { get; set; }
        public string groupname { get; set; }
        public string tagname { get; set; }
        public DateTime crtdate { get; set; }
        public DateTime updatetime { get; set; }
        public bool deleteflag { get; set; }
    }

    public class Typepic
    {
        public int id { get; set; }
        public int pid { get; set; }
        public int typeid { get; set; }
        public int orderno { get; set; }
        public string groupname { get; set; }
        public int mediatypeid { get; set; }
        public string mediatypename { get; set; }
        public DateTime crtdate { get; set; }
        public DateTime updatetime { get; set; }
        public bool deleteflag { get; set; }
    }

    public class Pubinfounit
    {
        public int unitid { get; set; }
        public int pid { get; set; }
        public int typeid { get; set; }
        public string areacode { get; set; }
        public string areaname { get; set; }
        public string unitname { get; set; }
        public object shortname { get; set; }
        public int orderno { get; set; }
        public string gpsbd { get; set; }
        public string gps { get; set; }
        public string gpsgd { get; set; }
        public string address { get; set; }
        public string postcode { get; set; }
        public string zonecode { get; set; }
        public string telephone { get; set; }
        public string infotel { get; set; }
        public object booktel { get; set; }
        public string complainttel { get; set; }
        public string fax { get; set; }
        public string url { get; set; }
        public string url360 { get; set; }
        public string logopic { get; set; }
        public string flagpic { get; set; }
        public string publictrafic { get; set; }
        public string memo { get; set; }
        public string desc { get; set; }
        public object manager { get; set; }
        public object managertel { get; set; }
        public object businesslicense { get; set; }
        public string businesstime { get; set; }
        public int level { get; set; }
        public int sourcefrom { get; set; }
        public object opentime { get; set; }
        public object decorationtime { get; set; }
        public object tips { get; set; }
        public string favouredpolicy { get; set; }
        public string innertrafic { get; set; }
        public int maxcapacity { get; set; }
        public int ticketprice { get; set; }
        public string pricedesc { get; set; }
        public int id5a { get; set; }
        public object name5a { get; set; }
        public int roomcount { get; set; }
        public int bedcount { get; set; }
        public int roomprice { get; set; }
        public int boxcount { get; set; }
        public int seatcount { get; set; }
        public int personprice { get; set; }
        public object licenseno { get; set; }
        public object mainline { get; set; }
        public object poitypename { get; set; }
        public object poitypetag { get; set; }
        public object detailurl { get; set; }
        public object overallrating { get; set; }
        public object servicerating { get; set; }
        public object environmentrating { get; set; }
        public object facilityrating { get; set; }
        public object hygienerating { get; set; }
        public int imgnum { get; set; }
        public int commentnum { get; set; }
        public object reservefield1 { get; set; }
        public object reservefield2 { get; set; }
        public object reservefield3 { get; set; }
        public object reservefield4 { get; set; }
        public object reservefield5 { get; set; }
        public object reservefield6 { get; set; }
        public object reservefield7 { get; set; }
        public object reservefield8 { get; set; }
        public object reservefield9 { get; set; }
        public int state { get; set; }
        public DateTime crtdate { get; set; }
        public DateTime updatetime { get; set; }
        public bool deleteflag { get; set; }
    }

    public class Pubunittag
    {
        public int unittagid { get; set; }
        public int pid { get; set; }
        public int unitid { get; set; }
        public int tagid { get; set; }
        public string tagvalue { get; set; }
    }

    public class Pubmediainfo
    {
        public int mediaid { get; set; }
        public bool topshow { get; set; }
        public int unitid { get; set; }
        public int typepicid { get; set; }
        public int pid { get; set; }
        public int orderno { get; set; }
        public string medianame { get; set; }
        public object desc { get; set; }
        public string memo { get; set; }
        public string mediaurl { get; set; }
        public object videourl { get; set; }
        public bool isshow { get; set; }
        public int mediatypeid { get; set; }
        public DateTime crtdate { get; set; }
        public DateTime updatetime { get; set; }
        public bool deleteflag { get; set; }
    }

    public class Pubinfounitchild
    {
        public int childid { get; set; }
        public int pid { get; set; }
        public int unitid { get; set; }
        public string childname { get; set; }
        public int orderno { get; set; }
        public string flagurl { get; set; }
        public string price { get; set; }
        public string desc { get; set; }
        public string memo { get; set; }
        public object guidevoice { get; set; }
        public object guidetext { get; set; }
        public object gpsbd { get; set; }
        public object gps { get; set; }
        public object gpsgd { get; set; }
        public bool isshow { get; set; }
        public DateTime crtdate { get; set; }
        public DateTime updatetime { get; set; }
        public bool deleteflag { get; set; }
    }

    


}
