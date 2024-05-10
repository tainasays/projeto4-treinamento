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
                Descricao = "Criar uma lista de tarefas",
                DataRegistro = new DateOnly(2000, 11, 01),
                Status = StatusTarefa.ToDo },

            new Tarefa {
                TarefaId = 2,
                Nome = "Criação de Exibição",
                Descricao = "Criar 2 Views",
                DataRegistro = new DateOnly(2003, 11, 01),
                Status = StatusTarefa.Doing },

            new Tarefa {
                TarefaId = 3,
                Nome = "Criação do TaskController",
                Descricao = "Criar métodos necessários",
                DataRegistro = new DateOnly(2003, 11, 01),
                Status = StatusTarefa.Done }
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
            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind("Nome,Descricao,Status")] Tarefa tarefa)
        {

            if (ModelState.IsValid)
            {
                tarefa.TarefaId = _tarefas.Count > 0 ? _tarefas.Max(t => t.TarefaId) + 1 : 1;
                tarefa.DataRegistro = DateOnly.FromDateTime(DateTime.Now);
                _tarefas.Add(tarefa);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var tarefa = _tarefas.FirstOrDefault(t => t.TarefaId == id);
            if (tarefa == null)
            {
                return NotFound();
            }

            return View(tarefa);
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
                    existingTarefa.DataRegistro = tarefa.DataRegistro;
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

