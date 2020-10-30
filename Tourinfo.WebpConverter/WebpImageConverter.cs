using GroupDocs.Conversion;
using GroupDocs.Conversion.FileTypes;
using GroupDocs.Conversion.Options.Convert;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace TourInfo.WebpConverter
{
    /// <summary>
    /// convert webp image to jpeg
    /// </summary>
    public class WebpImageConverter
    {
        public void Convert(string webpFullName)
        {
            string fileName = Path.GetFileNameWithoutExtension(webpFullName);
            string path = Path.GetDirectoryName(webpFullName);
            using (Converter converter = new Converter(webpFullName))
            {
                ImageConvertOptions options = new ImageConvertOptions
                { // Set the conversion format to JPG
                    Format = ImageFileType.Jpg
                };
                string targetFileName = fileName + ".jpg";
                string targetFileFullName = path + "\\" + targetFileName;
                converter.Convert(targetFileFullName, options);

            }
        }
    }
}
