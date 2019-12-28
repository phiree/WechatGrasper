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
        IInfoLocalizer<Pubmediainfo,int> infoLocalizerPubMediaInfo;
        IInfoLocalizer<Typeinfo, int> infoLocalizerTypeinfo;
        IInfoLocalizer<Pubinfounit, int> infoLocalizerPubinfounit;
        IInfoLocalizer<Pubinfounitchild, int> infoLocalizerPubinfounitchild;

        IUrlFetcher urlFetcher;
        IRepository<Projectinfo, int> repositoryProjectInfo;
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
            string initUrl, string syncUrl, IUrlFetcher urlFetcher,
            IRepository<Projectinfo, int> repositoryProjectInfo,
            IRepository<Typeinfo, int> repositoryTypeinfo,
            IRepository<Typefield, int> repositoryTypefield,
            IRepository<Typetag, int> repositoryTypetag,
            IRepository<Typepic, int> repositoryTypepic,
            IRepository<Pubinfounit, int> repositoryPubinfounit,
            IRepository<Pubunittag, int> repositoryPubunittag,
            IRepository<Pubmediainfo, int> repositoryPubmediainfo,
            IRepository<Pubinfounitchild, int> repositoryPubinfounitchild,
        IInfoLocalizer<Pubmediainfo, int> infoLocalizerPubMediaInfo,
        IInfoLocalizer<Typeinfo, int> infoLocalizerTypeinfo,
        IInfoLocalizer<Pubinfounit, int> infoLocalizerPubinfounit,
        IInfoLocalizer<Pubinfounitchild, int> infoLocalizerPubinfounitchild

            )
        {

            this.infoLocalizerPubinfounit = infoLocalizerPubinfounit;
            this.infoLocalizerPubinfounitchild = infoLocalizerPubinfounitchild;
            this.infoLocalizerPubMediaInfo = infoLocalizerPubMediaInfo;
            this.infoLocalizerTypeinfo = infoLocalizerTypeinfo;
            this.localSavedPath = localSavedPath;
            this.imageLocalizer = imageLocalizer;
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
            if (!existedData.Any())
            {
                targetUrl = initUrl;
            }
            string result = urlFetcher.FetchWithHeaderAsync(targetUrl
                , new Dictionary<string, string> { { HttpRequestHeader.Authorization.ToString(), token } }).Result;

            JsonSerializerSettings settings = new JsonSerializerSettings();

            var responseModel = JsonConvert.DeserializeObject<RapiResponse>(result, new ImageUrlJsonConverter(), new ImageUrlJsonConverter());
            if (responseModel.data.projectinfo != null)
            {

                repositoryProjectInfo.Insert(responseModel.data.projectinfo);
                repositoryProjectInfo.SaveChanges();
            }
            new System.Threading.Thread(() => {
                foreach (var item in responseModel.data.pubmediainfoes)
                {

                    infoLocalizerPubMediaInfo.Localize(item,string.Empty, localSavedPath, dataVersion);
                  

                }
            }).Start();


            new System.Threading.Thread(() => {
                foreach (var item in responseModel.data.typeinfoes)
                {
                    infoLocalizerTypeinfo.Localize(item,string.Empty, localSavedPath,dataVersion);
                    
                }
            }).Start();
            var alltypeinfoes = new List<Typeinfo>();

            new System.Threading.Thread(() => {
                foreach (var item in responseModel.data.pubinfounits)
                {
                    infoLocalizerPubinfounit.Localize(item, string.Empty, localSavedPath, dataVersion);
                   
                }
            }).Start();

            new System.Threading.Thread(() => {
                foreach (var item in responseModel.data.pubinfounitchilds)
                {
                 
                    infoLocalizerPubinfounitchild.Localize(item, string.Empty, localSavedPath,dataVersion);
                   
                }
            }).Start();
            repositoryPubunittag.BulkInsert(responseModel.data.pubunittags.Select(x => { x.Version = dataVersion; return x; }).ToList());
            repositoryTypefield.BulkInsert(responseModel.data.typefields.Select(x => { x.Version = dataVersion; return x; }).ToList());
            repositoryTypepic.BulkInsert(responseModel.data.typepics.Select(x => { x.Version = dataVersion; return x; }).ToList());
            repositoryTypetag.BulkInsert(responseModel.data.typetags.Select(x => { x.Version = dataVersion; return x; }).ToList());


        }

        private void M(Object stateInfo)
        { }




    }
    

}
