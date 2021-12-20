using Microsoft.Extensions.DependencyInjection;
using System;
using TourInfo.Domain.Base;
using TourInfo.Infrastracture.Repository.EFCore;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using Microsoft.Extensions.Configuration;
using TourInfo.Domain.ZBTA;
using System.Text.RegularExpressions;
using System.IO;
using System.Linq;
namespace RecoverImages
{

    class Program
    {
        static void Main(string[] args)
        {
            //获取所有数据
            //遍历数据,找文件
            //匹配的 copy+重命名为原始文件
            IConfiguration config = new ConfigurationBuilder()
                                    .AddJsonFile("appsettings.json")
                                    .Build();
            var conn = new SqlConnection(config.GetConnectionString("TourInfoConnectionString"));
            var OriginalImageFolder = new System.IO.DirectoryInfo(config["OriginalImageFolder"]);
            var TargetImageFolder = new System.IO.DirectoryInfo(config["TargetImageFolder"]);
            TargetImageFolder.Create();
            var allNews = conn.Query("select image_originalurl,image_localizedurl from zbtanews");
            foreach (var item in allNews)
            {
              var  fileNameInDb = (Regex.Match(item.image_localizedurl, @"[^\\]+\.\w+")).Value;
               
                if (OriginalImageFolder.GetFiles(fileNameInDb).Length == 1)
                {
                    string targetFilePath = TargetImageFolder + "\\" + item.image_originalurl;
                    var targetFile = new FileInfo(targetFilePath);
                    targetFile.Directory.Create();

                    File.Copy(OriginalImageFolder+"\\"+fileNameInDb, targetFilePath);

                }

            }

        }

    }
}
