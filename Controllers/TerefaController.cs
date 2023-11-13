using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using trilha_net_api_desafio.Context;
using trilha_net_api_desafio.Entities;

namespace trilha_net_api_desafio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TerefaController : ControllerBase
    {
        private readonly TarefaContext _context;

        public TerefaController(TarefaContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult CriarTarefa (Tarefa tarefa)
        {
            _context.Add(tarefa);
            _context.SaveChanges();
            return Ok(tarefa);
        }


        [HttpGet("{id}")]
        public IActionResult BuscarTarefaPorId (int id)
        {
            var tarefa = _context.Tarefas.Find(id);
            if(id == 0)
            {
                return NotFound();
            }
            return Ok (tarefa);
        }
        [HttpPut("{id}")]
        public IActionResult AlterarTarefa (int id, Tarefa tarefa)
        {
            var buscaTarefa = _context.Tarefas.Find(id);
            if (buscaTarefa == null)
            {
                return NotFound();
            }
            buscaTarefa.Titulo = tarefa.Titulo;
            buscaTarefa.Descricao = tarefa.Descricao;
            buscaTarefa.Data = tarefa.Data;
            buscaTarefa.Status = tarefa.Status;
            return Ok(tarefa);
        }
        [HttpDelete("{id}")]
        public IActionResult DeletaTarefa(int id)
        {
            var deletar = _context.Tarefas.Find(id);
            if (deletar == null)
            {
                return NotFound();
            }
            _context.Remove(deletar);
            _context.SaveChanges();
            return NoContent();
        }
    
    }
}