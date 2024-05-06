namespace QuizDemo.DataAccess.Entities;

public class PresignedUrlEntity
{
    public Guid Id { get; set; }

    public Guid BranchOfficeId { get; set; }

    public Guid EducationalProgramId { get; set; }

    public Guid TestId { get; set; }

    public string PresignedUrl { get; set; }

    public DateTime ExpiredDate { get; set; }

    public virtual BranchOfficeEntity BranchOffice { get; set; }

    public virtual EducationalProgramEntity EducationalProgram { get; set; }

    public virtual TestEntity Test { get; set; }
}