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
    private readonly IMapper _mapper;

    public QuizesService(ITestRepository testRepository, IQuestionRepository questionRepository, IMapper mapper)
    {
        _testRepository = testRepository;
        _questionRepository = questionRepository;
        _mapper = mapper;
    }

    public async Task<QuizResponse[]> GetAll()
    {
        var entities = await _testRepository.GetAll();
        return entities.Select(x => _mapper.Map<QuizResponse>(x)).ToArray();
    }

    public async Task<QuizResponse> GetById(Guid id)
    {
        var entity = await _testRepository.GetById(id);
        return _mapper.Map<QuizResponse>(entity);
    }

    public async Task Create(CreateQuizModel createQuizModel)
    {
        await _testRepository.Create(_mapper.Map<TestEntity>(createQuizModel));
        await _questionRepository.CreateMany(createQuizModel.Questions
            .Select(x => _mapper.Map<QuestionEntity>(x))
            .ToArray());
    }
}