using Microsoft.EntityFrameworkCore.Migrations;

namespace TourInfo.Infrastracture.Migrations
{
    public partial class imageurl_food : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "defaultphoto",
                table: "SDTAFoodDetail");

            migrationBuilder.DropColumn(
                name: "destination_adm_address",
                table: "SDTAFoodDetail");

            migrationBuilder.DropColumn(
                name: "destination_adm_name",
                table: "SDTAFoodDetail");

            migrationBuilder.DropColumn(
                name: "destination_adm_phone",
                table: "SDTAFoodDetail");

            migrationBuilder.DropColumn(
                name: "destination_airlines",
                table: "SDTAFoodDetail");

            migrationBuilder.DropColumn(
                name: "destination_area_id",
                table: "SDTAFoodDetail");

            migrationBuilder.DropColumn(
                name: "destination_audit_state",
                table: "SDTAFoodDetail");

            migrationBuilder.DropColumn(
                name: "destination_bus",
                table: "SDTAFoodDetail");

            migrationBuilder.DropColumn(
                name: "destination_charmcitypic",
                table: "SDTAFoodDetail");

            migrationBuilder.DropColumn(
                name: "destination_cityname",
                table: "SDTAFoodDetail");

            migrationBuilder.DropColumn(
                name: "destination_clim_des",
                table: "SDTAFoodDetail");

            migrationBuilder.DropColumn(
                name: "destination_created_at",
                table: "SDTAFoodDetail");

            migrationBuilder.DropColumn(
                name: "destination_culture",
                table: "SDTAFoodDetail");

            migrationBuilder.DropColumn(
                name: "destination_daren_picture",
                table: "SDTAFoodDetail");

            migrationBuilder.DropColumn(
                name: "destination_defaultphoto",
                table: "SDTAFoodDetail");

            migrationBuilder.DropColumn(
                name: "destination_dest_adver",
                table: "SDTAFoodDetail");

            migrationBuilder.DropColumn(
                name: "destination_dest_des",
                table: "SDTAFoodDetail");

            migrationBuilder.DropColumn(
                name: "destination_dest_type_id",
                table: "SDTAFoodDetail");

            migrationBuilder.DropColumn(
                name: "destination_destination_id",
                table: "SDTAFoodDetail");

            migrationBuilder.DropColumn(
                name: "destination_destname",
                table: "SDTAFoodDetail");

            migrationBuilder.DropColumn(
                name: "destination_fea_inf",
                table: "SDTAFoodDetail");

            migrationBuilder.DropColumn(
                name: "destination_fea_traffic",
                table: "SDTAFoodDetail");

            migrationBuilder.DropColumn(
                name: "destination_full_name",
                table: "SDTAFoodDetail");

            migrationBuilder.DropColumn(
                name: "destination_highway",
                table: "SDTAFoodDetail");

            migrationBuilder.DropColumn(
                name: "destination_is_404",
                table: "SDTAFoodDetail");

            migrationBuilder.DropColumn(
                name: "destination_keywords",
                table: "SDTAFoodDetail");

            migrationBuilder.DropColumn(
                name: "destination_latitude",
                table: "SDTAFoodDetail");

            migrationBuilder.DropColumn(
                name: "destination_longitude",
                table: "SDTAFoodDetail");

            migrationBuilder.DropColumn(
                name: "destination_notes_des",
                table: "SDTAFoodDetail");

            migrationBuilder.DropColumn(
                name: "destination_railway",
                table: "SDTAFoodDetail");

            migrationBuilder.DropColumn(
                name: "destination_rank",
                table: "SDTAFoodDetail");

            migrationBuilder.DropColumn(
                name: "destination_short_name",
                table: "SDTAFoodDetail");

            migrationBuilder.DropColumn(
                name: "destination_tags",
                table: "SDTAFoodDetail");

            migrationBuilder.DropColumn(
                name: "destination_taxi",
                table: "SDTAFoodDetail");

            migrationBuilder.DropColumn(
                name: "destination_tou_taboo",
                table: "SDTAFoodDetail");

            migrationBuilder.DropColumn(
                name: "destination_updated_at",
                table: "SDTAFoodDetail");

            migrationBuilder.RenameColumn(
                name: "pho_path",
                table: "SDTAFoodDetailPictures",
                newName: "pho_path_OriginalUrl");

            migrationBuilder.RenameColumn(
                name: "pho_path",
                table: "SDTAFoodDetailFilterPictures",
                newName: "pho_path_OriginalUrl");

            migrationBuilder.RenameColumn(
                name: "destination_website",
                table: "SDTAFoodDetail",
                newName: "defaultphoto_OriginalUrl");

            migrationBuilder.RenameColumn(
                name: "destination_water_carriage",
                table: "SDTAFoodDetail",
                newName: "defaultphoto_LocalizedUrl");

            migrationBuilder.AddColumn<string>(
                name: "pho_path_LocalizedUrl",
                table: "SDTAFoodDetailPictures",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "pho_path_LocalizedUrl",
                table: "SDTAFoodDetailFilterPictures",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SDTAFoodDetailDestination",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false),
                    FoodId = table.Column<int>(nullable: false),
                    destination_id = table.Column<string>(nullable: true),
                    destname = table.Column<string>(nullable: true),
                    full_name = table.Column<string>(nullable: true),
                    short_name = table.Column<string>(nullable: true),
                    adm_name = table.Column<string>(nullable: true),
                    adm_address = table.Column<string>(nullable: true),
                    adm_phone = table.Column<string>(nullable: true),
                    dest_des = table.Column<string>(nullable: true),
                    culture = table.Column<string>(nullable: true),
                    dest_adver = table.Column<string>(nullable: true),
                    clim_des = table.Column<string>(nullable: true),
                    notes_des = table.Column<string>(nullable: true),
                    tou_taboo = table.Column<string>(nullable: true),
                    fea_inf = table.Column<string>(nullable: true),
                    longitude = table.Column<string>(nullable: true),
                    latitude = table.Column<string>(nullable: true),
                    airlines = table.Column<string>(nullable: true),
                    railway = table.Column<string>(nullable: true),
                    highway = table.Column<string>(nullable: true),
                    water_carriage = table.Column<string>(nullable: true),
                    bus = table.Column<string>(nullable: true),
                    taxi = table.Column<string>(nullable: true),
                    fea_traffic = table.Column<string>(nullable: true),
                    created_at = table.Column<string>(nullable: true),
                    updated_at = table.Column<string>(nullable: true),
                    audit_state = table.Column<int>(nullable: false),
                    website = table.Column<string>(nullable: true),
                    dest_type_id = table.Column<int>(nullable: false),
                    defaultphoto_OriginalUrl = table.Column<string>(nullable: true),
                    defaultphoto_LocalizedUrl = table.Column<string>(nullable: true),
                    keywords = table.Column<string>(nullable: true),
                    tags = table.Column<string>(nullable: true),
                    charmcitypic = table.Column<string>(nullable: true),
                    daren_picture = table.Column<string>(nullable: true),
                    area_id = table.Column<string>(nullable: true),
                    rank = table.Column<int>(nullable: false),
                    is_404 = table.Column<int>(nullable: false),
                    cityname = table.Column<string>(nullable: true)
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

            migrationBuilder.CreateIndex(
                name: "IX_SDTAFoodDetailDestination_FoodId",
                table: "SDTAFoodDetailDestination",
                column: "FoodId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SDTAFoodDetailDestination");

            migrationBuilder.DropColumn(
                name: "pho_path_LocalizedUrl",
                table: "SDTAFoodDetailPictures");

            migrationBuilder.DropColumn(
                name: "pho_path_LocalizedUrl",
                table: "SDTAFoodDetailFilterPictures");

            migrationBuilder.RenameColumn(
                name: "pho_path_OriginalUrl",
                table: "SDTAFoodDetailPictures",
                newName: "pho_path");

            migrationBuilder.RenameColumn(
                name: "pho_path_OriginalUrl",
                table: "SDTAFoodDetailFilterPictures",
                newName: "pho_path");

            migrationBuilder.RenameColumn(
                name: "defaultphoto_OriginalUrl",
                table: "SDTAFoodDetail",
                newName: "destination_website");

            migrationBuilder.RenameColumn(
                name: "defaultphoto_LocalizedUrl",
                table: "SDTAFoodDetail",
                newName: "destination_water_carriage");

            migrationBuilder.AddColumn<string>(
                name: "defaultphoto",
                table: "SDTAFoodDetail",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "destination_adm_address",
                table: "SDTAFoodDetail",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "destination_adm_name",
                table: "SDTAFoodDetail",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "destination_adm_phone",
                table: "SDTAFoodDetail",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "destination_airlines",
                table: "SDTAFoodDetail",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "destination_area_id",
                table: "SDTAFoodDetail",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "destination_audit_state",
                table: "SDTAFoodDetail",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "destination_bus",
                table: "SDTAFoodDetail",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "destination_charmcitypic",
                table: "SDTAFoodDetail",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "destination_cityname",
                table: "SDTAFoodDetail",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "destination_clim_des",
                table: "SDTAFoodDetail",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "destination_created_at",
                table: "SDTAFoodDetail",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "destination_culture",
                table: "SDTAFoodDetail",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "destination_daren_picture",
                table: "SDTAFoodDetail",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "destination_defaultphoto",
                table: "SDTAFoodDetail",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "destination_dest_adver",
                table: "SDTAFoodDetail",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "destination_dest_des",
                table: "SDTAFoodDetail",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "destination_dest_type_id",
                table: "SDTAFoodDetail",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "destination_destination_id",
                table: "SDTAFoodDetail",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "destination_destname",
                table: "SDTAFoodDetail",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "destination_fea_inf",
                table: "SDTAFoodDetail",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "destination_fea_traffic",
                table: "SDTAFoodDetail",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "destination_full_name",
                table: "SDTAFoodDetail",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "destination_highway",
                table: "SDTAFoodDetail",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "destination_is_404",
                table: "SDTAFoodDetail",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "destination_keywords",
                table: "SDTAFoodDetail",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "destination_latitude",
                table: "SDTAFoodDetail",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "destination_longitude",
                table: "SDTAFoodDetail",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "destination_notes_des",
                table: "SDTAFoodDetail",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "destination_railway",
                table: "SDTAFoodDetail",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "destination_rank",
                table: "SDTAFoodDetail",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "destination_short_name",
                table: "SDTAFoodDetail",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "destination_tags",
                table: "SDTAFoodDetail",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "destination_taxi",
                table: "SDTAFoodDetail",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "destination_tou_taboo",
                table: "SDTAFoodDetail",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "destination_updated_at",
                table: "SDTAFoodDetail",
                nullable: true);
        }
    }
}
