using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Reflection;

namespace Sekure.Runtime.Security
{
    public class EncryptedJsonConverter<T> : JsonConverter
    {
        private readonly EncryptionService _encryptionService;
        private readonly bool _isSerializing;

        public EncryptedJsonConverter(
            EncryptionService encryptionService
            , bool isSerializing
        )
        {
            _encryptionService = encryptionService;
            _isSerializing = isSerializing;
        }

        public override bool CanConvert(
            Type objectType
        ) => objectType == typeof(T);

        public override object ReadJson(
            JsonReader reader
            , Type objectType
            , object existingValue
            , JsonSerializer serializer
        )
        {
            JObject obj = JObject.Load(reader);
            var instance = Activator.CreateInstance(objectType);

            foreach (var prop in objectType.GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                if (!prop.CanWrite) continue;

                var value = obj[prop.Name];
                if (value == null) continue;

                object finalValue = value.ToObject(prop.PropertyType);

                if (prop.GetCustomAttribute<EncryptedAttribute>() != null && prop.PropertyType == typeof(string))
                {
                    finalValue = _encryptionService.Decrypt((string)finalValue);
                }

                prop.SetValue(instance, finalValue);
            }

            return instance;
        }

        public override void WriteJson(
            JsonWriter writer
            , object value
            , JsonSerializer serializer
        )
        {
            JObject obj = new JObject();

            foreach (var prop in value.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                var val = prop.GetValue(value);

                if (prop.GetCustomAttribute<EncryptedAttribute>() != null && prop.PropertyType == typeof(string) && _isSerializing)
                {
                    val = _encryptionService.Encrypt((string)val);
                }

                obj.Add(prop.Name, val == null ? null : JToken.FromObject(val));
            }

            obj.WriteTo(writer);
        }
    }
}
