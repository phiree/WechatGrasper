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
            SqliteTableCreater<SqliteActivity> activityTableCreator 
                = new SqliteTableCreater<SqliteActivity>();

           
        }
    }
}