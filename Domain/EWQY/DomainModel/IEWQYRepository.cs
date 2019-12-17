using System;
using System.Collections.Generic;
using System.Text;
using TourInfo.Domain.Base;

namespace TourInfo.Domain.EWQY.DomainModel
{
   public  interface IEWQYRepository:IRepository<EWQYEntity,string>
    {
        void SaveOrUpdate(EWQYEntity eWQYEntity,string newVersion);
    }
}
