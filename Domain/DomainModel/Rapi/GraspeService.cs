using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using TourInfo.Domain.Base;
using System.Linq;
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
        string initUrl = "";
        string syncUrl = "";
        string appkey, appsecret;
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

        public RapiGraspeService(string initUrl, string syncUrl, string appkey, string appsecret, IUrlFetcher urlFetcher, IRepository<Projectinfo, int> repositoryProjectInfo, IRepository<Typeinfo, int> repositoryTypeinfo, IRepository<Typefield, int> repositoryTypefield, IRepository<Typetag, int> repositoryTypetag, IRepository<Typepic, int> repositoryTypepic, IRepository<Pubinfounit, int> repositoryPubinfounit, IRepository<Pubunittag, int> repositoryPubunittag, IRepository<Pubmediainfo, int> repositoryPubmediainfo, IRepository<Pubinfounitchild, int> repositoryPubinfounitchild)
        {
            this.initUrl = initUrl;
            this.syncUrl = syncUrl;
            this.appkey = appkey;
            this.appsecret = appsecret;
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
            //if database is empty, init, else  sync
            string targetUrl = syncUrl;
            var existedData = repositoryProjectInfo.GetAll();
            if (!existedData.Any()) {
                targetUrl = initUrl;
            }
            string result = urlFetcher.FetchAsync(targetUrl).Result;
            var responseModel = JsonConvert.DeserializeObject<RapiResponse>(result);

            repositoryProjectInfo.Insert(responseModel.data.projectinfo);
           
            foreach (var pubinfounit in responseModel.data.pubinfounits)
            {
                repositoryPubinfounit.Insert(pubinfounit);
            }
            foreach (var pubinfounitchild in responseModel.data.pubinfounitchilds)
            {
                repositoryPubinfounitchild.Insert(pubinfounitchild);
            }
            foreach (var pubmediainfo in responseModel.data.pubmediainfoes)
            {
                repositoryPubmediainfo.Insert(pubmediainfo);
            }
            foreach (var pubunittag in responseModel.data.pubunittags)
            {
                repositoryPubunittag.Insert(pubunittag);
            }
            foreach (var typefield in responseModel.data.typefields)
            {
                repositoryTypefield.Insert(typefield);
            }
            foreach (var typepic in responseModel.data.typepics)
            {
                repositoryTypepic.Insert(typepic);
            }
            foreach (var typeinfo in responseModel.data.typeinfoes)
            {
                repositoryTypeinfo.Insert(typeinfo);
            }
            foreach (var typetag in responseModel.data.typetags)
            {
                repositoryTypetag.Insert(typetag);
            }

        }

        
    }
}
