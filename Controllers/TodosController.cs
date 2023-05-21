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

    private TodoService _stodos;

    public TodosController(DataContext context, ILogger<TodosController> logger)
    {
        _context = context;
        _logger = logger;
        _stodos = new TodoService(_context, _logger);
    }

    [HttpGet]
    public async Task<ActionResult<List<Todo>>> Index()
    {
        var todos = new List<Todo>();
        todos.AddRange(await _stodos.All());

        return Ok(todos.Select(t => new TodoItemDto(t)));
    }

    [HttpGet("details/{id}")]
    public async Task<IActionResult> Details(int id)
    {
        var todo = await _stodos.Find(id);
        if (todo == null)
            return BadRequest();
            
        return Ok(new TodoItemDto(todo));
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] TodoCreateFormData form)
    {        
        var todo = new Todo(form.Titulo, form.Descricao, form.PrazoEntrega);

        var st = await _stodos.Create(todo);
        if (st.IsError)
            return NotFound(st.Error);

        return Ok(new TodoItemDto(todo));
    }

    [HttpPatch("update")]
    public async Task<IActionResult> Update(int id, TodoUpdateFormData form)
    {   
        var todo = await _stodos.Find(id);
        if (todo == null)
            return NotFound();

        todo.Descricao = form.Descricao;
        todo.Prazo = form.PrazoEntrega;
        todo.Status = (EStatusTodo) form.Status;
        todo.Titulo = form.Titulo;

        var st = await _stodos.Update(todo);
        if (st.IsError)
            return NotFound(st.Error);

        return Ok(new TodoItemDto(todo));
    }

    [HttpDelete("delete")]
    public async Task<IActionResult> Delete(int id)
    {
        var todo = await _stodos.Find(id);
        if (todo == null)
            return NotFound();
        
        var st = await _stodos.Delete(todo);
        if (st.IsError)
            return NotFound(st.Error);
        
        return Ok();
    }
} 