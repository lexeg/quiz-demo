namespace QuizDemo.Models;

public class CreateCandidateResultModel
{
    public Guid TestId { get; set; }

    public Guid BranchOfficeId { get; set; }

    public Guid EducationalProgramId { get; set; }

    public string Email { get; set; }

    public string FullName { get; set; }

    public string MobilePhone { get; set; }

    public CandidateAnswerModel[] Answers { get; set; }
}