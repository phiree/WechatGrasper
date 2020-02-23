 
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using TourInfo.Domain;
 
using System.IO;
namespace TourInfo.Domain
{
    public class ImageLocalizer : IImageLocalizer
    {
        IUrlFetcher urlFetcher;
      string localSavedPath,  clientPath;
        

        public ImageLocalizer(IUrlFetcher urlFetcher, string localSavedPath, string clientPath )
        {
            this.localSavedPath = localSavedPath;
            this.clientPath = clientPath; this.urlFetcher = urlFetcher;
        }

        public string Localize( string remotePicUrl)
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
            string imageReletiveName = clientPath + imageName;
              urlFetcher.FetchFile(remotePicUrl, imageFullName);
            return imageReletiveName;            
        }
    }

}

