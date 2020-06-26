using Microsoft.EntityFrameworkCore.Migrations;

namespace TourInfo.Infrastracture.Migrations
{
    public partial class refact_cityguide : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SDTACityGuideDetailCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SDTACityGuideSummary",
                table: "SDTACityGuideSummary");

            migrationBuilder.RenameTable(
                name: "SDTACityGuideSummary",
                newName: "SDTACityGuideCategoryList");

            migrationBuilder.AddColumn<string>(
                name: "CategoryGuideId",
                table: "SDTACityGuideCategoryList",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Categoryname",
                table: "SDTACityGuideCategoryList",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SDTACityGuideCategoryList",
                table: "SDTACityGuideCategoryList",
                column: "id");

            migrationBuilder.CreateTable(
                name: "SDTACityGuide",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    Version = table.Column<string>(nullable: true),
                    Fingerprint = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    nameEn = table.Column<string>(nullable: true),
                    thumb = table.Column<string>(nullable: true),
                    cover = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SDTACityGuide", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "SDTACityGuideCategory",
                columns: table => new
                {
                    name = table.Column<string>(nullable: false),
                    GuideId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SDTACityGuideCategory", x => new { x.GuideId, x.name });
                    table.ForeignKey(
                        name: "FK_SDTACityGuideCategory_SDTACityGuide_GuideId",
                        column: x => x.GuideId,
                        principalTable: "SDTACityGuide",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SDTACityGuideCategoryList_CategoryGuideId_Categoryname",
                table: "SDTACityGuideCategoryList",
                columns: new[] { "CategoryGuideId", "Categoryname" });

            migrationBuilder.AddForeignKey(
                name: "FK_SDTACityGuideCategoryList_SDTACityGuideCategory_CategoryGuideId_Categoryname",
                table: "SDTACityGuideCategoryList",
                columns: new[] { "CategoryGuideId", "Categoryname" },
                principalTable: "SDTACityGuideCategory",
                principalColumns: new[] { "GuideId", "name" },
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SDTACityGuideCategoryList_SDTACityGuideCategory_CategoryGuideId_Categoryname",
                table: "SDTACityGuideCategoryList");

            migrationBuilder.DropTable(
                name: "SDTACityGuideCategory");

            migrationBuilder.DropTable(
                name: "SDTACityGuide");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SDTACityGuideCategoryList",
                table: "SDTACityGuideCategoryList");

            migrationBuilder.DropIndex(
                name: "IX_SDTACityGuideCategoryList_CategoryGuideId_Categoryname",
                table: "SDTACityGuideCategoryList");

            migrationBuilder.DropColumn(
                name: "CategoryGuideId",
                table: "SDTACityGuideCategoryList");

            migrationBuilder.DropColumn(
                name: "Categoryname",
                table: "SDTACityGuideCategoryList");

            migrationBuilder.RenameTable(
                name: "SDTACityGuideCategoryList",
                newName: "SDTACityGuideSummary");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SDTACityGuideSummary",
                table: "SDTACityGuideSummary",
                column: "id");

            migrationBuilder.CreateTable(
                name: "SDTACityGuideDetailCategory",
                columns: table => new
                {
                    Dataid = table.Column<string>(nullable: false),
                    created_at = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    featured = table.Column<int>(nullable: false),
                    icon = table.Column<string>(nullable: true),
                    id = table.Column<int>(nullable: false),
                    is_default = table.Column<int>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    order = table.Column<int>(nullable: false),
                    parent_id = table.Column<int>(nullable: false),
                    slug = table.Column<string>(nullable: true),
                    status = table.Column<int>(nullable: false),
                    updated_at = table.Column<string>(nullable: true),
                    user_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SDTACityGuideDetailCategory", x => x.Dataid);
                    table.ForeignKey(
                        name: "FK_SDTACityGuideDetailCategory_SDTACityGuideDetail_Dataid",
                        column: x => x.Dataid,
                        principalTable: "SDTACityGuideDetail",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });
        }
    }
}
