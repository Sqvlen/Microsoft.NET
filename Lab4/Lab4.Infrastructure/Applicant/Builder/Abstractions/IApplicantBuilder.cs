using Lab4.Infrastructure.Applicant.Enums;

namespace Lab4.Infrastructure.Applicant.Builder.Abstractions;

public interface IApplicantBuilder
{
    void Reset();
    IApplicantBuilder SetFirstName(string firstName);
    IApplicantBuilder SetLastName(string lastName);
    IApplicantBuilder SetMiddleName(string middleName);
    IApplicantBuilder SetDateOfBirth(DateTime dateOfBirth);
    IApplicantBuilder AddExamResult(int scores, string subject);
    IApplicantBuilder AddSpeciality(string speciality);
    IApplicantBuilder SetEducationLevel(EducationLevel educationLevel);
    IApplicantBuilder SetStudyForm(StudyForm studyForm);
    ApplicantModel Build();
}