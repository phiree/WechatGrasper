using System.Collections.Generic;

namespace TourInfo.Domain.DomainModel.Rapi
{
    public interface IInfoLocalizer<T>
    {
        void Localize(T t, string localSavedPath);
        


    }
}