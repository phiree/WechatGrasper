using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TourInfo.Domain;
using TourInfo.Domain.Base;
//using FastMember;

namespace TourInfo.Domain
{
    public class InfoLocalizer<T, Key> : IInfoLocalizer<T, Key> where T : VersionedEntity<Key>
    {
        IRepository<T, Key> repository;
        IImageLocalizer imageLocalizer;
        IUrlFetcher urlFetcher;
        string localSavedPath, imageClientPath;



        public InfoLocalizer(IRepository<T, Key> repository, IUrlFetcher urlFetcher, string localSavedPath, string imageClientPath)
        {
            this.urlFetcher=urlFetcher;
            this.repository = repository;
              imageLocalizer=new ImageLocalizer(urlFetcher,localSavedPath,imageClientPath);
            this.localSavedPath = localSavedPath;
            this.imageClientPath = imageClientPath;
        }

        public void Localize(T t, string originImageRootUrl, string version, out bool isExisted)
        {
            isExisted = false;
            var existed = repository.Get(t.id);

            if (existed != null)
            {
                isExisted = true;
                return;
            }

            foreach (var p in t.GetType().GetProperties())
            {
                if (p.PropertyType == typeof(ImageUrl))
                {
                    var imageUrl = (ImageUrl)p.GetValue(t);
                    
                    if (imageUrl == null || string.IsNullOrEmpty(imageUrl.OriginalUrl))
                    {
                        imageUrl = ImageUrl.Null;
                    }
                    else
                    {
                        imageUrl.Localize(imageLocalizer,originImageRootUrl);
                        //imageUrl.UpdateLocalizedUrl(imageLocalizer.Localize(originImageRootUrl + imageUrl.OriginalUrl  ));

                    }
                    p.SetValue(t, imageUrl);
                }
                else if (p.PropertyType == typeof(ImageUrlsInText))
                {
                    var imageUrl = (ImageUrlsInText)p.GetValue(t);

                    imageUrl.Localize(imageLocalizer,originImageRootUrl);
                    p.SetValue(t, imageUrl);

                }
                else if (p.PropertyType.IsAssignableFrom(typeof(IList<ImageUrl>)))
                {
                    var arrayP = (IList<ImageUrl>)p.GetValue(t);
                    var imageUrls = new List<ImageUrl>();
                    foreach (var itemP in arrayP)
                    {
                        var imageUrl = itemP;
                        imageUrl.Localize(imageLocalizer ,originImageRootUrl  );
                        //string localizedImage = imageLocalizer.Localize(imageUrl.OriginalUrl, localSavedPath);
                        //p.SetValue(t, new ImageUrl(imageUrl.OriginalUrl, localizedImage));
                        imageUrls.Add(imageUrl);
                    }
                    p.SetValue(t, imageUrls.ToArray());
                }
            }
            t.Version = version;
            repository.Insert(t);

        }


    }
}
