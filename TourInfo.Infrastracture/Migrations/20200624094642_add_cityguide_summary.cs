using Microsoft.EntityFrameworkCore.Migrations;

namespace TourInfo.Infrastracture.Migrations
{
    public partial class add_cityguide_summary : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SDTACityGuideSummary",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    slug = table.Column<string>(nullable: true),
                    title = table.Column<string>(nullable: true),
                    isShow = table.Column<bool>(nullable: false),
                    tag = table.Column<string>(nullable: true),
                    color = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SDTACityGuideSummary", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SDTACityGuideSummary");
        }
    }
}
