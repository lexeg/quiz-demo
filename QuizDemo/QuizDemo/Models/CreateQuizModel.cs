namespace QuizDemo.Models;

public class CreateQuizModel
{
    public string Name { get; set; }

    public string Description { get; set; }

    public QuestionModel[] Questions { get; set; }
}