using QuizDemo.Messages;
using QuizDemo.Models;

namespace QuizDemo.Services;

public interface IBranchOfficesService
{
    Task<BranchOfficeResponse[]> GetAll();
    Task<BranchOfficeResponse> GetById(Guid id);
    Task Create(CreateBranchOfficeModel model);
}