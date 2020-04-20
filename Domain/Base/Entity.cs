using System;
using System.Security.Principal;

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
        public virtual Key id { get; set; }
        /// <summary>
        /// 获取当前对象值的hashcode
        /// </summary>
        /// <returns></returns>
       
        
    }
    /// <summary>
    /// 基类
    /// </summary>
    [Serializable]
    public abstract class GuidEntity : IEntity<string>
    {
        public GuidEntity(){
            id=Guid.NewGuid().ToString();
            }
        public virtual string id { get; set; }
        /// <summary>
        /// 获取当前对象值的hashcode
        /// </summary>
        /// <returns></returns>


    }
}

