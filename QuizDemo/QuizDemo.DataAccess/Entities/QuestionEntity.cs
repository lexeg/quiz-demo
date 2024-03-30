namespace QuizDemo.DataAccess.Entities;

public class QuestionEntity
{
    public Guid Id { get; set; }

    public Guid TestId { get; set; }

    public string Question { get; set; }

    public string Answers { get; set; }

    public virtual TestEntity Test { get; set; }
}