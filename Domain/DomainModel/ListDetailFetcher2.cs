using System;
using System.Collections.Generic;
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
    public class NestedFetcher<T0, Key0, T1, Key1, T2, Key2>
        : NestedFetcher<T0, Key0, T1, Key1>
        where T0 : DetailWrapper<T1, Key1>
        where T1 : DetailWrapper<T2, Key2>

    {

       
        HttpRequestMessage t2Request;
        bool persistanse2;
        IRepository<T2, Key2> repositoryT2;

        public NestedFetcher(IUrlFetcher urlFetcher, HttpRequestMessage rootRequest, bool persistanse0, IRepository<T0, Key0> repository0, HttpRequestMessage t1Request, bool persistanse1, IRepository<T1, Key1> repositoryT1, HttpRequestMessage t2Request, bool persistanse2, IRepository<T2, Key2> repositoryT2)
       : base(repository0, urlFetcher, rootRequest, persistanse0, repositoryT1, t1Request, persistanse1)
        {

            this.t2Request = t2Request;
            this.persistanse2 = persistanse2;
            this.repositoryT2 = repositoryT2;
        }

        public new IList<T2> Fetch()
        {
            var t2List = new List<T2>();
            var t1List = base.Fetch();
            foreach (var t1 in t1List)
            {
                foreach (var t2key in t1.DetailKeys)
                {
                    string detailJsonResult = urlFetcher.FetchAsync(t2Request).Result;
                    var detail = Newtonsoft.Json.JsonConvert.DeserializeObject<T2>(detailJsonResult);
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

    public class NestedFetcher<T0, Key0, T1, Key1> where T0 : DetailWrapper<T1, Key1>
    {
        IRepository<T0, Key0> repositoryT0;
        protected IUrlFetcher urlFetcher { get; }
        HttpRequestMessage rootRequest;
        IRepository<T1, Key1> repositoryT1;

        HttpRequestMessage t1Request;
        bool t0Persistanse, t1Persistanse;
        public NestedFetcher(IRepository<T0, Key0> repositoryT0,
            IUrlFetcher urlFetcher,
            HttpRequestMessage rootRequest,
            bool t0Persistanse,
            IRepository<T1, Key1> repositoryT1,

           HttpRequestMessage t1Request,

            bool t1Persistanse
            )
        {
            this.urlFetcher = urlFetcher;

            this.t0Persistanse = t0Persistanse;
            this.repositoryT0 = repositoryT0;
            this.rootRequest = rootRequest;

            this.t1Request = t1Request;
            this.t1Persistanse = t1Persistanse;
            this.repositoryT1 = repositoryT1;




        }

        public IList<T1> Fetch()
        {
            string rootJsonResult = urlFetcher.FetchAsync(rootRequest).Result;
            var list0 = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<T0>>(rootJsonResult);
            var detailList = new List<T1>();

            foreach (var root in list0)
            {
                if (t0Persistanse)
                {
                    repositoryT0.InsertOrUpdate(root);
                }
                foreach (var detailKey in root.DetailKeys)
                {
                    var request= requestbuilder.build(detailkey);
                    string detailJsonResult = urlFetcher.FetchAsync(t1Request).Result;
                    if (string.IsNullOrEmpty(detailJsonResult))
                    { continue; }
                    var detail = Newtonsoft.Json.JsonConvert.DeserializeObject<T1>(detailJsonResult);

                    detailList.Add(detail);

                }
                if (t1Persistanse)
                {
                    repositoryT1.InsertOrUpdate(detailList);
                }
            }
            return detailList;
        }
        //paging on top level

    }
    public abstract class DetailWrapper<TWrapper,TKey, TDetailSummary> where TWrapper:Entity<TKey>
    {
        public abstract IList<TDetailSummary> DetailSummarys { get; }
        public abstract  IDetailHttpRequestMessageCreator<TWrapper,TDetailSummary,TKey> DetailRequestBuilder();
        public TWrapper Wrapper { get;set;}


    }




}
