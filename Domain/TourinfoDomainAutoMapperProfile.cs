using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TourInfo.Domain.DomainModel.DataSync;
using Rapi=TourInfo.Domain.DomainModel.Rapi;
using TourInfo.Domain.TourNews;

namespace TourInfo.Domain
{
    public class TourinfoDomainAutoMapperProfile:Profile
    {
        public TourinfoDomainAutoMapperProfile()
        {
            CreateMap<Activity, SqliteActivity>()
                .ForMember(x=>x.pictureKeys,
                           c=>c.MapFrom(
                               d=>d.pictureKeys==null?string.Empty:string.Join(";",d.localizedPictureKeys)))
                .ForMember(x=>x.thumbnailKey,c=>c.MapFrom(d=>d.localizedThumbnailKey));

            CreateMap<CompanyVenue, SqliteCompanyVenue>()
                .ForMember(x => x.pictureKeys,
                           c => c.MapFrom(
                               d => d.pictureKeys == null ? string.Empty : string.Join(";", d.localizedPictureKeys)))
                .ForMember(x => x.thumbnailKey, c => c.MapFrom(d => d.localizedThumbnailKey));
            ;
            CreateMap<ZbtaNews, SqliteZbtaNews>()
                .ForMember(x => x.image, c => c.MapFrom( d =>d.localizedImage))
                .ForMember(x => x.details, c => c.MapFrom(d => d.localizedDetails));
            ;
            CreateMap<Rapi.Projectinfo, SqliteProjectinfo>();
            CreateMap<Rapi.Pubinfounit, SqlitePubinfounit>();
            CreateMap<Rapi.Pubinfounitchild, SqlitePubinfounitchild>();
            CreateMap<Rapi.Pubmediainfo, SqlitePubmediainfo>()
                 .ForMember(x => x.mediaurl, c => c.MapFrom(d => d.mediaurl.LocalizedUrl))
                .ForMember(x => x.mediaurlOriginal, c => c.MapFrom(d => d.mediaurl.OriginalUrl));
            ;
            CreateMap<Rapi.Pubunittag, SqlitePubunittag>();
            CreateMap<Rapi.Typeinfo, SqliteTypeinfo>();
            CreateMap<Rapi.Typefield, SqliteTypefield>();
            CreateMap<Rapi.Typetag,SqliteTypetag>();
            CreateMap<Rapi.Typepic, SqliteTypepic>();
        }
    }
}
