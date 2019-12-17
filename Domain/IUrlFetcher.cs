using System.Net;
using System.Threading.Tasks;

namespace TourInfo.Domain
{
    /// <summary>
    ///Url抓取 
    /// </summary>
    public interface IUrlFetcher
    {
        Task<string> FetchAsync(string url);
        Task<string> FetchEWQYAsync(string url );
    }

}

