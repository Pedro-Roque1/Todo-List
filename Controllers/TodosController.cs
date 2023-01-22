using Microsoft.AspNetCore.Mvc;
using WebApi.Helpers;
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
        todos.AddRange(await stodos.GetAll());

        return Ok(todos);
    }

    [HttpGet("details/{id}")]
    public async Task<IActionResult> Details(int id)
    {
        var stodos = new TodoService(_context, _logger);

        var todo = await stodos.GetById(id);
        if (todo == null)
            return BadRequest();
            
        return Ok(todo);
    }
} 