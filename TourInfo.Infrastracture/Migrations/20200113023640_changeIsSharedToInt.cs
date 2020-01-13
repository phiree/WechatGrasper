using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TourInfo.Infrastracture.Migrations
{
    public partial class changeIsSharedToInt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Videos",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Version = table.Column<string>(nullable: true),
                    Fingerprint = table.Column<string>(nullable: true),
                    orderno = table.Column<int>(nullable: false),
                    title = table.Column<string>(nullable: true),
                    subtitle = table.Column<string>(nullable: true),
                    author = table.Column<string>(nullable: true),
                    summary = table.Column<string>(nullable: true),
                    img = table.Column<string>(nullable: true),
                    attachment = table.Column<string>(nullable: true),
                    istop = table.Column<bool>(nullable: false),
                    iscycle = table.Column<bool>(nullable: false),
                    jumpurl = table.Column<string>(nullable: true),
                    pid = table.Column<int>(nullable: false),
                    mid = table.Column<int>(nullable: false),
                    pubtime = table.Column<DateTime>(nullable: false),
                    edituser = table.Column<string>(nullable: true),
                    editname = table.Column<string>(nullable: true),
                    checkuser = table.Column<string>(nullable: true),
                    checkname = table.Column<string>(nullable: true),
                    checkstate = table.Column<int>(nullable: false),
                    checktime = table.Column<DateTime>(nullable: true),
                    createtime = table.Column<DateTime>(nullable: false),
                    updatetime = table.Column<DateTime>(nullable: false),
                    deleteflag = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Videos", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Videos");
        }
    }
}
