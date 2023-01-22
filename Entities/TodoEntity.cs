namespace webapiCrud.Entities;

public class Todo
{
    public int Id { get; set; }
    public string Titulo { get; set; }
    public DateTime? Prazo { get; set; }
    public string Descricao { get; set; }
    public EStatusTodo Status { get; set; }
}

public enum EStatusTodo
{
    Pendente,
    EmAndamento,
    Finalizado
}