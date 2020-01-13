using Microsoft.EntityFrameworkCore.Migrations;

namespace TourInfo.Infrastracture.Migrations
{
    public partial class newsdetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "localizedDetails",
                table: "ZbtaNews",
                newName: "details_OriginaText");

            migrationBuilder.RenameColumn(
                name: "details",
                table: "ZbtaNews",
                newName: "details_ImageLocalizedText");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "details_OriginaText",
                table: "ZbtaNews",
                newName: "localizedDetails");

            migrationBuilder.RenameColumn(
                name: "details_ImageLocalizedText",
                table: "ZbtaNews",
                newName: "details");
        }
    }
}
