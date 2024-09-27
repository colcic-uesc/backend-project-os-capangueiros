using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

public class StudentSkillService : IStudentSkillService
{
    private readonly AppDbContext _context;

    public StudentSkillService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<StudentSkill> CreateStudentSkillAsync(StudentSkill studentSkill)
    {
        _context.StudentSkills.Add(studentSkill);
        await _context.SaveChangesAsync();
        return studentSkill;
    }

    public async Task<StudentSkill> GetStudentSkillByIdAsync(int studentId, int skillId)
    {
        return await _context.StudentSkills
            .FirstOrDefaultAsync(ss => ss.StudentId == studentId && ss.SkillId == skillId);
    }

    public async Task<IEnumerable<StudentSkill>> GetAllStudentSkillsAsync()
    {
        return await _context.StudentSkills.ToListAsync();
    }

    public async Task UpdateStudentSkillAsync(StudentSkill studentSkill)
    {
        _context.StudentSkills.Update(studentSkill);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteStudentSkillAsync(int studentId, int skillId)
    {
        var studentSkill = await _context.StudentSkills
            .FirstOrDefaultAsync(ss => ss.StudentId == studentId && ss.SkillId == skillId);
        if (studentSkill != null)
        {
            _context.StudentSkills.Remove(studentSkill);
            await _context.SaveChangesAsync();
        }
    }
}