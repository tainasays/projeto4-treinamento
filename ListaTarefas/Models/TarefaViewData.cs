using System.ComponentModel.DataAnnotations;

namespace ListaTarefas.Models
{
    public class TarefaViewData
    {

        
        public Tarefa? Tarefa { get; set; }

        public List<Tarefa>? ToDo { get; set; }

        public List<Tarefa>? Doing { get; set; }

        public List<Tarefa>? Done { get; set; }

        public List<StatusTarefa>? StatusOptions { get; set; }
        public List<PrioridadeTarefa>? PrioridadeOptions { get; set; }

    }
}
