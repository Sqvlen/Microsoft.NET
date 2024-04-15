using System.Text;
using Lab4.Infrastructure.Applicant.Enums;
using Lab4.Infrastructure.Database;

namespace Lab4.Infrastructure.Applicant;

public class ApplicantEntity : BaseEntity<long>
{
    public string LastName { get; set; }
    
    public string FirstName { get; set; }
    
    public string MiddleName { get; set; }
    
    public DateTime DateOfBirthday { get; set; } // replace to DateOnly

    public Dictionary<string, float> ExamsResults { get; } = new();

    public List<string> Specialties { get; } = new();
    
    public EducationLevel EducationLevel { get; set; }
    
    public StudyForm StudyForm { get; set; }

    public override string ToString()
    {
        var stringBuilder = new StringBuilder();

        stringBuilder.AppendLine($"First name - {FirstName}");
        stringBuilder.AppendLine($"Middle name - {MiddleName}");
        stringBuilder.AppendLine($"Last name - {LastName}");
        stringBuilder.AppendLine($"Date: {DateOfBirthday}");

        if (ExamsResults.Any())
        {
            stringBuilder.AppendLine("Exams results:");
            foreach (var keyValuePairResult in ExamsResults)
            {
                stringBuilder.AppendLine($"{keyValuePairResult.Key} - {keyValuePairResult.Value}");
            }
        }

        if (Specialties.Any())
        {
            stringBuilder.Append("Specialties: ");
            foreach (var speciality in Specialties)
            {
                stringBuilder.Append($"{speciality}, ");
            }

            stringBuilder.AppendLine();
        }

        stringBuilder.AppendLine($"Education level: {EducationLevel.ToString()}");
        stringBuilder.AppendLine($"Study form: {StudyForm.ToString()}");
        
        return stringBuilder.ToString();
    }
}