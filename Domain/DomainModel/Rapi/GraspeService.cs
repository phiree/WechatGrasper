using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using TourInfo.Domain.Base;
using System.Linq;
using System.Net;

namespace TourInfo.Domain.DomainModel.Rapi
{
    /// <summary>
    /// 抓取数据
    /// </summary>
    public interface IRapiGraspeService
    {
        void Graspe(string dataVersion);
    }
    public class RapiGraspeService : IRapiGraspeService
    {
        ITokenManager tokenManager;
        string initUrl = "";
        string syncUrl = "";
        IImageLocalizer imageLocalizer;
      
        IUrlFetcher urlFetcher;
        IRepository<Projectinfo,int> repositoryProjectInfo;
        IRepository<Typeinfo, int> repositoryTypeinfo;
        IRepository<Typefield, int> repositoryTypefield;
        IRepository<Typetag, int> repositoryTypetag;
        IRepository<Typepic, int> repositoryTypepic;
        IRepository<Pubinfounit, int> repositoryPubinfounit;
        IRepository<Pubunittag, int> repositoryPubunittag;
        IRepository<Pubmediainfo, int> repositoryPubmediainfo;
        IRepository<Pubinfounitchild, int> repositoryPubinfounitchild;
        string localSavedPath;
        public RapiGraspeService(string localSavedPath, IImageLocalizer imageLocalizer, ITokenManager tokenManager, string initUrl, string syncUrl,  IUrlFetcher urlFetcher, IRepository<Projectinfo, int> repositoryProjectInfo, IRepository<Typeinfo, int> repositoryTypeinfo, IRepository<Typefield, int> repositoryTypefield, IRepository<Typetag, int> repositoryTypetag, IRepository<Typepic, int> repositoryTypepic, IRepository<Pubinfounit, int> repositoryPubinfounit, IRepository<Pubunittag, int> repositoryPubunittag, IRepository<Pubmediainfo, int> repositoryPubmediainfo, IRepository<Pubinfounitchild, int> repositoryPubinfounitchild)
        {
            this.localSavedPath = localSavedPath;
            this.imageLocalizer=imageLocalizer;
            this.initUrl = initUrl;
            this.syncUrl = syncUrl;
            this.tokenManager = tokenManager;
            this.urlFetcher = urlFetcher;
            this.repositoryProjectInfo = repositoryProjectInfo;
            this.repositoryTypeinfo = repositoryTypeinfo;
            this.repositoryTypefield = repositoryTypefield;
            this.repositoryTypetag = repositoryTypetag;
            this.repositoryTypepic = repositoryTypepic;
            this.repositoryPubinfounit = repositoryPubinfounit;
            this.repositoryPubunittag = repositoryPubunittag;
            this.repositoryPubmediainfo = repositoryPubmediainfo;
            this.repositoryPubinfounitchild = repositoryPubinfounitchild;
        }

        public void Graspe(string dataVersion)
        {
            string token = tokenManager.GetToken();
            
            //if database is empty, init, else  sync
            string targetUrl = syncUrl;
            var existedData = repositoryProjectInfo.GetAll();
            if (!existedData.Any()) {
                targetUrl = initUrl;
            }
            string result = urlFetcher.FetchWithHeaderAsync(targetUrl
                ,new Dictionary<string, string> { { HttpRequestHeader.Authorization.ToString(),token } } ).Result;
            var responseModel = JsonConvert.DeserializeObject<RapiResponse>(result);
            if(responseModel.data.projectinfo!=null)
            { 
                
            repositoryProjectInfo.Insert(responseModel.data.projectinfo);
            repositoryProjectInfo.SaveChanges();
            }

            var allPubmediainfos=new List<Pubmediainfo>();
            foreach(var mediainfo in responseModel.data.pubmediainfoes)
            { 
                 string localImage= imageLocalizer.Localize(mediainfo.mediaurl, localSavedPath);
                mediainfo.mediaurl=localImage;
                allPubmediainfos.Add(mediainfo);
                }

            var alltypeinfoes = new List<Typeinfo>();
            foreach (var item in responseModel.data.typeinfoes)
            {
                string localImage = imageLocalizer.Localize(item.wapshowimg, localSavedPath);
                item.wapshowimg = localImage;
                alltypeinfoes.Add(item);
            }

            var allPubinfounit = new List<Pubinfounit>();
            foreach (var item in responseModel.data.pubinfounits)
            {
                string localImage = imageLocalizer.Localize(item.flagpic, localSavedPath);
                item.flagpic = localImage;
                allPubinfounit.Add(item);
            }
            repositoryPubmediainfo.BulkInsert(allPubmediainfos.Select(x => { x.Version = dataVersion; return x; }).ToList());
            repositoryPubinfounit.BulkInsert(allPubinfounit.Select(x=>{x.Version=dataVersion;return x;}).ToList());
            repositoryPubinfounitchild.BulkInsert(responseModel.data.pubinfounitchilds.Select(x => { x.Version = dataVersion; return x; }).ToList());
            repositoryPubunittag.BulkInsert(responseModel.data.pubunittags.Select(x => { x.Version = dataVersion; return x; }).ToList());
            repositoryTypefield.BulkInsert(responseModel.data.typefields.Select(x => { x.Version = dataVersion; return x; }).ToList());
            repositoryTypepic.BulkInsert( responseModel.data.typepics.Select(x => { x.Version = dataVersion; return x; }).ToList());
            repositoryTypeinfo.BulkInsert(alltypeinfoes.Select(x => { x.Version = dataVersion; return x; }).ToList());
            repositoryTypetag.BulkInsert(responseModel.data.typetags.Select(x => { x.Version = dataVersion; return x; }).ToList());


        }

        
    }
}
