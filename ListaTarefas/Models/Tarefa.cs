namespace ListaTarefas.Models
{
    public class Tarefa
    {
        public int TarefaId { get; set; }

        public string? Nome { get; set; }

        public string? Descricao { get; set; }

        public DateOnly DataRegistro { get; set; }

        public StatusTarefa Status { get; set;}

        public DateOnly DataConclusao { get; set; }

    }




    public enum StatusTarefa
    {
        ToDo,
        Doing,
        Done
    }
}
