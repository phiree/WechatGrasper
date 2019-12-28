using Microsoft.EntityFrameworkCore.Migrations;

namespace TourInfo.Infrastracture.Migrations
{
    public partial class add_ewqy_placetype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EWQYEntity_pictureKeys_EWQYEntity_id",
                table: "EWQYEntity_pictureKeys");

            migrationBuilder.DropTable(
                name: "CompanyVenueTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EWQYEntity_pictureKeys",
                table: "EWQYEntity_pictureKeys");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EWQYEntity",
                table: "EWQYEntity");

            migrationBuilder.RenameTable(
                name: "EWQYEntity_pictureKeys",
                newName: "EWQYPlaceTypeEntities_pictureKeys");

            migrationBuilder.RenameTable(
                name: "EWQYEntity",
                newName: "EWQYPlaceTypeEntities");

            migrationBuilder.RenameIndex(
                name: "IX_EWQYEntity_pictureKeys_id",
                table: "EWQYPlaceTypeEntities_pictureKeys",
                newName: "IX_EWQYPlaceTypeEntities_pictureKeys_id");

            migrationBuilder.AddColumn<string>(
                name: "CompanyVenueType_name",
                table: "EWQYPlaceTypeEntities",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_EWQYPlaceTypeEntities_pictureKeys",
                table: "EWQYPlaceTypeEntities_pictureKeys",
                columns: new[] { "OriginalUrl", "id" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_EWQYPlaceTypeEntities",
                table: "EWQYPlaceTypeEntities",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_EWQYPlaceTypeEntities_pictureKeys_EWQYPlaceTypeEntities_id",
                table: "EWQYPlaceTypeEntities_pictureKeys",
                column: "id",
                principalTable: "EWQYPlaceTypeEntities",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EWQYPlaceTypeEntities_pictureKeys_EWQYPlaceTypeEntities_id",
                table: "EWQYPlaceTypeEntities_pictureKeys");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EWQYPlaceTypeEntities_pictureKeys",
                table: "EWQYPlaceTypeEntities_pictureKeys");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EWQYPlaceTypeEntities",
                table: "EWQYPlaceTypeEntities");

            migrationBuilder.DropColumn(
                name: "CompanyVenueType_name",
                table: "EWQYPlaceTypeEntities");

            migrationBuilder.RenameTable(
                name: "EWQYPlaceTypeEntities_pictureKeys",
                newName: "EWQYEntity_pictureKeys");

            migrationBuilder.RenameTable(
                name: "EWQYPlaceTypeEntities",
                newName: "EWQYEntity");

            migrationBuilder.RenameIndex(
                name: "IX_EWQYPlaceTypeEntities_pictureKeys_id",
                table: "EWQYEntity_pictureKeys",
                newName: "IX_EWQYEntity_pictureKeys_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EWQYEntity_pictureKeys",
                table: "EWQYEntity_pictureKeys",
                columns: new[] { "OriginalUrl", "id" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_EWQYEntity",
                table: "EWQYEntity",
                column: "id");

            migrationBuilder.CreateTable(
                name: "CompanyVenueTypes",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    Fingerprint = table.Column<string>(nullable: true),
                    PlaceType = table.Column<int>(nullable: false),
                    Version = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyVenueTypes", x => x.id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_EWQYEntity_pictureKeys_EWQYEntity_id",
                table: "EWQYEntity_pictureKeys",
                column: "id",
                principalTable: "EWQYEntity",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
