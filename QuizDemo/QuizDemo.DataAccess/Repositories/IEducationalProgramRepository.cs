using QuizDemo.DataAccess.Entities;

namespace QuizDemo.DataAccess.Repositories;

public interface IEducationalProgramRepository
{
    Task<EducationalProgramEntity[]> GetAll();
    Task<EducationalProgramEntity> GetById(Guid id);
    Task Create(EducationalProgramEntity entity);
}