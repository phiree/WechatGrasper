namespace TourInfo.Domain.DomainModel.WHY
{
    public interface IRapiSync
    {
        int AddOrUpdate(RapiRequestModel request);
        void Delete(int unitId);
    }
}