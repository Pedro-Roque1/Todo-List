using Microsoft.AspNetCore.Mvc;
using WebApi.Helpers;
using webapiCrud.Dtos.TodoItemDto;
using webapiCrud.Entities;
using webapiCrud.Models;
using webapiCrud.Models.Todo;
using webapiCrud.TodosService;

namespace webapiCrud.Controllers;

[ApiController]
[Route("/todos")]
public class TodosController : ControllerBase
{
    private DataContext _context;
    private ILogger _logger;

    public TodosController(DataContext context, ILogger<TodosController> logger)
    {
        _context = context;
        _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<List<Todo>>> Index()
    {
        var stodos = new TodoService(_context, _logger);

        var todos = new List<Todo>();
        todos.AddRange(await stodos.All());

        return Ok(todos.Select(t => new TodoItemDto(t)));
    }

    [HttpGet("details/{id}")]
    public async Task<IActionResult> Details(int id)
    {
        var stodos = new TodoService(_context, _logger);

        var todo = await stodos.Find(id);
        if (todo == null)
            return BadRequest();
            
        return Ok(new TodoItemDto(todo));
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] TodoCreateFormData form)
    {
        var stodos = new TodoService(_context, _logger);
        
        if (form == null)
        {
            _logger.LogError($"Recebemos um item vazio.");
            return BadRequest();
        }

        var todo = new Todo(form.Titulo, form.Descricao, form.PrazoEntrega);

        await stodos.CreateItem(todo);

        return Ok();
    }
} 