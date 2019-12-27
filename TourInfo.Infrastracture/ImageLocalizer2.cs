
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using TourInfo.Domain;
using TourInfo.Infrastracture;
using System.IO;
using TourInfo.Domain.Base;
using System.Reflection;

namespace TourInfo.Infrastracture
{
    public class ImageLocalizer<T> : IImageLocalizer<T>
    {
        IUrlFetcher urlFetcher;

        public ImageLocalizer(IUrlFetcher urlFetcher)
        {
            this.urlFetcher = urlFetcher;
        }
        public void Localize(T t, string localSavedPath)
        {
            var members = t.GetType().GetMembers();
            foreach (var p in t.GetType().GetProperties())
            {
                if (p.PropertyType == typeof(ImageUrl))
                {
                    var imageUrl = (ImageUrl)p.GetValue(t);
                    imageUrl.UpdateLocalizedUrl(DownloadFile(imageUrl.OriginalUrl, localSavedPath));
                    //p.SetValue(t, imageUrl);
                }
                else if (p.PropertyType.IsArray&&p.PropertyType.GetElementType()==typeof(ImageUrl))
                {
                    var arrayP = (Array)p.GetValue(t);
                   
                    foreach (var itemP in arrayP)
                    {
                        var imageUrl = (ImageUrl)itemP;
                        imageUrl.UpdateLocalizedUrl( DownloadFile(imageUrl.OriginalUrl, localSavedPath));
                       

                    }
                }

            }
        }
        
        private string DownloadFile(string remotePicUrl, string localSavedPath)
        {
            string imgExt = Path.GetExtension(remotePicUrl);
            imgExt = string.IsNullOrEmpty(imgExt) ? ".jpg" : imgExt;
            string imageLocalDirectory = Environment.CurrentDirectory + "\\" + localSavedPath;
            if (!Directory.Exists(imageLocalDirectory))
            {
                Directory.CreateDirectory(imageLocalDirectory);
            }

            string imageName = Guid.NewGuid() + imgExt;
            string imageFullName = imageLocalDirectory + imageName;
            string imageReletiveName = localSavedPath + imageName;
            urlFetcher.FetchFile(remotePicUrl, imageFullName);
            return imageReletiveName;
        }
    }

}

