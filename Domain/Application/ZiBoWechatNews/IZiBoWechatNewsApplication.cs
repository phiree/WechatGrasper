using System;
using System.Collections.Generic;
using System.Text;
using TourInfo.Domain.DomainModel.ZiBoWechatNews;

namespace TourInfo.Domain.Application.ZiBoWechatNews
{
    public class ZiBoWechatNewsApplication : IZiBoWechatNewsApplication
    {
        IGrasper grasper;
        public ZiBoWechatNewsApplication(IGrasper grasper)
        { 
            this.grasper=grasper;
            }
        public void Graspe(string dataVersion)
        {
            grasper.GraspeWithPage(1,dataVersion);
        }
    }
}
