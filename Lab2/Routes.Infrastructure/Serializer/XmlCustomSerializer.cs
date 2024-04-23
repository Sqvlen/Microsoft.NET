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

    public static void Save<T>(IEnumerable<T> objects, string fileName)
    {
        XmlWriterSettings settings = new()
        {
            Indent = true
        };

        using var xmlWriter = XmlWriter.Create(fileName, settings);
        Write(objects, xmlWriter, "Routes");
    }

    private static void Write<T>(IEnumerable<T> objects, XmlWriter xmlWriter, string name)
    {
        xmlWriter.WriteStartElement(name);
        
        Type innerType;
        
        try
        {
            innerType = objects.GetType().GetGenericArguments().First();
        }
        catch (InvalidOperationException)
        {
            innerType = typeof(object);
        }

        foreach (var item in objects)
        {
            var itemType = item!.GetType();
            WriteElement(item, xmlWriter, innerType, innerType != itemType);
        }

        xmlWriter.WriteEndElement();
    }

    private static void WriteElement<T>(T obj, XmlWriter xmlWriter, Type type, bool writeString)
    {
        xmlWriter.WriteStartElement(type.Name);

        if (writeString)
            xmlWriter.WriteElementString(type.Name, obj!.GetType().ToString());

        foreach (var prop in type.GetProperties())
        {
            if (prop.CustomAttributes.All(a => a.AttributeType != typeof(XmlIgnoreAttribute)) &&
                prop.GetValue(obj) is not null)
            {
                WriteElement(prop.GetValue(obj), xmlWriter, prop.GetValue(obj)!.GetType(),
                    prop.PropertyType.IsInterface);
            }
        }

        xmlWriter.WriteEndElement();
    }
}