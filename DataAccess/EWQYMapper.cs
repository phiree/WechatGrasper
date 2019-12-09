using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
public    class ActivityMapper:DapperExtensions.Mapper.ClassMapper<Domain.Activity>
    {
       public ActivityMapper()
        { 
            
                Map(x=>x.pictureKeys).Ignore();
            AutoMap();
            }
    }
    public class CompanyVenueMapper : DapperExtensions.Mapper.ClassMapper<Domain.CompanyVenue>
    {
        public CompanyVenueMapper()
        {
            Map(x => x.location).Ignore();
            Map(x => x.pictureKeys).Ignore();
            AutoMap();
        }
    }

}
