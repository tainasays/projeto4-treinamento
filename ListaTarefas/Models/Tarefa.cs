using System.ComponentModel.DataAnnotations;

namespace ListaTarefas.Models
{
    public class Tarefa
    {
        public int TarefaId { get; set; }

        [Display(Name = "Nome:")]
        [Required(ErrorMessage = "O nome da tarefa é obrigatório.")]
        public string? Nome { get; set; }

        [Display(Name = "Descrição:")]
        public string? Descricao { get; set; }

        [Display(Name = "Data de Registro:")]
        public DateOnly DataRegistro { get; set; }

        [Display(Name = "Status:")]
        public StatusTarefa Status { get; set;}

        [Display(Name = "Data de Conclusão:")]
        public DateOnly DataConclusao { get; set; }

        [Display(Name = "Prazo Estimado:")]
        public DateOnly? PrazoDesejado { get; set; }

        [Display(Name = "Nível de Prioridade:")]
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
