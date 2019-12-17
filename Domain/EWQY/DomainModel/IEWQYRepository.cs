using System;
using System.Collections.Generic;
using System.Text;
using TourInfo.Domain.Base;

namespace TourInfo.Domain.EWQY.DomainModel
{
   public  interface IEWQYRepository:IVersionedRepository<EWQYEntity, string>
    {
         
    }
}
