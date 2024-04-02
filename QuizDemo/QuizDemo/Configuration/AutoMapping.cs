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
        CreateMap<CreateCandidateResultRequest, CreateCandidateResultModel>()
            .ForMember(dest => dest.TestId, opt => opt.MapFrom(src => src.TestId))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.Answers, opt => opt.MapFrom(src => src.Answers));
        CreateMap<QuestionResultModel, QuestionResultDataModel>()
            .ForMember(dest => dest.QuestionId, opt => opt.MapFrom(src => src.QuestionId))
            .ForMember(dest => dest.QuestionText, opt => opt.MapFrom(src => src.QuestionText))
            .ForMember(dest => dest.AnswerId, opt => opt.MapFrom(src => src.AnswerId))
            .ForMember(dest => dest.AnswerText, opt => opt.MapFrom(src => src.AnswerText))
            .ForMember(dest => dest.CandidateAnswerId, opt => opt.MapFrom(src => src.CandidateAnswerId));
        CreateMap<TestResultDataModel, CandidateResultResponse>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.TestId, opt => opt.MapFrom(src => src.TestId))
            .ForMember(dest => dest.TestName, opt => opt.MapFrom(src => src.TestName))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.Questions, opt => opt.MapFrom(src => src.Questions));
        CreateMap<CreateCandidateResultModel, TestResultEntity>()
            .ForMember(dest => dest.TestId, opt => opt.MapFrom(src => src.TestId))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.Answers, opt => opt.MapFrom(src => CreateAnswersMap(src.Answers)));
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
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.Questions, opt => opt.Ignore());
        CreateMap<QuestionModel, QuestionEntity>()
            .ForMember(dest => dest.TestId, opt => opt.MapFrom(src => src.TestId))
            .ForMember(dest => dest.Question, opt => opt.MapFrom(src => src.Question))
            .ForMember(dest => dest.Answers, opt => opt.MapFrom(src => CreateAnswersMap(src)));
    }

    private static QuestionDetailedModel[] CreateQuestionsMap(TestEntity testEntity) => testEntity.Questions
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

    private static string CreateAnswersMap(CandidateAnswerModel[] answers)
    {
        var items = answers.Select(answer => new CandidatesAnswerDataModel
            {
                QuestionId = answer.QuestionId,
                AnswerId = answer.AnswerId
            }
        ).ToArray();
        return JsonConvert.SerializeObject(items);
    }
}