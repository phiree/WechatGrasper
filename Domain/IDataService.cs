namespace TourInfo.Domain.DomainModel
{
    public interface IDataService
    {
        void CreateInitData();
        dynamic CreateSyncData(string version);
       
    }
}