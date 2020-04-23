using Microsoft.EntityFrameworkCore.Migrations;

namespace TourInfo.Infrastracture.Migrations
{
    public partial class imageurlofcityguide : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SDTACityGuideDetailPicImage",
                table: "SDTACityGuideDetailPicImage");

            migrationBuilder.DropColumn(
                name: "img",
                table: "SDTACityGuideDetailPicImage");

            migrationBuilder.RenameColumn(
                name: "image",
                table: "SDTACityGuideDetail",
                newName: "image_OriginalUrl");

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "SDTACityGuideDetailPicImage",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "img_LocalizedUrl",
                table: "SDTACityGuideDetailPicImage",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "img_OriginalUrl",
                table: "SDTACityGuideDetailPicImage",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "image_LocalizedUrl",
                table: "SDTACityGuideDetail",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SDTACityGuideDetailPicImage",
                table: "SDTACityGuideDetailPicImage",
                columns: new[] { "GuideId", "description" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SDTACityGuideDetailPicImage",
                table: "SDTACityGuideDetailPicImage");

            migrationBuilder.DropColumn(
                name: "img_LocalizedUrl",
                table: "SDTACityGuideDetailPicImage");

            migrationBuilder.DropColumn(
                name: "img_OriginalUrl",
                table: "SDTACityGuideDetailPicImage");

            migrationBuilder.DropColumn(
                name: "image_LocalizedUrl",
                table: "SDTACityGuideDetail");

            migrationBuilder.RenameColumn(
                name: "image_OriginalUrl",
                table: "SDTACityGuideDetail",
                newName: "image");

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "SDTACityGuideDetailPicImage",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "img",
                table: "SDTACityGuideDetailPicImage",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SDTACityGuideDetailPicImage",
                table: "SDTACityGuideDetailPicImage",
                columns: new[] { "GuideId", "img" });
        }
    }
}
