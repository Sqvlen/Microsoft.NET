using System.Text;
using Lab4.Infrastructure.Applicant.Enums;

namespace Lab4.Infrastructure.Applicant.PolymorphicFactoryMethod;

public class ConsoleLogger : ILogger
{
    public void Save(ApplicantEntity applicantEntity, string fileName)
    {
        var stringBuilder = new StringBuilder();
        
        stringBuilder.AppendLine($"First name - {applicantEntity.FirstName}");
        stringBuilder.AppendLine($"Middle name - {applicantEntity.MiddleName}");
        stringBuilder.AppendLine($"Last name - {applicantEntity.LastName}");
        stringBuilder.AppendLine($"Date: {applicantEntity.DateOfBirthday}");
        
        if (applicantEntity.ExamsResults.Any())
        {
            stringBuilder.AppendLine("Exams results:");
            foreach (var keyValuePairResult in applicantEntity.ExamsResults)
            {
                stringBuilder.AppendLine($"{keyValuePairResult.Key} - {keyValuePairResult.Value}");
            }
        }
        
        if (applicantEntity.Specialties.Any())
        {
            stringBuilder.Append("Specialties: ");
            foreach (var speciality in applicantEntity.Specialties)
            {
                stringBuilder.Append($"{speciality}, ");
            }
        
            stringBuilder.AppendLine();
        }
        
        stringBuilder.AppendLine($"Education level: {applicantEntity.EducationLevel.ToString()}");
        stringBuilder.AppendLine($"Study form: {applicantEntity.StudyForm.ToString()}");

        Console.WriteLine(stringBuilder.ToString());
    }
}