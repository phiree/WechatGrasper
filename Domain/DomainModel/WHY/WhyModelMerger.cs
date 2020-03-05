using System;
using System.Collections.Generic;
using System.Text;
using TourInfo.Domain.Base;
using System.Linq;
namespace TourInfo.Domain.DomainModel.WHY
{
    public class WhyModelMerger : IWhyModelMerger
    {
        IListMerger<WhyModel, string> merger;

        public WhyModelMerger(IListMerger<WhyModel, string> merger)
        {
            this.merger = merger;
        }

        public IList<MergeListResult<WhyModel>> Merge(IList<WhyModel> modelsInDb, IList<WhyModel> modelsFromApi)
        {
            var modelMergedList = merger.Merge(modelsInDb, modelsFromApi);
            //mergeresult中相同的model是fromapi的, 但是 rapiid和本地图片 应该来自数据库.需要把result中相关对象的rapid更新为数据库的
            foreach (var mergeResult in modelMergedList)
            {
                var modleInDb = modelsInDb.Where(x => x.id == mergeResult.Item.id);
                if(mergeResult.MergeResultStatus== MergeResultStatus.Updated)
                { 
                    //判断图片地址是否改变
                 mergeResult.ImageChanged=   mergeResult.Item.hposter.OriginalUrl!=modleInDb.First().hposter.OriginalUrl

                    ;
                    }
                
                if (modleInDb.Count() == 1)
                {
                    mergeResult.Item.RapiId = modleInDb.First().RapiId;
                    mergeResult.Item.hposter.UpdateLocalizedUrl(modleInDb.First().hposter.LocalizedUrl);
                }

            }
            return modelMergedList;
        }
    }
}
