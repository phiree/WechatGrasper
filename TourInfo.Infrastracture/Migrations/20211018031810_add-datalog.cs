using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TourInfo.Infrastracture.Migrations
{
    public partial class adddatalog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    AppId = table.Column<string>(nullable: true),
                    AppSecret = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "DataSources",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    BaseUrl = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataSources", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "DistributeLogs",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    DeviceId = table.Column<string>(nullable: true),
                    DistributeBeginTime = table.Column<DateTime>(nullable: false),
                    DistributeEndTime = table.Column<DateTime>(nullable: false),
                    DistributeAmount = table.Column<int>(nullable: false),
                    DistirbuteResult = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DistributeLogs", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "FetchLogs",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    SourceId = table.Column<string>(nullable: true),
                    FetchBeginTime = table.Column<DateTime>(nullable: false),
                    FetchEndTime = table.Column<DateTime>(nullable: false),
                    FetchAmount = table.Column<int>(nullable: false),
                    FetchResult = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FetchLogs", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "id", "AppId", "AppSecret", "Description", "Name" },
                values: new object[,]
                {
                    { "528a3ebc-775c-4fca-b125-f2b3389eca34", "appid001", "********", null, "大厅迎宾屏" },
                    { "e255daf9-3188-4e73-9849-5f510e265fad", "appid002", "********", null, "安卓客户端" },
                    { "15da55b8-511f-402a-9d42-637cd87a6405", "appid003", "********", null, "一号大屏" },
                    { "64afbfcf-62a8-40c5-9815-ad660288108f", "appid004", "********", null, "二号大屏" },
                    { "db1ea02d-1031-440c-bcae-036027e96001", "appid005", "********", null, "三号大屏" }
                });

            migrationBuilder.InsertData(
                table: "DataSources",
                columns: new[] { "id", "BaseUrl", "Name", "Status" },
                values: new object[,]
                {
                    { "528a3ebc-775c-4fca-b125-f2b3389eca34", "zbwhy.com", "淄博文化云", "正常" },
                    { "e255daf9-3188-4e73-9849-5f510e265fad", "w.culturedata.com.cn", "E文齐韵", "许可过期,已停用" },
                    { "15da55b8-511f-402a-9d42-637cd87a6405", "rapi.zjwist.com", "存档资源", "正常" },
                    { "64afbfcf-62a8-40c5-9815-ad660288108f", "zbta.net", "淄博旅游资讯网", "正常" },
                    { "db1ea02d-1031-440c-bcae-036027e96001", "----", "淄博新闻公众号", "正常" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "DataSources");

            migrationBuilder.DropTable(
                name: "DistributeLogs");

            migrationBuilder.DropTable(
                name: "FetchLogs");
        }
    }
}
