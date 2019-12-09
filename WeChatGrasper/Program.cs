using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Text;
using Domain;

namespace WeChatGrasper
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            StringBuilder ss=new StringBuilder();
            ss.Append("a");
            Console.WriteLine(ss.ToString().GetHashCode());
             
            Console.WriteLine(ss.ToString().GetHashCode());
            //
         new EWQY().Graspe();
        }
    }
    public class EWQY
    {
        Random rm = new Random();
        readonly List<string> apiUrls = new List<string> { "venue/findVenueList.action", "company/findCompanyList.action", "activity/findRegionActivityList.action" };
        readonly IList<string> areaCode = new List<string> { "370300" };
        DataAccess.IRepository repository=new DataAccess.DapperRepository();
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

       static readonly string _dateVersion=DateTime.Now.ToString("yyyyMMddhhmmss");
        
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
                    GraspePagedList<Activity>(apiUrl, startPageIndex, 5, type: 0);
                    GraspePagedList<Activity>(apiUrl, startPageIndex, 5, type: 1);
                }
                else
                {
                    GraspePagedList<CompanyVenue>(apiUrl, startPageIndex, 5, order: 0);

                }
            }
        }

        public void GraspePagedList<T>(string basePageUrl
            , int pageIndex, int pageSize
            , int? type = null, int? order = null)
            where T : Entity
        {

            var pagedUrl = urlCreator.CreatePagedUrl(basePageUrl, pageIndex, pageSize);

            string result = urlFetcher.FetchAsync(pagedUrl).Result;
          //  contentHandler.HandlerList(result);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject<ListResultWrapper<T>>(result);
            var status = jsonResult.status;// jsonResult["status"];
            if (status != 0)
            { throw new Exception("接口返回错误"); }
            var listData = jsonResult.data;
            foreach (var data in listData)
            {
                System.Threading.Thread.Sleep(500 + rm.Next(1, 100));
                string detailUrl = urlCreator.CreateDetailUrl(basePageUrl, data.id);
                string detailResult = urlFetcher.FetchAsync(detailUrl).Result;
                var detail = JsonConvert.DeserializeObject<DetailResultWrapper<T>>(detailResult);
                CopyValues<T>(detail.data, data);
                if (typeof(T) == typeof(CompanyVenue))
                { 
                    if (basePageUrl == "venue/findVenueList.action")
                        { detail.data.PlaceType= PlaceType.Venue; } 
                    else if(basePageUrl== "company/findCompanyList.action")
                    { 
                        detail.data.PlaceType= PlaceType.Company;
                        }
                    //活动
                    else if(type.HasValue)
                    { 
                        if(type.Value==1)
                        { 
                            detail.data.PlaceType= PlaceType.Company;
                            }
                        else {
                            detail.data.PlaceType = PlaceType.Venue;
                        }
                        }
                    }
                repository.Save(detail.data,_dateVersion);
              //  contentHandler.HandlerDetail(data.id, detail);
            }
            //保存当前状态
            progressRepository.Save(new Progress { PagedBaseUrl = basePageUrl, PageIndex = pageIndex });
            if (listData.Count == pageSize)
            {
                GraspePagedList<T>(basePageUrl, pageIndex + 1, pageSize);
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

}

