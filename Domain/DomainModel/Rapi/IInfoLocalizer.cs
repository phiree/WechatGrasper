using System.Collections.Generic;

namespace TourInfo.Domain.DomainModel.Rapi
{
    public interface IInfoLocalizer<T,Key>
    {
        void Localize(T t, string imageBaseUrl, string localSavedPath,string imageClientPath,string version,out bool isExisted);
        


    }
}