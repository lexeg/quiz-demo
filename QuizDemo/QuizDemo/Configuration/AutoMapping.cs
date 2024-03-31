using AutoMapper;
using Newtonsoft.Json;
using QuizDemo.DataAccess.DataModels;
using QuizDemo.DataAccess.Entities;
using QuizDemo.Messages;
using QuizDemo.Models;

namespace QuizDemo.Configuration;

public class AutoMapping : Profile
{
    public AutoMapping()
    {
        CreateMap<CreateQuizRequest, CreateQuizModel>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.Questions, opt => opt.MapFrom(src => src.Questions));
        CreateMap<CreateCandidateResultRequest, CreateCandidateResultModel>();
        CreateMap<TestEntity, QuizResponse>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
        CreateMap<TestEntity, QuizDetailedResponse>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.Questions, opt => opt.MapFrom(src => CreateQuestionsMap(src)));
        CreateMap<CreateQuizModel, TestEntity>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));
        CreateMap<QuestionModel, QuestionEntity>()
            .ForMember(dest => dest.TestId, opt => opt.MapFrom(src => src.TestId))
            .ForMember(dest => dest.Question, opt => opt.MapFrom(src => src.Question))
            .ForMember(dest => dest.Answers, opt => opt.MapFrom(src => CreateAnswersMap(src)));
    }

    private static QuestionDetailedModel[] CreateQuestionsMap(TestEntity testEntity) => testEntity.QuestionsTables
        .Select(entity => new QuestionDetailedModel
        {
            Id = entity.Id,
            TestId = entity.TestId,
            Question = entity.Question,
            Answers = CreateAnswersMap(entity.Answers)
        }).ToArray();

    private static AnswerModel[] CreateAnswersMap(string answers)
    {
        var answersDataModel = JsonConvert.DeserializeObject<AnswersDataModel>(answers);
        return answersDataModel.Answers.Select(x => new AnswerModel
        {
            Id = x.Id,
            Text = x.Text
        }).ToArray();
    }

    private static string CreateAnswersMap(QuestionModel questionModel)
    {
        var answersDataModel = new AnswersDataModel
        {
            Answers = questionModel.Answers.Select(x => new AnswerDataModel
            {
                Id = x.Id,
                Text = x.Text
            }).ToArray(),
            AnswerId = questionModel.AnswerId
        };
        return JsonConvert.SerializeObject(answersDataModel);
    }
}