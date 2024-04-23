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

    public static void Save<T>(object obj, string fileName, string name)
    {
        XmlWriterSettings settings = new()
        {
            Indent = true
        };

        using var xmlWriter = XmlWriter.Create(fileName, settings);
        Write<T>(obj, xmlWriter, name);
    }

    private static void Write<T>(object obj, XmlWriter xmlWriter, string name)
    {
        if (obj is IEnumerable<object> objects)
        {
            if (objects.Count() < 0)
                return;
                
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
                var itemType = item.GetType();
                WriteElement<T>(item, xmlWriter, innerType, innerType != itemType);
            }

            xmlWriter.WriteEndElement();   
        }
    }

    private static void WriteElement<T>(object obj, XmlWriter xmlWriter, Type type, bool writeString)
    {
        if (obj is IEnumerable<object>)
            Write<T>(obj, xmlWriter, type.Name);
        if (type.IsPrimitive || type.IsEnum || type == typeof(string) || type.IsAbstract)
            xmlWriter.WriteElementString(type.Name, obj.ToString());
        else
        {
            xmlWriter.WriteStartElement(type.Name);

            if (writeString)
                xmlWriter.WriteElementString(type.Name, obj.GetType().ToString());

            foreach (var prop in type.GetProperties())
            {
                if (prop.CustomAttributes.All(a => a.AttributeType != typeof(XmlIgnoreAttribute)) &&
                    prop.GetValue(obj) is not null)
                {
                    WriteElement<T>(prop.GetValue(obj)!, xmlWriter, prop.GetValue(obj)!.GetType(),
                        prop.PropertyType.IsInterface);
                }
            }

            xmlWriter.WriteEndElement();
        }
    }
}