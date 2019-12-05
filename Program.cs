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
        Random rm=new Random();
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

                GraspePagedList(apiUrl, startPageIndex, 5);
            }
        }

        public void GraspePagedList(string baseUrl, int pageIndex, int pageSize)
        {

            var pagedUrl = urlCreator.CreatePagedUrl(baseUrl, pageIndex, pageSize);

            string result = urlFetcher.FetchAsync(pagedUrl).Result;


            contentHandler.HandlerList(result);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject<Newtonsoft.Json.Linq.JObject>(result);
            var status = (int)jsonResult["status"];
            if (status != 0)
            { throw new Exception("接口返回错误"); }
            var listData = (JArray)jsonResult["data"];

            foreach (var data in listData)
            {
                System.Threading.Thread.Sleep(500+rm.Next(1,100));
                string detailUrl = urlCreator.CreateDetailUrl(baseUrl, data["id"].ToString());
                string detailResult = urlFetcher.FetchAsync(detailUrl).Result;
                contentHandler.HandlerDetail(detailResult);
            }
            //保存当前状态
            progressRepository.Save(new Progress { PagedBaseUrl = baseUrl, PageIndex = pageIndex });
            if (listData.Count == pageSize)
            {
                GraspePagedList(baseUrl, pageIndex + 1, pageSize);
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
        void HandlerDetail(string detailResult);

    }
    public class ContentHandler : IContentHandler
    {
        public event EventHandler ParserHandler;
        public event EventHandler ImageHandler;
        public event EventHandler DatabaseSaveHandler;
        public event EventHandler FileSaveHandler;

        public void HandlerList(string listResult)
        {
            OnImagesFound(new ContentHandlerEventArgs { Result = listResult.Substring(0, 105) });
        }
        public void HandlerDetail(string detailResult)
        {
            ImageHandler?.Invoke(this, new ContentHandlerEventArgs { Result = detailResult.Substring(0, 105) });
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
    //文化场馆, 文化企业
    public class CompanySummary {
       
        public string id{ get;set;}
        public float distance { get; set; }
        public int commentcount { get; set; }
        public string thumbnailKey { get; set; }
        public string name { get; set; }
        public string introduction { get; set; }
        public PlaceType PlaceType { get; set; }
    }
    /*
     文化企业列表里的企业
     {
            "id": "8eefefcdb1e04c99878ea32f9e27ca10",
            "distance": 12502060.927735005,
            "thumbnailKey": "/image/download/5b505c24cf114bac8ce45a0379a1460c.sjpg",
            "location": [
                118.30253601074219,
                36.81298828125
            ],
            "name": "淄博稷下图书音像有限公司",
            "satisfactionScore": "0.0",
            "typeId": "0f7df083ef084c39ab0147bab9b2bd64",
            "introduction": "书店主要业务涉及资格证考试辅导书，公务员考试资料，专升本辅导资料，中小学高中教辅资料，幼儿绘本，小说杂志等。"
        },
        详情的返回:
        {
        "isComment": {
            "status": false,
            "msg": "没有消费，不能评论"
        },
        "pictureKeys": [
            "/image/download/5b505c24cf114bac8ce45a0379a1460c.sjpg",
            "/image/download/23d4043911574aaf9e3b897c516544a6.sjpg"
        ],
        "address": "山东省淄博市临淄区桓公路220号大顺集团地下室",
        "isFavorite": false,
        "name": "淄博稷下图书音像有限公司",
        "satisfactionScore": "0",
        "introduction": "书店主要业务涉及资格证考试辅导书，公务员考试资料，专升本辅导资料，中小学高中教辅资料，幼儿绘本，小说杂志等。",
        "telNumber": "18653383322"
    }
         */
    public enum PlaceType
    { 
        Venue,//文化场馆
        Company//文化企业
        }

    public class CompanyDetail { }

}

