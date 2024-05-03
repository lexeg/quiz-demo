namespace QuizDemo.DataAccess.Entities;

public class EducationalProgramEntity
{
    public Guid ExternalId { get; set; }

    public string Name { get; set; }

    public virtual ICollection<TestResultEntity> TestResults { get; set; } = new List<TestResultEntity>();
}