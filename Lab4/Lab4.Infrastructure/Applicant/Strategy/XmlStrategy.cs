using System.Reflection;
using System.Xml.Serialization;

namespace Lab4.Infrastructure.Applicant.Strategy;

public class XmlStrategy : IApplicantStrategy
{
    public void DoLog(ApplicantModel applicantModel)
    {
        var fileName = Assembly.GetExecutingAssembly().GetName().Name + ".xml";
        var serializer = new XmlSerializer(typeof(ApplicantModel));
        using var writer = new StreamWriter(fileName);
        serializer.Serialize(writer, applicantModel);

        Console.WriteLine($"Saved as Xml - {fileName}");
    }
}