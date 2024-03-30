using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using QuizDemo.Messages;
using QuizDemo.Models;
using QuizDemo.Services;

namespace QuizDemo.Controllers;

[ApiController]
[Route("[controller]")]
public class CandidatesController : ControllerBase
{
    private readonly ICandidatesService _candidatesService;
    private readonly IMapper _mapper;

    public CandidatesController(ICandidatesService candidatesService, IMapper mapper)
    {
        _candidatesService = candidatesService;
        _mapper = mapper;
    }

    /// <summary>
    /// Вернуть список тестируемых с результатами прохождения теста: id-записи (таблица с результатами тестов), email тестируемого, название теста, балл за тест
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    [HttpGet]
    public Task<CandidateResultResponse[]> GetResults() => _candidatesService.GetResults();

    /// <summary>
    /// Вернуть детальную информацию о прохождении теста тестируемым: id-записи (таблица с результатами тестов), email тестируемого, название теста, балл за тест, ответы: вопрос, ответ
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    [HttpGet("{id}")]
    public Task<CandidateResultResponse> GetResultsById([FromRoute] Guid id) => _candidatesService.GetResultsById(id);

    /// <summary>
    /// Отправить информацию о прохождении теста тестируемым: id-теста, email тестируемого, ответы ([{id-вопроса, id-ответа}])
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    [HttpPost]
    public async Task<IActionResult> SaveCandidateResult([FromBody] CreateCandidateResultRequest request)
    {
        await _candidatesService.SaveCandidateResult(_mapper.Map<CreateCandidateResultModel>(request));
        return Ok();
    }
}