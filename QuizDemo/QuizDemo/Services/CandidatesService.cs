using AutoMapper;
using QuizDemo.DataAccess.Entities;
using QuizDemo.DataAccess.Repositories;
using QuizDemo.Messages;
using QuizDemo.Models;

namespace QuizDemo.Services;

public class CandidatesService : ICandidatesService
{
    private readonly ITestResultRepository _testResultRepository;
    private readonly IMapper _mapper;

    public CandidatesService(ITestResultRepository testResultRepository, IMapper mapper)
    {
        _testResultRepository = testResultRepository;
        _mapper = mapper;
    }

    public async Task<CandidateResultResponse[]> GetResults()
    {
        var entities = await _testResultRepository.GetDetailedAll();
        return entities.Select(x => _mapper.Map<CandidateResultResponse>(x)).ToArray();
    }

    public async Task<CandidateResultResponse> GetResultsById(Guid id)
    {
        var entity = await _testResultRepository.GetDetailedById(id);
        return _mapper.Map<CandidateResultResponse>(entity);
    }

    public Task SaveCandidateResult(CreateCandidateResultModel model)
    {
        return _testResultRepository.Create(_mapper.Map<TestResultEntity>(model));
    }
}