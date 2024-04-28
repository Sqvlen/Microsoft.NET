namespace Lab4.Infrastructure.Applicant.PolymorphicFactoryMethod;

public class XmlLogger : ILogger
{
    public void Save(ApplicantEntity applicantEntity, string fileName)
    {
        XmlCustomWriter.XmlCustomWriter.Write(new XmlCustomWriter.XmlCustomWriter.XmlWriterParams()
        {
            Data = new List<ApplicantEntity>() { applicantEntity }, FileName = fileName + ".xml",
            XmlSectionName = "Applicant"
        });

        Console.WriteLine($"Save as XML - {fileName}");
    }
}