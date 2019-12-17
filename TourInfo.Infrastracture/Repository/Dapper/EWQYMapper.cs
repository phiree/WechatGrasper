using System;
using System.Collections.Generic;
using System.Text;
using TourInfo.Domain;
namespace TourInfo.Infrastracture.Repository.Dapper
{
public   class ActivityMapper:DapperExtensions.Mapper.ClassMapper< Activity>
    {
       public ActivityMapper()
        { 
            
                Map(x=>x.pictureKeys).Ignore();
            AutoMap();
            }
    }
    public class CompanyVenueMapper : DapperExtensions.Mapper.ClassMapper< CompanyVenue>
    {
        public CompanyVenueMapper()
        {
            Map(x => x.location).Ignore();
            Map(x => x.pictureKeys).Ignore();
            AutoMap();
        }
    }

}
