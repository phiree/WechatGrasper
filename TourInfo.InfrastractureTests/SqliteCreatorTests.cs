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
            var sqliteConn = new SqliteDatabaseCreater().Create("tourinfo.db3");
            SqliteTableCreater<SqliteActivity,Activity> activityTableCreator 
                = new SqliteTableCreater<SqliteActivity,Activity>();

            activityTableCreator.CreateTable(sqliteConn, new List<SqliteActivity> { 
           (SqliteActivity) new SqliteActivity( ).UpdateFromEntity(new Activity{ Version="3"})
            });
        }
    }
}