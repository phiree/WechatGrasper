using Microsoft.VisualStudio.TestTools.UnitTesting;
using TourInfo.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using TourInfo.Domain.DomainModel.DataSync;

namespace TourInfo.Domain.Tests
{
    [TestClass()]
    public class SqliteCreatorTests
    {
        [TestMethod()]
        public void SqliteCreatorTest()
        {
          
            
            
        }

        [TestMethod()]
        public void CreateTableTest()
        {
            SqliteCreator sqliteCreator = new SqliteCreator("tourinfo.db3");
            sqliteCreator.CreateTable< SqliteTable<Activity>>(new List<SqliteTable< Activity>> {
            new SqliteActivity{  Version="212"}
            });
        }
    }
}