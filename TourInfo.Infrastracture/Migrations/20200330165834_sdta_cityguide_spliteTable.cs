using Microsoft.EntityFrameworkCore.Migrations;

namespace TourInfo.Infrastracture.Migrations
{
    public partial class sdta_cityguide_spliteTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "category_created_at",
                table: "SDTACityGuideDetail");

            migrationBuilder.DropColumn(
                name: "category_description",
                table: "SDTACityGuideDetail");

            migrationBuilder.DropColumn(
                name: "category_featured",
                table: "SDTACityGuideDetail");

            migrationBuilder.DropColumn(
                name: "category_icon",
                table: "SDTACityGuideDetail");

            migrationBuilder.DropColumn(
                name: "category_id",
                table: "SDTACityGuideDetail");

            migrationBuilder.DropColumn(
                name: "category_is_default",
                table: "SDTACityGuideDetail");

            migrationBuilder.DropColumn(
                name: "category_name",
                table: "SDTACityGuideDetail");

            migrationBuilder.DropColumn(
                name: "category_order",
                table: "SDTACityGuideDetail");

            migrationBuilder.DropColumn(
                name: "category_parent_id",
                table: "SDTACityGuideDetail");

            migrationBuilder.DropColumn(
                name: "category_slug",
                table: "SDTACityGuideDetail");

            migrationBuilder.DropColumn(
                name: "category_status",
                table: "SDTACityGuideDetail");

            migrationBuilder.DropColumn(
                name: "category_updated_at",
                table: "SDTACityGuideDetail");

            migrationBuilder.DropColumn(
                name: "category_user_id",
                table: "SDTACityGuideDetail");

            migrationBuilder.CreateTable(
                name: "SDTACityGuideDetailCategory",
                columns: table => new
                {
                    Dataid = table.Column<string>(nullable: false),
                    id = table.Column<int>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    slug = table.Column<string>(nullable: true),
                    parent_id = table.Column<int>(nullable: false),
                    description = table.Column<string>(nullable: true),
                    status = table.Column<int>(nullable: false),
                    user_id = table.Column<int>(nullable: false),
                    created_at = table.Column<string>(nullable: true),
                    updated_at = table.Column<string>(nullable: true),
                    icon = table.Column<string>(nullable: true),
                    featured = table.Column<int>(nullable: false),
                    order = table.Column<int>(nullable: false),
                    is_default = table.Column<int>(nullable: false)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SDTACityGuideDetailCategory");

            migrationBuilder.AddColumn<string>(
                name: "category_created_at",
                table: "SDTACityGuideDetail",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "category_description",
                table: "SDTACityGuideDetail",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "category_featured",
                table: "SDTACityGuideDetail",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "category_icon",
                table: "SDTACityGuideDetail",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "category_id",
                table: "SDTACityGuideDetail",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "category_is_default",
                table: "SDTACityGuideDetail",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "category_name",
                table: "SDTACityGuideDetail",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "category_order",
                table: "SDTACityGuideDetail",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "category_parent_id",
                table: "SDTACityGuideDetail",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "category_slug",
                table: "SDTACityGuideDetail",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "category_status",
                table: "SDTACityGuideDetail",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "category_updated_at",
                table: "SDTACityGuideDetail",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "category_user_id",
                table: "SDTACityGuideDetail",
                nullable: false,
                defaultValue: 0);
        }
    }
}
