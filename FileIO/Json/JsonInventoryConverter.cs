using System.Text.Json;
using System.Text.Json.Serialization;
using w4_assignment_ksteph.Inventories;

namespace w4_assignment_ksteph.FileIO.Json;

// The JsonInventoryConverter is used to turn json format into an Inventories Object automatically.
public class JsonInventoryConverter : JsonConverter<Inventory>
{
    public override Inventory? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return InventorySerializer.Deserialize(reader.GetString()!);
    }

    public override void Write(Utf8JsonWriter writer, Inventory inventory, JsonSerializerOptions options)
    {
        writer.WriteStringValue(InventorySerializer.Serialize(inventory));
    }
}
