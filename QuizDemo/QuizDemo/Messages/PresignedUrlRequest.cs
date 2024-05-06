using Microsoft.AspNetCore.Mvc;

namespace QuizDemo.Messages;

public class PresignedUrlRequest
{
    [FromQuery(Name = "branch-office")]
    public Guid BranchOfficeId { get; set; }

    [FromQuery(Name = "educational-program")]
    public Guid EducationalProgramId { get; set; }

    [FromQuery(Name = "test")]
    public Guid TestId { get; set; }
}