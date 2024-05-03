namespace QuizDemo.Messages;

public class CreateEducationalProgramRequest
{
    public Guid ExternalId { get; set; }

    public string Name { get; set; }
}