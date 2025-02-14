using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using w4_assignment_ksteph.Inventories;

namespace w4_assignment_ksteph.FileIO.Json
{
    public class JsonInventoryValueConverter : JsonConverterFactory
    {
        public override bool CanConvert(Type type)
        {
            if (type == typeof(Inventory) || type == typeof(string))
                return true;
            else
                return false;
        }

        public override JsonConverter CreateConverter(Type type, JsonSerializerOptions options)
        {
            Type[] typeArguments = type.GetGenericArguments();
            Type keyType = typeArguments[0];
            Type valueType = typeArguments[1];

            JsonConverter converter = (JsonConverter)Activator.CreateInstance(
                typeof(Inventory).MakeGenericType(
                    [keyType, valueType]),
                BindingFlags.Instance | BindingFlags.Public,
                binder: null,
                args: [options],
                culture: null)!;

            return converter;
        }
    }
}
