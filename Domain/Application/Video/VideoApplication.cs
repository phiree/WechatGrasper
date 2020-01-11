using System;
using System.Collections.Generic;
using System.Text;
using TourInfo.Domain.DomainModel.Video;

namespace TourInfo.Domain.Application.Video
{
    public class VideoApplication : IVideoApplication
    {
        DomainModel.Video.IGraspeService graspeService;

        public VideoApplication(IGraspeService graspeService)
        {
            this.graspeService = graspeService;
        }

        public void Graspe(string version)
        {
            graspeService.Graspe(version);
        }
    }
}
