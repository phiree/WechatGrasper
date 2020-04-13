using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using TourInfo.Domain.Base;

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

        IUrlFetcher urlFetcher2;
        IRepository<T2, Key2> repositoryT2;

        IDetailUrlBuilder<Key2> detailUrlBuilder2;
        bool persistanse2;
        bool isPost2;
        public NestedFetcher(
            string rootUrl,
            IUrlFetcher urlFetcher0,
             bool persistanse0,
             
            IRepository<T0, Key0> repository0,

            IDetailUrlBuilder<Key1> detailUrlBuilder1,
            IUrlFetcher urlFetcher1,
              bool persistanse1,
            IRepository<T1, Key1> repositoryT1,

             IDetailUrlBuilder<Key2> detailUrlBuilder2,
             bool isPost2,
            IUrlFetcher urlFetcher2,
               bool persistanse2,
            IRepository<T2, Key2> repositoryT2
         
            )
            : base(repository0, urlFetcher0, rootUrl, persistanse0,
                  repositoryT1, urlFetcher1, detailUrlBuilder1, persistanse1)
        {
            this.repositoryT2 = repositoryT2;
            this.detailUrlBuilder2 = detailUrlBuilder2;
            this.urlFetcher2 = urlFetcher2;
            this.persistanse2 = persistanse2;
            this.isPost2=isPost2;
        }

        public new IList<T2> Fetch()
        {
            var t2List = new List<T2>();
            var t1List = base.Fetch();
            foreach (var t1 in t1List)
            {
                foreach (var t2key in t1.DetailKeys)
                {
                    string t2DetailUrl = detailUrlBuilder2.Build(t2key);
                    string detailJsonResult=string.Empty;
                    if(isPost2)
                    {
                       detailJsonResult= urlFetcher2.fetchwithpos(t2DetailUrl).Result;
                        }
                    var detail = Newtonsoft.Json.JsonConvert.DeserializeObject<T2>(
                        );
                    t2List.Add(detail);
                }
            }
            if (persistanse2) { 
                repositoryT2.InsertOrUpdate(t2List);
                }
            return t2List;

        }
    }

    public class NestedFetcher<T0, Key0, T1, Key1> where T0 : DetailWrapper<T1, Key1>
    {
        IRepository<T0, Key0> repositoryT0;
        IUrlFetcher urlFetcher0;
        string rootUrl;
        IRepository<T1, Key1> repositoryT1;
        IUrlFetcher urlFetcher1;
        IDetailUrlBuilder<Key1> detailUrlBuilder1;
        bool t0Persistanse, t1Persistanse;
        public NestedFetcher(IRepository<T0, Key0> repositoryT0,
            IUrlFetcher urlFetcher0,
            string rootUrl,
            bool t0Persistanse,
            IRepository<T1, Key1> repositoryT1,
            IUrlFetcher urlFetcher1,
            IDetailUrlBuilder<Key1> detailUrlBuilder1,
            bool t1Persistanse
            )
        {
            this.repositoryT0 = repositoryT0;
            this.urlFetcher0 = urlFetcher0;
            this.rootUrl = rootUrl;
            this.repositoryT1 = repositoryT1;
            this.urlFetcher1 = urlFetcher1;
            this.detailUrlBuilder1 = detailUrlBuilder1;
            this.t0Persistanse = t0Persistanse;
            this.t1Persistanse = t1Persistanse;
        }

        public IList<T1> Fetch()
        {
            string rootJsonResult = urlFetcher0.FetchAsync(rootUrl).Result;
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
                    string detailUrl = detailUrlBuilder1.Build(detailKey);
                    string detailJsonResult = urlFetcher1.FetchAsync(detailUrl).Result;
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
    public abstract class DetailWrapper<Detail, DetailKey>
    {
        public abstract IList<DetailKey> DetailKeys { get; }


    }
    /// <summary>
    /// 是否需要保存到数据库
    /// </summary>
    public interface INeedPersistance { }



}
