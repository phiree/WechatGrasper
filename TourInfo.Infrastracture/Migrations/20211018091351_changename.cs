using Microsoft.EntityFrameworkCore.Migrations;

namespace TourInfo.Infrastracture.Migrations
{
    public partial class changename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SourceId",
                table: "FetchLogs",
                newName: "SourceName");

            migrationBuilder.RenameColumn(
                name: "DeviceId",
                table: "DistributeLogs",
                newName: "DeviceName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SourceName",
                table: "FetchLogs",
                newName: "SourceId");

            migrationBuilder.RenameColumn(
                name: "DeviceName",
                table: "DistributeLogs",
                newName: "DeviceId");
        }
    }
}
