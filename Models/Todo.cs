using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using webapiCrud.Entities;

namespace webapiCrud.Models.Todo;

public class Todo
{
    public int Id { get; private set; }
    public string Titulo { get; set; }
    public string Descricao { get; set; }
    public DateTime? Prazo{ get; set; }
    public EStatusTodo Status { get;set; }

    public TodoEntity? _entity { get; set; }

    public Todo(string titulo, string descricao, DateTime? prazo)
    {
        this.Titulo = titulo;
        this.Descricao = descricao;
        this.Prazo = prazo;
        this.Status = EStatusTodo.Pendente;
    }

    internal Todo(TodoEntity e)
    {
        this._entity = e;
        this.Id = e.Id;
        this.Titulo = e.Titulo;
        this.Descricao = e.Descricao;
        this.Prazo = e.Prazo;
        this.Status = EStatusTodo.Pendente;
    }
}