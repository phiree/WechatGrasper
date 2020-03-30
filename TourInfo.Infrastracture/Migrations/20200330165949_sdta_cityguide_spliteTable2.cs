using Microsoft.EntityFrameworkCore.Migrations;

namespace TourInfo.Infrastracture.Migrations
{
    public partial class sdta_cityguide_spliteTable2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SDTACityGuideDetailPicImage_SDTACityGuideDetail_GuideId",
                table: "SDTACityGuideDetailPicImage");

            migrationBuilder.DropColumn(
                name: "pics_content_id",
                table: "SDTACityGuideDetail");

            migrationBuilder.DropColumn(
                name: "pics_created_at",
                table: "SDTACityGuideDetail");

            migrationBuilder.DropColumn(
                name: "pics_deleted_at",
                table: "SDTACityGuideDetail");

            migrationBuilder.DropColumn(
                name: "pics_id",
                table: "SDTACityGuideDetail");

            migrationBuilder.DropColumn(
                name: "pics_reference",
                table: "SDTACityGuideDetail");

            migrationBuilder.DropColumn(
                name: "pics_updated_at",
                table: "SDTACityGuideDetail");

            migrationBuilder.CreateTable(
                name: "SDTACityGuideDetailPics",
                columns: table => new
                {
                    Dataid = table.Column<string>(nullable: false),
                    id = table.Column<int>(nullable: false),
                    content_id = table.Column<int>(nullable: false),
                    reference = table.Column<string>(nullable: true),
                    created_at = table.Column<string>(nullable: true),
                    updated_at = table.Column<string>(nullable: true),
                    deleted_at = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SDTACityGuideDetailPics", x => x.Dataid);
                    table.ForeignKey(
                        name: "FK_SDTACityGuideDetailPics_SDTACityGuideDetail_Dataid",
                        column: x => x.Dataid,
                        principalTable: "SDTACityGuideDetail",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_SDTACityGuideDetailPicImage_SDTACityGuideDetailPics_GuideId",
                table: "SDTACityGuideDetailPicImage",
                column: "GuideId",
                principalTable: "SDTACityGuideDetailPics",
                principalColumn: "Dataid",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SDTACityGuideDetailPicImage_SDTACityGuideDetailPics_GuideId",
                table: "SDTACityGuideDetailPicImage");

            migrationBuilder.DropTable(
                name: "SDTACityGuideDetailPics");

            migrationBuilder.AddColumn<int>(
                name: "pics_content_id",
                table: "SDTACityGuideDetail",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "pics_created_at",
                table: "SDTACityGuideDetail",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "pics_deleted_at",
                table: "SDTACityGuideDetail",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "pics_id",
                table: "SDTACityGuideDetail",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "pics_reference",
                table: "SDTACityGuideDetail",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "pics_updated_at",
                table: "SDTACityGuideDetail",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SDTACityGuideDetailPicImage_SDTACityGuideDetail_GuideId",
                table: "SDTACityGuideDetailPicImage",
                column: "GuideId",
                principalTable: "SDTACityGuideDetail",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
