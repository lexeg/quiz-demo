using QuizDemo.DataAccess.Entities;

namespace QuizDemo.DataAccess.Repositories;

public interface IBranchOfficeRepository
{
    Task<BranchOfficeEntity[]> GetAll();
    Task<BranchOfficeEntity> GetById(Guid id);
    Task Create(BranchOfficeEntity entity);
}