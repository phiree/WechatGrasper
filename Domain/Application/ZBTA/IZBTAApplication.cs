﻿namespace TourInfo.Domain.TourNews
{
    public interface IZBTAApplication
    {
        void Graspe(string _dateVersion);
          string GetNewsDetail(string newsId);
    }
}