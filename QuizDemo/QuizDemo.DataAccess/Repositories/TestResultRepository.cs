using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using QuizDemo.DataAccess.Contexts;
using QuizDemo.DataAccess.DataModels;
using QuizDemo.DataAccess.Entities;

namespace QuizDemo.DataAccess.Repositories;

public class TestResultRepository : ITestResultRepository
{
    private readonly QuizDbContext _quizDbContext;

    public TestResultRepository(QuizDbContext quizDbContext)
    {
        _quizDbContext = quizDbContext;
    }

    public Task<TestResultEntity[]> GetAll() => _quizDbContext.TestResults.ToArrayAsync();

    public Task<TestResultDataModel[]> GetDetailedAll()
    {
        return _quizDbContext.TestResults
            .Include(x => x.Test)
            .Select(x => new TestResultDataModel
            {
                Id = x.Id,
                TestId = x.TestId,
                TestName = x.Test.Name,
                Email = x.Email,
                Questions = CreateQuestions(x.Answers, x.Test.Questions),
            }).ToArrayAsync();
    }

    public Task<TestResultEntity> GetById(Guid id) => _quizDbContext.TestResults.FirstOrDefaultAsync(x => x.Id == id);

    public Task<TestResultDataModel> GetDetailedById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task Create(TestResultEntity entity)
    {
        if (entity.Id == Guid.Empty) entity.Id = Guid.NewGuid();
        _quizDbContext.TestResults.Add(entity);
        return _quizDbContext.SaveChangesAsync();
    }

    private static QuestionResultDataModel[] CreateQuestions(string answers, ICollection<QuestionEntity> questions)
    {
        var items = JsonConvert.DeserializeObject<CandidatesAnswerDataModel[]>(answers);
        return (from item in items
            let questionEntity = questions.Single(x => x.Id == item.QuestionId)
            let answersDataModel = JsonConvert.DeserializeObject<AnswersDataModel>(questionEntity.Answers)
            let model = answersDataModel.Answers.Single(x => x.Id == item.AnswerId)
            select new QuestionResultDataModel
            {
                QuestionId = questionEntity.Id,
                QuestionText = questionEntity.Question,
                AnswerId = answersDataModel.AnswerId,
                AnswerText = model.Text,
                CandidateAnswerId = item.AnswerId
            }).ToArray();
    }
}