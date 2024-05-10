using System.ComponentModel.DataAnnotations;

namespace ListaTarefas.Models
{
    public class Tarefa
    {
        public int TarefaId { get; set; }

        [Required(ErrorMessage = "O nome da tarefa é obrigatório.")]
        public string? Nome { get; set; }

        public string? Descricao { get; set; }

        public DateOnly DataRegistro { get; set; }

        public StatusTarefa Status { get; set;}

        public DateOnly DataConclusao { get; set; }

        public DateOnly? PrazoDesejado { get; set; }

        [Required(ErrorMessage = "O nível de prioridade obrigatório.")]
        public PrioridadeTarefa Prioridade { get; set; }
    }

    public enum StatusTarefa
    {
        ToDo,
        Doing,
        Done
    }

    public enum PrioridadeTarefa
    {
        Baixa,
        Moderada,
        Alta
    }
}
