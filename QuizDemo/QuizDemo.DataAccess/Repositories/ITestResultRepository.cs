using QuizDemo.DataAccess.DataModels;
using QuizDemo.DataAccess.Entities;

namespace QuizDemo.DataAccess.Repositories;

public interface ITestResultRepository
{
    Task<TestResultEntity[]> GetAll();
    Task<TestResultDataModel[]> GetDetailedAll();
    Task<TestResultEntity> GetById(Guid id);
    Task<TestResultDataModel> GetDetailedById(Guid id);
    Task Create(TestResultEntity entity);
}