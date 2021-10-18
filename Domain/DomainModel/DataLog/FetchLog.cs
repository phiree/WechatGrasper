using System;
using System.Collections.Generic;
using System.Text;
using TourInfo.Domain.Base;

namespace TourInfo.Domain.DomainModel.DataLog
{
    /// <summary>
    /// 抓取日志
    /// </summary>
    public class FetchLog:GuidEntity
    { 
        /// <summary>
        /// 
        /// </summary>
        public string SourceName { get; set; }
        public DateTime FetchBeginTime { get; set; }
        public DateTime FetchEndTime { get; set; }
        public int FetchAmount { get; set; }
        /// <summary>
        /// 抓取状态: 成功, 失败. 失败原因之类.
        /// </summary>
        public string FetchResult { get; set; }
    }

    /// <summary>
    /// 分发日志
    /// </summary>
    public class DistributeLog : GuidEntity
    { 
    public string DeviceName{ get; set; }
    public DateTime DistributeBeginTime { get; set; }
    public DateTime DistributeEndTime { get; set; }
        public int DistributeAmount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string DistirbuteResult { get; set; }

    }
    /// <summary>
    /// 数据源
    /// </summary>
    public class DataSource:GuidEntity
    { 
     public string Name { get; set; }
        public string BaseUrl { get; set; }
        /// <summary>
        /// 目前状态: 正常, 已停用.
        /// </summary>
        public string Status { get; set; }
       
    }
    /// <summary>
    /// 客户端. 获取这些数据的客户端
    /// </summary>
    public class Client : GuidEntity
    { 
        public string Name { get; set; }
        public string Description { get; set; }
        public string AppId { get; set; }
        public string AppSecret { get; set; }
         
    }
}
