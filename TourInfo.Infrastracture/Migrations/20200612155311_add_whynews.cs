using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TourInfo.Infrastracture.Migrations
{
    public partial class add_whynews : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WhyNews",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    Version = table.Column<string>(nullable: true),
                    Fingerprint = table.Column<string>(nullable: true),
                    area2 = table.Column<string>(nullable: true),
                    areaCheckStatus = table.Column<int>(nullable: false),
                    areaId = table.Column<string>(nullable: true),
                    author = table.Column<string>(nullable: true),
                    cityCheckStatus = table.Column<int>(nullable: false),
                    content = table.Column<string>(nullable: true),
                    createTime = table.Column<DateTime>(nullable: false),
                    grabStatus = table.Column<bool>(nullable: false),
                    imagepath_OriginalUrl = table.Column<string>(nullable: true),
                    imagepath_LocalizedUrl = table.Column<string>(nullable: true),
                    informationCategoryId = table.Column<string>(nullable: true),
                    isTop = table.Column<int>(nullable: false),
                    noHtmlContent = table.Column<string>(nullable: true),
                    redCount = table.Column<int>(nullable: false),
                    removed = table.Column<bool>(nullable: false),
                    sort = table.Column<int>(nullable: false),
                    startTime = table.Column<DateTime>(nullable: false),
                    title = table.Column<string>(nullable: true),
                    type = table.Column<int>(nullable: false),
                    updateTime = table.Column<DateTime>(nullable: false),
                    endTime = table.Column<DateTime>(nullable: true),
                    source = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WhyNews", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WhyNews");
        }
    }
}
