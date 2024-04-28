using Newtonsoft.Json;

namespace Lab4.Infrastructure.Applicant.PolymorphicFactoryMethod;

public class JsonLogger : ILogger
{
    public void Save(ApplicantEntity applicantEntity, string fileName)
    {
        var json = JsonConvert.SerializeObject(applicantEntity);
        
        File.WriteAllText(fileName + ".json", json);

        Console.WriteLine($"Saved as JSON - {fileName}");
    }
}