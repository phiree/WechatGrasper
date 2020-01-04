using Microsoft.EntityFrameworkCore.Migrations;

namespace TourInfo.Infrastracture.Migrations
{
    public partial class location_longitude_latitude_cannt_be_nullable_as_owneredentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "gpsgd_Longitude",
                table: "Pubinfounits",
                nullable: false,
                oldClrType: typeof(double),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "gpsgd_Latitude",
                table: "Pubinfounits",
                nullable: false,
                oldClrType: typeof(double),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "gpsbd_Longitude",
                table: "Pubinfounits",
                nullable: false,
                oldClrType: typeof(double),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "gpsbd_Latitude",
                table: "Pubinfounits",
                nullable: false,
                oldClrType: typeof(double),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "gps_Longitude",
                table: "Pubinfounits",
                nullable: false,
                oldClrType: typeof(double),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "gps_Latitude",
                table: "Pubinfounits",
                nullable: false,
                oldClrType: typeof(double),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "gpsgd_Longitude",
                table: "Pubinfounitchilds",
                nullable: false,
                oldClrType: typeof(double),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "gpsgd_Latitude",
                table: "Pubinfounitchilds",
                nullable: false,
                oldClrType: typeof(double),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "gpsbd_Longitude",
                table: "Pubinfounitchilds",
                nullable: false,
                oldClrType: typeof(double),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "gpsbd_Latitude",
                table: "Pubinfounitchilds",
                nullable: false,
                oldClrType: typeof(double),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "gps_Longitude",
                table: "Pubinfounitchilds",
                nullable: false,
                oldClrType: typeof(double),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "gps_Latitude",
                table: "Pubinfounitchilds",
                nullable: false,
                oldClrType: typeof(double),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "gpsgd_Longitude",
                table: "Pubinfounits",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<double>(
                name: "gpsgd_Latitude",
                table: "Pubinfounits",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<double>(
                name: "gpsbd_Longitude",
                table: "Pubinfounits",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<double>(
                name: "gpsbd_Latitude",
                table: "Pubinfounits",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<double>(
                name: "gps_Longitude",
                table: "Pubinfounits",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<double>(
                name: "gps_Latitude",
                table: "Pubinfounits",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<double>(
                name: "gpsgd_Longitude",
                table: "Pubinfounitchilds",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<double>(
                name: "gpsgd_Latitude",
                table: "Pubinfounitchilds",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<double>(
                name: "gpsbd_Longitude",
                table: "Pubinfounitchilds",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<double>(
                name: "gpsbd_Latitude",
                table: "Pubinfounitchilds",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<double>(
                name: "gps_Longitude",
                table: "Pubinfounitchilds",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<double>(
                name: "gps_Latitude",
                table: "Pubinfounitchilds",
                nullable: true,
                oldClrType: typeof(double));
        }
    }
}
