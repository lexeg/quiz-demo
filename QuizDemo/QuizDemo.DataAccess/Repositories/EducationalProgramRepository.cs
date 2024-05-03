using Microsoft.EntityFrameworkCore;
using QuizDemo.DataAccess.Contexts;
using QuizDemo.DataAccess.Entities;

namespace QuizDemo.DataAccess.Repositories;

public class EducationalProgramRepository : IEducationalProgramRepository
{
    private readonly QuizDbContext _quizDbContext;

    public EducationalProgramRepository(QuizDbContext quizDbContext)
    {
        _quizDbContext = quizDbContext;
    }

    public Task<EducationalProgramEntity[]> GetAll() => _quizDbContext.EducationalPrograms.ToArrayAsync();

    public Task<EducationalProgramEntity> GetById(Guid id) =>
        _quizDbContext.EducationalPrograms.FirstOrDefaultAsync(x => x.ExternalId == id);

    public Task Create(EducationalProgramEntity entity)
    {
        _quizDbContext.EducationalPrograms.Add(entity);
        return _quizDbContext.SaveChangesAsync();
    }
}