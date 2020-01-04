using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;

namespace TourInfo.Domain.DomainModel.Rapi
{
    /// <summary>
    /// 字符串转换为经纬度 
    /// </summary>
    public class LocationStringJsonConverter : JsonConverter<Location>
    {
        ILogger<LocationStringJsonConverter> logger;
        public bool longitudeFirst = true;
        public char spliter = ';';
        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="longitudeFirst">经度在前面</param>
        /// <param name="spliter">分隔符</param>
        public LocationStringJsonConverter(ILogger<LocationStringJsonConverter> logger, bool longitudeFirst, char spliter)
        {
            this.logger = logger;
            this.longitudeFirst = longitudeFirst;
            this.spliter = spliter;
        }
        public override Location ReadJson(JsonReader reader, Type objectType, Location existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var locationString = (string)reader.Value;
            if (string.IsNullOrEmpty(locationString))
            {
                return Location.Null;
            }
            var array = locationString.Split(spliter);
            if (array.Length != 2) { return Location.Null; }
            try
            {
                if (!longitudeFirst) { array = array.Reverse().ToArray(); }

                var longitude =string.IsNullOrEmpty(array[0])?0:Convert.ToDouble(array[0]);
                var latitude = string.IsNullOrEmpty(array[1]) ? 0 : Convert.ToDouble(array[1]);
                return new Location(longitude, latitude);
            }
            catch
            {
                logger.LogError($"位置字符串格式错误,无法转为坐标数值:[{locationString}]");
                return Location.Null;
            }
        }

        public override void WriteJson(JsonWriter writer, Location value, JsonSerializer serializer)
        {

            writer.WriteValue(longitudeFirst ? value.Longitude + spliter + value.Latitude : value.Latitude + spliter + value.Longitude);
        }
    }

    public class LocationDoubleArrayJsonConverter : JsonConverter<Location>
    {
        ILogger<LocationDoubleArrayJsonConverter> logger;
        public bool longitudeFirst = true;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="longitudeFirst">经度在前面</param>

        public LocationDoubleArrayJsonConverter(ILoggerFactory loggerFactory, bool longitudeFirst)
        {
            this.logger = loggerFactory.CreateLogger<LocationDoubleArrayJsonConverter>();
            this.longitudeFirst = longitudeFirst;

        }
        public override Location ReadJson(JsonReader reader, Type objectType, Location existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var jToken= JToken.Load(reader);
           
            if (jToken == null) { return Location.Null; }
            if (jToken.Count() != 2) { return Location.Null; }
            try
            { 
                var array =longitudeFirst?jToken.ToArray(): jToken.Reverse().ToArray(); 
                var longitude =Convert.ToDouble( array[0]);
                var latitude =Convert.ToDouble( array[1]);
                return new Location(longitude, latitude);
            }
            catch
            {
                logger.LogError($"位置字符串格式错误,无法转为坐标数值:[{reader.Value.ToString()}]");
                return Location.Null;
            }
        }

        public override void WriteJson(JsonWriter writer, Location value, JsonSerializer serializer)
        {

            writer.WriteValue(longitudeFirst ? new double[] { value.Longitude, value.Latitude } : new double[] { value.Latitude, value.Longitude });
        }
    }
}
