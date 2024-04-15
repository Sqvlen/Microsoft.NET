namespace Lab4.Infrastructure.Applicant.Strategy;

public class ConsoleStrategy : IApplicantStrategy
{
    public void DoLog(ApplicantModel applicantModel)
    {
        Console.WriteLine(applicantModel.ToString());
    }
}