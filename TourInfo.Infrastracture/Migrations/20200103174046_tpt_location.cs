using Microsoft.EntityFrameworkCore.Migrations;

namespace TourInfo.Infrastracture.Migrations
{
    public partial class tpt_location : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "location_Latitude",
                table: "EWQYPlaceTypeEntities");

            migrationBuilder.DropColumn(
                name: "location_Longitude",
                table: "EWQYPlaceTypeEntities");

            migrationBuilder.CreateTable(
                name: "CompanyVanueLocations",
                columns: table => new
                {
                    CompanyVenueid = table.Column<string>(nullable: false),
                    Longitude = table.Column<double>(nullable: false),
                    Latitude = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyVanueLocations", x => x.CompanyVenueid);
                    table.ForeignKey(
                        name: "FK_CompanyVanueLocations_EWQYPlaceTypeEntities_CompanyVenueid",
                        column: x => x.CompanyVenueid,
                        principalTable: "EWQYPlaceTypeEntities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyVanueLocations");

            migrationBuilder.AddColumn<double>(
                name: "location_Latitude",
                table: "EWQYPlaceTypeEntities",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "location_Longitude",
                table: "EWQYPlaceTypeEntities",
                nullable: true);
        }
    }
}
