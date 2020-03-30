using Microsoft.EntityFrameworkCore.Migrations;

namespace TourInfo.Infrastracture.Migrations
{
    public partial class sdta_cityguide : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SDTACityGuideDetail",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    detailid = table.Column<int>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    content = table.Column<string>(nullable: true),
                    status = table.Column<int>(nullable: false),
                    user_id = table.Column<int>(nullable: false),
                    cms_user_id = table.Column<string>(nullable: true),
                    featured = table.Column<int>(nullable: false),
                    rank = table.Column<int>(nullable: false),
                    primary_category = table.Column<int>(nullable: false),
                    image = table.Column<string>(nullable: true),
                    views = table.Column<int>(nullable: false),
                    author = table.Column<string>(nullable: true),
                    created_at = table.Column<string>(nullable: true),
                    updated_at = table.Column<string>(nullable: true),
                    commentscore = table.Column<string>(nullable: true),
                    commentcount = table.Column<int>(nullable: false),
                    likescount = table.Column<int>(nullable: false),
                    collectscount = table.Column<int>(nullable: false),
                    category_id = table.Column<int>(nullable: false),
                    category_name = table.Column<string>(nullable: true),
                    category_slug = table.Column<string>(nullable: true),
                    category_parent_id = table.Column<int>(nullable: false),
                    category_description = table.Column<string>(nullable: true),
                    category_status = table.Column<int>(nullable: false),
                    category_user_id = table.Column<int>(nullable: false),
                    category_created_at = table.Column<string>(nullable: true),
                    category_updated_at = table.Column<string>(nullable: true),
                    category_icon = table.Column<string>(nullable: true),
                    category_featured = table.Column<int>(nullable: false),
                    category_order = table.Column<int>(nullable: false),
                    category_is_default = table.Column<int>(nullable: false),
                    pics_id = table.Column<int>(nullable: false),
                    pics_content_id = table.Column<int>(nullable: false),
                    pics_reference = table.Column<string>(nullable: true),
                    pics_created_at = table.Column<string>(nullable: true),
                    pics_updated_at = table.Column<string>(nullable: true),
                    pics_deleted_at = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SDTACityGuideDetail", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "SDTACityGuideDetailPicImage",
                columns: table => new
                {
                    img = table.Column<string>(nullable: false),
                    GuideId = table.Column<string>(nullable: false),
                    description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SDTACityGuideDetailPicImage", x => new { x.GuideId, x.img });
                    table.ForeignKey(
                        name: "FK_SDTACityGuideDetailPicImage_SDTACityGuideDetail_GuideId",
                        column: x => x.GuideId,
                        principalTable: "SDTACityGuideDetail",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SDTACityGuideDetailPicImage");

            migrationBuilder.DropTable(
                name: "SDTACityGuideDetail");
        }
    }
}
