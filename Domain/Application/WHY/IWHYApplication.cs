﻿namespace TourInfo.Domain.Application.WHY
{
    public interface IWHYApplication
    {
        void Grasp(string dataVersion);
          void GraspNews(string version);
          void GraspActivity(string version);

    }
}