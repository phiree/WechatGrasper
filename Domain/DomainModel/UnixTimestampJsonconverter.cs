using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json.Converters;
using TourInfo.Domain.Base;

namespace TourInfo.Domain.DomainModel
{
   public class UnixTimestampJsonconverter : JsonConverter<DateTime>
    {
        public override DateTime ReadJson(JsonReader reader, Type objectType, DateTime existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            
           return DateTimeOffset.FromUnixTimeMilliseconds((long)reader.Value).DateTime;
        }

        public override void WriteJson(JsonWriter writer, DateTime value, JsonSerializer serializer)
        {
            writer.WriteValue(new DateTimeOffset(value).ToUnixTimeMilliseconds());
        }
      
    }
}
