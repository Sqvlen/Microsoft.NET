using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using Routes.Infrastructure.Database;
using Routes.Infrastructure.Entities;

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

    public static void Serialize<T>(object obj, string fileName, string name)
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
                WriteElement<T>(item, xmlWriter, innerType.Name, innerType, innerType != itemType);
            }

            xmlWriter.WriteEndElement();   
        }
    }

    private static void WriteElement<T>(object obj, XmlWriter xmlWriter, string name, Type type, bool writeString)
    {
        if (obj is IEnumerable<object>)
            Write<T>(obj, xmlWriter, name);
        else if (type.IsPrimitive || type.IsEnum || type == typeof(string))
            xmlWriter.WriteElementString(name, obj.ToString());
        else
        {
            xmlWriter.WriteStartElement(name);

            if (writeString)
                xmlWriter.WriteElementString(name, obj.GetType().ToString());

            foreach (var prop in type.GetProperties())
            {
                var value = prop.GetValue(obj);
                if (value is not null)
                {
                    WriteElement<T>(value, xmlWriter, prop.Name, prop.PropertyType,
                        prop.PropertyType.IsInterface);
                }
            }

            xmlWriter.WriteEndElement();
        }
    }

    public static T Read<T>(string fileName)
    {
        var xmlDocument = new XmlDocument();
        xmlDocument.Load(fileName);

        return ReadNode<T>(xmlDocument.DocumentElement!, "Routes");
    }
    
    public static T ReadNode<T>(XmlNode node, string name)
    {
        var type = typeof(T);
            if (type.IsPrimitive || type.IsEnum || type == typeof(string))
                return (T?)Convert.ChangeType(node.InnerText, type);
            else if (typeof(IEnumerable<object>).IsAssignableFrom(type))
            {
                var innerType = type.GetGenericArguments()[0];
                Type listType = typeof(List<>).MakeGenericType(innerType);
                var enumerable = Activator.CreateInstance(listType);
                foreach (XmlNode item in node)
                {
                    var method = typeof(XmlContext).GetMethod(nameof(XmlContext.Read), 
                        BindingFlags.NonPublic | BindingFlags.Instance);
                    var generic = method!.MakeGenericMethod(innerType);
                    object[] parameters = new object[] { item, innerType.Name, true };
                    var itemConverted = generic.Invoke(this, parameters);
                    enumerable!.GetType().GetMethod("Add")!.Invoke(enumerable, new[] { itemConverted });
                }
                return (T?)enumerable;
            }
            else
            {
                if (node[typeName] != null)
                    type = Type.GetType(node[typeName]!.InnerText)!;
                if (type.IsAbstract)
                {
                    throw new InvalidOperationException("Unable to create an object from the node.\n" +
                        "More likely, your type is an interface or an abstract class" +
                        " and no <type> child node was specified");
                }
                object obj = (T)Activator.CreateInstance(type)!;
                foreach (var prop in type.GetProperties())
                {
                    if (!prop.CustomAttributes.Any(a => a.AttributeType == typeof(XmlIgnoreAttribute)))
                    {
                        var method = typeof(XmlContext).GetMethod(nameof(XmlContext.Read), 
                            BindingFlags.NonPublic | BindingFlags.Instance);
                        var generic = method!.MakeGenericMethod(prop.PropertyType);
                        object?[] parameters = new object?[] 
                        { node[prop.Name.FirstToLower()], prop.PropertyType.ToString(), true };
                        var itemConverted = generic.Invoke(this, parameters);
                        if (itemConverted != default)
                            prop.SetValue(obj, itemConverted, null);
                    }
                }
                return (T?)obj;
            }
    }
}