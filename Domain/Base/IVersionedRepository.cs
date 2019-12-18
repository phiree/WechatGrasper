
using System;
using System.Collections.Generic;
using System.Text;

namespace TourInfo.Domain.Base
{
    public interface IVersionedRepository<T,Key>:IRepository<T, Key>
        
        
    {
          void SaveOrUpdate(T entity, string newVersion);
          IList<T> GetAllAfterVersion(string version);
    }

}
