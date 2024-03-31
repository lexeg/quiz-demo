using QuizDemo.DataAccess.Entities;

namespace QuizDemo.DataAccess.Repositories;

public interface ITestRepository
{
    Task<TestEntity[]> GetAll();
    Task<TestEntity> GetById(Guid id);
    Task<Guid> Create(TestEntity entity);
}