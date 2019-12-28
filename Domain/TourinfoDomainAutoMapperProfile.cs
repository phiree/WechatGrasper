﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TourInfo.Domain.DomainModel.DataSync;
using Rapi=TourInfo.Domain.DomainModel.Rapi;
using TourInfo.Domain.TourNews;
using System.Linq;
namespace TourInfo.Domain
{
    public class TourinfoDomainAutoMapperProfile:Profile
    {
        public TourinfoDomainAutoMapperProfile()
        {
            CreateMap<Activity, SqliteActivity>()
                .ForMember(x=>x.pictureKeys,
                           c=>c.MapFrom(
                               d=>d.pictureKeys==null?string.Empty:string.Join(";",d.pictureKeys.Select(x=>x.LocalizedUrl))))
                .ForMember(x => x.pictureKeysOriginal,
                           c => c.MapFrom(
                               d => d.pictureKeys == null ? string.Empty : string.Join(";", d.pictureKeys.Select(x => x.OriginalUrl))))

                .ForMember(x=>x.thumbnailKey,c=>c.MapFrom(d=>d.thumbnailKey.LocalizedUrl)) 
            .ForMember(x => x.thumbnailKeyOriginal, c => c.MapFrom(d => d.thumbnailKey.OriginalUrl));

            CreateMap<CompanyVenue, SqliteCompanyVenue>()
                .ForMember(x => x.pictureKeys,
                           c => c.MapFrom(
                               d => d.pictureKeys == null ? string.Empty : string.Join(";", d.pictureKeys.Select(x => x.LocalizedUrl))))
                .ForMember(x => x.pictureKeysOriginal,
                           c => c.MapFrom(
                               d => d.pictureKeys == null ? string.Empty : string.Join(";", d.pictureKeys.Select(x => x.OriginalUrl))))

                .ForMember(x => x.thumbnailKey, c => c.MapFrom(d => d.thumbnailKey.LocalizedUrl))
            .ForMember(x => x.thumbnailKeyOriginal, c => c.MapFrom(d => d.thumbnailKey.OriginalUrl));

            
            CreateMap<ZbtaNews, SqliteZbtaNews>()
                .ForMember(x => x.image, c => c.MapFrom( d =>d.image.LocalizedUrl))
                .ForMember(x => x.imageOriginal, c => c.MapFrom(d => d.image.OriginalUrl))
                .ForMember(x => x.details, c => c.MapFrom(d => d.localizedDetails));

            CreateMap<Rapi.Projectinfo, SqliteProjectinfo>();


            CreateMap<Rapi.Pubinfounit, SqlitePubinfounit>()
                 .ForMember(x => x.flagpic, c => c.MapFrom(d => d.flagpic.LocalizedUrl))
                .ForMember(x => x.flagpicOriginal, c => c.MapFrom(d => d.flagpic.OriginalUrl));
              


            CreateMap<Rapi.Pubinfounitchild, SqlitePubinfounitchild>()
                  .ForMember(x => x.flagurl, c => c.MapFrom(d => d.flagurl.LocalizedUrl))
                .ForMember(x => x.flagurlOriginal, c => c.MapFrom(d => d.flagurl.OriginalUrl)); 

            CreateMap<Rapi.Pubmediainfo, SqlitePubmediainfo>()
                 .ForMember(x => x.mediaurl, c => c.MapFrom(d => d.mediaurl.LocalizedUrl))
                .ForMember(x => x.mediaurlOriginal, c => c.MapFrom(d => d.mediaurl.OriginalUrl));
            ;
            CreateMap<Rapi.Pubunittag, SqlitePubunittag>();
            CreateMap<Rapi.Typeinfo, SqliteTypeinfo>()
                  .ForMember(x => x.wapshowimg, c => c.MapFrom(d => d.wapshowimg.LocalizedUrl))
                .ForMember(x => x.wapshowimgOriginal, c => c.MapFrom(d => d.wapshowimg.OriginalUrl)); 


            CreateMap<Rapi.Typefield, SqliteTypefield>();
            CreateMap<Rapi.Typetag,SqliteTypetag>();
            CreateMap<Rapi.Typepic, SqliteTypepic>();
        }
    }
}