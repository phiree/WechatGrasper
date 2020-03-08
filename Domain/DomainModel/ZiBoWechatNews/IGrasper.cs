namespace TourInfo.Domain.DomainModel.ZiBoWechatNews
{
    public interface IGrasper
    {
        void GraspeWithPage(int pageIndex, string dataVersion);
    }
}