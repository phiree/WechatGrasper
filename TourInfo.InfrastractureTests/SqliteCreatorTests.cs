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
            SqliteDatabaseCreater sqliteCreator = new SqliteDatabaseCreater("tourinfo.db3");
            SqliteTableCreater<SqliteActivity,Activity> activityTableCreator 
                = new SqliteTableCreater<SqliteActivity,Activity>(sqliteCreator.database);

            activityTableCreator.CreateTable(new List<SqliteActivity> { 
            new SqliteActivity(new Activity{ Version="2211"})
            });
        }
    }
}