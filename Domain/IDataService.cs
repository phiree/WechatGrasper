namespace TourInfo.Domain.DomainModel
{
    public interface IDataService
    {
        void CreateInitData(string version);
        dynamic CreateSyncData(string version);
          dynamic CreateSyncDataForTest();
    }
}