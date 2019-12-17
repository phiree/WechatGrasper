using Microsoft.EntityFrameworkCore.Migrations;

namespace TourInfo.Infrastracture.Migrations
{
    public partial class zbta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "back1",
                table: "Entities",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "checkState",
                table: "Entities",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "createUser",
                table: "Entities",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "created",
                table: "Entities",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "details",
                table: "Entities",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "image",
                table: "Entities",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "releaseTime",
                table: "Entities",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "titles",
                table: "Entities",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "back1",
                table: "Entities");

            migrationBuilder.DropColumn(
                name: "checkState",
                table: "Entities");

            migrationBuilder.DropColumn(
                name: "createUser",
                table: "Entities");

            migrationBuilder.DropColumn(
                name: "created",
                table: "Entities");

            migrationBuilder.DropColumn(
                name: "details",
                table: "Entities");

            migrationBuilder.DropColumn(
                name: "image",
                table: "Entities");

            migrationBuilder.DropColumn(
                name: "releaseTime",
                table: "Entities");

            migrationBuilder.DropColumn(
                name: "titles",
                table: "Entities");
        }
    }
}
