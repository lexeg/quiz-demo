using QuizDemo.Messages;
using QuizDemo.Models;

namespace QuizDemo.Services;

public class QuizesService : IQuizesService
{
    public Task<QuizResponse[]> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<QuizResponse> GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task Create(CreateQuizModel createQuizModel)
    {
        throw new NotImplementedException();
    }
}