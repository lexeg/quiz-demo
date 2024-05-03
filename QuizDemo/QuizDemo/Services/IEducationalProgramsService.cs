using QuizDemo.Messages;
using QuizDemo.Models;

namespace QuizDemo.Services;

public interface IEducationalProgramsService
{
    Task<EducationalProgramResponse[]> GetAll();
    Task<EducationalProgramResponse> GetById(Guid id);
    Task Create(CreateEducationalProgramModel model);
}