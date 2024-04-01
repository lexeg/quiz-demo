namespace QuizDemo.Models;

public class CreateCandidateResultModel
{
    public Guid TestId { get; set; }

    public string Email { get; set; }

    public CandidateAnswerModel[] Answers { get; set; }
}