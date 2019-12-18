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
            SqliteTableCreater<Activity> activityTableCreator = new SqliteTableCreater<Activity>(sqliteCreator.database);

            activityTableCreator.CreateTable(new List<SqliteActivity> { 
            new SqliteActivity{ Version="abcde"}
            });
        }
    }
}