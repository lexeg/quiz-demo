using AutoMapper;
using Newtonsoft.Json;
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
        CreateMap<CreateQuizModel, TestEntity>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));
        CreateMap<QuestionModel, QuestionEntity>()
            .ForMember(dest => dest.TestId, opt => opt.MapFrom(src => src.TestId))
            .ForMember(dest => dest.Question, opt => opt.MapFrom(src => src.Question))
            .ForMember(dest => dest.Answers, opt => opt.MapFrom(src => JsonConvert.SerializeObject(src.Answers)));
    }
}