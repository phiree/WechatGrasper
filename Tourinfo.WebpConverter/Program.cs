using GroupDocs.Conversion;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourInfo.WebpConverter;

namespace Tourinfo.WebpConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            ConvertFiles();
            Console.WriteLine("转换完毕");
            Console.ReadLine();
        }
       static WebpImageConverter converter = new WebpImageConverter();
        static void ConvertFiles()
        {
            string folder = ConfigurationSettings. AppSettings["ImageFolder"];
            DirectoryInfo dir = new DirectoryInfo(folder);
            foreach (var childDir in dir.GetDirectories())
            {
                ConvertOneDirectory(childDir);
            }

        }
        static void ConvertOneDirectory(DirectoryInfo directory)
        {
            Console.WriteLine("扫描文件夹:" + directory.FullName);
            foreach (var file in directory.GetFiles("*.webp"))
            {
                Console.WriteLine("发现webp,转换." + file.FullName);
                converter.Convert(file.FullName);
            }
            foreach (var childDir in directory.GetDirectories())
            {

                ConvertOneDirectory(childDir);
            }

        }
    }
}
