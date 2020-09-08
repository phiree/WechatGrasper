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
using TourInfo.Domain.DomainModel.SDTA;
using TourInfo.Domain.DomainModel.Weather;
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
        IWeatherApplication weatherApplication;

        public ZBTourController(IRepository<ZiBoWechatNews, string> repositoryWechatNews,
            IRepository<ZbtaNews, string> repositoryZbta,
            IRepository<WhyActivity, string> whyActivityRepository,
            IRepository<CityGuide, string> repositoryCityGuide,
            IRepository<CityGuideDetail.Data, string> repositoryCityGuideDetail,
            IRepository<SpecialLocalProductDetail.Data, string> repositorySpecialLocalProductDetail,
             IRepository<LineDetail, string> lineDetailRepository,
            IRepository<LineDetailScenic.Doc.Source, string> lineDetailScenicRepository,
            IRepository<Lines, string> linesRepository,
            IWeatherApplication weatherApplication,
        IMapper mapper)
        {
            this.linesRepository=linesRepository;
            this.lineDetailRepository = lineDetailRepository;
            this.lineDetailScenicRepository = lineDetailScenicRepository;
            this.repositoryCityGuide = repositoryCityGuide;
            this.repositoryWechatNews = repositoryWechatNews;
            this.repositoryZbta = repositoryZbta;
            this.mapper = mapper;
            this.whyActivityRepository = whyActivityRepository;
            this.repositoryCityGuideDetail = repositoryCityGuideDetail;
            this.repositorySpecialLocalProductDetail = repositorySpecialLocalProductDetail;
            this.weatherApplication=weatherApplication;
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
        public ResponseWrapperWithList<WhyActivitySummary> GetHotActivities(int pageIndex = 0, int pageSize = 10)
        {

            var activities = whyActivityRepository.GetList(pageIndex, pageSize);

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
        /// <summary>
        /// 活动详情
        /// </summary>
        /// <param name="id">活动列表中返回的Id</param>
        /// <returns></returns>
        [HttpGet("GetActivity")]
        public ResponseWrapper<WhyActivityDetail> GetActivity(string id)
        {

            var activity = whyActivityRepository.Get(id);

            var activitiyModel = mapper.Map<WhyActivityDetail>(activity);
            activitiyModel.ImageUrl =
           (Request.Scheme + "://" + Request.Host + "/" + activitiyModel.ImageUrl).Replace(@"\", @"/");



            //  var zbtaCa=mapper.Map<List<HomeCarousel>>(zbtaNewsList);
            return new ResponseWrapper<WhyActivityDetail>(activitiyModel);
        }

        IRepository<CityGuide, string> repositoryCityGuide;
        /// <summary>
        /// 5 城市锦囊 -- 首页”城市锦囊“的目标列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetCityGuides")]
        public ResponseWrapperWithList<CityGuideListModel> GetCityGuides()
        {
            var list = repositoryCityGuide.FindList(x => x.name == "淄博", o => o.name, true, 0, 10).SelectMany(x => x.category).ToList();
            var result = mapper.Map<List<CityGuideListModel>>(list);
            return new ResponseWrapperWithList<CityGuideListModel>(result);
        }

        IRepository<CityGuideDetail.Data, string> repositoryCityGuideDetail;

        /// <summary>
        /// 城市锦囊详情
        /// </summary>
        /// <param name="id">城市锦囊列表返回的id</param>
        /// <returns></returns>
        [HttpGet("GetCityGuide")]
        public ResponseWrapper<CityGuideDetailModel> GetCityGuide(string id)
        {

            var result = mapper.Map<CityGuideDetailModel>(repositoryCityGuideDetail.Get(id));
            return new ResponseWrapper<CityGuideDetailModel>(result);
        }


        IRepository<SpecialLocalProductDetail.Data, string> repositorySpecialLocalProductDetail;
        /// <summary>
        /// 特色商品列表
        /// </summary>
        /// <returns></returns>

        [HttpGet("GetSpecialLocalProducts")]

        public ResponseWrapperWithList<SpecialLocalProductSummary> GetSpecialLocalProducts(int pageIndex = 0, int pageSize = 10)
        {
            return new ResponseWrapperWithList<SpecialLocalProductSummary>(
                mapper.Map<IList<SpecialLocalProductSummary>>(
                repositorySpecialLocalProductDetail.FindList(x => true, x => x.commodity_id, true, pageIndex, pageSize)
                ));
        }
        /// <summary>
        /// 特色商品详情
        /// </summary>
        /// <param name="id">特色商品列表返回的Id</param>
        /// <returns></returns>
        [HttpGet("GetSpecialLocalProduct")]

        public ResponseWrapper<SpecialProductModel> GetSpecialLocalProduct(string id)
        {
            return new ResponseWrapper<SpecialProductModel>(mapper.Map<SpecialProductModel>(repositorySpecialLocalProductDetail.Get(id)));
        }

        IRepository<LineDetail, string> lineDetailRepository;


        /// <summary>
        /// 获取所有线路.只有4条数据,无需分页.
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetLines")]
        public ResponseWrapperWithList<LineListModel> GetLines()
        {
            return
                  new ResponseWrapperWithList<LineListModel>(mapper.Map<IList<LineListModel>>(lineDetailRepository.GetAll()));
        }
        IRepository<LineDetailScenic.Doc.Source, string> lineDetailScenicRepository;
        IRepository<Lines, string> linesRepository;
        /// <summary>
        /// 获取路线详情.
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetLineDetail")]
        public ResponseWrapper<LineDetailModel> GetLineDetail(string lineId)
        {
          //  var line = linesRepository.Get(lineId);
            var lineDetail = lineDetailRepository.Get(lineId);


            LineDetailModel lineDetailModel = new LineDetailModel();
           
            for (int i = 0; i < lineDetail.days.Count; i++)// var day in lineDetail.days)
            {
                var day = lineDetail.days[i];
               
                var dayModel = new LineDetailModel.DayDetaill { DayIndex = i + 1 };
                dayModel.Description=day.desc;
                foreach (var scenic in day.place)
                {
                    var detail = lineDetailScenicRepository.Get(scenic.type + "_" + scenic.id);
                    //var  = lineDetailScenic.docs[0]._source;
                    var scenicModel = new LineDetailModel.DayDetaill.Scenic
                    {
                        ImageUrl = detail.default_photo.LocalizedUrl,
                        Location = detail.location,
                        Name = detail.name_cn,
                        RecommentStayHour =int.Parse( scenic.time),
                        Description=detail.description
                    };
                    dayModel.Scenics.Add(scenicModel);
                }
                lineDetailModel.Days.Add(dayModel);


            }
            return new ResponseWrapper<LineDetailModel>(lineDetailModel);


           
        }
        [HttpGet("GetWeather")]
        public ActionResult<dynamic> GetWeather(string version)
        {

            return weatherApplication.GetWeather();

        }
    }
}
