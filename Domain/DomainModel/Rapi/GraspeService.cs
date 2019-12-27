using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using TourInfo.Domain.Base;
using System.Linq;
using System.Net;
using System.Threading;
//using FastMember;
using System.Collections;
using System;

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
        IInfoLocalizer<Pubmediainfo> infoLocalizerPubMediaInfo;
        IInfoLocalizer<Typeinfo> infoLocalizerTypeinfo;
        IInfoLocalizer<Pubinfounit> infoLocalizerPubinfounit;
        IInfoLocalizer<Pubinfounitchild> infoLocalizerPubinfounitchild;
        
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
        public RapiGraspeService(string localSavedPath,
            IImageLocalizer imageLocalizer, ITokenManager tokenManager,
            string initUrl, string syncUrl,  IUrlFetcher urlFetcher,
            IRepository<Projectinfo, int> repositoryProjectInfo,
            IRepository<Typeinfo, int> repositoryTypeinfo, 
            IRepository<Typefield, int> repositoryTypefield,
            IRepository<Typetag, int> repositoryTypetag,
            IRepository<Typepic, int> repositoryTypepic,
            IRepository<Pubinfounit, int> repositoryPubinfounit,
            IRepository<Pubunittag, int> repositoryPubunittag,
            IRepository<Pubmediainfo, int> repositoryPubmediainfo, 
            IRepository<Pubinfounitchild, int> repositoryPubinfounitchild,
        IInfoLocalizer<Pubmediainfo> infoLocalizerPubMediaInfo,
        IInfoLocalizer<Typeinfo> infoLocalizerTypeinfo,
        IInfoLocalizer<Pubinfounit> infoLocalizerPubinfounit,
        IInfoLocalizer<Pubinfounitchild> infoLocalizerPubinfounitchild 
            
            )
        {
             
            this.infoLocalizerPubinfounit=infoLocalizerPubinfounit;
            this.infoLocalizerPubinfounitchild= infoLocalizerPubinfounitchild;
            this.infoLocalizerPubMediaInfo=infoLocalizerPubMediaInfo;
            this.infoLocalizerTypeinfo=infoLocalizerTypeinfo;
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

            JsonSerializerSettings settings=new JsonSerializerSettings();
 
            var responseModel = JsonConvert.DeserializeObject<RapiResponse>(result,new ImageUrlJsonConverter());
            if(responseModel.data.projectinfo!=null)
            { 
                
            repositoryProjectInfo.Insert(responseModel.data.projectinfo);
            repositoryProjectInfo.SaveChanges();
            }
            foreach (var item in responseModel.data.pubmediainfoes)
            {
                
                var c=new C<Pubmediainfo,int>(repositoryPubmediainfo,infoLocalizerPubMediaInfo,item,dataVersion,localSavedPath);
                 int workerThreads,     completionPortThreads;
                 ThreadPool.GetMaxThreads(out workerThreads,out completionPortThreads);

                Console.WriteLine($"pubmediainfoes:workerThreads:{workerThreads},completionPortThreads{completionPortThreads}");
                ThreadPool.QueueUserWorkItem((object stateinfo)=>{
                infoLocalizerPubMediaInfo.Localize(item, localSavedPath);
                 
                    item.Version = dataVersion;
                    // alltypeinfoes.Add(item);
                    repositoryPubmediainfo.Insert(item);

                });
                

               
                
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
       
        private void M(Object stateInfo)
        { }
      

         
        
    }
    public class C<T, Key>  where T : VersionedEntity
    {
          IRepository<T, Key> repository;
        IInfoLocalizer<T> infoLocalizer;
        T item; string dataVersion; string localSavedPath;

        
        public C(IRepository<T, Key> repository, IInfoLocalizer<T> infoLocalizer, T item, string dataVersion, string localSavedPath)
        {
            this.repository = repository;
            this.infoLocalizer = infoLocalizer;
            this.item = item;
            this.dataVersion = dataVersion;
            this.localSavedPath = localSavedPath;
        }

        public void M()
        {
            item.Version = dataVersion;
            infoLocalizer.Localize(item, localSavedPath);
            repository.Insert(item);
        }
    }

}
