using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TourInfo.Application.Api.Models;
using TourInfo.Domain;
using TourInfo.Domain.Base;
using AutoMapper;
using TourInfo.Domain.DomainModel.ZiBoWechatNews;
using TourInfo.Domain.ZBTA;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TourInfo.Application.Api.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class ZBTourController : ControllerBase
    {
        IRepository<TourInfo.Domain.DomainModel.ZiBoWechatNews.ZiBoWechatNews, string> repositoryWechatNews;
        IRepository<TourInfo.Domain.ZBTA.ZbtaNews,string> repositoryZbta;
        IMapper mapper;

        public ZBTourController(IRepository<ZiBoWechatNews, string> repositoryWechatNews, IRepository<ZbtaNews, string> repositoryZbta, IMapper mapper)
        {
            this.repositoryWechatNews = repositoryWechatNews;
            this.repositoryZbta = repositoryZbta;
            this.mapper = mapper;
        }

        /// <summary>
        /// 获取首页轮播图
        /// </summary>
        /// <returns></returns>
        /// <param name="size">数量</param>
        // GET: api/<ZBTourController>/GetHomeCarousels
        [HttpGet("GetHomeCarousels")]
        public ResponseWrapperWithList<HomeCarousel> GetHomeCarousels(int size=5)
        {
           var wechatList= repositoryWechatNews.GetList(0,3);
            var zbtaNewsList=repositoryZbta.FindList(x=>true,x=>x.created,true,0,2);
            var zbtas=mapper .Map<List<HomeCarousel>>(zbtaNewsList)

                .Select(x =>{ x.ImageUrl=
                    (Request.Scheme+"://"+ Request.Host + "/" + x.ImageUrl).Replace(@"\",@"/"); 
                    return x; }).ToList();
            var wechats= mapper.Map<List<HomeCarousel>>(wechatList);

           var cas= zbtas.Concat(wechats).OrderByDescending(x=>x.Date).ToList();
            //  var zbtaCa=mapper.Map<List<HomeCarousel>>(zbtaNewsList);
         
            return new ResponseWrapperWithList<HomeCarousel>( cas );
        }

       /// <summary>
       /// 首页热门资讯
       /// </summary>
       /// <returns></returns>
        [HttpGet("GetHomeHotNews")]
        public ResponseWrapperWithList<HotNews> GetHomeHotNews()
        {
            var wechatList = repositoryWechatNews.GetList(0, 1);
            var zbtaNewsList = repositoryZbta.FindList(x => true, x => x.created, true, 0, 2);
            var zbtas = mapper.Map<List<HotNews>>(zbtaNewsList)
                .Select(x => {
                    x.ImageUrl =
          (Request.Scheme + "://" + Request.Host + "/" + x.ImageUrl).Replace(@"\", @"/");
                    return x;
                }).ToList();
            var wechats = mapper.Map<List<HotNews>>(wechatList);
            var cas = zbtas.Concat(wechats).OrderByDescending(x => x.Date).ToList();
            //  var zbtaCa=mapper.Map<List<HomeCarousel>>(zbtaNewsList);
            return new ResponseWrapperWithList<HotNews>(cas);
        }
        /// <summary>
        /// 资讯列表
        /// </summary>
        /// <param name="pageIndex">分页,从0开始</param>
        /// <param name="pageSize">每页数量</param>
        /// <returns></returns>
        [HttpGet("GetHotNews")]
        public ResponseWrapperWithList<HotNews> GetHotNews(int pageIndex,int pageSize)
        {
            var wechatList = repositoryWechatNews.FindList(x=>true,x=>x.pubtime,true, pageIndex,pageSize);
            var zbtaNewsList = repositoryZbta.FindList(x => true, x => x.created, true, pageIndex,pageSize);
            var zbtas = mapper.Map<List<HotNews>>(zbtaNewsList)
                .Select(x => {
                    x.ImageUrl =
          (Request.Scheme + "://" + Request.Host + "/" + x.ImageUrl).Replace(@"\", @"/");
                    return x;
                }).ToList();
            var wechats = mapper.Map<List<HotNews>>(wechatList);
            var cas = zbtas.Concat(wechats).OrderByDescending(x => x.Date).Skip(pageIndex*pageSize).Take(pageSize).ToList();
            //  var zbtaCa=mapper.Map<List<HomeCarousel>>(zbtaNewsList);
            return new ResponseWrapperWithList<HotNews>(cas);
        }
       
    }
}
