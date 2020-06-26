using Microsoft.EntityFrameworkCore.Migrations;

namespace TourInfo.Infrastracture.Migrations
{
    public partial class cityguide_content_image : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "content",
                table: "SDTACityGuideDetail",
                newName: "content_OriginaText");

            migrationBuilder.AddColumn<string>(
                name: "content_ImageBaseUrl",
                table: "SDTACityGuideDetail",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "content_ImageLocalizedText",
                table: "SDTACityGuideDetail",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "content_ImageBaseUrl",
                table: "SDTACityGuideDetail");

            migrationBuilder.DropColumn(
                name: "content_ImageLocalizedText",
                table: "SDTACityGuideDetail");

            migrationBuilder.RenameColumn(
                name: "content_OriginaText",
                table: "SDTACityGuideDetail",
                newName: "content");
        }
    }
}
