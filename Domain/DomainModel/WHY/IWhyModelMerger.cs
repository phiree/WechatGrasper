using System.Collections.Generic;
using TourInfo.Domain.Base;

namespace TourInfo.Domain.DomainModel.WHY
{
    public interface IWhyModelMerger
    {
        IList<MergeListResult<WhyModel>> Merge(IList<WhyModel> modelsInDb, IList<WhyModel> modelsFromApi);
    }
}