using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TourInfo.Infrastracture.Migrations
{
    public partial class delete_food_local : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommodityPrice");

            migrationBuilder.DropTable(
                name: "SDTAFoodDetailDestination");

            migrationBuilder.DropTable(
                name: "SDTAFoodDetailFilterPictures");

            migrationBuilder.DropTable(
                name: "SDTAFoodDetailPictures");

            migrationBuilder.DropTable(
                name: "SDTASpecialLocalProductDetailFilterPictures");

            migrationBuilder.DropTable(
                name: "SDTASpecialLocalProductDetailPictures");

            migrationBuilder.DropTable(
                name: "SDTAFoodDetail");

            migrationBuilder.DropTable(
                name: "SDTASpecialLocalProductDetail");

            migrationBuilder.DropTable(
                name: "CommodityType");

            migrationBuilder.AddColumn<string>(
                name: "Fingerprint",
                table: "SDTACityGuideDetail",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Version",
                table: "SDTACityGuideDetail",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "slug",
                table: "SDTACityGuideDetail",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Fingerprint",
                table: "SDTACityGuideDetail");

            migrationBuilder.DropColumn(
                name: "Version",
                table: "SDTACityGuideDetail");

            migrationBuilder.DropColumn(
                name: "slug",
                table: "SDTACityGuideDetail");

            migrationBuilder.CreateTable(
                name: "CommodityType",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    comm_name = table.Column<string>(nullable: true),
                    comm_type_id = table.Column<string>(nullable: true),
                    comm_type_id_p = table.Column<string>(nullable: true),
                    created_at = table.Column<string>(nullable: true),
                    deleted_at = table.Column<string>(nullable: true),
                    grade = table.Column<int>(nullable: false),
                    updated_at = table.Column<string>(nullable: true),
                    user_id = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommodityType", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "SDTAFoodDetail",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false),
                    areaname = table.Column<string>(nullable: true),
                    cityname = table.Column<string>(nullable: true),
                    collectscount = table.Column<int>(nullable: false),
                    commentcount = table.Column<int>(nullable: false),
                    commentscore = table.Column<string>(nullable: true),
                    compresspic = table.Column<string>(nullable: true),
                    created_at = table.Column<string>(nullable: true),
                    destination_id = table.Column<string>(nullable: true),
                    food_enname = table.Column<string>(nullable: true),
                    food_fullnane = table.Column<string>(nullable: true),
                    food_price = table.Column<string>(nullable: true),
                    food_recmmond = table.Column<string>(nullable: true),
                    food_shortname = table.Column<string>(nullable: true),
                    food_type_id = table.Column<string>(nullable: true),
                    is_404 = table.Column<int>(nullable: false),
                    keywords = table.Column<string>(nullable: true),
                    likescount = table.Column<int>(nullable: false),
                    perlink = table.Column<string>(nullable: true),
                    rank = table.Column<int>(nullable: false),
                    res_type_rela = table.Column<string>(nullable: true),
                    restaurant_id = table.Column<string>(nullable: true),
                    snack_int = table.Column<string>(nullable: true),
                    snack_intr_m = table.Column<string>(nullable: true),
                    snack_name = table.Column<string>(nullable: true),
                    snack_pho = table.Column<string>(nullable: true),
                    source = table.Column<int>(nullable: false),
                    state = table.Column<int>(nullable: false),
                    tags = table.Column<string>(nullable: true),
                    unitcode = table.Column<string>(nullable: true),
                    updated_at = table.Column<string>(nullable: true),
                    user_id = table.Column<string>(nullable: true),
                    snack_food_type_created_at = table.Column<string>(nullable: true),
                    snack_food_type_deleted_at = table.Column<string>(nullable: true),
                    snack_food_type_food_type_id = table.Column<string>(nullable: true),
                    snack_food_type_food_type_id_p = table.Column<string>(nullable: true),
                    snack_food_type_food_type_name = table.Column<string>(nullable: true),
                    snack_food_type_grade = table.Column<string>(nullable: true),
                    snack_food_type_updated_at = table.Column<string>(nullable: true),
                    snack_food_type_user_id = table.Column<string>(nullable: true),
                    defaultphoto_LocalizedUrl = table.Column<string>(nullable: true),
                    defaultphoto_OriginalUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SDTAFoodDetail", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "SDTASpecialLocalProductDetail",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    areaname = table.Column<string>(nullable: true),
                    auditdate = table.Column<string>(nullable: true),
                    cityname = table.Column<string>(nullable: true),
                    collectscount = table.Column<int>(nullable: false),
                    comm_type_id = table.Column<string>(nullable: true),
                    comm_type_name = table.Column<string>(nullable: true),
                    commentcount = table.Column<int>(nullable: false),
                    commentscore = table.Column<string>(nullable: true),
                    commodity_id = table.Column<string>(nullable: true),
                    commodity_intr = table.Column<string>(nullable: true),
                    commodity_typeid = table.Column<int>(nullable: true),
                    compresspic = table.Column<string>(nullable: true),
                    created_at = table.Column<string>(nullable: true),
                    destination_id = table.Column<string>(nullable: true),
                    full_name = table.Column<string>(nullable: true),
                    is_404 = table.Column<int>(nullable: false),
                    keywords = table.Column<string>(nullable: true),
                    likescount = table.Column<int>(nullable: false),
                    manufacturer_inf = table.Column<string>(nullable: true),
                    name_cn = table.Column<string>(nullable: true),
                    perlink = table.Column<string>(nullable: true),
                    price_desc = table.Column<string>(nullable: true),
                    rank = table.Column<int>(nullable: false),
                    short_name = table.Column<string>(nullable: true),
                    state = table.Column<int>(nullable: false),
                    tags = table.Column<string>(nullable: true),
                    updated_at = table.Column<string>(nullable: true),
                    version = table.Column<string>(nullable: true),
                    destination_adm_address = table.Column<string>(nullable: true),
                    destination_adm_name = table.Column<string>(nullable: true),
                    destination_adm_phone = table.Column<string>(nullable: true),
                    destination_airlines = table.Column<string>(nullable: true),
                    destination_area_id = table.Column<string>(nullable: true),
                    destination_audit_state = table.Column<int>(nullable: false),
                    destination_bus = table.Column<string>(nullable: true),
                    destination_charmcitypic = table.Column<string>(nullable: true),
                    destination_cityname = table.Column<string>(nullable: true),
                    destination_clim_des = table.Column<string>(nullable: true),
                    destination_created_at = table.Column<string>(nullable: true),
                    destination_culture = table.Column<string>(nullable: true),
                    destination_daren_picture = table.Column<string>(nullable: true),
                    destination_dest_adver = table.Column<string>(nullable: true),
                    destination_dest_des = table.Column<string>(nullable: true),
                    destination_dest_type_id = table.Column<int>(nullable: false),
                    destination_destination_id = table.Column<string>(nullable: true),
                    destination_destname = table.Column<string>(nullable: true),
                    destination_fea_inf = table.Column<string>(nullable: true),
                    destination_fea_traffic = table.Column<string>(nullable: true),
                    destination_full_name = table.Column<string>(nullable: true),
                    destination_highway = table.Column<string>(nullable: true),
                    destination_is_404 = table.Column<int>(nullable: false),
                    destination_keywords = table.Column<string>(nullable: true),
                    destination_latitude = table.Column<string>(nullable: true),
                    destination_longitude = table.Column<string>(nullable: true),
                    destination_notes_des = table.Column<string>(nullable: true),
                    destination_railway = table.Column<string>(nullable: true),
                    destination_rank = table.Column<int>(nullable: false),
                    destination_short_name = table.Column<string>(nullable: true),
                    destination_tags = table.Column<string>(nullable: true),
                    destination_taxi = table.Column<string>(nullable: true),
                    destination_tou_taboo = table.Column<string>(nullable: true),
                    destination_updated_at = table.Column<string>(nullable: true),
                    destination_water_carriage = table.Column<string>(nullable: true),
                    destination_website = table.Column<string>(nullable: true),
                    destination_defaultphoto_LocalizedUrl = table.Column<string>(nullable: true),
                    destination_defaultphoto_OriginalUrl = table.Column<string>(nullable: true),
                    defaultphoto_LocalizedUrl = table.Column<string>(nullable: true),
                    defaultphoto_OriginalUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SDTASpecialLocalProductDetail", x => x.id);
                    table.ForeignKey(
                        name: "FK_SDTASpecialLocalProductDetail_CommodityType_commodity_typeid",
                        column: x => x.commodity_typeid,
                        principalTable: "CommodityType",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SDTAFoodDetailDestination",
                columns: table => new
                {
                    FoodId = table.Column<int>(nullable: false),
                    id = table.Column<int>(nullable: false),
                    adm_address = table.Column<string>(nullable: true),
                    adm_name = table.Column<string>(nullable: true),
                    adm_phone = table.Column<string>(nullable: true),
                    airlines = table.Column<string>(nullable: true),
                    area_id = table.Column<string>(nullable: true),
                    audit_state = table.Column<int>(nullable: false),
                    bus = table.Column<string>(nullable: true),
                    charmcitypic = table.Column<string>(nullable: true),
                    cityname = table.Column<string>(nullable: true),
                    clim_des = table.Column<string>(nullable: true),
                    created_at = table.Column<string>(nullable: true),
                    culture = table.Column<string>(nullable: true),
                    daren_picture = table.Column<string>(nullable: true),
                    dest_adver = table.Column<string>(nullable: true),
                    dest_des = table.Column<string>(nullable: true),
                    dest_type_id = table.Column<int>(nullable: false),
                    destination_id = table.Column<string>(nullable: true),
                    destname = table.Column<string>(nullable: true),
                    fea_inf = table.Column<string>(nullable: true),
                    fea_traffic = table.Column<string>(nullable: true),
                    full_name = table.Column<string>(nullable: true),
                    highway = table.Column<string>(nullable: true),
                    is_404 = table.Column<int>(nullable: false),
                    keywords = table.Column<string>(nullable: true),
                    latitude = table.Column<string>(nullable: true),
                    longitude = table.Column<string>(nullable: true),
                    notes_des = table.Column<string>(nullable: true),
                    railway = table.Column<string>(nullable: true),
                    rank = table.Column<int>(nullable: false),
                    short_name = table.Column<string>(nullable: true),
                    tags = table.Column<string>(nullable: true),
                    taxi = table.Column<string>(nullable: true),
                    tou_taboo = table.Column<string>(nullable: true),
                    updated_at = table.Column<string>(nullable: true),
                    water_carriage = table.Column<string>(nullable: true),
                    website = table.Column<string>(nullable: true),
                    defaultphoto_LocalizedUrl = table.Column<string>(nullable: true),
                    defaultphoto_OriginalUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SDTAFoodDetailDestination", x => new { x.FoodId, x.id });
                    table.ForeignKey(
                        name: "FK_SDTAFoodDetailDestination_SDTAFoodDetail_FoodId",
                        column: x => x.FoodId,
                        principalTable: "SDTAFoodDetail",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SDTAFoodDetailFilterPictures",
                columns: table => new
                {
                    FoodId = table.Column<int>(nullable: false),
                    id = table.Column<int>(nullable: false),
                    created_at = table.Column<string>(nullable: true),
                    deleted_at = table.Column<string>(nullable: true),
                    is_404 = table.Column<int>(nullable: false),
                    pho_format = table.Column<string>(nullable: true),
                    pho_id = table.Column<string>(nullable: true),
                    pho_name = table.Column<string>(nullable: true),
                    pho_type = table.Column<string>(nullable: true),
                    picable_id = table.Column<string>(nullable: true),
                    picable_type = table.Column<string>(nullable: true),
                    rank = table.Column<int>(nullable: false),
                    updated_at = table.Column<string>(nullable: true),
                    pho_path_LocalizedUrl = table.Column<string>(nullable: true),
                    pho_path_OriginalUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SDTAFoodDetailFilterPictures", x => new { x.FoodId, x.id });
                    table.ForeignKey(
                        name: "FK_SDTAFoodDetailFilterPictures_SDTAFoodDetail_FoodId",
                        column: x => x.FoodId,
                        principalTable: "SDTAFoodDetail",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SDTAFoodDetailPictures",
                columns: table => new
                {
                    FoodId = table.Column<int>(nullable: false),
                    id = table.Column<int>(nullable: false),
                    created_at = table.Column<string>(nullable: true),
                    deleted_at = table.Column<string>(nullable: true),
                    is_404 = table.Column<int>(nullable: false),
                    pho_format = table.Column<string>(nullable: true),
                    pho_id = table.Column<string>(nullable: true),
                    pho_name = table.Column<string>(nullable: true),
                    pho_type = table.Column<string>(nullable: true),
                    picable_id = table.Column<string>(nullable: true),
                    picable_type = table.Column<string>(nullable: true),
                    rank = table.Column<int>(nullable: false),
                    updated_at = table.Column<string>(nullable: true),
                    pho_path_LocalizedUrl = table.Column<string>(nullable: true),
                    pho_path_OriginalUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SDTAFoodDetailPictures", x => new { x.FoodId, x.id });
                    table.ForeignKey(
                        name: "FK_SDTAFoodDetailPictures_SDTAFoodDetail_FoodId",
                        column: x => x.FoodId,
                        principalTable: "SDTAFoodDetail",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CommodityPrice",
                columns: table => new
                {
                    SpecialLocalProducId = table.Column<int>(nullable: false),
                    comm_price_id = table.Column<string>(nullable: false),
                    commodity_id = table.Column<string>(nullable: true),
                    created_at = table.Column<string>(nullable: true),
                    goods_caption = table.Column<string>(nullable: true),
                    price_caption = table.Column<int>(nullable: false),
                    price_type = table.Column<int>(nullable: false),
                    updated_at = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommodityPrice", x => new { x.SpecialLocalProducId, x.comm_price_id });
                    table.ForeignKey(
                        name: "FK_CommodityPrice_SDTASpecialLocalProductDetail_SpecialLocalProducId",
                        column: x => x.SpecialLocalProducId,
                        principalTable: "SDTASpecialLocalProductDetail",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SDTASpecialLocalProductDetailFilterPictures",
                columns: table => new
                {
                    SpecialLocalProducId = table.Column<int>(nullable: false),
                    id = table.Column<int>(nullable: false),
                    created_at = table.Column<string>(nullable: true),
                    deleted_at = table.Column<string>(nullable: true),
                    is_404 = table.Column<int>(nullable: false),
                    pho_format = table.Column<string>(nullable: true),
                    pho_id = table.Column<string>(nullable: true),
                    pho_name = table.Column<string>(nullable: true),
                    pho_type = table.Column<string>(nullable: true),
                    picable_id = table.Column<string>(nullable: true),
                    picable_type = table.Column<string>(nullable: true),
                    rank = table.Column<int>(nullable: false),
                    updated_at = table.Column<string>(nullable: true),
                    pho_path_LocalizedUrl = table.Column<string>(nullable: true),
                    pho_path_OriginalUrl = table.Column<string>(nullable: true)
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
                    SpecialLocalProducId = table.Column<int>(nullable: false),
                    id = table.Column<int>(nullable: false),
                    created_at = table.Column<string>(nullable: true),
                    deleted_at = table.Column<string>(nullable: true),
                    is_404 = table.Column<int>(nullable: false),
                    pho_format = table.Column<string>(nullable: true),
                    pho_id = table.Column<string>(nullable: true),
                    pho_name = table.Column<string>(nullable: true),
                    pho_type = table.Column<string>(nullable: true),
                    picable_id = table.Column<string>(nullable: true),
                    picable_type = table.Column<string>(nullable: true),
                    rank = table.Column<int>(nullable: false),
                    updated_at = table.Column<string>(nullable: true),
                    pho_path_LocalizedUrl = table.Column<string>(nullable: true),
                    pho_path_OriginalUrl = table.Column<string>(nullable: true)
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

            migrationBuilder.CreateIndex(
                name: "IX_SDTAFoodDetailDestination_FoodId",
                table: "SDTAFoodDetailDestination",
                column: "FoodId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SDTASpecialLocalProductDetail_commodity_typeid",
                table: "SDTASpecialLocalProductDetail",
                column: "commodity_typeid");
        }
    }
}
