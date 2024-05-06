using QuizDemo.DataAccess.Entities;

namespace QuizDemo.DataAccess.Repositories;

public interface IPresignedUrlRepository
{
    Task<PresignedUrlEntity[]> GetByPresignedUrl(string presignedUrl);
    Task<Guid> Create(PresignedUrlEntity entity);
}