namespace Lab4.Infrastructure.Applicant.PolymorphicFactoryMethod;

public interface ILogger
{
    void Save(ApplicantEntity applicantEntity, string fileName);
}