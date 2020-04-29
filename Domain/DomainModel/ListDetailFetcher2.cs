using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using TourInfo.Domain.Base;
using TourInfo.Domain.DomainModel.SDTA;

namespace TourInfo.Domain.DomainModel
{



    /// <summary>
    /// 三级 list-detail
    /// </summary>
    /// <typeparam name="T0"></typeparam>
    /// <typeparam name="Key0"></typeparam>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="Key1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="Key2"></typeparam>
    public class NestedFetcher<T0, Key0,T1Summary, T1, Key1,T2Summary, T2, Key2>
        : NestedFetcher<T0, Key0,T1Summary, T1, Key1>
        where T0 : DetailWrapper<T1Summary,Key1>,IEntity<Key0>
        where T1Summary:Entity<Key1>
        where T1 : DetailWrapper<T2Summary,Key2>,IEntity<Key1>
        where T2Summary:Entity<Key2>
        where T2:IEntity<Key2>

    {
        bool persistanse2;
        IRepository<T2, Key2> repositoryT2;

        public NestedFetcher(IUrlFetcher urlFetcher, HttpRequestMessage rootRequest, bool persistanse0, IRepository<T0, Key0> repository0, 
          
            bool persistanse1, IRepository<T1, Key1> repositoryT1,
            bool persistanse2, IRepository<T2, Key2> repositoryT2)
       : base(repository0, urlFetcher, rootRequest, persistanse0, repositoryT1, persistanse1)
        {

            
            this.persistanse2 = persistanse2;
            this.repositoryT2 = repositoryT2;
        }

        public new IList<T2> Fetch()
        {
            var t2List = new List<T2>();
            var t1List = base.Fetch();
            foreach (var t1 in t1List)
            {
                foreach (var t2Summary in t1.DetailSummarys)
                {
                    string detailJsonResult = urlFetcher.FetchAsync( t1.DetailRequestBuilder.Create(t2Summary) ).Result;
                    var detail = Newtonsoft.Json.JsonConvert.DeserializeObject<T2>(detailJsonResult);
                    detail.id=t2Summary.id;
                    t2List.Add(detail);
                }
            }
            if (persistanse2)
            {
                repositoryT2.InsertOrUpdate(t2List);
            }
            return t2List;

        }
    }

    public interface INestFetcherHttpRequestCreator
    {
        bool NeedPaging { get;set;}
        HttpRequestMessage Create();
        HttpRequestMessage CreateNextPageRequest();

    }
 
    public class NestFetcherPagingHttpRequestCreator
    {
         

    }
    /*
     下载
     分页下载

        根据一个url获取页面内容
         */
    public class NestedFetcher<T0, Key0,T1Summary, T1, Key1> 
        where T0 :DetailWrapper<T1Summary,Key1>,IEntity<Key0>
        where T1Summary:Entity<Key1>
        where T1: IEntity<Key1>
    {
        IRepository<T0, Key0> repositoryT0;
        protected IUrlFetcher urlFetcher { get; }
        HttpRequestMessage rootRequest;
        IRepository<T1, Key1> repositoryT1;
        INestFetcherHttpRequestCreator nestFetcherHttpRequestCreator;

        bool t0Persistanse, t1Persistanse;
        public NestedFetcher(IRepository<T0, Key0> repositoryT0,
            IUrlFetcher urlFetcher,
            HttpRequestMessage rootRequest,
            bool t0Persistanse,
            IRepository<T1, Key1> repositoryT1,
            bool t1Persistanse
            )
        {
            
            this.urlFetcher = urlFetcher;

            this.t0Persistanse = t0Persistanse;
            this.repositoryT0 = repositoryT0;
            this.rootRequest = rootRequest;

            
            this.t1Persistanse = t1Persistanse;
            this.repositoryT1 = repositoryT1;




        }
        public IList<T1> Fetch()
        { 
            nestFetcherHttpRequestCreator.Create();
            throw new NotImplementedException();
            }

        public IList<T1> Fetch(HttpRequestMessage httpRequestMessage)
        {
            string rootJsonResult = urlFetcher.FetchAsync(httpRequestMessage).Result;
            var root = Newtonsoft.Json.JsonConvert.DeserializeObject< T0>(rootJsonResult);
            var detailList = new List<T1>();
            if (t0Persistanse)
            {
                repositoryT0.InsertOrUpdate(root);
            }
            foreach (var t1Summary in root.DetailSummarys)
            {
                
                
                    var requestMessage= root.DetailRequestBuilder.Create(t1Summary);// requestbuilder.build(detailkey);
                    string detailJsonResult = urlFetcher.FetchAsync(requestMessage).Result;
                    if (string.IsNullOrEmpty(detailJsonResult))
                    { continue; }
                    var detail = Newtonsoft.Json.JsonConvert.DeserializeObject<T1>(detailJsonResult);
                    detail.id= t1Summary.id;
                    detailList.Add(detail);

               
                if (t1Persistanse)
                {
                   // IInfoLocalizer<T1,Key1> infoLocalizer=new InfoLocalizer<T1,Key1>(repositoryT1,urlFetcher)
                    repositoryT1.InsertOrUpdate(detailList);
                }
                if(nestFetcherHttpRequestCreator.NeedPaging)
                { 
                    Fetch(nestFetcherHttpRequestCreator.CreateNextPageRequest());
                    }

            }
            return detailList;
        }
        //paging on top level

    }
    public abstract class DetailWrapper<TDetailSummary,TDetailSummaryKey> where TDetailSummary:Entity<TDetailSummaryKey>
    {
        public abstract IEnumerable<TDetailSummary> DetailSummarys { get; }
        public abstract  IDetailHttpRequestMessageCreator<TDetailSummary> DetailRequestBuilder{ get;}
         


    }




}
