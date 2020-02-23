using Microsoft.VisualStudio.TestTools.UnitTesting;
using TourInfo.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using TourInfo.Domain.DomainModel.DataSync;
using TourInfo.Domain.DomainModel.WHY;
using Microsoft.Extensions.Logging;
using TourInfo.Domain.DomainModel.Rapi;

namespace TourInfo.Domain.Tests
{
    [TestClass()]
    public class JsonConverterTests
    {
        ILoggerFactory loggerFactory=new LoggerFactory();
        [TestMethod()]
        public void ValueObjectConvertTest()
        {
          var whymodels=new List<WhyModel>();
            whymodels.Add(new WhyModel {  hposter=new Base.ImageUrl("abc.jog"), location=new Base.Location(1,2)});
            string jsonString= Newtonsoft.Json.JsonConvert.SerializeObject(whymodels
                         );
            Console.WriteLine(jsonString);


        }

        
    }
}