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

namespace TourInfo.Domain
{
    public class TourinfoDomainAutoMapperProfile : Profile
    {
        public TourinfoDomainAutoMapperProfile()
        {
            CreateMap<Activity, SqliteActivity>()
                .ForMember(x => x.isShared, c => c.MapFrom(d => d.isShared ? 1 : 0))
                .ForMember(x => x.pictureKeys,
                           c => c.MapFrom(
                               d => d.pictureKeys == null ? string.Empty : string.Join(";", d.pictureKeys.Select(x => x.LocalizedUrl))))
                .ForMember(x => x.pictureKeysOriginal,
                           c => c.MapFrom(
                               d => d.pictureKeys == null ? string.Empty : string.Join(";", d.pictureKeys.Select(x => x.OriginalUrl))))

                .ForMember(x => x.thumbnailKey, c => c.MapFrom(d => d.thumbnailKey.LocalizedUrl))
            .ForMember(x => x.thumbnailKeyOriginal, c => c.MapFrom(d => d.thumbnailKey.OriginalUrl));
            CreateMap<CompanyVenueType, SqliteCompanyVenueType>();
            CreateMap<CompanyVenue, SqliteCompanyVenue>()
                .ForMember(x => x.pictureKeys,
                           c => c.MapFrom(
                               d => d.pictureKeys == null ? string.Empty : string.Join(";", d.pictureKeys.Select(x => x.LocalizedUrl))))
                .ForMember(x => x.pictureKeysOriginal,
                           c => c.MapFrom(
                               d => d.pictureKeys == null ? string.Empty : string.Join(";", d.pictureKeys.Select(x => x.OriginalUrl))))

                .ForMember(x => x.thumbnailKey, c => c.MapFrom(d => d.thumbnailKey.LocalizedUrl))
            .ForMember(x => x.thumbnailKeyOriginal, c => c.MapFrom(d => d.thumbnailKey.OriginalUrl))
            .ForMember(x => x.longitude, c => c.MapFrom(d => d.location.Longitude))
            .ForMember(x => x.latitude, c => c.MapFrom(d => d.location.Latitude))
            ;



            CreateMap<ZbtaNews, SqliteZbtaNews>()
                .ForMember(x => x.image, c => c.MapFrom(d => d.image.LocalizedUrl))
                .ForMember(x => x.imageOriginal, c => c.MapFrom(d => d.image.OriginalUrl))
                .ForMember(x => x.details, c => c.MapFrom(d => d.details.ImageLocalizedText));

            CreateMap<Rapi.Projectinfo, SqliteProjectinfo>();


            CreateMap<Rapi.Pubinfounit, SqlitePubinfounit>()
                 .ForMember(x => x.flagpic, c => c.MapFrom(d => d.flagpic.LocalizedUrl))
                .ForMember(x => x.flagpicOriginal, c => c.MapFrom(d => d.flagpic.OriginalUrl))

               .ForMember(x => x.gpsbd_longitude, c => c.MapFrom(d => d.gpsbd.Longitude))
             .ForMember(x => x.gpsbd_latitude, c => c.MapFrom(d => d.gpsbd.Latitude))
             .ForMember(x => x.gps_longitude, c => c.MapFrom(d => d.gps.Longitude))
             .ForMember(x => x.gps_latitude, c => c.MapFrom(d => d.gps.Latitude))
             .ForMember(x => x.gpsgd_longitude, c => c.MapFrom(d => d.gpsgd.Longitude))
             .ForMember(x => x.gpsgd_latitude, c => c.MapFrom(d => d.gpsgd.Latitude));


            CreateMap<Rapi.Pubinfounitchild, SqlitePubinfounitchild>()
                  .ForMember(x => x.flagurl, c => c.MapFrom(d => d.flagurl.LocalizedUrl))
                .ForMember(x => x.flagurlOriginal, c => c.MapFrom(d => d.flagurl.OriginalUrl))
                  .ForMember(x => x.gpsbd_longitude, c => c.MapFrom(d => d.gpsbd.Longitude))
             .ForMember(x => x.gpsbd_latitude, c => c.MapFrom(d => d.gpsbd.Latitude))
             .ForMember(x => x.gps_longitude, c => c.MapFrom(d => d.gps.Longitude))
             .ForMember(x => x.gps_latitude, c => c.MapFrom(d => d.gps.Latitude))
             .ForMember(x => x.gpsgd_longitude, c => c.MapFrom(d => d.gpsgd.Longitude))
             .ForMember(x => x.gpsgd_latitude, c => c.MapFrom(d => d.gpsgd.Latitude));

            CreateMap<Rapi.Pubmediainfo, SqlitePubmediainfo>()
                 .ForMember(x => x.mediaurl, c => c.MapFrom(d => d.mediaurl.LocalizedUrl))
                .ForMember(x => x.mediaurlOriginal, c => c.MapFrom(d => d.mediaurl.OriginalUrl));
            ;
            CreateMap<Rapi.Pubunittag, SqlitePubunittag>();
            CreateMap<Rapi.Typeinfo, SqliteTypeinfo>()
                  .ForMember(x => x.wapshowimg, c => c.MapFrom(d => d.wapshowimg.LocalizedUrl))
                .ForMember(x => x.wapshowimgOriginal, c => c.MapFrom(d => d.wapshowimg.OriginalUrl));


            CreateMap<Rapi.Typefield, SqliteTypefield>();
            CreateMap<Rapi.Typetag, SqliteTypetag>();
            CreateMap<Rapi.Typepic, SqliteTypepic>();
            CreateMap<DomainModel.Video.Video, SqliteVideo>();

            //文化云
            CreateMap<Domain.Application.WHY.WHYDetailOrganization, DomainModel.WHY.WhyModel>()
                 .ForMember(x => x.addressInfo, c => c.MapFrom(d => d.addressInfo))
               .ForMember(x => x.contact, c => c.MapFrom(d => d.contact))

               .ForMember(x => x.hposter, c => c.MapFrom(d => new ImageUrl(d.hposter)))
               .ForMember(x => x.id, c => c.MapFrom(d => d.id))
               .ForMember(x => x.location, c => c.MapFrom(d =>d.location.Count==0?Location.Null: new Location(d.location[0], d.location[1])))
               .ForMember(x => x.name, c => c.MapFrom(d => d.name))
                .ForMember(x => x.summary, c => c.MapFrom(d => d.summary))
                 .ForMember(x => x.website, c => c.MapFrom(d => d.website))
               ;
            CreateMap<WhyModel,RapiRequestModel>()
                 .ForMember(x => x.address, c => c.MapFrom(d => d.addressInfo))
                  .ForMember(x => x.unitid, c => c.MapFrom(d => d.RapiId))
               .ForMember(x => x.desc, c => c.MapFrom(d => d.summary))

               .ForMember(x => x.flagpic, c => c.MapFrom(d =>d.hposter.LocalizedUrl))
               .ForMember(x => x.gpsbd, c => c.MapFrom(d => d.location == null ? string.Empty : d.location.ToString()))
               .ForMember(x => x.unitname, c => c.MapFrom(d => d.name))
                .ForMember(x => x.telephone, c => c.MapFrom(d => d.telephoneWithoutAreaCode))
                 .ForMember(x => x.url, c => c.MapFrom(d => d.website))
               ;

        }
    }
}
