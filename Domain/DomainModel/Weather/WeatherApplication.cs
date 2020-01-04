using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft;
namespace TourInfo.Domain.DomainModel.Weather
{
    public class WeatherApplication : IWeatherApplication
    {
        readonly string weatherApi = "http://api.jirengu.com/getWeather.php?city=淄博";
        IUrlFetcher urlFetcher;
        public WeatherApplication(IUrlFetcher fetcher)
        {
            this.urlFetcher = fetcher;
        }
        public WeatherModel GetWeather()
        {
            string result = urlFetcher.FetchAsync(weatherApi).Result;
            var weathreObject = Newtonsoft.Json.JsonConvert.DeserializeObject<JiRenGu>(result);
            var currenWeather = weathreObject.results[0].weather_data[0];
            return new WeatherModel { weather = currenWeather.weather, temperature = currenWeather.temperature, wind = currenWeather.wind };

        }
    }
}
