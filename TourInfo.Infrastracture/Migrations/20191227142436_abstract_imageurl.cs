using Microsoft.EntityFrameworkCore.Migrations;

namespace TourInfo.Infrastracture.Migrations
{
    public partial class abstract_imageurl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "mediaurl",
                table: "Pubmediainfos",
                newName: "mediaurl_OriginalUrl");

            migrationBuilder.AddColumn<string>(
                name: "mediaurl_LocalizedUrl",
                table: "Pubmediainfos",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "mediaurl_LocalizedUrl",
                table: "Pubmediainfos");

            migrationBuilder.RenameColumn(
                name: "mediaurl_OriginalUrl",
                table: "Pubmediainfos",
                newName: "mediaurl");
        }
    }
}
