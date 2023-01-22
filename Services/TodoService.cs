using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Helpers;
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
    public async Task<List<Todo>> GetAll()
    {
        var registros = await _context.Todos.ToListAsync();
        return registros;
    }

    public async Task<Todo> GetById(int id)
    {
        return await _context.Todos
            .Where(t => t.Id == id)
            ?.FirstOrDefaultAsync() ?? null ;
    }
}