using Microsoft.EntityFrameworkCore.Migrations;

namespace TourInfo.Infrastracture.Migrations
{
    public partial class local_product2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SDTASpecialLocalProductDetail",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    Version = table.Column<string>(nullable: true),
                    Fingerprint = table.Column<string>(nullable: true),
                    commodity_id = table.Column<string>(nullable: true),
                    comm_type_id = table.Column<string>(nullable: true),
                    destination_id = table.Column<string>(nullable: true),
                    name_cn = table.Column<string>(nullable: true),
                    full_name = table.Column<string>(nullable: true),
                    short_name = table.Column<string>(nullable: true),
                    commodity_intr = table.Column<string>(nullable: true),
                    manufacturer_inf = table.Column<string>(nullable: true),
                    state = table.Column<int>(nullable: false),
                    auditdate = table.Column<string>(nullable: true),
                    created_at = table.Column<string>(nullable: true),
                    updated_at = table.Column<string>(nullable: true),
                    keywords = table.Column<string>(nullable: true),
                    tags = table.Column<string>(nullable: true),
                    defaultphoto_OriginalUrl = table.Column<string>(nullable: true),
                    defaultphoto_LocalizedUrl = table.Column<string>(nullable: true),
                    rank = table.Column<int>(nullable: false),
                    is_404 = table.Column<int>(nullable: false),
                    price_desc = table.Column<string>(nullable: true),
                    cityname = table.Column<string>(nullable: true),
                    areaname = table.Column<string>(nullable: true),
                    comm_type_name = table.Column<string>(nullable: true),
                    commentscore = table.Column<string>(nullable: true),
                    commentcount = table.Column<int>(nullable: false),
                    likescount = table.Column<int>(nullable: false),
                    collectscount = table.Column<int>(nullable: false),
                    perlink = table.Column<string>(nullable: true),
                    compresspic = table.Column<string>(nullable: true),
                    destination_id1 = table.Column<int>(nullable: false),
                    destination_destination_id = table.Column<string>(nullable: true),
                    destination_destname = table.Column<string>(nullable: true),
                    destination_full_name = table.Column<string>(nullable: true),
                    destination_short_name = table.Column<string>(nullable: true),
                    destination_adm_name = table.Column<string>(nullable: true),
                    destination_adm_address = table.Column<string>(nullable: true),
                    destination_adm_phone = table.Column<string>(nullable: true),
                    destination_dest_des = table.Column<string>(nullable: true),
                    destination_culture = table.Column<string>(nullable: true),
                    destination_dest_adver = table.Column<string>(nullable: true),
                    destination_clim_des = table.Column<string>(nullable: true),
                    destination_notes_des = table.Column<string>(nullable: true),
                    destination_tou_taboo = table.Column<string>(nullable: true),
                    destination_fea_inf = table.Column<string>(nullable: true),
                    destination_longitude = table.Column<string>(nullable: true),
                    destination_latitude = table.Column<string>(nullable: true),
                    destination_airlines = table.Column<string>(nullable: true),
                    destination_railway = table.Column<string>(nullable: true),
                    destination_highway = table.Column<string>(nullable: true),
                    destination_water_carriage = table.Column<string>(nullable: true),
                    destination_bus = table.Column<string>(nullable: true),
                    destination_taxi = table.Column<string>(nullable: true),
                    destination_fea_traffic = table.Column<string>(nullable: true),
                    destination_created_at = table.Column<string>(nullable: true),
                    destination_updated_at = table.Column<string>(nullable: true),
                    destination_audit_state = table.Column<int>(nullable: false),
                    destination_website = table.Column<string>(nullable: true),
                    destination_dest_type_id = table.Column<int>(nullable: false),
                    destination_defaultphoto_OriginalUrl = table.Column<string>(nullable: true),
                    destination_defaultphoto_LocalizedUrl = table.Column<string>(nullable: true),
                    destination_keywords = table.Column<string>(nullable: true),
                    destination_tags = table.Column<string>(nullable: true),
                    destination_charmcitypic = table.Column<string>(nullable: true),
                    destination_daren_picture = table.Column<string>(nullable: true),
                    destination_area_id = table.Column<string>(nullable: true),
                    destination_rank = table.Column<int>(nullable: false),
                    destination_is_404 = table.Column<int>(nullable: false),
                    destination_cityname = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SDTASpecialLocalProductDetail", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "SDTASpecialLocalProductDetailFilterPictures",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false),
                    SpecialLocalProducId = table.Column<string>(nullable: false),
                    pho_id = table.Column<string>(nullable: true),
                    picable_id = table.Column<string>(nullable: true),
                    picable_type = table.Column<string>(nullable: true),
                    pho_name = table.Column<string>(nullable: true),
                    pho_type = table.Column<string>(nullable: true),
                    pho_format = table.Column<string>(nullable: true),
                    pho_path_OriginalUrl = table.Column<string>(nullable: true),
                    pho_path_LocalizedUrl = table.Column<string>(nullable: true),
                    created_at = table.Column<string>(nullable: true),
                    updated_at = table.Column<string>(nullable: true),
                    rank = table.Column<int>(nullable: false),
                    is_404 = table.Column<int>(nullable: false),
                    deleted_at = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SDTASpecialLocalProductDetailFilterPictures", x => new { x.SpecialLocalProducId, x.id });
                    table.ForeignKey(
                        name: "FK_SDTASpecialLocalProductDetailFilterPictures_SDTASpecialLocalProductDetail_SpecialLocalProducId",
                        column: x => x.SpecialLocalProducId,
                        principalTable: "SDTASpecialLocalProductDetail",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SDTASpecialLocalProductDetailPictures",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false),
                    SpecialLocalProducId = table.Column<string>(nullable: false),
                    pho_id = table.Column<string>(nullable: true),
                    picable_id = table.Column<string>(nullable: true),
                    picable_type = table.Column<string>(nullable: true),
                    pho_name = table.Column<string>(nullable: true),
                    pho_type = table.Column<string>(nullable: true),
                    pho_format = table.Column<string>(nullable: true),
                    pho_path_OriginalUrl = table.Column<string>(nullable: true),
                    pho_path_LocalizedUrl = table.Column<string>(nullable: true),
                    created_at = table.Column<string>(nullable: true),
                    updated_at = table.Column<string>(nullable: true),
                    rank = table.Column<int>(nullable: false),
                    is_404 = table.Column<int>(nullable: false),
                    deleted_at = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SDTASpecialLocalProductDetailPictures", x => new { x.SpecialLocalProducId, x.id });
                    table.ForeignKey(
                        name: "FK_SDTASpecialLocalProductDetailPictures_SDTASpecialLocalProductDetail_SpecialLocalProducId",
                        column: x => x.SpecialLocalProducId,
                        principalTable: "SDTASpecialLocalProductDetail",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SDTASpecialLocalProductDetailFilterPictures");

            migrationBuilder.DropTable(
                name: "SDTASpecialLocalProductDetailPictures");

            migrationBuilder.DropTable(
                name: "SDTASpecialLocalProductDetail");
        }
    }
}
