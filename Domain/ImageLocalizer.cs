using System;
using System.Collections.Generic;
using System.Text;

namespace TourInfo.Domain
{
    public interface IImageLocalizer
    {
        string Localize(string picUrl);
    }
}
