using Microsoft.EntityFrameworkCore;
using QuizDemo.DataAccess.Contexts;
using QuizDemo.DataAccess.Entities;

namespace QuizDemo.DataAccess.Repositories;

public class PresignedUrlRepository : IPresignedUrlRepository
{
    private readonly QuizDbContext _quizDbContext;

    public PresignedUrlRepository(QuizDbContext quizDbContext)
    {
        _quizDbContext = quizDbContext;
    }

    public Task<PresignedUrlEntity[]> GetByPresignedUrl(string presignedUrl) =>
        _quizDbContext
            .PresignedUrls
            .Where(x => x.PresignedUrl.Equals(presignedUrl, StringComparison.OrdinalIgnoreCase))
            .ToArrayAsync();

    public async Task<Guid> Create(PresignedUrlEntity entity)
    {
        if (entity.Id == Guid.Empty) entity.Id = Guid.NewGuid();
        _quizDbContext.PresignedUrls.Add(entity);
        await _quizDbContext.SaveChangesAsync();
        return entity.Id;
    }
}