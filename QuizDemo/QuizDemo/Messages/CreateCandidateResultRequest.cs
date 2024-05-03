using QuizDemo.Models;

namespace QuizDemo.Messages;

public class CreateCandidateResultRequest
{
    public Guid TestId { get; set; }

    public Guid BranchOfficeId { get; set; }

    public Guid EducationalProgramId { get; set; }

    public string Email { get; set; }

    public string FullName { get; set; }

    public string MobilePhone { get; set; }

    public CandidateAnswerModel[] Answers { get; set; }
}