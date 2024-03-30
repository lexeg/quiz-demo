using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using QuizDemo.Messages;
using QuizDemo.Models;
using QuizDemo.Services;

namespace QuizDemo.Controllers;

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
    /// вернуть список всех тестов: id теста, название теста
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    [HttpGet]
    public Task<QuizResponse[]> GetAll() => _quizesService.GetAll();

    /// <summary>
    /// Вернуть детальную информацию о тесте (id теста): все поля из таблицы с тестами + ответы теста.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    [HttpGet("{id}")]
    public Task<QuizResponse> GetById([FromRoute] Guid id) => _quizesService.GetById(id);

    //создать тест
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateQuizRequest request)
    {
        await _quizesService.Create(_mapper.Map<CreateQuizModel>(request));
        return Ok();
    }
}