﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TourInfo.Domain.DomainModel.DataSync;
using Rapi = TourInfo.Domain.DomainModel.Rapi;
using TourInfo.Domain.TourNews;
using System.Linq;
using TourInfo.Domain.DomainModel.EWQY;
using TourInfo.Domain.Base;
using TourInfo.Domain.DomainModel.WHY;
using TourInfo.Domain.ZBTA;
using TourInfo.Application.Api.Models;
using TourInfo.Domain.DomainModel.ZiBoWechatNews;
using TourInfo.Domain.DomainModel.SDTA;

namespace TourInfo.Application.Api
{
    public class TourinfoApiAutoMapperProfile : Profile
    {
        public TourinfoApiAutoMapperProfile()
        {
            //首页轮播图

            CreateMap<ZbtaNews, Models.HomeCarousel>()
                .ForMember(x => x.Id, c => c.MapFrom(d => d.id))
                .ForMember(x => x.Title, c => c.MapFrom(d => d.titles))
                 .ForMember(x =>x.ImageUrl, c => c.MapFrom(d => d.image.LocalizedUrl))
                    .ForMember(x => x.Date, c => c.MapFrom(d => Convert.ToDateTime( d.created).ToString("yyyy-MM-dd")))
                 ;
           //资讯列表
            CreateMap<ZbtaNews, Models.ZbtaNewsDetail>()
           .ForMember(x => x.Title, c => c.MapFrom(d => d.titles))
             .ForMember(x => x.TitleImage, c => c.MapFrom(d => d.image.LocalizedUrl))
               .ForMember(x => x.Content, c => c.MapFrom(d => d.details));
            ;
           
          
            CreateMap<WhyActivity, Models.WhyActivitySummary>()
                .Include<WhyActivity,WhyActivityDetail>()
             .ForMember(x => x.Id, c => c.MapFrom(d => d.id))
             .ForMember(x => x.Title, c => c.MapFrom(d => d.name))
                .ForMember(x => x.ImageUrl, c => c.MapFrom(d => d.hPoster.LocalizedUrl))
                 .ForMember(x => x.Date, c => c.MapFrom(d => Convert.ToDateTime(d.createTime).ToString("yyyy-MM-dd")))
                    .ForMember(x => x.StartDate, c => c.MapFrom(d => Convert.ToDateTime(d.recentHoldStartTime).ToString("yyyy-MM-dd")))
                       .ForMember(x => x.EndDate, c => c.MapFrom(d => Convert.ToDateTime(d.recentHoldEndTime).ToString("yyyy-MM-dd")))
             
                       ;
            CreateMap<WhyActivity, Models.WhyActivityDetail>()
                     .ForMember(x => x.Content, c => c.MapFrom(d => d.content))
             ;

            CreateMap<CityGuide.Category.List,CityGuideListModel.GuideLineTitle>()
                  .ForMember(x => x.Id, c => c.MapFrom(d => d.id))
                    .ForMember(x => x.Name, c => c.MapFrom(d => d.title))
                   .ForMember(x => x.Tag, c => c.MapFrom(d => d.tag))
                  ;


            //城市锦囊列表
            CreateMap<CityGuide.Category, CityGuideListModel>()
                    .ForMember(x => x.CategoryName, c => c.MapFrom(d => d.name))
                    .ForMember(x=>x.Titles,c=>c.MapFrom(d=>d.list))
            ;
            //城市锦囊详情
            CreateMap<CityGuideDetail.Data, CityGuideDetailModel>()
                    .ForMember(x => x.Name, c => c.MapFrom(d => d.name))
                    .ForMember(x => x.Summary, c => c.MapFrom(d => d.description))
                      .ForMember(x => x.Content, c => c.MapFrom(d => d.content.ImageLocalizedText))
            ;


            /*已过时*/
            CreateMap<ZiBoWechatNews, Models.HomeCarousel>()
              .ForMember(x => x.Id, c => c.MapFrom(d => d.id))
              .ForMember(x => x.DetailUrl, c => c.MapFrom(d => d.url))
              .ForMember(x => x.Title, c => c.MapFrom(d => d.title))
                .ForMember(x => x.ImageUrl, c => c.MapFrom(d => d.img.LocalizedUrl))
                  .ForMember(x => x.Date, c => c.MapFrom(d => d.pubtime.ToString("yyyy-MM-dd")))
               ;
            CreateMap<ZiBoWechatNews, Models.WeChatNewsDetail>()
             .ForMember(x => x.Title, c => c.MapFrom(d => d.title))
               .ForMember(x => x.TitleImage, c => c.MapFrom(d => d.img.LocalizedUrl))
                 .ForMember(x => x.Content, c => c.MapFrom(d => d.content.ImageLocalizedText));
            ;
            CreateMap<ZiBoWechatNews, Models.HotNews>()
             .ForMember(x => x.Id, c => c.MapFrom(d => d.id))
             .ForMember(x => x.Title, c => c.MapFrom(d => d.title))
                .ForMember(x => x.ImageUrl, c => c.MapFrom(d => d.img.LocalizedUrl))
                 .ForMember(x => x.Date, c => c.MapFrom(d => d.pubtime.ToString("yyyy-MM-dd")))
              ;
        }
    }
}
