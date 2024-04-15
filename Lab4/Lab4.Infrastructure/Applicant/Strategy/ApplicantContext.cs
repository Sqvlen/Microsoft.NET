namespace Lab4.Infrastructure.Applicant.Strategy;

public class ApplicantContext
{
    private IApplicantStrategy _strategy = null!;
    
    public ApplicantContext()
    {
        
    }

    public ApplicantContext(IApplicantStrategy strategy)
    {
        _strategy = strategy;
    }
    
    public void SetStrategy(IApplicantStrategy strategy)
    {
        _strategy = strategy;
    }
    
    public void SaveAndOutputLogic(ApplicantModel applicantModel)
    {
        _strategy.DoLog(applicantModel);
    }
}