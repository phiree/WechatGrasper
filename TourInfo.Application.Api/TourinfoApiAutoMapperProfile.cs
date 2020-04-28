using AutoMapper;
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
namespace TourInfo.Application.Api
{
    public class TourinfoApiAutoMapperProfile : Profile
    {
        public TourinfoApiAutoMapperProfile()
        {

            CreateMap<ZbtaNews, Models.HomeCarousel>()
                .ForMember(x => x.Id, c => c.MapFrom(d => d.id))
                .ForMember(x => x.Title, c => c.MapFrom(d => d.titles))
                .ForMember(x => x.DataSourceType, c => c.MapFrom(d=>HomeCarouselDataSourceType.ZbtaNews))// c.MapFrom(d => d.details.ImageLocalizedText))
                 .ForMember(x =>x.ImageUrl, c => c.MapFrom(d => d.image.LocalizedUrl))
                    .ForMember(x => x.Date, c => c.MapFrom(d => d.created))
                 ;
            CreateMap<ZiBoWechatNews, Models.HomeCarousel>()
               .ForMember(x => x.Id, c => c.MapFrom(d => d.id))
               .ForMember(x => x.Title, c => c.MapFrom(d => d.title))
               .ForMember(x => x.DataSourceType, c => c.MapFrom(d => HomeCarouselDataSourceType.WeChatNews))// c.MapFrom(d => d.details.ImageLocalizedText))
                .ForMember(x => x.ImageUrl, c => c.MapFrom(d => d.img))
                   .ForMember(x => x.Date, c => c.MapFrom(d => d.pubtime.ToString("yyyy-MM-dd hh:mm:ss")))
                ;

            CreateMap<ZiBoWechatNews, Models.HotNews>()
              .ForMember(x => x.Id, c => c.MapFrom(d => d.id))
              .ForMember(x => x.Title, c => c.MapFrom(d => d.title))
                 .ForMember(x => x.ImageUrl, c => c.MapFrom(d => d.img))
                  .ForMember(x => x.Date, c => c.MapFrom(d => d.pubtime.ToString("yyyy-MM-dd hh:mm:ss")))
               ;
            CreateMap<ZbtaNews, Models.HotNews>()
             .ForMember(x => x.Id, c => c.MapFrom(d => d.id))
             .ForMember(x => x.Title, c => c.MapFrom(d => d.titles))
                .ForMember(x => x.ImageUrl, c => c.MapFrom(d => d.image.LocalizedUrl))
                 .ForMember(x => x.Date, c => c.MapFrom(d => d.created ))
              ;

        }
    }
}
