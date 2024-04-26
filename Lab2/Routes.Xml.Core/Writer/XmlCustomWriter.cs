using System.Xml;

namespace Routes.Xml.Core.Writer;

public abstract class XmlCustomWriter
{
    private static XmlWriter? _xmlWriter;

    public void SetUp(XmlWriterParams xmlWriterParams)
    {
        xmlWriterParams.Settings ??= new() { Indent = true };

        _xmlWriter = XmlWriter.Create(xmlWriterParams.FileName, xmlWriterParams.Settings);
    }
    
    public static void Write<T>(XmlWriterParams xmlWriterParams)
    {
        xmlWriterParams.Settings ??= new() { Indent = true };

        using var xmlWriter = XmlWriter.Create(xmlWriterParams.FileName, xmlWriterParams.Settings);
        Write<T>(xmlWriterParams.Data, xmlWriter, xmlWriterParams.XmlSectionName);
    }

    public static void Write<T>(XmlElementParams xmlElementParams) =>
        Write<T>(xmlElementParams.Data, _xmlWriter, xmlElementParams.ElementName);

    public static void Write<T>(object obj, XmlWriter? xmlWriter, string name)
    {
        if (xmlWriter is null)
            throw new InvalidOperationException("Create the XmlWriter before to use XmlCustomWriter");

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

    public static void WriteElement<T>(XmlPropParams xmlPropParams) => WriteElement<T>(xmlPropParams.Data,
        _xmlWriter, xmlPropParams.ElementName, xmlPropParams.Type, xmlPropParams.WriteState);

    public static void WriteElement<T>(object obj, XmlWriter? xmlWriter, string name, Type type, bool writeString)
    {
        if (xmlWriter is null)
            throw new InvalidOperationException("Create the XmlWriter before to use XmlCustomWriter");

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
}