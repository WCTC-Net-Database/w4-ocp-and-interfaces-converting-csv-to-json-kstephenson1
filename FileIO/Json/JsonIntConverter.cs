using System.Text.Json;
using System.Text.Json.Serialization;

namespace w4_assignment_ksteph.FileIO.Json;

// The JsonIntConverter is used to turn imported strings into ints automatically
public class JsonIntConverter : JsonConverter<int>
{
    public override int Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return Convert.ToInt32(reader.GetString());
    }

    public override void Write(Utf8JsonWriter writer, int value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString());
    }
}
