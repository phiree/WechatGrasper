using System.Threading.Tasks;

namespace WeChatGrasper
{
    /// <summary>
    ///Url抓取 
    /// </summary>
    public interface IUrlFetcher
    {
        Task<string> FetchAsync(string url);
    }

}

