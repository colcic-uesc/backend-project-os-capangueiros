using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

public class SkillService : ISkillService
{
    private readonly AppDbContext _context;

    public SkillService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Skill> CreateSkillAsync(Skill skill)
    {
        _context.Skills.Add(skill);
        await _context.SaveChangesAsync();
        return skill;
    }

    public async Task<Skill> GetSkillByIdAsync(int skillId)
    {
        return await _context.Skills.FindAsync(skillId);
    }

    public async Task<IEnumerable<Skill>> GetAllSkillsAsync()
    {
        return await _context.Skills.ToListAsync();
    }

    public async Task UpdateSkillAsync(Skill skill)
    {
        _context.Skills.Update(skill);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteSkillAsync(int skillId)
    {
        var skill = await _context.Skills.FindAsync(skillId);
        if (skill != null)
        {
            _context.Skills.Remove(skill);
            await _context.SaveChangesAsync();
        }
    }
}