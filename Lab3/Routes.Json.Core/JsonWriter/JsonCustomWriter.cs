using System.Text.Json;

namespace Routes.Json.Core.JsonWriter;

public static class JsonCustomWriter
{
    public static void Write(JsonWriterParams jsonWriterParams)
    {
        jsonWriterParams.JsonSerializerOptions ??= new JsonSerializerOptions()
        {
            
        };
        
        using var fileStream = new FileStream(jsonWriterParams.FileName, FileMode.Create);
        var json = JsonSerializer.Serialize(jsonWriterParams.Data, jsonWriterParams.JsonSerializerOptions);
        var writer = new Utf8JsonWriter(fileStream);
        var document = JsonDocument.Parse(json);
        var root = document.RootElement;
        
        root.WriteTo(writer);
        writer.Flush();
    }

    // public static void Write(object obj, Utf8JsonWriter writer, string name)
    // {
    //     if (obj is not IEnumerable<object> objects) 
    //         return;
    //     objects.TryGetNonEnumeratedCount(out var count);
    //     if (count < 0)
    //         return;
    //
    //     writer.WriteStartArray();
    //
    //     Type innerType;
    //
    //     try
    //     {
    //         innerType = objects.GetType().GetGenericArguments().First();
    //     }
    //     catch (InvalidOperationException)
    //     {
    //         innerType = typeof(object);
    //     }
    //
    //     foreach (var item in objects)
    //     {
    //         var itemType = item.GetType();
    //         WriteElement(item, writer, innerType.Name, innerType, innerType != itemType);
    //     }
    //
    //     writer.WriteEndArray();
    //     writer.Flush();
    // }
    //
    // public static void WriteElement(object obj, Utf8JsonWriter writer, string name, Type type, bool write)
    // {
    //     if (obj is IEnumerable<object>)
    //         Write(obj, writer, name);
    //     else if (type.IsPrimitive || type.IsEnum || type == typeof(string))
    //         WriteString(obj, writer, name);
    //     else
    //     {
    //         writer.WriteStartObject(name);
    //
    //         if (write)
    //             WriteString(obj, writer, name);
    //
    //         foreach (var prop in type.GetProperties())
    //         {
    //             var value = prop.GetValue(obj);
    //             if (value is not null)
    //             {
    //                 WriteElement(value, writer, prop.Name, prop.PropertyType,
    //                     prop.PropertyType.IsInterface);
    //             }
    //         }
    //
    //         writer.WriteEndObject();
    //         writer.Flush();
    //     }
    // }
    //
    // public static void WriteString(object obj, Utf8JsonWriter writer, string name)
    // {
    //     writer.WritePropertyName(name);
    //     writer.WriteStringValue(obj.GetType().ToString());
    // }
}