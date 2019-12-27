using System;
using System.Collections.Generic;
using TourInfo.Domain.Base;
//using FastMember;

namespace TourInfo.Domain.DomainModel.Rapi
{
    public class InfoLocalizer<T > : IInfoLocalizer<T> 
    {
        IImageLocalizer imageLocalizer;
        
        public InfoLocalizer(IImageLocalizer imageLocalizer
             )
        {
            this.imageLocalizer = imageLocalizer;
            
        }
         
        public void Localize(T t, string localSavedPath)
        {
            var members = t.GetType().GetMembers();
            foreach (var p in t.GetType().GetProperties())
            {
                if (p.PropertyType == typeof(ImageUrl))
                {
                    var imageUrl = (ImageUrl)p.GetValue(t);
                    imageUrl.UpdateLocalizedUrl(imageLocalizer.Localize(imageUrl.OriginalUrl, localSavedPath));
                    p.SetValue(t, imageUrl);
                }
                else if (p.PropertyType.IsArray && p.PropertyType.GetElementType() == typeof(ImageUrl))
                {
                    var arrayP = (Array)p.GetValue(t);
                    var imageUrls = new List<ImageUrl>();
                    foreach (var itemP in arrayP)
                    {
                        var imageUrl = (ImageUrl)itemP;
                        imageUrl.UpdateLocalizedUrl(imageLocalizer.Localize(imageUrl.OriginalUrl, localSavedPath));
                        //string localizedImage = imageLocalizer.Localize(imageUrl.OriginalUrl, localSavedPath);
                        //p.SetValue(t, new ImageUrl(imageUrl.OriginalUrl, localizedImage));
                        imageUrls.Add(imageUrl);
                    }
                    p.SetValue(t, imageUrls.ToArray());
                }
            }
            
            
            
        }
    }
}
