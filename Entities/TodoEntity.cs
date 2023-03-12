using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapiCrud.Entities;

[Table("todos")]
public class TodoEntity
{
    [Column("id")]
    public int Id { get; set; }

    [Column("titulo")]
    public string Titulo { get; set; }

    [Column("prazo")]
    public DateTime? Prazo { get; set; }

    [Column("descricao")]
    public string Descricao { get; set; }

    [Column("status")]
    public EStatusTodo Status { get; set; }
}

public enum EStatusTodo
{
    [Description("Pendente")]
    Pendente,
    [Description("Em Andamento")]
    EmAndamento,
    [Description("Finalizado")]
    Finalizado
}