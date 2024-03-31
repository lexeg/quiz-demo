namespace QuizDemo.Models;

public class QuestionModel
{
    public Guid TestId { get; set; }

    public string Question { get; set; }

    public AnswerModel[] Answers { get; set; }
}