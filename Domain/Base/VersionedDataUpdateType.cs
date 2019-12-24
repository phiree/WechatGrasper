using System;
using System.Collections.Generic;
using System.Text;

namespace TourInfo.Domain.Base
{
    /// <summary>
    /// 带版本数据的变化情况
    /// </summary>
   public enum VersionedDataUpdateType
    {
        NoChange,
        Updated,//已有数据更新了
        Added,//
    }
}
