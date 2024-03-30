using QuizDemo.Messages;
using QuizDemo.Models;

namespace QuizDemo.Services;

public class CandidatesService : ICandidatesService
{
    public Task<CandidateResultResponse[]> GetResults()
    {
        throw new NotImplementedException();
    }

    public Task<CandidateResultResponse> GetResultsById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task SaveCandidateResult(CreateCandidateResultModel map)
    {
        throw new NotImplementedException();
    }
}