using Microsoft.EntityFrameworkCore.Migrations;

namespace TourInfo.Infrastracture.Migrations
{
    public partial class addsdta_lineDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Typetags",
                table: "Typetags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Typepics",
                table: "Typepics");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Typeinfos",
                table: "Typeinfos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Typefields",
                table: "Typefields");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pubunittags",
                table: "Pubunittags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pubmediainfos",
                table: "Pubmediainfos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pubinfounits",
                table: "Pubinfounits");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pubinfounitchilds",
                table: "Pubinfounitchilds");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Projectinfos",
                table: "Projectinfos");

            migrationBuilder.RenameTable(
                name: "Typetags",
                newName: "Typetag");

            migrationBuilder.RenameTable(
                name: "Typepics",
                newName: "Typepic");

            migrationBuilder.RenameTable(
                name: "Typeinfos",
                newName: "Typeinfo");

            migrationBuilder.RenameTable(
                name: "Typefields",
                newName: "Typefield");

            migrationBuilder.RenameTable(
                name: "Pubunittags",
                newName: "Pubunittag");

            migrationBuilder.RenameTable(
                name: "Pubmediainfos",
                newName: "Pubmediainfo");

            migrationBuilder.RenameTable(
                name: "Pubinfounits",
                newName: "Pubinfounit");

            migrationBuilder.RenameTable(
                name: "Pubinfounitchilds",
                newName: "Pubinfounitchild");

            migrationBuilder.RenameTable(
                name: "Projectinfos",
                newName: "Projectinfo");

            migrationBuilder.RenameIndex(
                name: "IX_Pubinfounitchilds_childid",
                table: "Pubinfounitchild",
                newName: "IX_Pubinfounitchild_childid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Typetag",
                table: "Typetag",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Typepic",
                table: "Typepic",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Typeinfo",
                table: "Typeinfo",
                column: "typeid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Typefield",
                table: "Typefield",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pubunittag",
                table: "Pubunittag",
                column: "unittagid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pubmediainfo",
                table: "Pubmediainfo",
                column: "mediaid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pubinfounit",
                table: "Pubinfounit",
                column: "unitid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pubinfounitchild",
                table: "Pubinfounitchild",
                column: "childid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Projectinfo",
                table: "Projectinfo",
                column: "pid");

            migrationBuilder.CreateTable(
                name: "LineDetails",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    thumb = table.Column<string>(nullable: true),
                    tags = table.Column<string>(nullable: true),
                    bestSeason = table.Column<string>(nullable: true),
                    city = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LineDetails", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Day",
                columns: table => new
                {
                    name = table.Column<string>(nullable: false),
                    LineId = table.Column<string>(nullable: false),
                    desc = table.Column<string>(nullable: true),
                    hotelDesc = table.Column<string>(nullable: true),
                    foodDesc = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Day", x => new { x.LineId, x.name });
                    table.ForeignKey(
                        name: "FK_Day_LineDetails_LineId",
                        column: x => x.LineId,
                        principalTable: "LineDetails",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Place",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    LineId = table.Column<string>(nullable: false),
                    name = table.Column<string>(nullable: false),
                    type = table.Column<string>(nullable: true),
                    time = table.Column<string>(nullable: true),
                    tag = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Place", x => new { x.LineId, x.name, x.id });
                    table.ForeignKey(
                        name: "FK_Place_Day_LineId_name",
                        columns: x => new { x.LineId, x.name },
                        principalTable: "Day",
                        principalColumns: new[] { "LineId", "name" },
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Place");

            migrationBuilder.DropTable(
                name: "Day");

            migrationBuilder.DropTable(
                name: "LineDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Typetag",
                table: "Typetag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Typepic",
                table: "Typepic");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Typeinfo",
                table: "Typeinfo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Typefield",
                table: "Typefield");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pubunittag",
                table: "Pubunittag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pubmediainfo",
                table: "Pubmediainfo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pubinfounitchild",
                table: "Pubinfounitchild");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pubinfounit",
                table: "Pubinfounit");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Projectinfo",
                table: "Projectinfo");

            migrationBuilder.RenameTable(
                name: "Typetag",
                newName: "Typetags");

            migrationBuilder.RenameTable(
                name: "Typepic",
                newName: "Typepics");

            migrationBuilder.RenameTable(
                name: "Typeinfo",
                newName: "Typeinfos");

            migrationBuilder.RenameTable(
                name: "Typefield",
                newName: "Typefields");

            migrationBuilder.RenameTable(
                name: "Pubunittag",
                newName: "Pubunittags");

            migrationBuilder.RenameTable(
                name: "Pubmediainfo",
                newName: "Pubmediainfos");

            migrationBuilder.RenameTable(
                name: "Pubinfounitchild",
                newName: "Pubinfounitchilds");

            migrationBuilder.RenameTable(
                name: "Pubinfounit",
                newName: "Pubinfounits");

            migrationBuilder.RenameTable(
                name: "Projectinfo",
                newName: "Projectinfos");

            migrationBuilder.RenameIndex(
                name: "IX_Pubinfounitchild_childid",
                table: "Pubinfounitchilds",
                newName: "IX_Pubinfounitchilds_childid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Typetags",
                table: "Typetags",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Typepics",
                table: "Typepics",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Typeinfos",
                table: "Typeinfos",
                column: "typeid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Typefields",
                table: "Typefields",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pubunittags",
                table: "Pubunittags",
                column: "unittagid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pubmediainfos",
                table: "Pubmediainfos",
                column: "mediaid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pubinfounitchilds",
                table: "Pubinfounitchilds",
                column: "childid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pubinfounits",
                table: "Pubinfounits",
                column: "unitid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Projectinfos",
                table: "Projectinfos",
                column: "pid");
        }
    }
}
