using System.Collections.Generic;
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
        Task FetchFile(string url, string fileName);
        string PostWithJsonAsync(string url, string postJson);
           Task<string> FetchWithHeaderAsync(string url, IDictionary<string, string> header);


    }

}

