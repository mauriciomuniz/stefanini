using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using stefanini_prova.Model;



namespace stefanini_prova.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class TarefasController : Controller
    {
        private readonly Contexto _context;

        public TarefasController(Contexto context)
        {
            _context = context;
        }

        // GET: Tarefas/Listar
        // https://localhost:7070/api/Tarefas/Listar
        [HttpGet("Listar")]
        public async Task<IActionResult> Index()
        {
            var res = await _context.Tarefas.ToListAsync();
            return Ok(res);
        }

        // GET: Tarefas/Buscar/5
        // https://localhost:7070/api/Tarefas/Buscar/id
        [HttpGet("Buscar/{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tarefa = await _context.Tarefas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tarefa == null)
            {
                return NotFound();
            }

            return Ok(tarefa);
        }



        // POST: Tarefas/Cadastrar
        // endereço https://localhost:7070/api/Tarefas/Cadastrar
        [HttpPost("Cadastrar")]    
        public async Task<IActionResult> Create([FromBody] Tarefa tarefa)
        {
                if (_context.Tarefas == null)
                {
                return BadRequest("entidade está nula");
                }

                
                try 
                {
                    _context.Add(tarefa);
                    await _context.SaveChangesAsync();
                    return Ok(new { id = tarefa.Id });
                }
                catch(DbUpdateException ex)
                {
                    if(TarefaExists(tarefa.Id))
                    {
                        return Conflict("Já existe uma tarefa com o ID especificado");
                    }
                    else { 
                    return Problem($"Ocorreu um erro ao salvar a tarefa: {ex.Message}"); }
                }
                
                
        }

        

        

        

        

        private bool TarefaExists(int id)
        {
            return _context.Tarefas.Any(e => e.Id == id);
        }
    }
}
