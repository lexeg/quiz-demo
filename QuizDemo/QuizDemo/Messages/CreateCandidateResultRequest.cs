using QuizDemo.Models;

namespace QuizDemo.Messages;

public class CreateCandidateResultRequest
{
    public Guid TestId { get; set; }

    public string Email { get; set; }

    public CandidateAnswerModel[] Answers { get; set; }
}