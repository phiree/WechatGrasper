
using System;
using System.Collections.Generic;
using System.Text;

namespace TourInfo.Domain.Base
{
    public interface IVersionedRepository<T,Key>:IRepository<T, Key>
        where T:Entity,IHasVersion
        
    {
          void SaveOrUpdate(T entity, string newVersion);
    }

}
