using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UescColcicAPI.Service;

namespace UescColcicAPI.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfessorsController : ControllerBase
    {
        private readonly IProfessorService _professorService;
        private readonly DbContext _context;

        public ProfessorsController(IProfessorService professorService, DbContext context)
        {
            _professorService = professorService;
            _context = context;
        }

        // Obter todos os professores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Professor>>> GetAllProfessors()
        {
            var professores = await _professorService.GetAllProfessorsAsync();
            return Ok(professores);
        }

        // Obter um professor por ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Professor>> GetProfessorById(int id)
        {
            var professor = await _professorService.GetProfessorByIdAsync(id);
            if (professor == null)
            {
                return NotFound();
            }
            return Ok(professor);
        }

        // Criar um novo professor
        [HttpPost]
        public async Task<ActionResult<Professor>> CreateProfessor(Professor professor)
        {
            var createdProfessor = await _professorService.CreateProfessorAsync(professor);
            return CreatedAtAction("GetProfessor", new { id = createdProfessor.ProfessorId }, createdProfessor);
        }

        // Atualizar um professor
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProfessor(int id, Professor professor)
        {
            if (id != professor.ProfessorId)
            {
                return BadRequest();
            }

            try
            {
                await _professorService.UpdateProfessorAsync(professor);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProfessorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // Deletar um professor
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProfessor(int id)
        {
            await _professorService.DeleteProfessorAsync(id);
            return NoContent();
        }

        private bool ProfessorExists(int id)
        {
            return _context.Set<Professor>().Any(e => e.ProfessorId == id);
        }
    }
}