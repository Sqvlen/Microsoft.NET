namespace Routes.Xml.Core.Writer;

public class XmlPropParams : XmlElementParams
{
    public required Type Type { get; set; }
    public bool WriteState { get; set; }
}

public class XmlElementParams
{
    public required object Data { get; set; }
    public required string ElementName { get; set; }
}