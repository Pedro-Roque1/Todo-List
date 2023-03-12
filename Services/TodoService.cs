using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Helpers;
using webapiCrud.Entities;
using webapiCrud.Models;
using webapiCrud.Models.Todo;
namespace webapiCrud.TodosService;

public class TodoService
{
    private DataContext _context;
    private ILogger _logger;

    public TodoService(DataContext context, ILogger logger)
    {
        _context = context;
        _logger = logger;
    }

    // Método responsável por retornar
    // todos os registros de 'Todos' da base de dados
    public async Task<IEnumerable<Todo>> All()
    {
        var registros = await _context.Todos.ToListAsync();
        return registros.Select(c => new Todo(c));
    }

    public async Task<Todo> Find(int id)
    {
        var todo = await _context.Todos
            .Where(t => t.Id == id)
            .FirstOrDefaultAsync();
        
        if (todo != null)
            return new Todo(todo);
        
        return null;
    }

    public async Task CreateItem(Todo it)
    {
        var te = new TodoEntity();
        
        te.Descricao = it.Descricao;
        te.Titulo = it.Titulo;
        te.Prazo = it.Prazo;
        
        _context.Add(te);
        await _context.SaveChangesAsync();
    }
}