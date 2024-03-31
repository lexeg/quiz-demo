using QuizDemo.DataAccess.Entities;

namespace QuizDemo.DataAccess.Repositories;

public interface ITestResultRepository
{
    Task<TestResultEntity[]> GetAll();
    Task<TestResultEntity> GetById(Guid id);
    Task Create(TestResultEntity entity);
}