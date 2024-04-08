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
/// Контроллер для работы с тестами
/// </summary>
[ApiController]
[Route("[controller]")]
public class QuizesController : ControllerBase
{
    private readonly IQuizesService _quizesService;
    private readonly IMapper _mapper;

    public QuizesController(IQuizesService quizesService, IMapper mapper)
    {
        _quizesService = quizesService;
        _mapper = mapper;
    }

    /// <summary>
    /// Вернуть список всех тестов: id теста, название теста
    /// </summary>
    /// <returns></returns>
    /// <response code="200">Запрос успешно прошел</response>
    [HttpGet]
    [Produces("application/json")]
    [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(CandidateResultResponse[]),
        Description = "Запрос успешно прошел")]
    public Task<QuizResponse[]> GetAll() => _quizesService.GetAll();

    /// <summary>
    /// Вернуть детальную информацию о тесте (id теста): все поля из таблицы с тестами + ответы теста.
    /// </summary>
    /// <param name="id">id теста</param>
    /// <returns></returns>
    /// <response code="200">Запрос успешно прошел</response>
    /// <response code="404">Запись с таким id не найдена</response>
    [HttpGet("{id}")]
    [Produces("application/json")]
    [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(CandidateResultResponse),
        Description = "Запрос успешно прошел")]
    [SwaggerResponse(StatusCodes.Status404NotFound, Description = "Запись с таким id не найдена")]
    public async Task<QuizDetailedResponse> GetById([FromRoute] Guid id)
    {
        var quiz = await _quizesService.GetById(id);
        if (quiz == null)
        {
            throw new HttpResponseException(HttpStatusCode.NotFound, $"quiz with id = {id} not found");
        }

        return quiz;
    }

    /// <summary>
    /// Создать тест
    /// </summary>
    /// <param name="request">Данные для теста</param>
    /// <returns></returns>
    /// <response code="200">Запрос успешно прошел</response>
    [HttpPost]
    [Consumes("application/json")]
    [Produces("application/json")]
    [SwaggerResponse(StatusCodes.Status200OK, Description = "Запрос успешно прошел")]
    public async Task<IActionResult> Create([FromBody] CreateQuizRequest request)
    {
        await _quizesService.Create(_mapper.Map<CreateQuizModel>(request));
        return Ok();
    }
}