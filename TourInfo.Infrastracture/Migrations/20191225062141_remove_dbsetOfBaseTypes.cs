using Microsoft.EntityFrameworkCore.Migrations;

namespace TourInfo.Infrastracture.Migrations
{
    public partial class remove_dbsetOfBaseTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Entities",
                table: "Entities");

            migrationBuilder.DropColumn(
                name: "address",
                table: "Entities");

            migrationBuilder.DropColumn(
                name: "createTime",
                table: "Entities");

            migrationBuilder.DropColumn(
                name: "credits",
                table: "Entities");

            migrationBuilder.DropColumn(
                name: "detail",
                table: "Entities");

            migrationBuilder.DropColumn(
                name: "endTime",
                table: "Entities");

            migrationBuilder.DropColumn(
                name: "isShared",
                table: "Entities");

            migrationBuilder.DropColumn(
                name: "name",
                table: "Entities");

            migrationBuilder.DropColumn(
                name: "startTime",
                table: "Entities");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Entities");

            migrationBuilder.DropColumn(
                name: "CompanyVenue_address",
                table: "Entities");

            migrationBuilder.DropColumn(
                name: "introduction",
                table: "Entities");

            migrationBuilder.DropColumn(
                name: "isFavorite",
                table: "Entities");

            migrationBuilder.DropColumn(
                name: "location",
                table: "Entities");

            migrationBuilder.DropColumn(
                name: "CompanyVenue_name",
                table: "Entities");

            migrationBuilder.DropColumn(
                name: "satisfactionScore",
                table: "Entities");

            migrationBuilder.DropColumn(
                name: "serviceNote",
                table: "Entities");

            migrationBuilder.DropColumn(
                name: "serviceTimeEnd",
                table: "Entities");

            migrationBuilder.DropColumn(
                name: "serviceTimeStart",
                table: "Entities");

            migrationBuilder.DropColumn(
                name: "telNumber",
                table: "Entities");

            migrationBuilder.DropColumn(
                name: "typeId",
                table: "Entities");

            migrationBuilder.DropColumn(
                name: "PlaceType",
                table: "Entities");

            migrationBuilder.DropColumn(
                name: "localizedPictureKeys",
                table: "Entities");

            migrationBuilder.DropColumn(
                name: "localizedThumbnailKey",
                table: "Entities");

            migrationBuilder.DropColumn(
                name: "pictureKeys",
                table: "Entities");

            migrationBuilder.DropColumn(
                name: "thumbnailKey",
                table: "Entities");

            migrationBuilder.RenameTable(
                name: "Entities",
                newName: "ZbtaNews");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ZbtaNews",
                table: "ZbtaNews",
                column: "id");

            migrationBuilder.CreateTable(
                name: "EWQYEntity",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    Version = table.Column<string>(nullable: true),
                    Fingerprint = table.Column<string>(nullable: true),
                    PlaceType = table.Column<int>(nullable: false),
                    thumbnailKey = table.Column<string>(nullable: true),
                    localizedThumbnailKey = table.Column<string>(nullable: true),
                    pictureKeys = table.Column<string>(nullable: true),
                    localizedPictureKeys = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    startTime = table.Column<string>(nullable: true),
                    createTime = table.Column<string>(nullable: true),
                    address = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    endTime = table.Column<string>(nullable: true),
                    detail = table.Column<string>(nullable: true),
                    credits = table.Column<int>(nullable: true),
                    isShared = table.Column<bool>(nullable: true),
                    location = table.Column<string>(nullable: true),
                    CompanyVenue_name = table.Column<string>(nullable: true),
                    satisfactionScore = table.Column<string>(nullable: true),
                    typeId = table.Column<string>(nullable: true),
                    introduction = table.Column<string>(nullable: true),
                    CompanyVenue_address = table.Column<string>(nullable: true),
                    isFavorite = table.Column<string>(nullable: true),
                    serviceTimeStart = table.Column<string>(nullable: true),
                    serviceNote = table.Column<string>(nullable: true),
                    serviceTimeEnd = table.Column<string>(nullable: true),
                    telNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EWQYEntity", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EWQYEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ZbtaNews",
                table: "ZbtaNews");

            migrationBuilder.RenameTable(
                name: "ZbtaNews",
                newName: "Entities");

            migrationBuilder.AddColumn<string>(
                name: "address",
                table: "Entities",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "createTime",
                table: "Entities",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "credits",
                table: "Entities",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "detail",
                table: "Entities",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "endTime",
                table: "Entities",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isShared",
                table: "Entities",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "Entities",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "startTime",
                table: "Entities",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Entities",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CompanyVenue_address",
                table: "Entities",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "introduction",
                table: "Entities",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "isFavorite",
                table: "Entities",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "location",
                table: "Entities",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyVenue_name",
                table: "Entities",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "satisfactionScore",
                table: "Entities",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "serviceNote",
                table: "Entities",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "serviceTimeEnd",
                table: "Entities",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "serviceTimeStart",
                table: "Entities",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "telNumber",
                table: "Entities",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "typeId",
                table: "Entities",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PlaceType",
                table: "Entities",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "localizedPictureKeys",
                table: "Entities",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "localizedThumbnailKey",
                table: "Entities",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "pictureKeys",
                table: "Entities",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "thumbnailKey",
                table: "Entities",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Entities",
                table: "Entities",
                column: "id");
        }
    }
}
