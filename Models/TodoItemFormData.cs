using webapiCrud.Models.Todo;

namespace webapiCrud.Models;

public class TodoCreateFormData
{
    public string Titulo { get; set; }
    public string Descricao { get; set; }
    public DateTime? PrazoEntrega { get; set; }
}

public class TodoUpdateFormData
{
    public string Titulo { get; set; }
    public string Descricao { get; set; }
    public DateTime? PrazoEntrega { get; set; }
    public int Status { get; set; }
}