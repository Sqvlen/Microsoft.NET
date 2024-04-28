using Lab4.Infrastructure.Applicant.Builder.Abstractions;
using Lab4.Infrastructure.Applicant.Enums;

namespace Lab4.Infrastructure.Applicant.Builder;

public class ApplicantBuilder : IApplicantBuilder
{
    private ApplicantEntity _applicantEntity = new ApplicantEntity();

    public ApplicantBuilder()
    {
        Reset();
    }

    public void Reset()
    {
        _applicantEntity = new ApplicantEntity();
    }

    public IApplicantBuilder SetFirstName(string firstName)
    {
        _applicantEntity.FirstName = firstName;
        return this;
    }

    public IApplicantBuilder SetLastName(string lastName)
    {
        _applicantEntity.LastName = lastName;
        return this;
    }

    public IApplicantBuilder SetMiddleName(string middleName)
    {
        _applicantEntity.MiddleName = middleName;
        return this;
    }

    public IApplicantBuilder SetDateOfBirth(DateTime dateOfBirth)
    {
        _applicantEntity.DateOfBirthday = dateOfBirth;
        return this;
    }

    public IApplicantBuilder AddExamResult(int scores, string subject)
    {
        _applicantEntity.ExamsResults.Add(subject, scores);
        return this;
    }

    public IApplicantBuilder AddSpeciality(string speciality)
    {
        _applicantEntity.Specialties.Add(speciality);
        return this;
    }

    public IApplicantBuilder SetEducationLevel(EducationLevel educationLevel)
    {
        _applicantEntity.EducationLevel = educationLevel;
        return this;
    }

    public IApplicantBuilder SetStudyForm(StudyForm studyForm)
    {
        _applicantEntity.StudyForm = studyForm;
        return this;
    }

    public ApplicantEntity Build()
    {
        return _applicantEntity;
    }
}