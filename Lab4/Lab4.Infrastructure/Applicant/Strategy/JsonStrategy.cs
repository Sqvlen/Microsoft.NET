using System.Reflection;
using Newtonsoft.Json;

namespace Lab4.Infrastructure.Applicant.Strategy;

public class JsonStrategy : IApplicantStrategy
{
    public void DoLog(ApplicantEntity applicantEntity)
    {
        var fileName = Assembly.GetExecutingAssembly().GetName().Name + ".json";
        
        var json = JsonConvert.SerializeObject(applicantEntity);
        
        File.WriteAllText(fileName, json);

        Console.WriteLine($"Saved as JSON - {fileName}");
    }
}