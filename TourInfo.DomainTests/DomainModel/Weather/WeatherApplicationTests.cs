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
namespace TourInfo.Domain.DomainModel.Weather.Tests
{
    [TestClass()]
    public class WeatherApplicationTests
    {
        [TestMethod()]
        public void GetWeatherTest()
        {
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            var logger = fixture.Freeze<Mock<ILogger<UrlFetcher>>>();
          var  app=new WeatherApplication(new UrlFetcher(logger.Object));
            var weather=app.GetWeather();
            Console.Write(weather.weather);
        }
    }
}