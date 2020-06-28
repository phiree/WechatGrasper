using Microsoft.EntityFrameworkCore.Migrations;

namespace TourInfo.Infrastracture.Migrations
{
    public partial class remove_zibonews_content : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SDTASpecialLocalProductDetailFilterPictures");

            migrationBuilder.DropColumn(
                name: "content_ImageBaseUrl",
                table: "ZiBoWechatNews");

            migrationBuilder.DropColumn(
                name: "content_ImageLocalizedText",
                table: "ZiBoWechatNews");

            migrationBuilder.DropColumn(
                name: "content_OriginaText",
                table: "ZiBoWechatNews");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "content_ImageBaseUrl",
                table: "ZiBoWechatNews",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "content_ImageLocalizedText",
                table: "ZiBoWechatNews",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "content_OriginaText",
                table: "ZiBoWechatNews",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SDTASpecialLocalProductDetailFilterPictures",
                columns: table => new
                {
                    SpecialLocalProducId = table.Column<string>(nullable: false),
                    id = table.Column<int>(nullable: false),
                    created_at = table.Column<string>(nullable: true),
                    deleted_at = table.Column<string>(nullable: true),
                    is_404 = table.Column<int>(nullable: false),
                    pho_format = table.Column<string>(nullable: true),
                    pho_id = table.Column<string>(nullable: true),
                    pho_name = table.Column<string>(nullable: true),
                    pho_type = table.Column<string>(nullable: true),
                    picable_id = table.Column<string>(nullable: true),
                    picable_type = table.Column<string>(nullable: true),
                    rank = table.Column<int>(nullable: false),
                    updated_at = table.Column<string>(nullable: true),
                    pho_path_LocalizedUrl = table.Column<string>(nullable: true),
                    pho_path_OriginalUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SDTASpecialLocalProductDetailFilterPictures", x => new { x.SpecialLocalProducId, x.id });
                    table.ForeignKey(
                        name: "FK_SDTASpecialLocalProductDetailFilterPictures_SDTASpecialLocalProductDetail_SpecialLocalProducId",
                        column: x => x.SpecialLocalProducId,
                        principalTable: "SDTASpecialLocalProductDetail",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });
        }
    }
}
