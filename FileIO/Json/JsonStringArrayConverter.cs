using System.Buffers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using w4_assignment_ksteph.Inventories;

namespace w4_assignment_ksteph.FileIO.Json;

// The JsonInventoryConverter is used to turn json format into an Inventories Object automatically.
public class JsonStringArrayConverter : JsonConverter<Inventory>
{
    public override Inventory? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.Null)
        {
            throw new JsonException("ARRAYREADER: Value is null");
        } else if (reader.TokenType != JsonTokenType.StartArray)
        {
            throw new JsonException("ARRAYREADER: Value is not an array.");
        }
        var itemSet = new List<string>();
        while (reader.Read())
        {
            if (reader.TokenType == JsonTokenType.EndArray)
            {
                Inventory inventory = new();
                foreach (string item in itemSet)
                {
                    inventory.Items.Add(new(item));
                }
                return inventory;
            }
            else if (reader.TokenType == JsonTokenType.String)
            {
                itemSet.Add((reader.GetString()));
            }
            else
            {
                throw new JsonException($"ARRAYREADER: Unexpected token type {reader.TokenType}");
            }
        }
        throw new JsonException($"ARRAYREADER: Unexpected token type {reader.TokenType}");
    }

    public override void Write(Utf8JsonWriter writer, Inventory inventory, JsonSerializerOptions options)
    {
        List<string> items = new();
        writer.WriteStartArray();
        foreach (Item item in inventory.Items)
        {
            writer.WriteStringValue(item.ID);
        }
        writer.WriteEndArray();
    }
}
