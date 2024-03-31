using QuizDemo.Models;

namespace QuizDemo.Messages;

public class QuizDetailedResponse
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public QuestionDetailedModel[] Questions { get; set; }
}