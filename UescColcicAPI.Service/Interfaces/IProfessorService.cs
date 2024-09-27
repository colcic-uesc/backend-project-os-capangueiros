using Microsoft.EntityFrameworkCore;
using UescColcicAPI.Core;

namespace UescColcicAPI.Service
{
    public interface IProfessorService
    {
        Task<Professor> CreateProfessorAsync(Professor professor);
        Task<Professor> GetProfessorByIdAsync(int id);
        Task<IEnumerable<Professor>> GetAllProfessorsAsync();
        Task UpdateProfessorAsync(Professor professor);
        Task DeleteProfessorAsync(int id);
    }

    public class ProfessorService : IProfessorService
    {
        private readonly AppDbContext _context;

        public ProfessorService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Professor> CreateProfessorAsync(Professor professor)
        {
            // Verificar se o professor já existe
            var existingProfessor = await _context.Professores
                .FirstOrDefaultAsync(p => p.Email == professor.Email);
            if (existingProfessor != null)
            {
                throw new InvalidOperationException("Professor já existe com este email.");
            }

            // Validar campos obrigatórios
            if (string.IsNullOrWhiteSpace(professor.Nome))
            {
                throw new ArgumentException("O nome do professor é obrigatório.");
            }

            if (string.IsNullOrWhiteSpace(professor.Email))
            {
                throw new ArgumentException("O email do professor é obrigatório.");
            }

            // Adicionar o professor ao contexto e salvar as mudanças
            _context.Professores.Add(professor);
            await _context.SaveChangesAsync();
            return professor;
        }

        public async Task<Professor> GetProfessorByIdAsync(int id)
        {
            return await _context.Professores.FindAsync(id);
        }

        public async Task<IEnumerable<Professor>> GetAllProfessorsAsync()
        {
            return await _context.Professores.ToListAsync();
        }

        public async Task UpdateProfessorAsync(Professor professor)
        {
            _context.Professores.Update(professor);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProfessorAsync(int id)
        {
            var professor = await _context.Professores.FindAsync(id);
            if (professor != null)
            {
                _context.Professores.Remove(professor);
                await _context.SaveChangesAsync();
            }
        }
    }
}