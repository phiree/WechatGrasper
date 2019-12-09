using System.Collections.Generic;

namespace WeChatGrasper
{
    public class ListResultWrapper<T> : ResultWrapper
    {
        public IList<T> data { get; set; }
    }

}

