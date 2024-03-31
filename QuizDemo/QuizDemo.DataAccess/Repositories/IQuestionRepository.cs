using QuizDemo.DataAccess.Entities;

namespace QuizDemo.DataAccess.Repositories;

public interface IQuestionRepository
{
    Task<QuestionEntity[]> GetByTestId(Guid id);
    Task Create(QuestionEntity entity);
}