namespace WeChatGrasper
{
    /// <summary>
    /// 初始化URL
    /// </summary>
    public interface IUrlCreator
    {
        string CreatePagedUrl(string pagedBaseUrl, int pageIndex, int pageSize, int? type = null, int? order = null);
        string CreateDetailUrl(string pagedBaseUrl, string detailId);


    }

}

