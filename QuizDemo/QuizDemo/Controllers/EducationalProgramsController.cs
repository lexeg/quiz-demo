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
/// Контроллер для работы с программами обучения
/// </summary>
[ApiController]
[Route("[controller]")]
public class EducationalProgramsController : ControllerBase
{
    private readonly IEducationalProgramsService _educationalProgramsService;
    private readonly IMapper _mapper;

    public EducationalProgramsController(IEducationalProgramsService educationalProgramsService, IMapper mapper)
    {
        _educationalProgramsService = educationalProgramsService;
        _mapper = mapper;
    }

    /// <summary>
    /// Вернуть список программ обучения
    /// </summary>
    /// <returns></returns>
    /// <response code="200">Запрос успешно прошел</response>
    [HttpGet]
    [Produces("application/json")]
    [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(EducationalProgramResponse[]),
        Description = "Запрос успешно прошел")]
    public Task<EducationalProgramResponse[]> GetAll() => _educationalProgramsService.GetAll();

    /// <summary>
    /// Вернуть детальную информацию о программе обучения
    /// </summary>
    /// <param name="id">id программы</param>
    /// <returns></returns>
    /// <response code="200">Запрос успешно прошел</response>
    /// <response code="404">Запись с таким id не найдена</response>
    [HttpGet("{id}")]
    [Produces("application/json")]
    [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(EducationalProgramResponse),
        Description = "Запрос успешно прошел")]
    [SwaggerResponse(StatusCodes.Status404NotFound, Description = "Запись с таким id не найдена")]
    public async Task<EducationalProgramResponse> GetById([FromRoute] Guid id)
    {
        var educationalProgram = await _educationalProgramsService.GetById(id);
        if (educationalProgram == null)
        {
            throw new HttpResponseException(HttpStatusCode.NotFound, $"educational program with id = {id} not found");
        }

        return educationalProgram;
    }

    /// <summary>
    /// Создать программу обучения
    /// </summary>
    /// <param name="request">Данные для программы</param>
    /// <returns></returns>
    /// <response code="200">Запрос успешно прошел</response>
    [HttpPost]
    [Consumes("application/json")]
    [Produces("application/json")]
    [SwaggerResponse(StatusCodes.Status200OK, Description = "Запрос успешно прошел")]
    public async Task<IActionResult> Create([FromBody] CreateEducationalProgramRequest request)
    {
        await _educationalProgramsService.Create(_mapper.Map<CreateEducationalProgramModel>(request));
        return Ok();
    }
}