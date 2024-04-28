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

    public ICollection<string> Specialties { get; } = new List<string>();
    
    public EducationLevel EducationLevel { get; set; }
    
    public StudyForm StudyForm { get; set; }
}