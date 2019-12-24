namespace TourInfo.Domain.DomainModel.ZBTA
{
    public interface IDetailImageLocalizer
    {
        /// <summary>
        /// 本地化详情内的图片
        /// </summary>
        /// <param name="zbtaNewsDetail">接口返回的详情</param>
        /// <param name="zbtaNewsReplacedDetail">被替换过图片后的详情，用于删除被更新的图片</param>
        /// <returns></returns>
        string Localize(string zbtaNewsDetail,string zbtaNewsReplacedDetail);
    }
}