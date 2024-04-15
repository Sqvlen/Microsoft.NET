using System.Reflection;
using System.Xml.Serialization;

namespace Lab4.Infrastructure.Applicant.Strategy;

public class XmlStrategy : IApplicantStrategy
{
    public void DoLog(ApplicantEntity applicantEntity)
    {
        var fileName = Assembly.GetExecutingAssembly().GetName().Name + ".xml";
        var serializer = new XmlSerializer(typeof(ApplicantEntity));
        using var writer = new StreamWriter(fileName);
        serializer.Serialize(writer, applicantEntity);

        Console.WriteLine($"Saved as Xml - {fileName}");
    }
}