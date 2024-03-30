using QuizDemo.Messages;
using QuizDemo.Models;

namespace QuizDemo.Services;

public interface ICandidatesService
{
    Task<CandidateResultResponse[]> GetResults();
    Task<CandidateResultResponse> GetResultsById(Guid id);
    Task SaveCandidateResult(CreateCandidateResultModel map);
}