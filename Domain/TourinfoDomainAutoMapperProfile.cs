using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TourInfo.Domain.DomainModel.DataSync;
using TourInfo.Domain.DomainModel.Rapi;

namespace TourInfo.Domain
{
    public class TourinfoDomainAutoMapperProfile:Profile
    {
        public TourinfoDomainAutoMapperProfile()
        {
            CreateMap<SqliteProjectinfo, SqliteTable<Projectinfo>>();
        }
    }
}
