using System.Collections.Generic;

namespace TourInfo.Domain.Base
{
    public interface IListMerger<T, Key> where T : VersionedEntity<Key>
    {
        IList<MergeListResult<T>> Merge(IList<T> source, IList<T> target);
    }
}