using Microsoft.EntityFrameworkCore.Migrations;

namespace TourInfo.Infrastracture.Migrations
{
    public partial class whyactivity_titleimage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "hPoster",
                table: "WhyActivities",
                newName: "hPoster_OriginalUrl");

            migrationBuilder.AddColumn<string>(
                name: "hPoster_LocalizedUrl",
                table: "WhyActivities",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "hPoster_LocalizedUrl",
                table: "WhyActivities");

            migrationBuilder.RenameColumn(
                name: "hPoster_OriginalUrl",
                table: "WhyActivities",
                newName: "hPoster");
        }
    }
}
