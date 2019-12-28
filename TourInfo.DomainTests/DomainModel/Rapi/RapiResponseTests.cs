using Microsoft.VisualStudio.TestTools.UnitTesting;
using TourInfo.Domain.DomainModel.Rapi;
using System;
using System.Collections.Generic;
using System.Text;

namespace TourInfo.Domain.DomainModel.Rapi.Tests
{
    [TestClass()]
    public class RapiResponseTests
    {
        [TestMethod()]
        public void RapiResponse_JsonParseTest()
        {
            string json = System.IO.File.ReadAllText(Environment.CurrentDirectory + "\\DomainModel\\Rapi\\initdata.json");
            var response = Newtonsoft.Json.JsonConvert.DeserializeObject<RapiResponse>(json, new ImageUrlJsonConverter());

        }
    }
}