 
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using TourInfo.Domain;
using TourInfo.Infrastracture;
using System.IO;
namespace TourInfo.Infrastracture
{
    public class ImageLocalizer : IImageLocalizer
    {
        IUrlFetcher urlFetcher;
      
        public ImageLocalizer(IUrlFetcher urlFetcher)
        {
            this.urlFetcher = urlFetcher;
        }
        public string Localize(string remotePicUrl, string localSavedPath)
        {
            string imgExt=Path.GetExtension(remotePicUrl);
            string imageLocalDirectory = Environment.CurrentDirectory + "\\" + localSavedPath;
            if (!Directory.Exists(imageLocalDirectory))
            {
                Directory.CreateDirectory(imageLocalDirectory);
            }
            string imageName =imageLocalDirectory+ Guid.NewGuid() + imgExt;

            urlFetcher.FetchFile(remotePicUrl, imageName);
            return imageName;            
        }
    }

}

