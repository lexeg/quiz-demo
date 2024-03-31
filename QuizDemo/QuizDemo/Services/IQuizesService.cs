using QuizDemo.Messages;
using QuizDemo.Models;

namespace QuizDemo.Services;

public interface IQuizesService
{
    Task<QuizResponse[]> GetAll();
    Task<QuizDetailedResponse> GetById(Guid id);
    Task Create(CreateQuizModel createQuizModel);
}