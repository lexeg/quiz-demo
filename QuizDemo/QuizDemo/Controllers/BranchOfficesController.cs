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
/// Контроллер для работы с офисами
/// </summary>
[ApiController]
[Route("[controller]")]
public class BranchOfficesController : ControllerBase
{
    private readonly IBranchOfficesService _branchOfficesService;
    private readonly IMapper _mapper;

    public BranchOfficesController(IBranchOfficesService branchOfficesService, IMapper mapper)
    {
        _branchOfficesService = branchOfficesService;
        _mapper = mapper;
    }

    /// <summary>
    /// Вернуть список всех офисов
    /// </summary>
    /// <returns></returns>
    /// <response code="200">Запрос успешно прошел</response>
    [HttpGet]
    [Produces("application/json")]
    [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(BranchOfficeResponse[]),
        Description = "Запрос успешно прошел")]
    public Task<BranchOfficeResponse[]> GetAll() => _branchOfficesService.GetAll();

    /// <summary>
    /// Вернуть информацию об офисе
    /// </summary>
    /// <param name="id">id офиса</param>
    /// <returns></returns>
    /// <response code="200">Запрос успешно прошел</response>
    /// <response code="404">Запись с таким id не найдена</response>
    [HttpGet("{id}")]
    [Produces("application/json")]
    [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(BranchOfficeResponse),
        Description = "Запрос успешно прошел")]
    [SwaggerResponse(StatusCodes.Status404NotFound, Description = "Запись с таким id не найдена")]
    public async Task<BranchOfficeResponse> GetById([FromRoute] Guid id)
    {
        var branchOffice = await _branchOfficesService.GetById(id);
        if (branchOffice == null)
        {
            throw new HttpResponseException(HttpStatusCode.NotFound, $"branch office with id = {id} not found");
        }

        return branchOffice;
    }

    /// <summary>
    /// Создать офис
    /// </summary>
    /// <param name="request">Данные для офиса</param>
    /// <returns></returns>
    /// <response code="200">Запрос успешно прошел</response>
    [HttpPost]
    [Consumes("application/json")]
    [Produces("application/json")]
    [SwaggerResponse(StatusCodes.Status200OK, Description = "Запрос успешно прошел")]
    public async Task<IActionResult> Create([FromBody] CreateBranchOfficeRequest request)
    {
        await _branchOfficesService.Create(_mapper.Map<CreateBranchOfficeModel>(request));
        return Ok();
    }
}