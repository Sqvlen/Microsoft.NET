using System.Xml;
using System.Xml.Serialization;

namespace Routes.Xml.Core.Reader;

public class XmlCustomReader
{
    public T Read<T>(XmlReaderParams xmlReaderParams)
    {
        var xmlDocument = new XmlDocument();
        xmlDocument.Load(xmlReaderParams.FileName);

        return ReadNode<T>(xmlDocument.DocumentElement, xmlReaderParams.ElementName);
    }

    public T ReadNode<T>(XmlElement? element, string name)
    {
        if (element == null)
            return default!;

        var type = typeof(T);

        if (type.IsPrimitive || type.IsEnum || type == typeof(string))
            return ((T?)Convert.ChangeType(element.InnerText, type))!;

        if (typeof(IEnumerable<object>).IsAssignableFrom(type))
        {
            var innerType = type.GetGenericArguments()[0];

            var listType = typeof(List<>).MakeGenericType(innerType);
            var enumerable = Activator.CreateInstance(listType);

            foreach (var itemConverted in from XmlNode item in element
                     let method = typeof(XmlCustomReader).GetMethod(nameof(XmlCustomReader.ReadNode))
                     let generic = method!.MakeGenericMethod(innerType)
                     let parameters = new object[] { item, innerType.Name }
                     select generic.Invoke(this, parameters))
            {
                enumerable!.GetType().GetMethod("Add")!.Invoke(enumerable, new[] { itemConverted });
            }

            return ((T?)enumerable)!;
        }

        if (element["_type"] != null)
            type = Type.GetType(element["_type"]!.InnerText)!;

        if (type.IsAbstract)
            throw new InvalidOperationException();

        object obj = (T)Activator.CreateInstance(type)!;

        foreach (var prop in type.GetProperties())
        {
            if (prop.CustomAttributes.Any(a => a.AttributeType == typeof(XmlIgnoreAttribute)))
                continue;

            var method = typeof(XmlCustomReader).GetMethod(nameof(XmlCustomReader.ReadNode));
            var generic = method!.MakeGenericMethod(prop.PropertyType);

            object?[] parameters = [element[prop.Name], prop.PropertyType.ToString()];

            var itemConverted = generic.Invoke(this, parameters);
            if (itemConverted != default)
                prop.SetValue(obj, itemConverted, null);
        }

        return ((T?)obj)!;
    }
}