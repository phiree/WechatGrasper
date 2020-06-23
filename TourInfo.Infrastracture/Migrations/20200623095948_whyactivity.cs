using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TourInfo.Infrastracture.Migrations
{
    public partial class whyactivity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "endTime",
                table: "WhyNews",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "WhyActivities",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    Version = table.Column<string>(nullable: true),
                    Fingerprint = table.Column<string>(nullable: true),
                    accessNumber = table.Column<int>(nullable: false),
                    actSessionSTime = table.Column<DateTime>(nullable: false),
                    activityCategoryId = table.Column<string>(nullable: true),
                    ageTagId = table.Column<string>(nullable: true),
                    area = table.Column<string>(nullable: true),
                    areaCheckStatus = table.Column<int>(nullable: false),
                    areaId = table.Column<string>(nullable: true),
                    back = table.Column<int>(nullable: false),
                    cashType = table.Column<string>(nullable: true),
                    cityCheckStatus = table.Column<int>(nullable: false),
                    commentScope = table.Column<int>(nullable: false),
                    commentStatus = table.Column<int>(nullable: false),
                    content = table.Column<string>(nullable: true),
                    createTime = table.Column<DateTime>(nullable: false),
                    fPoster = table.Column<string>(nullable: true),
                    grabStatus = table.Column<bool>(nullable: false),
                    grade = table.Column<int>(nullable: false),
                    gradeNum = table.Column<int>(nullable: false),
                    hPoster = table.Column<string>(nullable: true),
                    hasSession = table.Column<bool>(nullable: false),
                    isTop = table.Column<int>(nullable: false),
                    keywords = table.Column<string>(nullable: true),
                    limit = table.Column<int>(nullable: false),
                    maxCount = table.Column<int>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    _operator = table.Column<string>(nullable: true),
                    organizationId = table.Column<string>(nullable: true),
                    organizationtypeId = table.Column<string>(nullable: true),
                    previewNumber = table.Column<int>(nullable: false),
                    price = table.Column<int>(nullable: false),
                    rate = table.Column<int>(nullable: false),
                    recentHoldEndTime = table.Column<DateTime>(nullable: false),
                    recentHoldStartTime = table.Column<DateTime>(nullable: false),
                    removed = table.Column<bool>(nullable: false),
                    reportNum = table.Column<int>(nullable: false),
                    reservationMode = table.Column<int>(nullable: false),
                    sort = table.Column<int>(nullable: false),
                    status = table.Column<int>(nullable: false),
                    summary = table.Column<string>(nullable: true),
                    ticketNumber = table.Column<int>(nullable: false),
                    type = table.Column<int>(nullable: false),
                    updateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WhyActivities", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WhyActivities");

            migrationBuilder.AlterColumn<DateTime>(
                name: "endTime",
                table: "WhyNews",
                nullable: true,
                oldClrType: typeof(DateTime));
        }
    }
}
