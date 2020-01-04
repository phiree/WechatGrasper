using Microsoft.EntityFrameworkCore.Migrations;

namespace TourInfo.Infrastracture.Migrations
{
    public partial class location_refactor_to_valueobject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "gps",
                table: "Pubinfounits");

            migrationBuilder.DropColumn(
                name: "gpsbd",
                table: "Pubinfounits");

            migrationBuilder.DropColumn(
                name: "gpsgd",
                table: "Pubinfounits");

            migrationBuilder.DropColumn(
                name: "gps",
                table: "Pubinfounitchilds");

            migrationBuilder.DropColumn(
                name: "gpsbd",
                table: "Pubinfounitchilds");

            migrationBuilder.DropColumn(
                name: "gpsgd",
                table: "Pubinfounitchilds");

            migrationBuilder.DropColumn(
                name: "location",
                table: "EWQYPlaceTypeEntities");

            migrationBuilder.AddColumn<double>(
                name: "gps_Latitude",
                table: "Pubinfounits",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "gps_Longitude",
                table: "Pubinfounits",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "gpsbd_Latitude",
                table: "Pubinfounits",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "gpsbd_Longitude",
                table: "Pubinfounits",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "gpsgd_Latitude",
                table: "Pubinfounits",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "gpsgd_Longitude",
                table: "Pubinfounits",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "gps_Latitude",
                table: "Pubinfounitchilds",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "gps_Longitude",
                table: "Pubinfounitchilds",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "gpsbd_Latitude",
                table: "Pubinfounitchilds",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "gpsbd_Longitude",
                table: "Pubinfounitchilds",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "gpsgd_Latitude",
                table: "Pubinfounitchilds",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "gpsgd_Longitude",
                table: "Pubinfounitchilds",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "location_Latitude",
                table: "EWQYPlaceTypeEntities",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "location_Longitude",
                table: "EWQYPlaceTypeEntities",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "gps_Latitude",
                table: "Pubinfounits");

            migrationBuilder.DropColumn(
                name: "gps_Longitude",
                table: "Pubinfounits");

            migrationBuilder.DropColumn(
                name: "gpsbd_Latitude",
                table: "Pubinfounits");

            migrationBuilder.DropColumn(
                name: "gpsbd_Longitude",
                table: "Pubinfounits");

            migrationBuilder.DropColumn(
                name: "gpsgd_Latitude",
                table: "Pubinfounits");

            migrationBuilder.DropColumn(
                name: "gpsgd_Longitude",
                table: "Pubinfounits");

            migrationBuilder.DropColumn(
                name: "gps_Latitude",
                table: "Pubinfounitchilds");

            migrationBuilder.DropColumn(
                name: "gps_Longitude",
                table: "Pubinfounitchilds");

            migrationBuilder.DropColumn(
                name: "gpsbd_Latitude",
                table: "Pubinfounitchilds");

            migrationBuilder.DropColumn(
                name: "gpsbd_Longitude",
                table: "Pubinfounitchilds");

            migrationBuilder.DropColumn(
                name: "gpsgd_Latitude",
                table: "Pubinfounitchilds");

            migrationBuilder.DropColumn(
                name: "gpsgd_Longitude",
                table: "Pubinfounitchilds");

            migrationBuilder.DropColumn(
                name: "location_Latitude",
                table: "EWQYPlaceTypeEntities");

            migrationBuilder.DropColumn(
                name: "location_Longitude",
                table: "EWQYPlaceTypeEntities");

            migrationBuilder.AddColumn<string>(
                name: "gps",
                table: "Pubinfounits",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "gpsbd",
                table: "Pubinfounits",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "gpsgd",
                table: "Pubinfounits",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "gps",
                table: "Pubinfounitchilds",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "gpsbd",
                table: "Pubinfounitchilds",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "gpsgd",
                table: "Pubinfounitchilds",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "location",
                table: "EWQYPlaceTypeEntities",
                nullable: true);
        }
    }
}
