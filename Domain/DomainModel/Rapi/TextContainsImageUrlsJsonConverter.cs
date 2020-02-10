using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json.Converters;
using TourInfo.Domain.Base;

namespace TourInfo.Domain.DomainModel.Rapi
{
   public class TextContainsImageUrlsJsonConverter : JsonConverter<ImageUrlsInText>
    {
        public override ImageUrlsInText ReadJson(JsonReader reader, Type objectType, ImageUrlsInText existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
           return new ImageUrlsInText((string)reader.Value);
        }

        public override void WriteJson(JsonWriter writer, ImageUrlsInText value, JsonSerializer serializer)
        {
            writer.WriteValue(value.OriginaText);
        }
    }
}
