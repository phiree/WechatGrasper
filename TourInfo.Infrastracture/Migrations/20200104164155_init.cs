using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TourInfo.Infrastracture.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EWQYPlaceTypeEntities",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    Version = table.Column<string>(nullable: true),
                    Fingerprint = table.Column<string>(nullable: true),
                    PlaceType = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    CompanyVenueType_name = table.Column<string>(nullable: true),
                    thumbnailKey_OriginalUrl = table.Column<string>(nullable: true),
                    thumbnailKey_LocalizedUrl = table.Column<string>(nullable: true),
                    startTime = table.Column<string>(nullable: true),
                    createTime = table.Column<string>(nullable: true),
                    address = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    endTime = table.Column<string>(nullable: true),
                    detail = table.Column<string>(nullable: true),
                    credits = table.Column<int>(nullable: true),
                    isShared = table.Column<bool>(nullable: true),
                    CompanyVenue_name = table.Column<string>(nullable: true),
                    satisfactionScore = table.Column<string>(nullable: true),
                    typeId = table.Column<string>(nullable: true),
                    introduction = table.Column<string>(nullable: true),
                    CompanyVenue_address = table.Column<string>(nullable: true),
                    isFavorite = table.Column<string>(nullable: true),
                    serviceTimeStart = table.Column<string>(nullable: true),
                    serviceNote = table.Column<string>(nullable: true),
                    serviceTimeEnd = table.Column<string>(nullable: true),
                    telNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EWQYPlaceTypeEntities", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Projectinfos",
                columns: table => new
                {
                    pid = table.Column<int>(nullable: false),
                    id = table.Column<int>(nullable: false),
                    Version = table.Column<string>(nullable: true),
                    Fingerprint = table.Column<string>(nullable: true),
                    pname = table.Column<string>(nullable: true),
                    homeurl = table.Column<string>(nullable: true),
                    areacode = table.Column<string>(nullable: true),
                    desc = table.Column<string>(nullable: true),
                    topvideourl = table.Column<string>(nullable: true),
                    toppicurl = table.Column<string>(nullable: true),
                    topjumpurl = table.Column<string>(nullable: true),
                    detailhead = table.Column<string>(nullable: true),
                    detailfoot = table.Column<string>(nullable: true),
                    topresourceurl = table.Column<string>(nullable: true),
                    wapbgimg = table.Column<string>(nullable: true),
                    appid = table.Column<string>(nullable: true),
                    defaultlogo = table.Column<string>(nullable: true),
                    subpid = table.Column<int>(nullable: false),
                    iscomment = table.Column<bool>(nullable: false),
                    crtdate = table.Column<DateTime>(nullable: false),
                    updatetime = table.Column<DateTime>(nullable: false),
                    deleteflag = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projectinfos", x => x.pid);
                });

            migrationBuilder.CreateTable(
                name: "Pubinfounitchilds",
                columns: table => new
                {
                    childid = table.Column<int>(nullable: false),
                    id = table.Column<int>(nullable: false),
                    Version = table.Column<string>(nullable: true),
                    Fingerprint = table.Column<string>(nullable: true),
                    pid = table.Column<int>(nullable: false),
                    unitid = table.Column<int>(nullable: false),
                    childname = table.Column<string>(nullable: true),
                    orderno = table.Column<float>(nullable: false),
                    flagurl_OriginalUrl = table.Column<string>(nullable: true),
                    flagurl_LocalizedUrl = table.Column<string>(nullable: true),
                    price = table.Column<string>(nullable: true),
                    desc = table.Column<string>(nullable: true),
                    memo = table.Column<string>(nullable: true),
                    guidevoice = table.Column<string>(nullable: true),
                    guidetext = table.Column<string>(nullable: true),
                    gpsbd_Longitude = table.Column<double>(nullable: false),
                    gpsbd_Latitude = table.Column<double>(nullable: false),
                    gps_Longitude = table.Column<double>(nullable: false),
                    gps_Latitude = table.Column<double>(nullable: false),
                    gpsgd_Longitude = table.Column<double>(nullable: false),
                    gpsgd_Latitude = table.Column<double>(nullable: false),
                    isshow = table.Column<bool>(nullable: false),
                    crtdate = table.Column<DateTime>(nullable: false),
                    updatetime = table.Column<DateTime>(nullable: false),
                    deleteflag = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pubinfounitchilds", x => x.childid);
                });

            migrationBuilder.CreateTable(
                name: "Pubinfounits",
                columns: table => new
                {
                    unitid = table.Column<int>(nullable: false),
                    id = table.Column<int>(nullable: false),
                    Version = table.Column<string>(nullable: true),
                    Fingerprint = table.Column<string>(nullable: true),
                    pid = table.Column<int>(nullable: false),
                    typeid = table.Column<int>(nullable: false),
                    areacode = table.Column<string>(nullable: true),
                    areaname = table.Column<string>(nullable: true),
                    unitname = table.Column<string>(nullable: true),
                    shortname = table.Column<string>(nullable: true),
                    orderno = table.Column<float>(nullable: false),
                    gpsbd_Longitude = table.Column<double>(nullable: false),
                    gpsbd_Latitude = table.Column<double>(nullable: false),
                    gps_Longitude = table.Column<double>(nullable: false),
                    gps_Latitude = table.Column<double>(nullable: false),
                    gpsgd_Longitude = table.Column<double>(nullable: false),
                    gpsgd_Latitude = table.Column<double>(nullable: false),
                    address = table.Column<string>(nullable: true),
                    postcode = table.Column<string>(nullable: true),
                    zonecode = table.Column<string>(nullable: true),
                    telephone = table.Column<string>(nullable: true),
                    infotel = table.Column<string>(nullable: true),
                    booktel = table.Column<string>(nullable: true),
                    complainttel = table.Column<string>(nullable: true),
                    fax = table.Column<string>(nullable: true),
                    url = table.Column<string>(nullable: true),
                    url360 = table.Column<string>(nullable: true),
                    logopic = table.Column<string>(nullable: true),
                    flagpic_OriginalUrl = table.Column<string>(nullable: true),
                    flagpic_LocalizedUrl = table.Column<string>(nullable: true),
                    publictrafic = table.Column<string>(nullable: true),
                    memo = table.Column<string>(nullable: true),
                    desc = table.Column<string>(nullable: true),
                    manager = table.Column<string>(nullable: true),
                    managertel = table.Column<string>(nullable: true),
                    businesslicense = table.Column<string>(nullable: true),
                    businesstime = table.Column<string>(nullable: true),
                    level = table.Column<int>(nullable: false),
                    sourcefrom = table.Column<int>(nullable: false),
                    opentime = table.Column<string>(nullable: true),
                    decorationtime = table.Column<string>(nullable: true),
                    tips = table.Column<string>(nullable: true),
                    favouredpolicy = table.Column<string>(nullable: true),
                    innertrafic = table.Column<string>(nullable: true),
                    maxcapacity = table.Column<int>(nullable: false),
                    ticketprice = table.Column<float>(nullable: false),
                    pricedesc = table.Column<string>(nullable: true),
                    id5a = table.Column<int>(nullable: false),
                    name5a = table.Column<string>(nullable: true),
                    roomcount = table.Column<int>(nullable: false),
                    bedcount = table.Column<int>(nullable: false),
                    roomprice = table.Column<float>(nullable: false),
                    boxcount = table.Column<int>(nullable: false),
                    seatcount = table.Column<int>(nullable: false),
                    personprice = table.Column<float>(nullable: false),
                    licenseno = table.Column<string>(nullable: true),
                    mainline = table.Column<string>(nullable: true),
                    poitypename = table.Column<string>(nullable: true),
                    poitypetag = table.Column<string>(nullable: true),
                    detailurl = table.Column<string>(nullable: true),
                    overallrating = table.Column<string>(nullable: true),
                    servicerating = table.Column<string>(nullable: true),
                    environmentrating = table.Column<string>(nullable: true),
                    facilityrating = table.Column<string>(nullable: true),
                    hygienerating = table.Column<string>(nullable: true),
                    imgnum = table.Column<int>(nullable: false),
                    commentnum = table.Column<int>(nullable: false),
                    reservefield1 = table.Column<string>(nullable: true),
                    reservefield2 = table.Column<string>(nullable: true),
                    reservefield3 = table.Column<string>(nullable: true),
                    reservefield4 = table.Column<string>(nullable: true),
                    reservefield5 = table.Column<string>(nullable: true),
                    reservefield6 = table.Column<string>(nullable: true),
                    reservefield7 = table.Column<string>(nullable: true),
                    reservefield8 = table.Column<string>(nullable: true),
                    reservefield9 = table.Column<string>(nullable: true),
                    state = table.Column<int>(nullable: false),
                    crtdate = table.Column<DateTime>(nullable: false),
                    updatetime = table.Column<DateTime>(nullable: false),
                    deleteflag = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pubinfounits", x => x.unitid);
                });

            migrationBuilder.CreateTable(
                name: "Pubmediainfos",
                columns: table => new
                {
                    mediaid = table.Column<int>(nullable: false),
                    id = table.Column<int>(nullable: false),
                    Version = table.Column<string>(nullable: true),
                    Fingerprint = table.Column<string>(nullable: true),
                    topshow = table.Column<bool>(nullable: false),
                    unitid = table.Column<int>(nullable: false),
                    typepicid = table.Column<int>(nullable: false),
                    pid = table.Column<int>(nullable: false),
                    orderno = table.Column<float>(nullable: false),
                    medianame = table.Column<string>(nullable: true),
                    desc = table.Column<string>(nullable: true),
                    memo = table.Column<string>(nullable: true),
                    mediaurl_OriginalUrl = table.Column<string>(nullable: true),
                    mediaurl_LocalizedUrl = table.Column<string>(nullable: true),
                    videourl = table.Column<string>(nullable: true),
                    isshow = table.Column<bool>(nullable: false),
                    mediatypeid = table.Column<int>(nullable: false),
                    crtdate = table.Column<DateTime>(nullable: false),
                    updatetime = table.Column<DateTime>(nullable: false),
                    deleteflag = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pubmediainfos", x => x.mediaid);
                });

            migrationBuilder.CreateTable(
                name: "Pubunittags",
                columns: table => new
                {
                    unittagid = table.Column<int>(nullable: false),
                    id = table.Column<int>(nullable: false),
                    Version = table.Column<string>(nullable: true),
                    Fingerprint = table.Column<string>(nullable: true),
                    pid = table.Column<int>(nullable: false),
                    unitid = table.Column<int>(nullable: false),
                    tagid = table.Column<int>(nullable: false),
                    tagvalue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pubunittags", x => x.unittagid);
                });

            migrationBuilder.CreateTable(
                name: "Typefields",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false),
                    Version = table.Column<string>(nullable: true),
                    Fingerprint = table.Column<string>(nullable: true),
                    pid = table.Column<int>(nullable: false),
                    typeid = table.Column<int>(nullable: false),
                    orderno = table.Column<float>(nullable: false),
                    fieldname = table.Column<string>(nullable: true),
                    fieldtype = table.Column<string>(nullable: true),
                    groupname = table.Column<string>(nullable: true),
                    customname = table.Column<string>(nullable: true),
                    isedit = table.Column<bool>(nullable: false),
                    isdisplay = table.Column<bool>(nullable: false),
                    displayorder = table.Column<int>(nullable: false),
                    crtdate = table.Column<DateTime>(nullable: false),
                    updatetime = table.Column<DateTime>(nullable: false),
                    deleteflag = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Typefields", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Typeinfos",
                columns: table => new
                {
                    typeid = table.Column<int>(nullable: false),
                    id = table.Column<int>(nullable: false),
                    Version = table.Column<string>(nullable: true),
                    Fingerprint = table.Column<string>(nullable: true),
                    pid = table.Column<int>(nullable: false),
                    orderno = table.Column<float>(nullable: false),
                    typename = table.Column<string>(nullable: true),
                    editurl = table.Column<string>(nullable: true),
                    showurl = table.Column<string>(nullable: true),
                    mobilememo = table.Column<string>(nullable: true),
                    ptypeid = table.Column<int>(nullable: false),
                    isshow = table.Column<bool>(nullable: false),
                    existschild = table.Column<bool>(nullable: false),
                    existsroom = table.Column<bool>(nullable: false),
                    existsscenic = table.Column<bool>(nullable: false),
                    wapshowimg_OriginalUrl = table.Column<string>(nullable: true),
                    wapshowimg_LocalizedUrl = table.Column<string>(nullable: true),
                    crtdate = table.Column<DateTime>(nullable: false),
                    updatetime = table.Column<DateTime>(nullable: false),
                    deleteflag = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Typeinfos", x => x.typeid);
                });

            migrationBuilder.CreateTable(
                name: "Typepics",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false),
                    Version = table.Column<string>(nullable: true),
                    Fingerprint = table.Column<string>(nullable: true),
                    pid = table.Column<int>(nullable: false),
                    typeid = table.Column<int>(nullable: false),
                    orderno = table.Column<float>(nullable: false),
                    groupname = table.Column<string>(nullable: true),
                    mediatypeid = table.Column<int>(nullable: false),
                    mediatypename = table.Column<string>(nullable: true),
                    crtdate = table.Column<DateTime>(nullable: false),
                    updatetime = table.Column<DateTime>(nullable: false),
                    deleteflag = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Typepics", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Typetags",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false),
                    Version = table.Column<string>(nullable: true),
                    Fingerprint = table.Column<string>(nullable: true),
                    pid = table.Column<int>(nullable: false),
                    typeid = table.Column<int>(nullable: false),
                    orderno = table.Column<float>(nullable: false),
                    groupname = table.Column<string>(nullable: true),
                    tagname = table.Column<string>(nullable: true),
                    crtdate = table.Column<DateTime>(nullable: false),
                    updatetime = table.Column<DateTime>(nullable: false),
                    deleteflag = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Typetags", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ZbtaNews",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    Version = table.Column<string>(nullable: true),
                    Fingerprint = table.Column<string>(nullable: true),
                    releaseTime = table.Column<string>(nullable: true),
                    checkState = table.Column<string>(nullable: true),
                    titles = table.Column<string>(nullable: true),
                    image_OriginalUrl = table.Column<string>(nullable: true),
                    image_LocalizedUrl = table.Column<string>(nullable: true),
                    created = table.Column<string>(nullable: true),
                    back1 = table.Column<string>(nullable: true),
                    details = table.Column<string>(nullable: true),
                    localizedDetails = table.Column<string>(nullable: true),
                    createUser = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZbtaNews", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "CompanyVanueLocations",
                columns: table => new
                {
                    CompanyVenueid = table.Column<string>(nullable: false),
                    Longitude = table.Column<double>(nullable: false),
                    Latitude = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyVanueLocations", x => x.CompanyVenueid);
                    table.ForeignKey(
                        name: "FK_CompanyVanueLocations_EWQYPlaceTypeEntities_CompanyVenueid",
                        column: x => x.CompanyVenueid,
                        principalTable: "EWQYPlaceTypeEntities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EWQYPlaceTypeEntities_pictureKeys",
                columns: table => new
                {
                    OriginalUrl = table.Column<string>(nullable: false),
                    id = table.Column<string>(nullable: false),
                    LocalizedUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EWQYPlaceTypeEntities_pictureKeys", x => new { x.OriginalUrl, x.id });
                    table.ForeignKey(
                        name: "FK_EWQYPlaceTypeEntities_pictureKeys_EWQYPlaceTypeEntities_id",
                        column: x => x.id,
                        principalTable: "EWQYPlaceTypeEntities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EWQYPlaceTypeEntities_pictureKeys_id",
                table: "EWQYPlaceTypeEntities_pictureKeys",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_Pubinfounitchilds_childid",
                table: "Pubinfounitchilds",
                column: "childid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyVanueLocations");

            migrationBuilder.DropTable(
                name: "EWQYPlaceTypeEntities_pictureKeys");

            migrationBuilder.DropTable(
                name: "Projectinfos");

            migrationBuilder.DropTable(
                name: "Pubinfounitchilds");

            migrationBuilder.DropTable(
                name: "Pubinfounits");

            migrationBuilder.DropTable(
                name: "Pubmediainfos");

            migrationBuilder.DropTable(
                name: "Pubunittags");

            migrationBuilder.DropTable(
                name: "Typefields");

            migrationBuilder.DropTable(
                name: "Typeinfos");

            migrationBuilder.DropTable(
                name: "Typepics");

            migrationBuilder.DropTable(
                name: "Typetags");

            migrationBuilder.DropTable(
                name: "ZbtaNews");

            migrationBuilder.DropTable(
                name: "EWQYPlaceTypeEntities");
        }
    }
}
