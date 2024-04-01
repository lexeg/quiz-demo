using QuizDemo.Models;

namespace QuizDemo.Messages;

public class CandidateResultResponse
{
    public Guid Id { get; set; }

    public Guid TestId { get; set; }

    public string TestName { get; set; }

    public string Email { get; set; }

    public QuestionResultModel[] Questions { get; set; }
}