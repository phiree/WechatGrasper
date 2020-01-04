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
using Microsoft.Extensions.Logging;

namespace TourInfo.Domain.DomainModel.Rapi
{
    /// <summary>
    /// 抓取数据
    /// </summary>
    public interface IRapiGraspeService
    {
        /// <summary>
        /// 拉取rapi数据
        /// </summary>
        /// <param name="dataVersion"></param>
        /// <param name="forceInit">因为rapi提供了sync接口</param>
        void Graspe(string dataVersion,bool forceInit);
    }
    public class RapiGraspeService : IRapiGraspeService
    {
        ILogger<LocationJsonConverter> locationJsonConverterLogger;
        ILogger<RapiGraspeService> logger;
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
        IInfoLocalizer<Pubinfounitchild, int> infoLocalizerPubinfounitchild,
 ILogger<RapiGraspeService> logger,
 ILogger<LocationJsonConverter> locationJsonConverterLogger
            )
        {
            this.locationJsonConverterLogger = locationJsonConverterLogger;
            this.logger = logger;
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

        public void Graspe(string dataVersion,bool forceInit)
        {
            string token = tokenManager.GetToken();

            //if database is empty, init, else  sync
            string targetUrl = syncUrl;
            var existedData = repositoryProjectInfo.GetAll();
            if (forceInit||!existedData.Any())
            {
                targetUrl = initUrl;
            }
            string result = urlFetcher.FetchWithHeaderAsync(targetUrl
                , new Dictionary<string, string> { { HttpRequestHeader.Authorization.ToString(), token } }).Result;

            JsonSerializerSettings settings = new JsonSerializerSettings();
            var responseModel = JsonConvert.DeserializeObject<RapiResponse>(result,
                new ImageUrlJsonConverter(), new LocationJsonConverter(locationJsonConverterLogger,false,',')
                );
            if (responseModel.data.projectinfo != null)
            {
                 responseModel.data.projectinfo.UpdateVersion(string.Empty, dataVersion);
                repositoryProjectInfo.InsertOrUpdate(responseModel.data.projectinfo);
                
            }
            var pubmediaThread = new System.Threading.Thread(() => {
                
                foreach (var item in responseModel.data.pubmediainfoes)
                {
                    bool isExisted=false;
                    infoLocalizerPubMediaInfo.Localize(item, string.Empty, localSavedPath, dataVersion,out isExisted);
                    if (isExisted) { break;}


                }
                logger.LogInformation(" pubmediainfo抓取完毕");
            });
            
            pubmediaThread.Start();
           




            var typeInfoThread =new  System.Threading.Thread(() => {
                logger.LogInformation("开始抓取typeInfoT");
                foreach (var item in responseModel.data.typeinfoes)
                {
                    bool isExisted;
                    infoLocalizerTypeinfo.Localize(item, string.Empty, localSavedPath, dataVersion,out isExisted);
                    if (isExisted) { break;}

                }
                logger.LogInformation("typeInfoT抓取完毕");
            });
            typeInfoThread.Start();
           



            var pubinfounitThread = new System.Threading.Thread(() => {
                logger.LogInformation("开始抓取pubinfounit");
                foreach (var item in responseModel.data.pubinfounits)
                {
                    bool isExisted;
                    infoLocalizerPubinfounit.Localize(item, string.Empty, localSavedPath, dataVersion,out isExisted);
                    if (isExisted) { break;}

                }
                logger.LogInformation(" pubinfounit抓取完毕");
            });
            pubinfounitThread.Start();
           

            var pubinfounitchildThread = new System.Threading.Thread(() => {
                logger.LogInformation("开始抓取pubinfounitchild");
                foreach (var item in responseModel.data.pubinfounitchilds)
                {
                    bool isExisted;
                    infoLocalizerPubinfounitchild.Localize(item, string.Empty, localSavedPath, dataVersion,out isExisted);

                }
                logger.LogInformation("pubinfounitchild抓取完毕");
            });
            pubinfounitchildThread.Start();
          
            repositoryPubunittag.InsertOrUpdate(responseModel.data.pubunittags.Select(x => { x.Version = dataVersion; return x; }).ToList());
            repositoryTypefield.InsertOrUpdate(responseModel.data.typefields.Select(x => { x.Version = dataVersion; return x; }).ToList());
            repositoryTypepic.InsertOrUpdate(responseModel.data.typepics.Select(x => { x.Version = dataVersion; return x; }).ToList());
            repositoryTypetag.InsertOrUpdate(responseModel.data.typetags.Select(x => { x.Version = dataVersion; return x; }).ToList());


        }

        private void M(Object stateInfo)
        { }




    }
    

}
