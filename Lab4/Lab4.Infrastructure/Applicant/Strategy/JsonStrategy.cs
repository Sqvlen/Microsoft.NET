using System.Reflection;
using Newtonsoft.Json;

namespace Lab4.Infrastructure.Applicant.Strategy;

public class JsonStrategy : IApplicantStrategy
{
    public void DoLog(ApplicantModel applicantModel)
    {
        var fileName = Assembly.GetExecutingAssembly().GetName().Name + ".json";
        
        var json = JsonConvert.SerializeObject(applicantModel);
        
        File.WriteAllText(fileName, json);

        Console.WriteLine($"Saved as JSON - {fileName}");
    }
}