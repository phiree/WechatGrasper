using System.Collections.Generic;
using TourInfo.Domain.Base;

namespace TourInfo.Domain
{
    public interface IInfoLocalizer<T,Key>
    {
        void Localize(T t, string imageBaseUrl,  string version,out bool isExisted);
        

    }
}