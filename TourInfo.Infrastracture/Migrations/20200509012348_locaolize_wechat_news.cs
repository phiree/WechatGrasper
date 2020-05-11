using Microsoft.EntityFrameworkCore.Migrations;

namespace TourInfo.Infrastracture.Migrations
{
    public partial class locaolize_wechat_news : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "img",
                table: "ZiBoWechatNews",
                newName: "content_OriginaText");

            migrationBuilder.AddColumn<string>(
                name: "img_LocalizedUrl",
                table: "ZiBoWechatNews",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "img_OriginalUrl",
                table: "ZiBoWechatNews",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "content_ImageBaseUrl",
                table: "ZiBoWechatNews",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "content_ImageLocalizedText",
                table: "ZiBoWechatNews",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "img_LocalizedUrl",
                table: "ZiBoWechatNews");

            migrationBuilder.DropColumn(
                name: "img_OriginalUrl",
                table: "ZiBoWechatNews");

            migrationBuilder.DropColumn(
                name: "content_ImageBaseUrl",
                table: "ZiBoWechatNews");

            migrationBuilder.DropColumn(
                name: "content_ImageLocalizedText",
                table: "ZiBoWechatNews");

            migrationBuilder.RenameColumn(
                name: "content_OriginaText",
                table: "ZiBoWechatNews",
                newName: "img");
        }
    }
}
