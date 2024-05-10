using Microsoft.AspNetCore.Mvc;
using ListaTarefas.Models;

namespace ListaTarefas.Controllers
{

    public class TarefaController : Controller
    {

        private static List<Tarefa> _tarefas = new List<Tarefa>()
        {
            new Tarefa {
                TarefaId = 1,
                Nome = "Gerenciador de Tarefa",
                Descricao = "Criar uma lista de tarefas (To Do List)",
                DataRegistro = new DateOnly(2000, 11, 01),
                Status = StatusTarefa.ToDo ,
                PrazoDesejado = new DateOnly(2024, 05, 10),
                Prioridade = PrioridadeTarefa.Alta },

            new Tarefa {
                TarefaId = 2,
                Nome = "Estilização das Views",
                Descricao = "Estilização feita utilizando Bootstrap",
                DataRegistro = new DateOnly(2024, 05, 09),
                Status = StatusTarefa.Doing,
                Prioridade = PrioridadeTarefa.Baixa },

            new Tarefa {
                TarefaId = 3,
                Nome = "Criação de Exibição",
                Descricao = "Criar duas Views: Tarefas em Andamento e Tarefas Concluídas.",
                DataRegistro = new DateOnly(2003, 11, 01),
                DataConclusao = new DateOnly(2024,05,01),
                Status = StatusTarefa.Done,
                Prioridade = PrioridadeTarefa.Moderada }
        };


        public IActionResult Index()
        {
            var _tarefasViewData = new TarefaViewData
            {
                ToDo = _tarefas.Where(t => t.Status == StatusTarefa.ToDo).ToList(),
                Doing = _tarefas.Where(t => t.Status == StatusTarefa.Doing).ToList(),
                Done = _tarefas.Where(t => t.Status == StatusTarefa.Done).ToList()

            };

            return View(_tarefasViewData);
        }


        [HttpGet]
        public IActionResult Create()
        {
            var _tarefasViewData = new TarefaViewData
            {
                //StatusOptions = Enum.GetValues(typeof(StatusTarefa)).Cast<StatusTarefa>().ToList(),
                PrioridadeOptions = Enum.GetValues(typeof(PrioridadeTarefa)).Cast<PrioridadeTarefa>().ToList()

            };
            return View(_tarefasViewData);
        }


        [HttpPost]
        public IActionResult Create(Tarefa tarefa)
        {
            if (ModelState.IsValid)
            {
                tarefa.TarefaId = _tarefas.Count > 0 ? _tarefas.Max(t => t.TarefaId) + 1 : 1;
                tarefa.DataRegistro = DateOnly.FromDateTime(DateTime.Now);
                _tarefas.Add(tarefa);
                return RedirectToAction("Index");
            }
            return View("Index");
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            TarefaViewData _tarefaViewData = new TarefaViewData
            {
                Tarefa = _tarefas.FirstOrDefault(t => t.TarefaId == id),
                StatusOptions = Enum.GetValues(typeof(StatusTarefa)).Cast<StatusTarefa>().ToList(),
                PrioridadeOptions = Enum.GetValues(typeof(PrioridadeTarefa)).Cast<PrioridadeTarefa>().ToList()

            };            
            return View(_tarefaViewData);
        }
        

        [HttpPost]
        public IActionResult Edit(Tarefa tarefa)
        {
            if (ModelState.IsValid)
            {
                var existingTarefa = _tarefas.FirstOrDefault(t => t.TarefaId == tarefa.TarefaId);
                if (existingTarefa != null)
                {
                    existingTarefa.Nome = tarefa.Nome;
                    existingTarefa.Descricao = tarefa.Descricao;
                    existingTarefa.Prioridade = tarefa.Prioridade;
             
                    existingTarefa.PrazoDesejado = tarefa.PrazoDesejado;
                    if (existingTarefa.Status == StatusTarefa.Done)
                    {
                        existingTarefa.DataConclusao = DateOnly.FromDateTime(DateTime.Now);

                    }

                    existingTarefa.Status = tarefa.Status;
                }

                return RedirectToAction("Index");
            }
            return View(tarefa);
        }

        public IActionResult Details(int id)
        {
            var tarefa = _tarefas.FirstOrDefault(t => t.TarefaId == id);
            if (tarefa == null)
            {
                return NotFound();
            }

            return View(tarefa);
        }

        public IActionResult Delete(int id)
        {
            var tarefa = _tarefas.FirstOrDefault(t => t.TarefaId == id);
            if (tarefa == null)
            {
                return NotFound();
            }

            _tarefas.Remove(tarefa);
            return RedirectToAction("Index");
        }



        public IActionResult Backlog()
        {
            var _tarefasViewData = new TarefaViewData
            {
                ToDo = _tarefas.Where(t => t.Status == StatusTarefa.ToDo).ToList()
            };

            return View(_tarefasViewData);
        }



        public IActionResult TarefasDoing()
        {
            var _tarefasViewData = new TarefaViewData
            {
                Doing = _tarefas.Where(t => t.Status == StatusTarefa.Doing).ToList()
            };

            return View(_tarefasViewData);
        }

        public IActionResult TarefasDone()
        {
            var _tarefasViewData = new TarefaViewData
            {
                Done = _tarefas.Where(t => t.Status == StatusTarefa.Done).ToList()
            };

            return View(_tarefasViewData);
        }
    }
}

