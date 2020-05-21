using Microsoft.VisualStudio.TestTools.UnitTesting;
using TourInfo.Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace TourInfo.Domain.Base.Tests
{
    [TestClass()]
    public class ListMergerTests
    {
        [TestMethod()]
        public void MergeTest()
        {
          var source=new List<MergeTestClass> {
              new MergeTestClass{  id="1", Name="name1"},
               new MergeTestClass{  id="2", Name="name2"},
                 new MergeTestClass{  id="4", Name="name4"},

              };
            var target = new List<MergeTestClass> {
              new MergeTestClass{  id="1", Name="name1"},
              new MergeTestClass{  id="2", Name="name2_updated"},
               new MergeTestClass{  id="3", Name="name3"},

              };
            var merger=new ListMerger<MergeTestClass,string>(new Infrastracture.MD5Helper());
          var result=  merger.Merge(source,target).OrderBy(x=>x.Item.id);

            Assert.AreEqual(4,result.Count());
            Assert.AreEqual("1",result.First().Item.id);
            Assert.AreEqual("name1", result.First().Item.Name);
            Assert.AreEqual(MergeResultStatus.NoChanged, result.First().MergeResultStatus);

            Assert.AreEqual("2", result.Skip(1).First().Item.id);
            Assert.AreEqual("name2_updated", result.Skip(1).First().Item.Name);
            Assert.AreEqual(MergeResultStatus.Updated, result.Skip(1).First().MergeResultStatus);

            Assert.AreEqual("3", result.Skip(2).First().Item.id);
            Assert.AreEqual("name3", result.Skip(2).First().Item.Name);
            Assert.AreEqual(MergeResultStatus.Added, result.Skip(2).First().MergeResultStatus);

            Assert.AreEqual("4", result.Skip(3).First().Item.id);
            Assert.AreEqual("name4", result.Skip(3).First().Item.Name);
            Assert.AreEqual(MergeResultStatus.Deleted, result.Skip(3).First().MergeResultStatus);
        }
        public class MergeTestClass:VersionedEntity<string>
        {
            public override string id { get; set; }
            public string Name { get;set;}
            public string P3 { get;set;}
            public override string CalculateFingerprint(IMD5Helper mD5Helper)
            {
                string raw=$"id:{id},name:{Name},p3:{P3}";

                return  mD5Helper.CalculateMD5Hash(raw);
            }
        }
    }
}