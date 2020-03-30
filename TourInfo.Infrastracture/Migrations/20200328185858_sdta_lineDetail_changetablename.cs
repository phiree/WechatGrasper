using Microsoft.EntityFrameworkCore.Migrations;

namespace TourInfo.Infrastracture.Migrations
{
    public partial class sdta_lineDetail_changetablename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Day_LineDetails_LineId",
                table: "Day");

            migrationBuilder.DropForeignKey(
                name: "FK_Place_Day_LineId_name",
                table: "Place");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Place",
                table: "Place");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LineDetails",
                table: "LineDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Day",
                table: "Day");

            migrationBuilder.RenameTable(
                name: "Place",
                newName: "SDTALineDetailDayPlace");

            migrationBuilder.RenameTable(
                name: "LineDetails",
                newName: "SDTALineDetail");

            migrationBuilder.RenameTable(
                name: "Day",
                newName: "SDTALineDetailDay");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SDTALineDetailDayPlace",
                table: "SDTALineDetailDayPlace",
                columns: new[] { "LineId", "name", "id" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_SDTALineDetail",
                table: "SDTALineDetail",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SDTALineDetailDay",
                table: "SDTALineDetailDay",
                columns: new[] { "LineId", "name" });

            migrationBuilder.AddForeignKey(
                name: "FK_SDTALineDetailDay_SDTALineDetail_LineId",
                table: "SDTALineDetailDay",
                column: "LineId",
                principalTable: "SDTALineDetail",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SDTALineDetailDayPlace_SDTALineDetailDay_LineId_name",
                table: "SDTALineDetailDayPlace",
                columns: new[] { "LineId", "name" },
                principalTable: "SDTALineDetailDay",
                principalColumns: new[] { "LineId", "name" },
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SDTALineDetailDay_SDTALineDetail_LineId",
                table: "SDTALineDetailDay");

            migrationBuilder.DropForeignKey(
                name: "FK_SDTALineDetailDayPlace_SDTALineDetailDay_LineId_name",
                table: "SDTALineDetailDayPlace");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SDTALineDetailDayPlace",
                table: "SDTALineDetailDayPlace");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SDTALineDetailDay",
                table: "SDTALineDetailDay");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SDTALineDetail",
                table: "SDTALineDetail");

            migrationBuilder.RenameTable(
                name: "SDTALineDetailDayPlace",
                newName: "Place");

            migrationBuilder.RenameTable(
                name: "SDTALineDetailDay",
                newName: "Day");

            migrationBuilder.RenameTable(
                name: "SDTALineDetail",
                newName: "LineDetails");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Place",
                table: "Place",
                columns: new[] { "LineId", "name", "id" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Day",
                table: "Day",
                columns: new[] { "LineId", "name" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_LineDetails",
                table: "LineDetails",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Day_LineDetails_LineId",
                table: "Day",
                column: "LineId",
                principalTable: "LineDetails",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Place_Day_LineId_name",
                table: "Place",
                columns: new[] { "LineId", "name" },
                principalTable: "Day",
                principalColumns: new[] { "LineId", "name" },
                onDelete: ReferentialAction.Cascade);
        }
    }
}
