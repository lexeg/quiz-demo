namespace QuizDemo.DataAccess.DataModels;

public class TestResultDataModel
{
    public Guid Id { get; set; }

    public Guid TestId { get; set; }

    public string TestName { get; set; }

    public string Email { get; set; }

    public QuestionResultDataModel[] Questions { get; set; }
}