using Lab4.Infrastructure.Applicant.Builder.Abstractions;
using Lab4.Infrastructure.Applicant.Enums;

namespace Lab4.Infrastructure.Applicant.Builder;

public class ApplicantBuilder : IApplicantBuilder
{
    private readonly ApplicantModel _applicantModel = new ApplicantModel();
    
    public IApplicantBuilder SetFirstName(string firstName)
    {
        _applicantModel.FirstName = firstName;
        return this;
    }

    public IApplicantBuilder SetLastName(string lastName)
    {
        _applicantModel.LastName = lastName;
        return this;
    }

    public IApplicantBuilder SetMiddleName(string middleName)
    {
        _applicantModel.MiddleName = middleName;
        return this;
    }

    public IApplicantBuilder SetDateOfBirth(DateTime dateOfBirth)
    {
        _applicantModel.DateOfBirthday = dateOfBirth;
        return this;
    }

    public IApplicantBuilder AddExamResult(int scores, string subject)
    {
        _applicantModel.ExamsResults.Add(subject, scores);
        return this;
    }

    public IApplicantBuilder AddSpeciality(string speciality)
    {
        _applicantModel.Specialties.Add(speciality);
        return this;
    }

    public IApplicantBuilder SetEducationLevel(EducationLevel educationLevel)
    {
        _applicantModel.EducationLevel = educationLevel;
        return this;
    }

    public IApplicantBuilder SetStudyForm(StudyForm studyForm)
    {
        _applicantModel.StudyForm = studyForm;
        return this;
    }

    public ApplicantModel Build()
    {
        return _applicantModel;
    }
}