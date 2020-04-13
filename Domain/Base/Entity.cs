using System;

namespace TourInfo.Domain.Base
{
    public interface  IEntity<Key>
    {
         Key id { get; set; }
        /// <summary>
        /// 获取当前对象值的hashcode
        /// </summary>
        /// <returns></returns>
  
    }
    /// <summary>
    /// 基类
    /// </summary>
    [Serializable]
    public abstract class Entity<Key>:IEntity<Key>
    {
        public Key id { get; set; }
        /// <summary>
        /// 获取当前对象值的hashcode
        /// </summary>
        /// <returns></returns>
       
        
    }
    
}

