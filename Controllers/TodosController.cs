using Microsoft.AspNetCore.Mvc;
using WebApi.Helpers;
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
    public async Task<ActionResult> Index()
    {
        var stodos = new TodoService(_context, _logger);
        return Ok(await stodos.GetAll());
    }
}