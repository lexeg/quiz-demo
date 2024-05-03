namespace QuizDemo.DataAccess.Entities;

public class TestResultEntity
{
    public Guid Id { get; set; }

    public Guid TestId { get; set; }

    public Guid BranchOfficeId { get; set; }

    public Guid EducationalProgramId { get; set; }

    public string Email { get; set; }

    public string FullName { get; set; }

    public string MobilePhone { get; set; }

    public string PresignedUrl { get; set; }

    public DateTime ExpiredDate { get; set; }

    public string Answers { get; set; }

    public virtual TestEntity Test { get; set; }

    public virtual BranchOfficeEntity BranchOffice { get; set; }

    public virtual EducationalProgramEntity EducationalProgram { get; set; }
}