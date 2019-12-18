namespace TourInfo.Domain.EWQY
{
    public interface IEWQYApplication
    {
        void CopyValues<T>(T target, T source);
        void Graspe(string _dateVersion);
        void GraspePagedList<T>(string basePageUrl, int pageIndex, int pageSize, PlaceType? type = null, int? order = null) where T : EWQYEntity;
    }
}