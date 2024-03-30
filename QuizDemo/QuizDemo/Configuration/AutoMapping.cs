using AutoMapper;
using QuizDemo.Messages;
using QuizDemo.Models;

namespace QuizDemo.Configuration;

public class AutoMapping : Profile
{
    public AutoMapping()
    {
        CreateMap<CreateQuizRequest, CreateQuizModel>();
        CreateMap<CreateCandidateResultRequest, CreateCandidateResultModel>();
    }
}