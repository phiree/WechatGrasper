using Microsoft.EntityFrameworkCore.Migrations;

namespace TourInfo.Infrastracture.Migrations
{
    public partial class add_localized_images : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompanyVenue_pictureKeys",
                table: "Entities");

            migrationBuilder.DropColumn(
                name: "CompanyVenue_thumbnailKey",
                table: "Entities");

            migrationBuilder.AddColumn<string>(
                name: "localizedPictureKeys",
                table: "Entities",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "localizedThumbnailKey",
                table: "Entities",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "localizedPictureKeys",
                table: "Entities");

            migrationBuilder.DropColumn(
                name: "localizedThumbnailKey",
                table: "Entities");

            migrationBuilder.AddColumn<string>(
                name: "CompanyVenue_pictureKeys",
                table: "Entities",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyVenue_thumbnailKey",
                table: "Entities",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
