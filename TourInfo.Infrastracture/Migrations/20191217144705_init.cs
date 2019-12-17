using Microsoft.EntityFrameworkCore.Migrations;

namespace TourInfo.Infrastracture.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Entities",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    Fingerprint = table.Column<string>(nullable: true),
                    PlaceType = table.Column<int>(nullable: true),
                    Version = table.Column<string>(nullable: true),
                    startTime = table.Column<string>(nullable: true),
                    createTime = table.Column<string>(nullable: true),
                    thumbnailKey = table.Column<string>(nullable: true),
                    address = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    endTime = table.Column<string>(nullable: true),
                    detail = table.Column<string>(nullable: true),
                    pictureKeys = table.Column<string>(nullable: true),
                    credits = table.Column<int>(nullable: true),
                    isShared = table.Column<bool>(nullable: true),
                    CompanyVenue_thumbnailKey = table.Column<string>(nullable: true),
                    locations = table.Column<string>(nullable: true),
                    location = table.Column<string>(nullable: true),
                    CompanyVenue_name = table.Column<string>(nullable: true),
                    satisfactionScore = table.Column<string>(nullable: true),
                    typeId = table.Column<string>(nullable: true),
                    introduction = table.Column<string>(nullable: true),
                    CompanyVenue_pictureKeys = table.Column<string>(nullable: true),
                    CompanyVenue_address = table.Column<string>(nullable: true),
                    isFavorite = table.Column<string>(nullable: true),
                    serviceTimeStart = table.Column<string>(nullable: true),
                    serviceNote = table.Column<string>(nullable: true),
                    serviceTimeEnd = table.Column<string>(nullable: true),
                    telNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entities", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Entities");
        }
    }
}
