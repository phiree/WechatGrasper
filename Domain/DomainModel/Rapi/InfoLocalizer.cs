using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
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
         
        public void Localize(T t,string originImageRootUrl, string localSavedPath,string imageClientPath, string version,out bool isExisted )
        {

            isExisted=false;
            var  existed=repository.Get(t.id);
            if (existed!=null) {isExisted=true; return ;}
            var members = t.GetType().GetMembers();
            foreach (var p in t.GetType().GetProperties())
            {
                if (p.PropertyType == typeof(ImageUrl))
                {
                    var imageUrl = (ImageUrl)p.GetValue(t);
                    if (imageUrl == null ||string.IsNullOrEmpty( imageUrl.OriginalUrl)) {
                        imageUrl = ImageUrl.Null;
                    }
                    else
                    {
                        imageUrl.UpdateLocalizedUrl(imageLocalizer.Localize(originImageRootUrl + imageUrl.OriginalUrl, localSavedPath, imageClientPath));

                    }
                    p.SetValue(t, imageUrl);
                }
                else if (p.PropertyType == typeof(ImageUrlsInText))
                {
                    var imageUrl = (ImageUrlsInText)p.GetValue(t);
                    string pattern = "(?<=<img[^>]+src=\")[^\">]+(?=\")";
                    var matches = Regex.Matches(imageUrl.OriginaText, pattern);
                    var textWithLocalizedImageUrl = imageUrl.OriginaText;
                    //特殊判断:  对象自己定义的根路径 优先.
                    //原因: zbtanews 的 标题图片的根路径 不带 ziboback/ 这一节, 但是内容里面的图片地址带.
                    string imageBaseUrl = string.IsNullOrEmpty(imageUrl.ImageBaseUrl) ? originImageRootUrl : imageUrl.ImageBaseUrl;
                    foreach (Match m in matches)
                    {
                        var localizedImage = imageLocalizer.Localize(imageBaseUrl + m.Value, localSavedPath, imageClientPath);
                        textWithLocalizedImageUrl = textWithLocalizedImageUrl.Replace(m.Value, localizedImage);
                    }
                    imageUrl.UpdateImageLocalizedText(textWithLocalizedImageUrl);
                    p.SetValue(t, imageUrl);

                }
                else if (p.PropertyType.IsAssignableFrom(typeof(IList<ImageUrl>)))
                {
                    var arrayP = (IList<ImageUrl>)p.GetValue(t);
                    var imageUrls = new List<ImageUrl>();
                    foreach (var itemP in arrayP)
                    {
                        var imageUrl = itemP;
                        imageUrl.UpdateLocalizedUrl(imageLocalizer.Localize(originImageRootUrl + imageUrl.OriginalUrl, localSavedPath, imageClientPath));
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
