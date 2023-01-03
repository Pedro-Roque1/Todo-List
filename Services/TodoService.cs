using WebApi.Helpers;
using webapiCrud.Models.Todo;

namespace webapiCrud.TodoService;

public class TodoService
{
    private DataContext _context;
    private ILogger _logger;

    public TodoService(DataContext context, ILogger logger)
    {
        _context = context;
        _logger = logger;
    }
}