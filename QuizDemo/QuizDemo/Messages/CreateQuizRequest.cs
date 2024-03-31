using QuizDemo.Models;

namespace QuizDemo.Messages;

public class CreateQuizRequest
{
    public string Name { get; set; }

    public string Description { get; set; }

    public QuestionModel[] Questions { get; set; }
}