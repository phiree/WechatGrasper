using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
namespace TourInfo.Domain.DomainModel.ZBTA
{
    public class DetailImageLocalizer : IDetailImageLocalizer
    {
        IImageLocalizer imageLocalizer;
        string detailImageBaseUrl, localSavedPath,imageClientPath;
        public DetailImageLocalizer(IImageLocalizer imageLocalizer,string detailImageBaseUrl,string localSavedPath,string imageClientPath)
        {
            this.imageLocalizer = imageLocalizer;
            this.detailImageBaseUrl = detailImageBaseUrl;
            this.localSavedPath = localSavedPath;
            this.imageClientPath = imageClientPath;
        }
        public string Localize(string zbtaNewsDetail,string version)
        {
            string pattern = "(?<=<img[^>]+src=\")[^\">]+(?=\")";


            var matches = Regex.Matches(zbtaNewsDetail, pattern);
            string replacedDetail = zbtaNewsDetail;
            for (int i = 0; i < matches.Count; i++)
            {
                var m = matches[i];
                string localImage = imageLocalizer.Localize( detailImageBaseUrl + m.Value, localSavedPath,imageClientPath);
                replacedDetail = replacedDetail.Replace(m.Value, localImage);

            }
            return replacedDetail;

        }
    }
}
