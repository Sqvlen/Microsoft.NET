using System.Xml;

namespace Routes.Xml.Core.Writer;

public class XmlWriterParams
{
    public required object Data { get; set; }
    
    public required string FileName { get; set; }

    public required string XmlSectionName { get; set; }

    public XmlWriterSettings? Settings { get; set; }
}