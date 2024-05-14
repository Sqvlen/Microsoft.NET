using System.Reflection;
using Lab4.Infrastructure.Applicant.Builder;
using Lab4.Infrastructure.Applicant.Enums;
using Lab4.Infrastructure.Applicant.PolymorphicFactoryMethod;

namespace Lab4.Console.Extensions;

public class MenuExtensions
{
    public void Process()
    {
        var fileName = Assembly.GetExecutingAssembly().GetName().Name;
        
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
        
        do
        {
            System.Console.WriteLine("Save and output as:\n1. JSON\n2. Xml\n3. Console");
            var input = System.Console.ReadLine();
            ILogger logger = new ConsoleLogger();
            switch (input)
            {
                case "1":
                    logger = LoggerProviderFactory.GetLoggingProvider(LoggerProviderFactory.LoggingProvider.Json);
                    break;
                case "2":
                    logger = LoggerProviderFactory.GetLoggingProvider(LoggerProviderFactory.LoggingProvider.Xml);
                    break;
                case "3":
                    logger = LoggerProviderFactory.GetLoggingProvider(LoggerProviderFactory.LoggingProvider.Console);
                    break;
                case "q":
                    return;
            }
            
            logger.Save(applicantEntity, fileName!);
        } while (true);
    }
}