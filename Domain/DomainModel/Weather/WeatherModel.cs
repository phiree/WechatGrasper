using System;
using System.Collections.Generic;
using System.Text;

namespace TourInfo.Domain.DomainModel.Weather
{

    public class WeatherModel
    {
        public string weather { get; set; }
        public string wind { get; set; }
        public string temperature { get; set; }
    }
    public class JiRenGu
    {
        public int error { get; set; }
        public string status { get; set; }
        public string date { get; set; }
        public List<Result> results { get; set; }
        public class Result
        {
            public string currentCity { get; set; }
            public string pm25 { get; set; }
            public List<Index> index { get; set; }
            public List<WeatherData> weather_data { get; set; }
            public class Index
            {
                public string des { get; set; }
                public string tipt { get; set; }
                public string title { get; set; }
                public string zs { get; set; }
            }
            public class WeatherData
            {
                public string date { get; set; }
                public string dayPictureUrl { get; set; }
                public string nightPictureUrl { get; set; }
                public string weather { get; set; }
                public string wind { get; set; }
                public string temperature { get; set; }
            }
        }
    }

    public class WeatherModelApiBang
    {
        public string status { get; set; }
        public string cityen { get; set; }
        public string city { get; set; }
        public string citycode { get; set; }
        public string temp { get; set; }
        public string tempf { get; set; }
        public string wd { get; set; }
        public string wden { get; set; }
        public string wdenimg { get; set; }
        public string wdforce { get; set; }
        public string wdspd { get; set; }
        public string uptime { get; set; }
        public string weather { get; set; }
        public string weatheren { get; set; }
        public string weathercode { get; set; }
        public string weatherimg { get; set; }
        public string stp { get; set; }
        public string wisib { get; set; }
        public string humidity { get; set; }
        public string prcp { get; set; }
        public string prcp24h { get; set; }
        public string aqi { get; set; }
        public string pm25 { get; set; }
        public string today { get; set; }
    }
}
