using QuizDemo.Messages;
using QuizDemo.Models;

namespace QuizDemo.Services;

public interface IQuizesService
{
    Task<QuizResponse[]> GetAll();
    Task<QuizDetailedResponse> GetById(Guid id);
    Task<QuizDetailedResponse> GetByPresignedUrl(string presignedUrl);
    Task Create(CreateQuizModel createQuizModel);
}