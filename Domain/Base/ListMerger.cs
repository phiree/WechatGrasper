using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace TourInfo.Domain.Base
{
    /// <summary>
    /// 合并两个List
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="Key"></typeparam>
    public class ListMerger<T, Key> : IListMerger<T, Key> where T : VersionedEntity<Key>
    {
        IMD5Helper mD5Helper;
        public ListMerger(IMD5Helper mD5Helper)
        {
            this.mD5Helper = mD5Helper;
        }
        public IList<MergeListResult<T>> Merge(IList<T> source, IList<T> target)
        {
            var deletedFromSource = source.Except(target);
            var addedToSource = target.Except(source);
            //var bothExistedInSource=source.Intersect(target);

            var bothExistedInTarget = target.Intersect(source);// source.Where(x=>!addedToSource.Any(y=>y.id.Equals( x.id)));
            var mergeListResult = new List<MergeListResult<T>>();
            mergeListResult.AddRange(deletedFromSource.Select(x => new MergeListResult<T> { Item = x, MergeResultStatus = MergeResultStatus.Deleted }));
            mergeListResult.AddRange(addedToSource.Select(x => new MergeListResult<T> { Item = x, MergeResultStatus = MergeResultStatus.Added }));

            foreach (var item in bothExistedInTarget)
            {
                bool isUpdated = item.CalculateFingerprint(mD5Helper) != source.First(x => x.id.Equals(item.id)).CalculateFingerprint(mD5Helper);
                var updateMergeResult = isUpdated ? MergeResultStatus.Updated : MergeResultStatus.NoChanged;
                mergeListResult.Add(new MergeListResult<T> { MergeResultStatus = updateMergeResult, Item = item });
            }
            return mergeListResult;
        }
    }
    public class MergeListResult<T>
    {
        public T Item { get; set; }
        public bool ImageChanged { get;set;}
        public MergeResultStatus MergeResultStatus { get; set; }
    }
    public enum MergeResultStatus
    {
        Added,
        Updated,
        Deleted,
        NoChanged
    }
}
