using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json.Converters;
using TourInfo.Domain.Base;

namespace TourInfo.Domain.DomainModel
{
   public class ImageUrlJsonConverter : JsonConverter<ImageUrl>
    {
        public override ImageUrl ReadJson(JsonReader reader, Type objectType, ImageUrl existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
           return new ImageUrl((string)reader.Value);
        }

        public override void WriteJson(JsonWriter writer, ImageUrl value, JsonSerializer serializer)
        {
            writer.WriteValue(value.LocalizedUrl);
        }
    }
}
