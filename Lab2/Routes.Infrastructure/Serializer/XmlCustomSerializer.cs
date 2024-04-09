using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using Routes.Infrastructure.Database;

namespace Routes.Infrastructure.Serializer;

public static class XmlCustomSerializer
{
    public static T Deserialize<T>(this XElement element) where T : BaseEntity<long>
    {
        var serializer = new XmlSerializer(typeof(T));
        
        return (T)serializer.Deserialize(element.CreateReader())!;
    }

    public static IEnumerable<T> Deserialize<T>(this IEnumerable<XElement> elements) where T : BaseEntity<long>
    {
        return elements.Select(Deserialize<T>);
    }
    
    public static string Serialize<T>(T obj)
    {
        var serializer = new XmlSerializer(typeof(T));
        using var stringWriter = new StringWriter();
        
        
        using var xmlTextWriter = new XmlTextWriter(stringWriter);
        xmlTextWriter.Formatting = Formatting.Indented;
        
        serializer.Serialize(xmlTextWriter, obj);
        
        return stringWriter.ToString();
    }
}