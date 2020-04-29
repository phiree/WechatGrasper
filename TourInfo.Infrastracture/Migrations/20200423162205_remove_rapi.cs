using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TourInfo.Infrastracture.Migrations
{
    public partial class remove_rapi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Projectinfo");

            migrationBuilder.DropTable(
                name: "Pubinfounit");

            migrationBuilder.DropTable(
                name: "Pubinfounitchild");

            migrationBuilder.DropTable(
                name: "Pubmediainfo");

            migrationBuilder.DropTable(
                name: "Pubunittag");

            migrationBuilder.DropTable(
                name: "Typefield");

            migrationBuilder.DropTable(
                name: "Typeinfo");

            migrationBuilder.DropTable(
                name: "Typepic");

            migrationBuilder.DropTable(
                name: "Typetag");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Projectinfo",
                columns: table => new
                {
                    pid = table.Column<int>(nullable: false),
                    Fingerprint = table.Column<string>(nullable: true),
                    Version = table.Column<string>(nullable: true),
                    appid = table.Column<string>(nullable: true),
                    areacode = table.Column<string>(nullable: true),
                    crtdate = table.Column<DateTime>(nullable: false),
                    defaultlogo = table.Column<string>(nullable: true),
                    deleteflag = table.Column<bool>(nullable: false),
                    desc = table.Column<string>(nullable: true),
                    detailfoot = table.Column<string>(nullable: true),
                    detailhead = table.Column<string>(nullable: true),
                    homeurl = table.Column<string>(nullable: true),
                    id = table.Column<int>(nullable: false),
                    iscomment = table.Column<bool>(nullable: false),
                    pname = table.Column<string>(nullable: true),
                    subpid = table.Column<int>(nullable: false),
                    topjumpurl = table.Column<string>(nullable: true),
                    toppicurl = table.Column<string>(nullable: true),
                    topresourceurl = table.Column<string>(nullable: true),
                    topvideourl = table.Column<string>(nullable: true),
                    updatetime = table.Column<DateTime>(nullable: false),
                    wapbgimg = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projectinfo", x => x.pid);
                });

            migrationBuilder.CreateTable(
                name: "Pubinfounit",
                columns: table => new
                {
                    unitid = table.Column<int>(nullable: false),
                    Fingerprint = table.Column<string>(nullable: true),
                    Version = table.Column<string>(nullable: true),
                    address = table.Column<string>(nullable: true),
                    areacode = table.Column<string>(nullable: true),
                    areaname = table.Column<string>(nullable: true),
                    bedcount = table.Column<int>(nullable: false),
                    booktel = table.Column<string>(nullable: true),
                    boxcount = table.Column<int>(nullable: false),
                    businesslicense = table.Column<string>(nullable: true),
                    businesstime = table.Column<string>(nullable: true),
                    commentnum = table.Column<int>(nullable: false),
                    complainttel = table.Column<string>(nullable: true),
                    crtdate = table.Column<DateTime>(nullable: false),
                    decorationtime = table.Column<string>(nullable: true),
                    deleteflag = table.Column<bool>(nullable: false),
                    desc = table.Column<string>(nullable: true),
                    detailurl = table.Column<string>(nullable: true),
                    environmentrating = table.Column<string>(nullable: true),
                    facilityrating = table.Column<string>(nullable: true),
                    favouredpolicy = table.Column<string>(nullable: true),
                    fax = table.Column<string>(nullable: true),
                    hygienerating = table.Column<string>(nullable: true),
                    id = table.Column<int>(nullable: false),
                    id5a = table.Column<int>(nullable: false),
                    imgnum = table.Column<int>(nullable: false),
                    infotel = table.Column<string>(nullable: true),
                    innertrafic = table.Column<string>(nullable: true),
                    level = table.Column<int>(nullable: false),
                    licenseno = table.Column<string>(nullable: true),
                    logopic = table.Column<string>(nullable: true),
                    mainline = table.Column<string>(nullable: true),
                    manager = table.Column<string>(nullable: true),
                    managertel = table.Column<string>(nullable: true),
                    maxcapacity = table.Column<int>(nullable: false),
                    memo = table.Column<string>(nullable: true),
                    name5a = table.Column<string>(nullable: true),
                    opentime = table.Column<string>(nullable: true),
                    orderno = table.Column<float>(nullable: false),
                    overallrating = table.Column<string>(nullable: true),
                    personprice = table.Column<float>(nullable: false),
                    pid = table.Column<int>(nullable: false),
                    poitypename = table.Column<string>(nullable: true),
                    poitypetag = table.Column<string>(nullable: true),
                    postcode = table.Column<string>(nullable: true),
                    pricedesc = table.Column<string>(nullable: true),
                    publictrafic = table.Column<string>(nullable: true),
                    reservefield1 = table.Column<string>(nullable: true),
                    reservefield2 = table.Column<string>(nullable: true),
                    reservefield3 = table.Column<string>(nullable: true),
                    reservefield4 = table.Column<string>(nullable: true),
                    reservefield5 = table.Column<string>(nullable: true),
                    reservefield6 = table.Column<string>(nullable: true),
                    reservefield7 = table.Column<string>(nullable: true),
                    reservefield8 = table.Column<string>(nullable: true),
                    reservefield9 = table.Column<string>(nullable: true),
                    roomcount = table.Column<int>(nullable: false),
                    roomprice = table.Column<float>(nullable: false),
                    seatcount = table.Column<int>(nullable: false),
                    servicerating = table.Column<string>(nullable: true),
                    shortname = table.Column<string>(nullable: true),
                    sourcefrom = table.Column<int>(nullable: false),
                    state = table.Column<int>(nullable: false),
                    telephone = table.Column<string>(nullable: true),
                    ticketprice = table.Column<float>(nullable: false),
                    tips = table.Column<string>(nullable: true),
                    typeid = table.Column<int>(nullable: false),
                    unitname = table.Column<string>(nullable: true),
                    updatetime = table.Column<DateTime>(nullable: false),
                    url = table.Column<string>(nullable: true),
                    url360 = table.Column<string>(nullable: true),
                    zonecode = table.Column<string>(nullable: true),
                    flagpic_LocalizedUrl = table.Column<string>(nullable: true),
                    flagpic_OriginalUrl = table.Column<string>(nullable: true),
                    gps_Latitude = table.Column<double>(nullable: false),
                    gps_Longitude = table.Column<double>(nullable: false),
                    gpsbd_Latitude = table.Column<double>(nullable: false),
                    gpsbd_Longitude = table.Column<double>(nullable: false),
                    gpsgd_Latitude = table.Column<double>(nullable: false),
                    gpsgd_Longitude = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pubinfounit", x => x.unitid);
                });

            migrationBuilder.CreateTable(
                name: "Pubinfounitchild",
                columns: table => new
                {
                    childid = table.Column<int>(nullable: false),
                    Fingerprint = table.Column<string>(nullable: true),
                    Version = table.Column<string>(nullable: true),
                    childname = table.Column<string>(nullable: true),
                    crtdate = table.Column<DateTime>(nullable: false),
                    deleteflag = table.Column<bool>(nullable: false),
                    desc = table.Column<string>(nullable: true),
                    guidetext = table.Column<string>(nullable: true),
                    guidevoice = table.Column<string>(nullable: true),
                    id = table.Column<int>(nullable: false),
                    isshow = table.Column<bool>(nullable: false),
                    memo = table.Column<string>(nullable: true),
                    orderno = table.Column<float>(nullable: false),
                    pid = table.Column<int>(nullable: false),
                    price = table.Column<string>(nullable: true),
                    unitid = table.Column<int>(nullable: false),
                    updatetime = table.Column<DateTime>(nullable: false),
                    flagurl_LocalizedUrl = table.Column<string>(nullable: true),
                    flagurl_OriginalUrl = table.Column<string>(nullable: true),
                    gps_Latitude = table.Column<double>(nullable: false),
                    gps_Longitude = table.Column<double>(nullable: false),
                    gpsbd_Latitude = table.Column<double>(nullable: false),
                    gpsbd_Longitude = table.Column<double>(nullable: false),
                    gpsgd_Latitude = table.Column<double>(nullable: false),
                    gpsgd_Longitude = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pubinfounitchild", x => x.childid);
                });

            migrationBuilder.CreateTable(
                name: "Pubmediainfo",
                columns: table => new
                {
                    mediaid = table.Column<int>(nullable: false),
                    Fingerprint = table.Column<string>(nullable: true),
                    Version = table.Column<string>(nullable: true),
                    crtdate = table.Column<DateTime>(nullable: false),
                    deleteflag = table.Column<bool>(nullable: false),
                    desc = table.Column<string>(nullable: true),
                    id = table.Column<int>(nullable: false),
                    isshow = table.Column<bool>(nullable: false),
                    medianame = table.Column<string>(nullable: true),
                    mediatypeid = table.Column<int>(nullable: false),
                    memo = table.Column<string>(nullable: true),
                    orderno = table.Column<float>(nullable: false),
                    pid = table.Column<int>(nullable: false),
                    topshow = table.Column<bool>(nullable: false),
                    typepicid = table.Column<int>(nullable: false),
                    unitid = table.Column<int>(nullable: false),
                    updatetime = table.Column<DateTime>(nullable: false),
                    videourl = table.Column<string>(nullable: true),
                    mediaurl_LocalizedUrl = table.Column<string>(nullable: true),
                    mediaurl_OriginalUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pubmediainfo", x => x.mediaid);
                });

            migrationBuilder.CreateTable(
                name: "Pubunittag",
                columns: table => new
                {
                    unittagid = table.Column<int>(nullable: false),
                    Fingerprint = table.Column<string>(nullable: true),
                    Version = table.Column<string>(nullable: true),
                    id = table.Column<int>(nullable: false),
                    pid = table.Column<int>(nullable: false),
                    tagid = table.Column<int>(nullable: false),
                    tagvalue = table.Column<string>(nullable: true),
                    unitid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pubunittag", x => x.unittagid);
                });

            migrationBuilder.CreateTable(
                name: "Typefield",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false),
                    Fingerprint = table.Column<string>(nullable: true),
                    Version = table.Column<string>(nullable: true),
                    crtdate = table.Column<DateTime>(nullable: false),
                    customname = table.Column<string>(nullable: true),
                    deleteflag = table.Column<bool>(nullable: false),
                    displayorder = table.Column<int>(nullable: false),
                    fieldname = table.Column<string>(nullable: true),
                    fieldtype = table.Column<string>(nullable: true),
                    groupname = table.Column<string>(nullable: true),
                    isdisplay = table.Column<bool>(nullable: false),
                    isedit = table.Column<bool>(nullable: false),
                    orderno = table.Column<float>(nullable: false),
                    pid = table.Column<int>(nullable: false),
                    typeid = table.Column<int>(nullable: false),
                    updatetime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Typefield", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Typeinfo",
                columns: table => new
                {
                    typeid = table.Column<int>(nullable: false),
                    Fingerprint = table.Column<string>(nullable: true),
                    Version = table.Column<string>(nullable: true),
                    crtdate = table.Column<DateTime>(nullable: false),
                    deleteflag = table.Column<bool>(nullable: false),
                    editurl = table.Column<string>(nullable: true),
                    existschild = table.Column<bool>(nullable: false),
                    existsroom = table.Column<bool>(nullable: false),
                    existsscenic = table.Column<bool>(nullable: false),
                    id = table.Column<int>(nullable: false),
                    isshow = table.Column<bool>(nullable: false),
                    mobilememo = table.Column<string>(nullable: true),
                    orderno = table.Column<float>(nullable: false),
                    pid = table.Column<int>(nullable: false),
                    ptypeid = table.Column<int>(nullable: false),
                    showurl = table.Column<string>(nullable: true),
                    typename = table.Column<string>(nullable: true),
                    updatetime = table.Column<DateTime>(nullable: false),
                    wapshowimg_LocalizedUrl = table.Column<string>(nullable: true),
                    wapshowimg_OriginalUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Typeinfo", x => x.typeid);
                });

            migrationBuilder.CreateTable(
                name: "Typepic",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false),
                    Fingerprint = table.Column<string>(nullable: true),
                    Version = table.Column<string>(nullable: true),
                    crtdate = table.Column<DateTime>(nullable: false),
                    deleteflag = table.Column<bool>(nullable: false),
                    groupname = table.Column<string>(nullable: true),
                    mediatypeid = table.Column<int>(nullable: false),
                    mediatypename = table.Column<string>(nullable: true),
                    orderno = table.Column<float>(nullable: false),
                    pid = table.Column<int>(nullable: false),
                    typeid = table.Column<int>(nullable: false),
                    updatetime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Typepic", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Typetag",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false),
                    Fingerprint = table.Column<string>(nullable: true),
                    Version = table.Column<string>(nullable: true),
                    crtdate = table.Column<DateTime>(nullable: false),
                    deleteflag = table.Column<bool>(nullable: false),
                    groupname = table.Column<string>(nullable: true),
                    orderno = table.Column<float>(nullable: false),
                    pid = table.Column<int>(nullable: false),
                    tagname = table.Column<string>(nullable: true),
                    typeid = table.Column<int>(nullable: false),
                    updatetime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Typetag", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pubinfounitchild_childid",
                table: "Pubinfounitchild",
                column: "childid");
        }
    }
}
