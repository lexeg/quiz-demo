namespace QuizDemo.DataAccess.Entities;

public class TestResultEntity
{
    public Guid Id { get; set; }

    public Guid TestId { get; set; }

    public string Email { get; set; }

    public string Answers { get; set; }

    public virtual TestEntity Test { get; set; }
}