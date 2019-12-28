 
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
        public string Localize( string remotePicUrl, string localSavedPath)
        {
            string imgExt=Path.GetExtension(remotePicUrl);
            imgExt=string.IsNullOrEmpty(imgExt)?".jpg":imgExt;
            string imageLocalDirectory = Environment.CurrentDirectory + "\\"+ localSavedPath;
            if (!Directory.Exists(imageLocalDirectory))
            {
                Directory.CreateDirectory(imageLocalDirectory);
            }

            string imageName = Guid.NewGuid() + imgExt;
            string imageFullName =imageLocalDirectory+imageName;
            string imageReletiveName = localSavedPath + imageName;
              urlFetcher.FetchFile(remotePicUrl, imageFullName);
            return imageReletiveName;            
        }
    }

}

