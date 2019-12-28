using System;
using System.Collections.Generic;
using TourInfo.Domain.Base;
//using FastMember;

namespace TourInfo.Domain.DomainModel.Rapi
{
    public class InfoLocalizer<T,Key > : IInfoLocalizer<T,Key> where T:VersionedEntity<Key>
    {
        IRepository<T,Key> repository;
        IImageLocalizer imageLocalizer;
        
        
        public InfoLocalizer(IImageLocalizer imageLocalizer,IRepository<T,Key> repository
             )
        {
            this.repository=repository;
            this.imageLocalizer = imageLocalizer;
            
        }
         
        public void Localize(T t,string originImageRootUrl, string localSavedPath,string version )
        {
            var existed=repository.Get(t.id);
            if (existed!=null) { return ;}
            var members = t.GetType().GetMembers();
            foreach (var p in t.GetType().GetProperties())
            {
                if (p.PropertyType == typeof(ImageUrl))
                {
                    var imageUrl = (ImageUrl)p.GetValue(t);
                    imageUrl.UpdateLocalizedUrl(imageLocalizer.Localize(originImageRootUrl+imageUrl.OriginalUrl, localSavedPath));
                    p.SetValue(t, imageUrl);
                }
                else if (p.PropertyType.IsAssignableFrom(typeof(IList<ImageUrl>)) 
                    
                    )
                {
                    var arrayP = (IList<ImageUrl>)p.GetValue(t);
                    var imageUrls = new List<ImageUrl>();
                    foreach (var itemP in arrayP)
                    {
                        var imageUrl = (ImageUrl)itemP;
                        imageUrl.UpdateLocalizedUrl(imageLocalizer.Localize(originImageRootUrl+imageUrl.OriginalUrl, localSavedPath));
                        //string localizedImage = imageLocalizer.Localize(imageUrl.OriginalUrl, localSavedPath);
                        //p.SetValue(t, new ImageUrl(imageUrl.OriginalUrl, localizedImage));
                        imageUrls.Add(imageUrl);
                    }
                    p.SetValue(t, imageUrls.ToArray());
                }
            }
            t.Version=version;
            repository.Insert(t);
            
            
            
            
        }
    }
}
