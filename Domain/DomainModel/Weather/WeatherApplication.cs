using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;
using Newtonsoft;
namespace TourInfo.Domain.DomainModel.Weather
{
    public class JirenguWeatherApplication : IWeatherApplication
    {
        readonly string weatherApi = "http://api.jirengu.com/getWeather.php?city=淄博";
        IUrlFetcher urlFetcher;
        ILogger<JirenguWeatherApplication> logger;
        public JirenguWeatherApplication(IUrlFetcher fetcher, ILogger<JirenguWeatherApplication> logger)
        {
            this.urlFetcher = fetcher;
            this.logger=logger;
        }
        public WeatherModel GetWeather()
        {
            try { 
            string result = urlFetcher.FetchAsync(weatherApi).Result;
            var weathreObject = Newtonsoft.Json.JsonConvert.DeserializeObject<JiRenGu>(result);
            var currenWeather = weathreObject.results[0].weather_data[0];
            return new WeatherModel { weather = currenWeather.weather, temperature = currenWeather.temperature, wind = currenWeather.wind };
            }
            catch(Exception ex)
            { 
           logger.LogError("天气数据获取失败:"+ex.ToString());
                return new WeatherModel();
                }
        }
    }

    public class ApiBangWeatherApplication : IWeatherApplication
    {
        readonly string weatherApi = "http://api.help.bj.cn/apis/weather/?id=101120301";
        IUrlFetcher urlFetcher;
        ILogger<ApiBangWeatherApplication> logger;
        public ApiBangWeatherApplication(IUrlFetcher fetcher, ILogger<ApiBangWeatherApplication> logger)
        {
            this.urlFetcher = fetcher;
            this.logger=logger;
        }
        public WeatherModel GetWeather()
        {
            try
            {
                string result = urlFetcher.FetchAsync2(weatherApi).Result;
                var weatherObject = Newtonsoft.Json.JsonConvert.DeserializeObject<WeatherModelApiBang>(result);
             //   var currenWeather = weathreObject.results[0].weather_data[0];
                return new WeatherModel { weather = weatherObject.weather, 
                    temperature = weatherObject.temp, wind = weatherObject.wd };
            }
            catch (Exception ex)
            {
                logger.LogError("天气数据获取失败:" + ex.ToString());
                return new WeatherModel();
            }
        }
    }
}
