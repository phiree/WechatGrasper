using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using TourInfo.Domain.Base;
using System.Linq;
using System.Net;
using System.Threading;
//using FastMember;
using System.Collections;

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

            foreach (var item in responseModel.data.pubmediainfoes)
            { 
                //string localImage = imageLocalizer.Localize(item.mediaurl, localSavedPath);
                //item.mediaurl = localImage;
                //item.Version = dataVersion;
                //// allPubmediainfos.Add(mediainfo);
                //repositoryPubmediainfo.Insert(item);
            }

            //var allPubmediainfos=new List<Pubmediainfo>();
            new  System.Threading.Thread(()=>{
               foreach (var item in responseModel.data.pubmediainfoes)
               {

                   //string localImage = imageLocalizer.Localize(item.mediaurl, localSavedPath);
                   //item.mediaurl = localImage;
                   //item.Version = dataVersion;
                   //// allPubmediainfos.Add(mediainfo);
                   //repositoryPubmediainfo.Insert(item);
               }
           }).Start();

            new System.Threading.Thread(() => {
                foreach (var item in responseModel.data.typeinfoes)
                {
                    string localImage = imageLocalizer.Localize(item.wapshowimg, localSavedPath);
                    item.wapshowimg = localImage;
                    item.Version = dataVersion;
                    // alltypeinfoes.Add(item);
                    repositoryTypeinfo.Insert(item);
                }
            }).Start();
            var alltypeinfoes = new List<Typeinfo>();
           
            new System.Threading.Thread(() => {
                foreach (var item in responseModel.data.pubinfounits)
                {
                    string localImage = imageLocalizer.Localize(item.flagpic, localSavedPath);
                    item.flagpic = localImage;
                    item.Version = dataVersion;
                    //     allPubinfounit.Add(item);
                    repositoryPubinfounit.Insert(item);
                }
            }).Start();

            new System.Threading.Thread(() => {
                foreach (var item in responseModel.data.pubinfounitchilds)
                {
                    string localImage = imageLocalizer.Localize(item.flagurl, localSavedPath);
                    item.flagurl = localImage;
                    item.Version = dataVersion;
                    //     allPubinfounit.Add(item);
                    repositoryPubinfounitchild.Insert(item);
                }
            }).Start();
            //     var allPubinfounit = new List<Pubinfounit>();

            //   repositoryPubmediainfo.BulkInsert(allPubmediainfos.Select(x => { x.Version = dataVersion; return x; }).ToList());
            //    repositoryPubinfounit.BulkInsert(allPubinfounit.Select(x=>{x.Version=dataVersion;return x;}).ToList());
           // repositoryPubinfounitchild.BulkInsert(responseModel.data.pubinfounitchilds.Select(x => { x.Version = dataVersion; return x; }).ToList());
            repositoryPubunittag.BulkInsert(responseModel.data.pubunittags.Select(x => { x.Version = dataVersion; return x; }).ToList());
            repositoryTypefield.BulkInsert(responseModel.data.typefields.Select(x => { x.Version = dataVersion; return x; }).ToList());
            repositoryTypepic.BulkInsert( responseModel.data.typepics.Select(x => { x.Version = dataVersion; return x; }).ToList());
         //   repositoryTypeinfo.BulkInsert(alltypeinfoes.Select(x => { x.Version = dataVersion; return x; }).ToList());
            repositoryTypetag.BulkInsert(responseModel.data.typetags.Select(x => { x.Version = dataVersion; return x; }).ToList());


        }

         
        
    }
    public class InfoLocalizer<T>
    {
        IImageLocalizer imageLocalizer;

        public InfoLocalizer(IImageLocalizer imageLocalizer)
        {
            this.imageLocalizer = imageLocalizer;
        }

        public void Localizer(T t,string localSavedPath)
        {
            var members = t.GetType().GetMembers();
            foreach (var p in t.GetType().GetProperties())
            {
                if (p.PropertyType != typeof(ImageUrl)) { continue; }
                
                var imageUrl = (ImageUrl)p.GetValue(t);
               string localizedImage= imageLocalizer.Localize(imageUrl.OriginalUrl, localSavedPath);
                p.SetValue(t, new ImageUrl(imageUrl.OriginalUrl, localizedImage));
            }
        }
    }
}
