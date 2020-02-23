
using System;
using System.Collections.Generic;
using System.Text;

namespace TourInfo.Domain.Base
{
    public interface IVersionedRepository<T,Key>:IRepository<T, Key>
        
        
    {
          void SaveOrUpdate(T entity, string newVersion);
          IList<T> GetAllAfterVersion(string version);
        /// <summary>
        /// 根据传入的对象列表更新数据库
        /// </summary>
        /// <param name="newKeys"></param>
        /// <returns>更新结果.包含状态</returns>
       
    }

}
