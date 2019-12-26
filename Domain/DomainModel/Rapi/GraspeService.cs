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

        public RapiGraspeService(ITokenManager tokenManager, string initUrl, string syncUrl,  IUrlFetcher urlFetcher, IRepository<Projectinfo, int> repositoryProjectInfo, IRepository<Typeinfo, int> repositoryTypeinfo, IRepository<Typefield, int> repositoryTypefield, IRepository<Typetag, int> repositoryTypetag, IRepository<Typepic, int> repositoryTypepic, IRepository<Pubinfounit, int> repositoryPubinfounit, IRepository<Pubunittag, int> repositoryPubunittag, IRepository<Pubmediainfo, int> repositoryPubmediainfo, IRepository<Pubinfounitchild, int> repositoryPubinfounitchild)
        {
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

            //foreach (var pubinfounit in responseModel.data.pubinfounits)
            //{
            //    repositoryPubinfounit.Insert(pubinfounit);
            //}
            repositoryPubmediainfo.ExecuteRawSql(" ALTER INDEX [PK_Pubmediainfos] on Pubmediainfos DISABLE");
            repositoryPubmediainfo.BulkInsert(responseModel.data.pubmediainfoes);
            repositoryPubmediainfo.ExecuteRawSql(" ALTER INDEX [PK_Pubmediainfos] on Pubmediainfos Rebuild");

            repositoryPubinfounit.BulkInsert(responseModel.data.pubinfounits);
            repositoryPubinfounit.SaveChanges();
            //foreach (var pubinfounitchild in responseModel.data.pubinfounitchilds)
            //{
            //    repositoryPubinfounitchild.Insert(pubinfounitchild);
            //}
           repositoryPubinfounit.ExecuteRawSql(" ALTER INDEX [PK_Pubinfounits] on Pubinfounits DISABLE");
            repositoryPubinfounitchild.BulkInsert(responseModel.data.pubinfounitchilds);
            repositoryPubinfounit.ExecuteRawSql(" ALTER INDEX [PK_Pubinfounits] on Pubinfounits Rebuild");

            //foreach (var pubmediainfo in responseModel.data.pubmediainfoes)
            //{
            //    repositoryPubmediainfo.Insert(pubmediainfo);
            //}
          
 
            foreach (var pubunittag in responseModel.data.pubunittags)
            {
                repositoryPubunittag.Insert(pubunittag);
            }
            repositoryPubunittag.SaveChanges();
            foreach (var typefield in responseModel.data.typefields)
            {
                repositoryTypefield.Insert(typefield);
            }
            repositoryTypefield.SaveChanges();
            foreach (var typepic in responseModel.data.typepics)
            {
                repositoryTypepic.Insert(typepic);
            }
            repositoryTypepic.SaveChanges();
            foreach (var typeinfo in responseModel.data.typeinfoes)
            {
                repositoryTypeinfo.Insert(typeinfo);
            }
            repositoryTypeinfo.SaveChanges();
            foreach (var typetag in responseModel.data.typetags)
            {
                repositoryTypetag.Insert(typetag);
            }
            repositoryTypetag.SaveChanges();

        }

        
    }
}
