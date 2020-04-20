using Microsoft.EntityFrameworkCore.Migrations;

namespace TourInfo.Infrastracture.Migrations
{
    public partial class addlinedetailscenicdosource : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "thumb",
                table: "SDTALineDetail",
                newName: "Version");

            migrationBuilder.AddColumn<string>(
                name: "Fingerprint",
                table: "SDTALineDetail",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "thumb_LocalizedUrl",
                table: "SDTALineDetail",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "thumb_OriginalUrl",
                table: "SDTALineDetail",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SDTALineDetailScenicDocSource",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    Version = table.Column<string>(nullable: true),
                    Fingerprint = table.Column<string>(nullable: true),
                    ele_id = table.Column<string>(nullable: true),
                    ele_type = table.Column<string>(nullable: true),
                    ele_type_name = table.Column<string>(nullable: true),
                    name_cn = table.Column<string>(nullable: true),
                    address = table.Column<string>(nullable: true),
                    default_photo_OriginalUrl = table.Column<string>(nullable: true),
                    default_photo_LocalizedUrl = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    contact = table.Column<string>(nullable: true),
                    level = table.Column<int>(nullable: false),
                    city = table.Column<int>(nullable: false),
                    area = table.Column<string>(nullable: true),
                    rank = table.Column<int>(nullable: false),
                    ele_type_name_en = table.Column<string>(nullable: true),
                    lvl1 = table.Column<string>(nullable: true),
                    city_order = table.Column<int>(nullable: false),
                    level_name = table.Column<string>(nullable: true),
                    date_for_order = table.Column<int>(nullable: false),
                    location = table.Column<string>(nullable: true),
                    buyable = table.Column<string>(nullable: true),
                    lowest_price = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SDTALineDetailScenicDocSource", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "SDTALineDetailScenicDocSourceEletype",
                columns: table => new
                {
                    value = table.Column<string>(nullable: false),
                    sourceid = table.Column<string>(nullable: false),
                    level = table.Column<int>(nullable: false),
                    ancestors = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SDTALineDetailScenicDocSourceEletype", x => new { x.sourceid, x.value });
                    table.ForeignKey(
                        name: "FK_SDTALineDetailScenicDocSourceEletype_SDTALineDetailScenicDocSource_sourceid",
                        column: x => x.sourceid,
                        principalTable: "SDTALineDetailScenicDocSource",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SDTALineDetailScenicDocSourceEletype");

            migrationBuilder.DropTable(
                name: "SDTALineDetailScenicDocSource");

            migrationBuilder.DropColumn(
                name: "Fingerprint",
                table: "SDTALineDetail");

            migrationBuilder.DropColumn(
                name: "thumb_LocalizedUrl",
                table: "SDTALineDetail");

            migrationBuilder.DropColumn(
                name: "thumb_OriginalUrl",
                table: "SDTALineDetail");

            migrationBuilder.RenameColumn(
                name: "Version",
                table: "SDTALineDetail",
                newName: "thumb");
        }
    }
}
