using System;

namespace TourInfo.Domain.Base
{
    /// <summary>
    /// 基类
    /// </summary>
    [Serializable]
    public abstract class Entity<Key>
    {
        public Key id { get; set; }
        /// <summary>
        /// 获取当前对象值的hashcode
        /// </summary>
        /// <returns></returns>
       
        
    }
    

}

