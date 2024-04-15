using Lab4.Infrastructure.Applicant.Builder;
using Lab4.Infrastructure.Applicant.Enums;
using Lab4.Infrastructure.Applicant.Strategy;

namespace Lab4.Console.Extensions;

public class MenuExtensions
{
    public void Process()
    {
        var applicantEntity = new ApplicantBuilder()
            .SetFirstName("First name")
            .SetLastName("Second name")
            .SetMiddleName("Middle name")
            .SetDateOfBirth(DateTime.UtcNow)
            .AddExamResult(192, "Math")
            .AddExamResult(190, "Ukrainian")
            .AddExamResult(200, "History of Ukraine")
            .AddSpeciality("Speciality 1")
            .AddSpeciality("Speciality 2")
            .AddSpeciality("Speciality 3")
            .SetEducationLevel(EducationLevel.Bachelor)
            .SetStudyForm(StudyForm.StateFunded)
            .Build();

        var context = new ApplicantContext();
        
        do
        {
            System.Console.WriteLine("Save and output as:\n1. JSON\n2. Xml\n3. Console");
            var input = System.Console.ReadLine();
            switch (input)
            {
                case "1":
                    context.SetStrategy(new JsonStrategy());
                    break;
                case "2":
                    context.SetStrategy(new XmlStrategy());
                    break;
                case "3":
                    context.SetStrategy(new ConsoleStrategy());
                    break;
            }
            
            context.SaveAndOutputLogic(applicantEntity);
        } while (true);
    }
}