using System.Text.Json;

namespace Routes.Json.Core.JsonWriter;

public class JsonWriterParams
{
    public required string Name { get; set; }
    public required object Data { get; set; }
    
    public required string FileName { get; set; }
    
    public JsonSerializerOptions? JsonSerializerOptions { get; set; }
}