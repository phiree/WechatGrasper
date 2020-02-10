using Microsoft.EntityFrameworkCore.Migrations;

namespace TourInfo.Infrastracture.Migrations
{
    public partial class add_why : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WHYDetailOrganizations",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    Version = table.Column<string>(nullable: true),
                    Fingerprint = table.Column<string>(nullable: true),
                    contact = table.Column<string>(nullable: true),
                    hposter_OriginalUrl = table.Column<string>(nullable: true),
                    hposter_LocalizedUrl = table.Column<string>(nullable: true),
                    addressInfo = table.Column<string>(nullable: true),
                    location_Longitude = table.Column<double>(nullable: false),
                    location_Latitude = table.Column<double>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    summary = table.Column<string>(nullable: true),
                    website = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WHYDetailOrganizations", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WHYDetailOrganizations");
        }
    }
}
