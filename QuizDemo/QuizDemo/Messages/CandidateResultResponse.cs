using QuizDemo.Models;

namespace QuizDemo.Messages;

public class CandidateResultResponse
{
    public Guid Id { get; set; }

    public Guid TestId { get; set; }

    public string TestName { get; set; }

    public Guid BranchOfficeId { get; set; }

    public string BranchOfficeName { get; set; }

    public Guid EducationalProgramId { get; set; }

    public string EducationalProgramName { get; set; }

    public string Email { get; set; }

    public string FullName { get; set; }

    public string MobilePhone { get; set; }

    public string PresignedUrl { get; set; }

    public DateTime ExpiredDate { get; set; }

    public QuestionResultModel[] Questions { get; set; }
}