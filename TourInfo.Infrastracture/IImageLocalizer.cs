namespace TourInfo.Infrastracture
{
    public interface IImageLocalizer<T>
    {
          void Localize(T t, string localSavedPath);
    }
}