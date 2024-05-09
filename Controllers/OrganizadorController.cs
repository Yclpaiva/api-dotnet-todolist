using Microsoft.AspNetCore.Mvc;
using TodoApi.Entities;
using TodoApi.Context;

namespace TodoApi.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class ContatoController : ControllerBase
    {
        private readonly OrganizadorContext _context;

        public ContatoController(OrganizadorContext context)//construtor
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Create(Tarefa tarefa)
        {
            _context.Add(tarefa);
            _context.SaveChanges(); //adiciona o contato e salva as mudanças

            return Ok(tarefa);
        }

        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id)
        {
            var tarefa = _context.Tarefas.Find(id);

            if (tarefa == null)
            {
                return NotFound();
            }
            return Ok(tarefa);

        }

        [HttpGet("ObterTodos")]
        public IActionResult ObterTodos()
        {
            var tarefas = _context.Tarefas.ToList();
            return Ok(tarefas);
        }


        [HttpGet("ObterPorTitulo")]
        public IActionResult OBterPorTitulo(string titulo)
        {
            var tarefas = _context.Tarefas.Where(t => t.Titulo.Contains(titulo)).ToList();
            return Ok(tarefas);
        }

        [HttpGet("ObterPorData")]
        public IActionResult ObterPorData(DateTime data)
        {
            var tarefas = _context.Tarefas.Where(t => t.Data == data).ToList();
            return Ok(tarefas);
        }

        [HttpGet("ObterPorStatus")]
        public IActionResult ObterPorStatus(Status status)
        {
            var tarefas = _context.Tarefas.Where(t => t.Status == status).ToList();
            return Ok(tarefas);
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Tarefa tarefa)
        {
            var tarefaBanco = _context.Tarefas.Find(id);
            if (tarefaBanco == null)
            {
                return NotFound();
            }

            tarefaBanco.Titulo = tarefa.Titulo;
            tarefaBanco.Descricao = tarefa.Descricao;
            tarefaBanco.Data = tarefa.Data;
            tarefaBanco.Status = tarefa.Status;
            _context.Tarefas.Update(tarefaBanco);
            _context.SaveChanges();

            return Ok(tarefaBanco);
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            var tarefa = _context.Tarefas.Find(id);
            if (tarefa == null)
            {
                return NotFound();
            }

            _context.Tarefas.Remove(tarefa);
            _context.SaveChanges();

            return Ok();
        }
    }
}
