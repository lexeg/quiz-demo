namespace QuizDemo.DataAccess.DataModels;

public class QuestionResultDataModel
{
    public Guid QuestionId { get; set; }

    public string QuestionText { get; set; }

    public int AnswerId { get; set; }

    public string AnswerText { get; set; }

    public int CandidateAnswerId { get; set; }
}