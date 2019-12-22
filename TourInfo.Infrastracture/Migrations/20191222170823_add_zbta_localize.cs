using Microsoft.EntityFrameworkCore.Migrations;

namespace TourInfo.Infrastracture.Migrations
{
    public partial class add_zbta_localize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "localizedDetails",
                table: "Entities",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "localizedImage",
                table: "Entities",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "localizedDetails",
                table: "Entities");

            migrationBuilder.DropColumn(
                name: "localizedImage",
                table: "Entities");
        }
    }
}
