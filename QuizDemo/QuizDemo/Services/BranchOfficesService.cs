using AutoMapper;
using QuizDemo.DataAccess.Entities;
using QuizDemo.DataAccess.Repositories;
using QuizDemo.Messages;
using QuizDemo.Models;

namespace QuizDemo.Services;

public class BranchOfficesService : IBranchOfficesService
{
    private readonly IBranchOfficeRepository _branchOfficeRepository;
    private readonly IMapper _mapper;

    public BranchOfficesService(IBranchOfficeRepository branchOfficeRepository, IMapper mapper)
    {
        _branchOfficeRepository = branchOfficeRepository;
        _mapper = mapper;
    }

    public async Task<BranchOfficeResponse[]> GetAll()
    {
        var entities = await _branchOfficeRepository.GetAll();
        return entities.Select(x => _mapper.Map<BranchOfficeResponse>(x)).ToArray();
    }

    public async Task<BranchOfficeResponse> GetById(Guid id)
    {
        var entity = await _branchOfficeRepository.GetById(id);
        return _mapper.Map<BranchOfficeResponse>(entity);
    }

    public Task Create(CreateBranchOfficeModel model)
    {
        return _branchOfficeRepository.Create(_mapper.Map<BranchOfficeEntity>(model));
    }
}