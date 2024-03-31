using Microsoft.EntityFrameworkCore;
using QuizDemo.DataAccess.Contexts;
using QuizDemo.DataAccess.Entities;

namespace QuizDemo.DataAccess.Repositories;

public class TestRepository : ITestRepository
{
    private readonly QuizDbContext _quizDbContext;

    public TestRepository(QuizDbContext quizDbContext)
    {
        _quizDbContext = quizDbContext;
    }

    public Task<TestEntity[]> GetAll() => _quizDbContext.Tests.ToArrayAsync();

    public Task<TestEntity> GetById(Guid id) => _quizDbContext.Tests.FirstOrDefaultAsync(x => x.Id == id);

    public Task Create(TestEntity entity)
    {
        _quizDbContext.Tests.Add(entity);
        return _quizDbContext.SaveChangesAsync();
    }
}