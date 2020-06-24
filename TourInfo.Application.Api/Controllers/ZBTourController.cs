﻿using System;
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
using TourInfo.Domain.DomainModel.WHY;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TourInfo.Application.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ZBTourController : ControllerBase
    {
        IRepository<TourInfo.Domain.DomainModel.ZiBoWechatNews.ZiBoWechatNews, string> repositoryWechatNews;
        IRepository<TourInfo.Domain.ZBTA.ZbtaNews, string> repositoryZbta;
        IMapper mapper;
        IRepository<WhyActivity, string> whyActivityRepository;
        

        public ZBTourController(IRepository<ZiBoWechatNews, string> repositoryWechatNews,
            IRepository<ZbtaNews, string> repositoryZbta,
            IRepository<WhyActivity, string> whyActivityRepository,
            IMapper mapper)
        {
            this.repositoryWechatNews = repositoryWechatNews;
            this.repositoryZbta = repositoryZbta;
            this.mapper = mapper;
            this.whyActivityRepository= whyActivityRepository;
        }

        /// <summary>
        /// 1 首页轮播图
        /// </summary>
        /// <returns></returns>
        /// <param name="size">数量</param>
        // GET: api/<ZBTourController>/GetHomeCarousels
        [HttpGet("GetHomeCarousels")]
        public ResponseWrapperWithList<HomeCarousel> GetHomeCarousels(int size = 3)
        {
            //var wechatList= repositoryWechatNews.GetList(0,3);
            var zbtaNewsList = repositoryZbta.FindList(x => true, x => x.created, true, 0, 3);
            var zbtas = mapper.Map<List<HomeCarousel>>(zbtaNewsList)
                .Select(x =>
                {

                    x.DetailUrl = Request.Scheme + "://" + Request.Host + "/api/tourinfo/GetZbtaNewsDetail?id=" + x.Id;

                    return x;
                });
            //  var wechats= mapper.Map<List<HomeCarousel>>(wechatList);

            var cas = zbtas
                   //.Concat(wechats) 
                   .Select(x =>
                   {
                       if (!x.ImageUrl.StartsWith("http"))
                       {
                           x.ImageUrl = (Request.Scheme + "://" + Request.Host + "/" + x.ImageUrl).Replace(@"\", @"/");
                       }

                       return x;
                   }).
                 OrderByDescending(x => x.Date).ToList();

            //  var zbtaCa=mapper.Map<List<HomeCarousel>>(zbtaNewsList);

            return new ResponseWrapperWithList<HomeCarousel>(cas);
        }

        /// <summary>
        /// 2 首页顶部菜单“资讯”对应的列表
        /// </summary>
        /// <param name="pageIndex">分页页码，从0开始，默认0</param>
        /// <param name="pageSize">分页页幅,默认10条</param>
        /// <returns></returns>
        [HttpGet("GetHomeHotNews")]
        public ResponseWrapperWithList<HotNews> GetHomeHotNews(int pageIndex = 0, int pageSize = 10)
        {
            // var wechatList = repositoryWechatNews.GetList(0, 1);
            var zbtaNewsList = repositoryZbta.FindList(x => true, x => x.created, true, pageIndex, pageSize);
            var zbtas = mapper.Map<List<HotNews>>(zbtaNewsList);

            // var wechats = mapper.Map<List<HotNews>>(wechatList);
            var cas = zbtas
                //.Concat(wechats)
                .Select(x =>
                {
                    if (!x.ImageUrl.StartsWith("http"))
                    {
                        x.ImageUrl = (Request.Scheme + "://" + Request.Host + "/" + x.ImageUrl).Replace(@"\", @"/");
                    }

                    return x;
                }).OrderByDescending(x => x.Date).ToList();
            //  var zbtaCa=mapper.Map<List<HomeCarousel>>(zbtaNewsList);
            return new ResponseWrapperWithList<HotNews>(cas);
        }



        /// <summary>
        /// 3 首页 热门资讯活动，取自 文化云活动 
        /// </summary>
        /// <param name="pageIndex">分页,从0开始</param>
        /// <param name="pageSize">每页数量</param>
        /// <returns></returns>
        [HttpGet("GetHotActivities")]
        public ResponseWrapperWithList<WhyActivitySummary> GetHotActivities(int pageIndex=0, int pageSize=10)
        {
          
            var activities= whyActivityRepository.GetList(pageIndex,pageSize);

            var activitiyModels = mapper.Map<List<WhyActivitySummary>>(activities)
                .Select(x =>
                {
                    x.ImageUrl =
          (Request.Scheme + "://" + Request.Host + "/" + x.ImageUrl).Replace(@"\", @"/");
                    return x;
                }).ToList();
          
           
            //  var zbtaCa=mapper.Map<List<HomeCarousel>>(zbtaNewsList);
            return new ResponseWrapperWithList<WhyActivitySummary>(activitiyModels);
        }
        [HttpGet("GetActivity")]
        public ResponseWrapper<WhyActivityDetail> GetActivity(string id)
        {

            var activity = whyActivityRepository.Get(id);

            var activitiyModel = mapper.Map< WhyActivityDetail>(activity);
            activitiyModel.ImageUrl= 
           (Request.Scheme + "://" + Request.Host + "/" + activitiyModel.ImageUrl).Replace(@"\", @"/");
       


            //  var zbtaCa=mapper.Map<List<HomeCarousel>>(zbtaNewsList);
            return new ResponseWrapper <WhyActivityDetail>(activitiyModel);
        }

        /// <summary>
        /// 4  热门活动列表，对应首页模块“热门资讯活动”的 查看更多
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetActivities")]
        public ResponseWrapperWithList<HotNews> GetActivities()
        {
            throw new Exception();
        }
        /// <summary>
        /// 5 城市锦囊 -- 首页”城市锦囊“的目标列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetCityGuides")]
        public ResponseWrapperWithList<HotNews> GetCityGuides()
        { throw new Exception(); }
        /// <summary>
        /// 6 特色商品 --首页 ”特色商品“ 的目标列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetSpecialProducts")]
        public ResponseWrapperWithList<HotNews> GetSpecialProducts()
        {
            throw new Exception();
        }
        /// <summary>
        /// 7 首页经典路线  
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetHotLines")]
        public ResponseWrapperWithList<HotNews> GetHotLines()
        {
            throw new Exception();
        }

        /// <summary>
        /// 8 经典路线 列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetLines")]
        public ResponseWrapperWithList<HotNews> GetLines()
        {
            throw new Exception();
        }

        [Obsolete("微信页面难以被嵌入，取消此数据源")]
        [HttpGet("RenderWechatNewsDetail")]
        public ActionResult<string> RenderWechatNewsDetail(string id)
        {
            ZiBoWechatNews news = repositoryWechatNews.Get(id);
            var model = mapper.Map<WeChatNewsDetail>(news);
            return Content(model.Content, "text/html", System.Text.Encoding.Default);

        }

        [Obsolete("微信页面难以被嵌入，取消此数据源")]
        [HttpGet("GetWechatNewsDetail")]
        public ResponseWrapper<WeChatNewsDetail> GetWechatNewsDetail(string id)
        {
            ZiBoWechatNews news = repositoryWechatNews.Get(id);
            var model = mapper.Map<WeChatNewsDetail>(news);
            return new ResponseWrapper<WeChatNewsDetail>(model);
        }
    }
}
