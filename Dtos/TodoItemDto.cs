using webapiCrud.Models.Todo;

namespace webapiCrud.Dtos.TodoItemDto;

public class TodoItemDto
{
    public int Id { get; set; }
    public string Titulo { get; set; }
    public string Descricao { get; set; }
    public DateTime? Prazo{ get; set; }
    public string StatusStr { get;set; }

    public TodoItemDto()
    {}

    public TodoItemDto(Todo t)
    {
        this.Id = t.Id;
        this.Titulo = t.Titulo;
        this.Descricao = t.Descricao;
        this.Prazo = t.Prazo;
        this.StatusStr = t.Status.ToString(); 
    }
}