using System;
using Newtonsoft.Json;
using UnityEngine;

namespace Editor
{
    // Unity类型的转换器
    public class UnityTypeConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType.Namespace?.StartsWith("UnityEngine") ?? false;
        }
        
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
        
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            switch (value)
            {
                case Vector3 vec:
                    writer.WriteValue($"Vector3({vec.x}, {vec.y}, {vec.z})");
                    break;
                case Bounds bounds:
                    writer.WriteValue($"Bounds(center:{bounds.center}, size:{bounds.size})");
                    break;
                default:
                    writer.WriteValue(value.ToString());
                    break;
            }
        }
    }
}