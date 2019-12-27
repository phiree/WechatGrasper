using TourInfo.Domain.Base;

namespace TourInfo.Domain.DomainModel.Rapi
{
    public interface IC<T> where T : VersionedEntity
    {
        void M(T item, string dataVersion, string localSavedPath);
    }
}