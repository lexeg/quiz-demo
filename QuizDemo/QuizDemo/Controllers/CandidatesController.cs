using System.Net;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using QuizDemo.Exceptions;
using QuizDemo.Messages;
using QuizDemo.Models;
using QuizDemo.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace QuizDemo.Controllers;

/// <summary>
/// Контроллер для работы с результатами тестирования
/// </summary>
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
    /// <response code="200">Запрос успешно прошел</response>
    [HttpGet]
    [Produces("application/json")]
    [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(CandidateResultResponse[]),
        Description = "Запрос успешно прошел")]
    public Task<CandidateResultResponse[]> GetResults() => _candidatesService.GetResults();

    /// <summary>
    /// Вернуть детальную информацию о прохождении теста тестируемым: id-записи (таблица с результатами тестов), email тестируемого, название теста, балл за тест, ответы: вопрос, ответ
    /// </summary>
    /// <param name="id">id результата теста</param>
    /// <returns></returns>
    /// <response code="200">Запрос успешно прошел</response>
    /// <response code="404">Запись с таким id не найдена</response>
    [HttpGet("{id}")]
    [Produces("application/json")]
    [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(CandidateResultResponse),
        Description = "Запрос успешно прошел")]
    [SwaggerResponse(StatusCodes.Status404NotFound, Description = "Запись с таким id не найдена")]
    public async Task<CandidateResultResponse> GetResultsById([FromRoute] Guid id)
    {
        var candidateResults = await _candidatesService.GetResultsById(id);
        if (candidateResults == null)
        {
            throw new HttpResponseException(HttpStatusCode.NotFound, $"candidate results with id = {id} not found");
        }

        return candidateResults;
    }

    /// <summary>
    /// Отправить информацию о прохождении теста тестируемым: id-теста, email тестируемого, ответы ([{id-вопроса, id-ответа}])
    /// </summary>
    /// <param name="request">Данные о прохождении теста кандидатом</param>
    /// <returns></returns>
    /// <response code="200">Запрос успешно прошел</response>
    [HttpPost]
    [Consumes("application/json")]
    [Produces("application/json")]
    [SwaggerResponse(StatusCodes.Status200OK, Description = "Запрос успешно прошел")]
    public async Task<IActionResult> SaveCandidateResult([FromBody] CreateCandidateResultRequest request)
    {
        await _candidatesService.SaveCandidateResult(_mapper.Map<CreateCandidateResultModel>(request));
        return Ok();
    }

    /// <summary>
    /// Отправить временный url с тестом
    /// </summary>
    /// <param name="request">Данные для создания ссылки</param>
    /// <returns></returns>
    /// <response code="200">Запрос успешно прошел</response>
    [HttpGet("presigned-url")]
    [Produces("application/json")]
    [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(string), Description = "Запрос успешно прошел")]
    public async Task<string> GetPresignedUrl([FromQuery] PresignedUrlRequest request)
    {
        var presignedUrl = await _candidatesService.CreatePresignedUrl(_mapper.Map<PresignedUrlModel>(request));
        return Url.ActionLink(action: nameof(QuizesController.GetByPresignedUrl),
            controller: "Quizes",
            values: new { presignedUrl = presignedUrl });
    }
}