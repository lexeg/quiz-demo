using Microsoft.EntityFrameworkCore;
using QuizDemo.DataAccess.Contexts;
using QuizDemo.DataAccess.Entities;

namespace QuizDemo.DataAccess.Repositories;

public class BranchOfficeRepository : IBranchOfficeRepository
{
    private readonly QuizDbContext _quizDbContext;

    public BranchOfficeRepository(QuizDbContext quizDbContext)
    {
        _quizDbContext = quizDbContext;
    }

    public Task<BranchOfficeEntity[]> GetAll() => _quizDbContext.BranchOffices.ToArrayAsync();

    public Task<BranchOfficeEntity> GetById(Guid id) =>
        _quizDbContext.BranchOffices.FirstOrDefaultAsync(x => x.Id == id);

    public Task Create(BranchOfficeEntity entity)
    {
        if (entity.Id == Guid.Empty) entity.Id = Guid.NewGuid();
        _quizDbContext.BranchOffices.Add(entity);
        return _quizDbContext.SaveChangesAsync();
    }
}