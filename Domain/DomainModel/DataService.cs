using System;
using System.Collections.Generic;
using System.Text;
using TourInfo.Domain.EWQY;
using TourInfo.Domain.EWQY.DomainModel;

namespace TourInfo.Domain.DomainModel
{
    public class DataService
    {
        IEWQYRepository eWQYRepository;
        public DataService(IEWQYRepository eWQYRepository)
        {
            this.eWQYRepository = eWQYRepository;
        }
        public void CreateInitData()
        {
          var allEwqyEntity =  eWQYRepository.GetAll();
            foreach (var ewqyEntity in allEwqyEntity)
            { 
            
            }
            //数据处理（图片下载）
            //创建图片压缩包
        }
        public void CreateSyncData()
        { 
        
        }
    }
}
