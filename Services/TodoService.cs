using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OperationResult;
using static OperationResult.Helpers;
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


    ///<summary>
    /// Retorna todos os registros de 'Todos' da base
    ///</summary>
    public async Task<IEnumerable<Todo>> All()
    {
        var registros = await _context.Todos.ToListAsync();
        return registros.Select(c => new Todo(c));
    }

    ///<summary>
    /// Procura na base um todo
    /// com base no id
    ///</summary>
    public async Task<Todo> Find(int id)
    {
        var todo = await _context.Todos
            .Where(t => t.Id == id)
            .FirstOrDefaultAsync();
        
        if (todo != null)
            return new Todo(todo);
        
        return null;
    }

    ///<summary>
    /// Cria um registro de Todo
    ///</summary>
    public async Task<Status<String>> Create(Todo it)
    {
        _logger.LogInformation("Cadastrando item de Todo ...OK");

        var te = new TodoEntity();
        
        te.Descricao = it.Descricao;
        te.Titulo = it.Titulo;
        te.Prazo = it.Prazo;
               
        _context.Add(te);
        await _context.SaveChangesAsync();

        return Ok();
    }

    ///<summary>
    /// Atualiza o registro de Todo
    ///</summary>
    public async Task<Status<String>> Update(Todo it)
    {
        var te = it._entity;
        if (te == null)
            return Error("Item ainda não cadastrado");

        _logger.LogInformation("Alterando item de Todo ...OK");

        te.Descricao = it.Descricao;
        te.Titulo = it.Titulo;
        te.Prazo = it.Prazo;
        te.Status = it.Status;
               
        _context.Update(te);
        await _context.SaveChangesAsync();

        return Ok();
    }

    ///<summary>
    /// Remove o registro de Todo
    ///</summary>
    public async Task<Status<String>> Delete(Todo it)
    {
        var te = it._entity;
        if (te == null)
            return Error("Item ainda não cadastrado");

        _logger.LogInformation("Removendo item de Todo ...OK");

        _context.Remove(te);
        await _context.SaveChangesAsync();

        return Ok();
    }
}