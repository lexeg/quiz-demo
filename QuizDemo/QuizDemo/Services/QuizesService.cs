using AutoMapper;
using QuizDemo.DataAccess.Entities;
using QuizDemo.DataAccess.Repositories;
using QuizDemo.Messages;
using QuizDemo.Models;

namespace QuizDemo.Services;

public class QuizesService : IQuizesService
{
    private readonly ITestRepository _testRepository;
    private readonly IQuestionRepository _questionRepository;
    private readonly IPresignedUrlRepository _presignedUrlRepository;
    private readonly IMapper _mapper;

    public QuizesService(ITestRepository testRepository,
        IQuestionRepository questionRepository,
        IPresignedUrlRepository presignedUrlRepository,
        IMapper mapper)
    {
        _testRepository = testRepository;
        _questionRepository = questionRepository;
        _presignedUrlRepository = presignedUrlRepository;
        _mapper = mapper;
    }

    public async Task<QuizResponse[]> GetAll()
    {
        var entities = await _testRepository.GetAll();
        return entities.Select(x => _mapper.Map<QuizResponse>(x)).ToArray();
    }

    public async Task<QuizDetailedResponse> GetById(Guid id)
    {
        var entity = await _testRepository.GetById(id);
        return _mapper.Map<QuizDetailedResponse>(entity);
    }

    public async Task<QuizDetailedResponse> GetByPresignedUrl(string presignedUrl)
    {
        var presignedUrlEntity = (await _presignedUrlRepository.GetByPresignedUrl(presignedUrl))
            .FirstOrDefault(x => x.ExpiredDate >= DateTime.UtcNow);
        if (presignedUrlEntity == null) return null;
        return await GetById(presignedUrlEntity.TestId);
    }

    public async Task Create(CreateQuizModel createQuizModel)
    {
        var testId = await _testRepository.Create(_mapper.Map<TestEntity>(createQuizModel));
        foreach (var model in createQuizModel.Questions)
        {
            model.TestId = testId;
        }

        await _questionRepository.CreateMany(createQuizModel.Questions
            .Select(x => _mapper.Map<QuestionEntity>(x))
            .ToArray());
    }
}