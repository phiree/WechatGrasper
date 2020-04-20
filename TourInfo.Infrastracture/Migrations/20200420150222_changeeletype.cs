using Microsoft.EntityFrameworkCore.Migrations;

namespace TourInfo.Infrastracture.Migrations
{
    public partial class changeeletype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SDTALineDetailScenicDocSourceEletype",
                table: "SDTALineDetailScenicDocSourceEletype");

            migrationBuilder.AlterColumn<string>(
                name: "value",
                table: "SDTALineDetailScenicDocSourceEletype",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "id",
                table: "SDTALineDetailScenicDocSourceEletype",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SDTALineDetailScenicDocSourceEletype",
                table: "SDTALineDetailScenicDocSourceEletype",
                columns: new[] { "sourceid", "id" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SDTALineDetailScenicDocSourceEletype",
                table: "SDTALineDetailScenicDocSourceEletype");

            migrationBuilder.DropColumn(
                name: "id",
                table: "SDTALineDetailScenicDocSourceEletype");

            migrationBuilder.AlterColumn<string>(
                name: "value",
                table: "SDTALineDetailScenicDocSourceEletype",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SDTALineDetailScenicDocSourceEletype",
                table: "SDTALineDetailScenicDocSourceEletype",
                columns: new[] { "sourceid", "value" });
        }
    }
}
