using Microsoft.VisualStudio.TestTools.UnitTesting;
using TourInfo.Domain.DomainModel.Weather;
using System;
using System.Collections.Generic;
using System.Text;
using TourInfo.Infrastracture;
using Microsoft.Extensions.Logging;
using AutoFixture.AutoMoq;
using AutoFixture;
using Moq;
using Microsoft.Extensions.Logging.Abstractions;
using System.Net.Http;

namespace TourInfo.Domain.DomainModel.Weather.Tests
{
    [TestClass()]
    public class WeatherApplicationTests
    {
        [TestMethod()]
        public void GetWeatherTest()
        {
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            var logger = fixture.Freeze<Mock<ILoggerFactory>>();
          var  app=new JirenguWeatherApplication(new UrlFetcher(null, logger.Object),NullLogger<JirenguWeatherApplication>.Instance);
            var weather=app.GetWeather();
            Console.Write(weather.weather);
        }
    }
}