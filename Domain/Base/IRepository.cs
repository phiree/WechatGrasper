
using System;
using System.Collections.Generic;
using System.Text;

namespace TourInfo.Domain.Base
{
    public interface IRepository<T, Key>
    {

        void Insert(T entity);
        bool Update(T entity);
        T Get(Key id);
        IList<T> GetAll();
      



    }

}
