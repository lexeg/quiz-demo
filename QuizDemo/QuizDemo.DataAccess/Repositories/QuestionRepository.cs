using Microsoft.EntityFrameworkCore;
using QuizDemo.DataAccess.Contexts;
using QuizDemo.DataAccess.Entities;

namespace QuizDemo.DataAccess.Repositories;

public class QuestionRepository : IQuestionRepository
{
    private readonly QuizDbContext _quizDbContext;

    public QuestionRepository(QuizDbContext quizDbContext)
    {
        _quizDbContext = quizDbContext;
    }

    public Task<QuestionEntity[]> GetByTestId(Guid id) =>
        _quizDbContext.Questions.Where(x => x.TestId == id).ToArrayAsync();

    public Task Create(QuestionEntity entity)
    {
        _quizDbContext.Questions.Add(entity);
        return _quizDbContext.SaveChangesAsync();
    }
}