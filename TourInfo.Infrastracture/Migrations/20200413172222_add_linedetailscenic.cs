using Microsoft.EntityFrameworkCore.Migrations;

namespace TourInfo.Infrastracture.Migrations
{
    public partial class add_linedetailscenic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SDTALineDetailScenic",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SDTALineDetailScenic", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "SDTALineDetailScenicDoc",
                columns: table => new
                {
                    _id = table.Column<string>(nullable: false),
                    DocId = table.Column<string>(nullable: false),
                    _index = table.Column<string>(nullable: true),
                    _type = table.Column<string>(nullable: true),
                    _version = table.Column<int>(nullable: false),
                    found = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SDTALineDetailScenicDoc", x => new { x.DocId, x._id });
                    table.ForeignKey(
                        name: "FK_SDTALineDetailScenicDoc_SDTALineDetailScenic_DocId",
                        column: x => x.DocId,
                        principalTable: "SDTALineDetailScenic",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SDTALineDetailScenicDocSource",
                columns: table => new
                {
                    DocId = table.Column<string>(nullable: false),
                    Doc_id = table.Column<string>(nullable: false),
                    ele_id = table.Column<string>(nullable: true),
                    ele_type = table.Column<string>(nullable: true),
                    ele_type_name = table.Column<string>(nullable: true),
                    name_cn = table.Column<string>(nullable: true),
                    address = table.Column<string>(nullable: true),
                    default_photo = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    contact = table.Column<string>(nullable: true),
                    level = table.Column<int>(nullable: false),
                    city = table.Column<int>(nullable: false),
                    area = table.Column<string>(nullable: true),
                    rank = table.Column<int>(nullable: false),
                    ele_type_name_en = table.Column<string>(nullable: true),
                    lvl1 = table.Column<string>(nullable: true),
                    city_order = table.Column<int>(nullable: false),
                    level_name = table.Column<string>(nullable: true),
                    date_for_order = table.Column<int>(nullable: false),
                    location = table.Column<string>(nullable: true),
                    buyable = table.Column<string>(nullable: true),
                    lowest_price = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SDTALineDetailScenicDocSource", x => new { x.DocId, x.Doc_id });
                    table.ForeignKey(
                        name: "FK_SDTALineDetailScenicDocSource_SDTALineDetailScenicDoc_DocId_Doc_id",
                        columns: x => new { x.DocId, x.Doc_id },
                        principalTable: "SDTALineDetailScenicDoc",
                        principalColumns: new[] { "DocId", "_id" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SDTALineDetailScenicDocSourceEletype",
                columns: table => new
                {
                    level = table.Column<int>(nullable: false),
                    DocId = table.Column<string>(nullable: false),
                    _id = table.Column<string>(nullable: false),
                    value = table.Column<string>(nullable: true),
                    ancestors = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SDTALineDetailScenicDocSourceEletype", x => new { x.DocId, x._id, x.level });
                    table.ForeignKey(
                        name: "FK_SDTALineDetailScenicDocSourceEletype_SDTALineDetailScenicDocSource_DocId__id",
                        columns: x => new { x.DocId, x._id },
                        principalTable: "SDTALineDetailScenicDocSource",
                        principalColumns: new[] { "DocId", "Doc_id" },
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SDTALineDetailScenicDocSourceEletype");

            migrationBuilder.DropTable(
                name: "SDTALineDetailScenicDocSource");

            migrationBuilder.DropTable(
                name: "SDTALineDetailScenicDoc");

            migrationBuilder.DropTable(
                name: "SDTALineDetailScenic");
        }
    }
}
