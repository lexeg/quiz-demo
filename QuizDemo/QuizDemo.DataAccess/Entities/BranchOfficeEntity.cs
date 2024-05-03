namespace QuizDemo.DataAccess.Entities;

public class BranchOfficeEntity
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Prefix { get; set; }

    public virtual ICollection<TestResultEntity> TestResults { get; set; } = new List<TestResultEntity>();
}