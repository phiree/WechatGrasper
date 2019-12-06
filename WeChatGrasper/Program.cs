using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Linq;
namespace WeChatGrasper
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            new EWQY().Graspe();
        }
    }
    public class EWQY
    {
        Random rm = new Random();
        readonly List<string> apiUrls = new List<string> { "venue/findVenueList.action", "company/findCompanyList.action", "activity/findRegionActivityList.action" };
        readonly IList<string> areaCode = new List<string> { "370300" };

        public EWQY()
        {
            urlCreator = new UrlCreator();
            urlFetcher = new UrlFetcher();
            contentHandler = new ContentHandler();
            contentHandler.FileSaveHandler += ContentHandler_FileSaveHandler;
            contentHandler.DatabaseSaveHandler += ContentHandler_DatabaseSaveHandler;
            contentHandler.ImageHandler += ContentHandler_ImageHandler;
            contentHandler.ParserHandler += ContentHandler_ParserHandler;
        }
        IUrlCreator urlCreator;
        IUrlFetcher urlFetcher;
        IContentHandler contentHandler;
        ProgressRepository progressRepository = new ProgressRepository();
        public void Graspe()
        {
            var progressList = progressRepository.Get();
            foreach (var apiUrl in apiUrls)
            {
                int startPageIndex = 0;
                var existedProgress = progressList.FirstOrDefault(x => x.PagedBaseUrl == apiUrl);
                if (existedProgress != null)
                { startPageIndex = existedProgress.PageIndex; }
                if (apiUrl == "activity/findRegionActivityList.action")
                {
                    GraspePagedList<Activity>(apiUrl, startPageIndex, 5);
                }
                else
                {
                    GraspePagedList<CompanyVenue>(apiUrl, startPageIndex, 5);
                }
            }
        }

        public void GraspePagedList<T>(string baseUrl, int pageIndex, int pageSize) where T : Entity
        {

            var pagedUrl = urlCreator.CreatePagedUrl(baseUrl, pageIndex, pageSize);

            string result = urlFetcher.FetchAsync(pagedUrl).Result;


            contentHandler.HandlerList(result);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject<ListResultWrapper<T>>(result);
            var status = jsonResult.status;// jsonResult["status"];
            if (status != 0)
            { throw new Exception("接口返回错误"); }
            var listData = jsonResult.data;

            foreach (var data in listData)
            {
                System.Threading.Thread.Sleep(500 + rm.Next(1, 100));
                string detailUrl = urlCreator.CreateDetailUrl(baseUrl, data.id);
                string detailResult = urlFetcher.FetchAsync(detailUrl).Result;
                var detail=JsonConvert.DeserializeObject<DetailResultWrapper<T>>(detailResult);
                CopyValues<T>(detail.data,data);
                contentHandler.HandlerDetail(data.id, detail);
            }
            //保存当前状态
            progressRepository.Save(new Progress { PagedBaseUrl = baseUrl, PageIndex = pageIndex });
            if (listData.Count == pageSize)
            {
                GraspePagedList<T>(baseUrl, pageIndex + 1, pageSize);
            }




        }
        public void CopyValues<T>(T target, T source)
        {
            Type t = typeof(T);

            var properties = t.GetProperties().Where(prop => prop.CanRead && prop.CanWrite);

            foreach (var prop in properties)
            {
                var value = prop.GetValue(source, null);
                if (value != null)
                    prop.SetValue(target, value, null);
            }
        }

        private void ContentHandler_ParserHandler(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ContentHandler_ImageHandler(object sender, EventArgs e)
        {
            Console.WriteLine("Image:" + ((ContentHandlerEventArgs)e).Result);
        }

        private void ContentHandler_DatabaseSaveHandler(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ContentHandler_FileSaveHandler(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
    public class InitializeData
    {

    }
    public interface Initializer
    {

    }
    /// <summary>
    /// 初始化URL
    /// </summary>
    public interface IUrlCreator
    {
        string CreatePagedUrl(string pagedBaseUrl, int pageIndex, int pageSize);
        string CreateDetailUrl(string pagedBaseUrl, string detailId);


    }
    public class UrlCreator : IUrlCreator
    {
        readonly string baseUrl = "https://w.culturedata.com.cn/";
        /// <summary>
        /// 
        /// </summary>
        readonly IDictionary<string, string> PagedDetailUrlMap = new Dictionary<string, string> {
            {"venue/findVenueList.action","venue/findVenueDetail.action" },
            {"company/findCompanyList.action","company/findCompanyDetail.action" },
            {"activity/findActivityDetail.action","activity/findRegionActivityList.action" }};
        public IList<string> CreateSeeds()
        {
            return new List<string> { "https://w.culturedata.com.cn/activity/findRegionActivityList.action?type=0&gotCount=0&number=5&regionCode=370300" };
        }
        public string CreatePagedUrl(string pagedBaseUrl, int pageIndex, int pageSize)
        {

            return $"{baseUrl}{pagedBaseUrl}?type=0&gotCount={pageIndex}&number={pageSize}&regionCode=370300";
        }
        public string CreateDetailUrl(string pagedBaseUrl, string detailId)
        {

            return $"{baseUrl}{PagedDetailUrlMap[pagedBaseUrl]}?id={detailId}";
        }
    }

    /// <summary>
    ///Url抓取 
    /// </summary>
    public interface IUrlFetcher
    {
        Task<string> FetchAsync(string url);
    }
    public class UrlFetcher : IUrlFetcher
    {

        public async Task<string> FetchAsync(string url)
        {
            var webClient = new CookieAwareWebClient();
            var cookiesContainer = new CookieContainer();
            cookiesContainer.Add(new Cookie("JSESSIONID", "2AF06A3225C7E4D578C6C2749C79FAF8", "/", "w.culturedata.com.cn"));
            cookiesContainer.Add(new Cookie("showTip", "true", "/", "w.culturedata.com.cn"));
            webClient.CookieContainer = cookiesContainer;
            var result = await webClient.DownloadStringTaskAsync(new Uri(url));

            return result;


        }
    }

    /// <summary>
    /// 内容处理
    ///   解析数据
    ///   分析是否有图片
    ///   构建其他url
    /// 
    /// </summary>
    public interface IContentHandler
    {
        event EventHandler ParserHandler;
        event EventHandler ImageHandler;
        event EventHandler DatabaseSaveHandler;
        event EventHandler FileSaveHandler;
        void HandlerList(string listResult);
        void HandlerDetail<T>(string id,T detailResult);

    }
    public class ContentHandler : IContentHandler
    {
        public event EventHandler ParserHandler;
        public event EventHandler ImageHandler;
        public event EventHandler DatabaseSaveHandler;
        public event EventHandler FileSaveHandler;

        public void HandlerList(string listResult)
        {
            ImageHandler?.Invoke(this, new ContentHandlerEventArgs { Result = listResult.Substring(0, 105) });
        }
        public void HandlerDetail<T>(string id, T detailResult)
        {
            ImageHandler?.Invoke(this, new ContentHandlerEventArgs { Result = detailResult.GetType().ToString() });
        }
    }
    public class ContentHandlerEventArgs : EventArgs
    {
        public string Result { get; set; }
    }

    public class ProgressRepository
    {
        readonly string progressFileName = Environment.CurrentDirectory + "\\Progress.txt";
        private IList<Progress> InitProgress = new List<Progress>();
        public ProgressRepository()
        {

            if (!File.Exists(progressFileName))
            {
                using (File.Create(progressFileName)) { }
            }
            InitProgress = Get();
        }

        public IList<Progress> Get()
        {
            var progressList = new List<Progress>();
            string[] progreses = File.ReadAllLines(progressFileName);
            foreach (string progress in progreses)
            {
                string[] s = progress.Split(" ");
                if (s.Length != 2)
                {
                    continue;
                }
                int pageIndex;
                if (!int.TryParse(s[1], out pageIndex)) { continue; }
                progressList.Add(new Progress { PagedBaseUrl = s[0], PageIndex = pageIndex });
            }
            return progressList;

        }
        public void Save(Progress progress)
        {
            var existed = InitProgress.FirstOrDefault(x => x.PagedBaseUrl == progress.PagedBaseUrl);
            if (existed != null)
            {
                InitProgress.Remove(existed);
            }
            InitProgress.Add(progress);
            File.WriteAllLines(progressFileName, InitProgress.Select(x => x.PagedBaseUrl + " " + x.PageIndex).ToArray());

        }
    }
    //Progress
    public class Progress
    {
        public string PagedBaseUrl { get; set; }
        public int PageIndex { get; set; }


    }
    public class IsComment
    {
        public int status { get; set; }
        public string msg { get; set; }
    }

    //文化企业/场馆列表项

    public class CompanyVenue : Entity
    {

        public double distance { get; set; }
        public string thumbnailKey { get; set; }
        /// <summary>
        /// 企业独有属性.
        /// </summary>
        public List<double> location { get; set; }
        public string name { get; set; }
        public string satisfactionScore { get; set; }
        public string typeId { get; set; }
        public string introduction { get; set; }
        public IsComment isComment { get; set; }
        public List<string> pictureKeys { get; set; }
        public string address { get; set; }
        public bool isFavorite { get; set; }

        #region 场馆独有属性
        public string serviceTimeStart { get; set; }

        public string serviceNote { get; set; }
        public string serviceTimeEnd { get; set; }
        #endregion

        public string telNumber { get; set; }
        public PlaceType PlaceType { get; set; }

    }

    public class Entity
    {
        public string id { get; set; }
    }

    public enum PlaceType
    {
        Venue,//文化场馆
        Company//文化企业
    }
    /// <summary>
    /// 活动列表项
    /// </summary>
    public class Activity : Entity
    {

        public string startTime { get; set; }
        public string createTime { get; set; }
        public string thumbnailKey { get; set; }
        public string address { get; set; }
        public string name { get; set; }
        public string endTime { get; set; }

        public string detail { get; set; }
        public List<string> pictureKeys { get; set; }

        public int credits { get; set; }
        public bool isShared { get; set; }

    }
    /// <summary>
    /// 数据版本
    /// </summary>
    public interface VersionedData
    {
        string VersionNumber { get; set; }
    }
    public class ResultWrapper
    {
        public int status { get; set; }
        public string msg { get; set; }
    }
    public class ListResultWrapper<T> : ResultWrapper
    {
        public IList<T> data { get; set; }
    }
    public class DetailResultWrapper<T> : ResultWrapper
    {
        public T data { get; set; }
    }

}

