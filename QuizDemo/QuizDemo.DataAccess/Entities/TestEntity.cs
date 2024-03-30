namespace QuizDemo.DataAccess.Entities;

public class TestEntity
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public virtual ICollection<QuestionEntity> QuestionsTables { get; set; } = new List<QuestionEntity>();

    public virtual TestResultEntity TestResultEntity { get; set; }
}