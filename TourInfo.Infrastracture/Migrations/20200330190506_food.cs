using Microsoft.EntityFrameworkCore.Migrations;

namespace TourInfo.Infrastracture.Migrations
{
    public partial class food : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SDTAFoodDetail",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false),
                    res_type_rela = table.Column<string>(nullable: true),
                    restaurant_id = table.Column<string>(nullable: true),
                    user_id = table.Column<string>(nullable: true),
                    snack_name = table.Column<string>(nullable: true),
                    snack_pho = table.Column<string>(nullable: true),
                    snack_int = table.Column<string>(nullable: true),
                    updated_at = table.Column<string>(nullable: true),
                    destination_id = table.Column<string>(nullable: true),
                    keywords = table.Column<string>(nullable: true),
                    snack_intr_m = table.Column<string>(nullable: true),
                    tags = table.Column<string>(nullable: true),
                    source = table.Column<int>(nullable: false),
                    unitcode = table.Column<string>(nullable: true),
                    state = table.Column<int>(nullable: false),
                    food_fullnane = table.Column<string>(nullable: true),
                    food_shortname = table.Column<string>(nullable: true),
                    food_enname = table.Column<string>(nullable: true),
                    food_recmmond = table.Column<string>(nullable: true),
                    food_price = table.Column<string>(nullable: true),
                    created_at = table.Column<string>(nullable: true),
                    food_type_id = table.Column<string>(nullable: true),
                    defaultphoto = table.Column<string>(nullable: true),
                    rank = table.Column<int>(nullable: false),
                    is_404 = table.Column<int>(nullable: false),
                    cityname = table.Column<string>(nullable: true),
                    areaname = table.Column<string>(nullable: true),
                    commentscore = table.Column<string>(nullable: true),
                    commentcount = table.Column<int>(nullable: false),
                    likescount = table.Column<int>(nullable: false),
                    collectscount = table.Column<int>(nullable: false),
                    perlink = table.Column<string>(nullable: true),
                    compresspic = table.Column<string>(nullable: true),
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
                    destination_defaultphoto = table.Column<string>(nullable: true),
                    destination_keywords = table.Column<string>(nullable: true),
                    destination_tags = table.Column<string>(nullable: true),
                    destination_charmcitypic = table.Column<string>(nullable: true),
                    destination_daren_picture = table.Column<string>(nullable: true),
                    destination_area_id = table.Column<string>(nullable: true),
                    destination_rank = table.Column<int>(nullable: false),
                    destination_is_404 = table.Column<int>(nullable: false),
                    destination_cityname = table.Column<string>(nullable: true),
                    snack_food_type_food_type_id = table.Column<string>(nullable: true),
                    snack_food_type_user_id = table.Column<string>(nullable: true),
                    snack_food_type_food_type_id_p = table.Column<string>(nullable: true),
                    snack_food_type_food_type_name = table.Column<string>(nullable: true),
                    snack_food_type_grade = table.Column<string>(nullable: true),
                    snack_food_type_updated_at = table.Column<string>(nullable: true),
                    snack_food_type_deleted_at = table.Column<string>(nullable: true),
                    snack_food_type_created_at = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SDTAFoodDetail", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "SDTAFoodDetailFilterPictures",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false),
                    FoodId = table.Column<int>(nullable: false),
                    pho_id = table.Column<string>(nullable: true),
                    picable_id = table.Column<string>(nullable: true),
                    picable_type = table.Column<string>(nullable: true),
                    pho_name = table.Column<string>(nullable: true),
                    pho_type = table.Column<string>(nullable: true),
                    pho_format = table.Column<string>(nullable: true),
                    pho_path = table.Column<string>(nullable: true),
                    created_at = table.Column<string>(nullable: true),
                    updated_at = table.Column<string>(nullable: true),
                    rank = table.Column<int>(nullable: false),
                    is_404 = table.Column<int>(nullable: false),
                    deleted_at = table.Column<string>(nullable: true)
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
                    id = table.Column<int>(nullable: false),
                    FoodId = table.Column<int>(nullable: false),
                    pho_id = table.Column<string>(nullable: true),
                    picable_id = table.Column<string>(nullable: true),
                    picable_type = table.Column<string>(nullable: true),
                    pho_name = table.Column<string>(nullable: true),
                    pho_type = table.Column<string>(nullable: true),
                    pho_format = table.Column<string>(nullable: true),
                    pho_path = table.Column<string>(nullable: true),
                    created_at = table.Column<string>(nullable: true),
                    updated_at = table.Column<string>(nullable: true),
                    rank = table.Column<int>(nullable: false),
                    is_404 = table.Column<int>(nullable: false),
                    deleted_at = table.Column<string>(nullable: true)
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SDTAFoodDetailFilterPictures");

            migrationBuilder.DropTable(
                name: "SDTAFoodDetailPictures");

            migrationBuilder.DropTable(
                name: "SDTAFoodDetail");
        }
    }
}
