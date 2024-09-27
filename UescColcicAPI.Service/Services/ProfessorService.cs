using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UescColcicAPI.Service.Services
{
    public interface IProfessorService
    {
        Task<Professor> CreateProfessorAsync(Professor professor);
        Task<Professor?> GetProfessorByIdAsync(int id);
        Task<IEnumerable<Professor>> GetAllProfessorsAsync();
        Task UpdateProfessorAsync(Professor professor);
        Task DeleteProfessorAsync(int id);
    }

    public class ProfessorService(AppDbContext context) : IProfessorService
    {
        private readonly AppDbContext _context = context;

        public async Task<Professor> CreateProfessorAsync(Professor professor)
        {
            _context.Professores.Add(professor);
            await _context.SaveChangesAsync();
            return professor;
        }

        public async Task<Professor?> GetProfessorByIdAsync(int id)
        {
            return await _context.Professores.FindAsync(id);
        }

        public async Task<IEnumerable<Professor>> GetAllProfessorsAsync()
        {
            return await _context.Professores.ToListAsync();
        }

        public async Task UpdateProfessorAsync(Professor professor)
        {
            _context.Entry(professor).State = EntityState.Modified;
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