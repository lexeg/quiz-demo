namespace QuizDemo.Models;

public class QuestionDetailedModel
{
    public Guid Id { get; set; }

    public Guid TestId { get; set; }

    public string Question { get; set; }

    public AnswerModel[] Answers { get; set; }
}