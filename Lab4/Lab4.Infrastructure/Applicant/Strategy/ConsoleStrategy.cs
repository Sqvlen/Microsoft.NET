namespace Lab4.Infrastructure.Applicant.Strategy;

public class ConsoleStrategy : IApplicantStrategy
{
    public void DoLog(ApplicantEntity applicantEntity)
    {
        Console.WriteLine(applicantEntity.ToString());
    }
}