using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json.Converters;
using TourInfo.Domain.Base;

namespace TourInfo.Domain.DomainModel.Rapi
{
   public class TextContainsImageUrlsJsonConverter : JsonConverter<TextContainsImageUrls>
    {
        public override TextContainsImageUrls ReadJson(JsonReader reader, Type objectType, TextContainsImageUrls existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
           return new TextContainsImageUrls((string)reader.Value);
        }

        public override void WriteJson(JsonWriter writer, TextContainsImageUrls value, JsonSerializer serializer)
        {
            writer.WriteValue(value.OriginaText);
        }
    }
}
