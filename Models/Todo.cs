using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapiCrud.Models.Todo;

public class Todo
{
    [Column("Id")]
    [Key]
    public int Id { get; set; }
    
    [Column("Titulo")]
    public string Titulo { get; set; }
   
    [Column("Descricao")]
    public string Descricao { get; set; }

    [Column("Prazo")]
    public DateTime? Prazo{ get; set; }

    [Column("Status")]
    public EStatusTodo Status { get;set; }
}

public enum EStatusTodo
{
    Pendente = 0,
    EmAndamento = 1,
    Finalizado = 2
}