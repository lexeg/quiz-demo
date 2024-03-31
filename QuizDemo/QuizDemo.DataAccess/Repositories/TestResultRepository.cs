using Microsoft.EntityFrameworkCore;
using QuizDemo.DataAccess.Contexts;
using QuizDemo.DataAccess.Entities;

namespace QuizDemo.DataAccess.Repositories;

public class TestResultRepository : ITestResultRepository
{
    private readonly QuizDbContext _quizDbContext;

    public TestResultRepository(QuizDbContext quizDbContext)
    {
        _quizDbContext = quizDbContext;
    }

    public Task<TestResultEntity[]> GetAll() => _quizDbContext.TestResults.ToArrayAsync();

    public Task<TestResultEntity> GetById(Guid id) => _quizDbContext.TestResults.FirstOrDefaultAsync(x => x.Id == id);

    public Task Create(TestResultEntity entity)
    {
        _quizDbContext.TestResults.Add(entity);
        return _quizDbContext.SaveChangesAsync();
    }
}