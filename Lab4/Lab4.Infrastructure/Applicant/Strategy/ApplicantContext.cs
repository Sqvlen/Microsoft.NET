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
    
    public void SaveAndOutputLogic(ApplicantEntity applicantEntity)
    {
        _strategy.DoLog(applicantEntity);
    }
}