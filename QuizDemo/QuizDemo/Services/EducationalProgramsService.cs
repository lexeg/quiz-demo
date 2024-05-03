using AutoMapper;
using QuizDemo.DataAccess.Entities;
using QuizDemo.DataAccess.Repositories;
using QuizDemo.Messages;
using QuizDemo.Models;

namespace QuizDemo.Services;

public class EducationalProgramsService : IEducationalProgramsService
{
    private readonly IEducationalProgramRepository _educationalProgramRepository;
    private readonly IMapper _mapper;

    public EducationalProgramsService(IEducationalProgramRepository educationalProgramRepository, IMapper mapper)
    {
        _educationalProgramRepository = educationalProgramRepository;
        _mapper = mapper;
    }

    public async Task<EducationalProgramResponse[]> GetAll()
    {
        var entities = await _educationalProgramRepository.GetAll();
        return entities.Select(x => _mapper.Map<EducationalProgramResponse>(x)).ToArray();
    }

    public async Task<EducationalProgramResponse> GetById(Guid id)
    {
        var entity = await _educationalProgramRepository.GetById(id);
        return _mapper.Map<EducationalProgramResponse>(entity);
    }

    public Task Create(CreateEducationalProgramModel model)
    {
        return _educationalProgramRepository.Create(_mapper.Map<EducationalProgramEntity>(model));
    }
}