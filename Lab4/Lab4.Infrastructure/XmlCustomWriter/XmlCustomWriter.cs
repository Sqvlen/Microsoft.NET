using System.Xml;

namespace Lab4.Infrastructure.XmlCustomWriter;

public abstract class XmlCustomWriter
{
    public class XmlWriterParams
    {
        public required object Data { get; init; }
        public required string FileName { get; init; }
        public required string XmlSectionName { get; init; }
        public XmlWriterSettings? Settings { get; set; }
    }
    
    public static void Write(XmlWriterParams xmlWriterParams)
    {
        xmlWriterParams.Settings ??= new() { Indent = true };

        using var xmlWriter = XmlWriter.Create(xmlWriterParams.FileName, xmlWriterParams.Settings);
        Write(xmlWriterParams.Data, xmlWriter, xmlWriterParams.XmlSectionName);
    }

    public static void Write(object obj, XmlWriter? xmlWriter, string name)
    {
        if (xmlWriter is null)
            throw new InvalidOperationException("Create the XmlWriter before to use XmlCustomWriter");

        if (obj is not IEnumerable<object> objects)
            return;

        objects.TryGetNonEnumeratedCount(out var count);

        if (count < 0)
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
            WriteElement(item, xmlWriter, innerType.Name, innerType, innerType != itemType);
        }

        xmlWriter.WriteEndElement();
    }

    public static void WriteElement(object obj, XmlWriter? xmlWriter, string name, Type type, bool writeString)
    {
        if (xmlWriter is null)
            throw new InvalidOperationException("Create the XmlWriter before to use XmlCustomWriter");

        if (obj is IEnumerable<object>)
            Write(obj, xmlWriter, name);
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
                    WriteElement(value, xmlWriter, prop.Name, prop.PropertyType,
                        prop.PropertyType.IsInterface);
                }
            }

            xmlWriter.WriteEndElement();
        }
    }
}