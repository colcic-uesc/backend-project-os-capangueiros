using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

public class ProjectSkillService : IProjectSkillService
{
    private readonly AppDbContext _context;

    public ProjectSkillService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<ProjectSkill> CreateProjectSkillAsync(ProjectSkill projectSkill)
    {
        _context.ProjectSkills.Add(projectSkill);
        await _context.SaveChangesAsync();
        return projectSkill;
    }

    public async Task<ProjectSkill> GetProjectSkillByIdAsync(int projectId, int skillId)
    {
        return await _context.ProjectSkills
            .FirstOrDefaultAsync(ps => ps.ProjectId == projectId && ps.SkillId == skillId);
    }

    public async Task<IEnumerable<ProjectSkill>> GetAllProjectSkillsAsync()
    {
        return await _context.ProjectSkills.ToListAsync();
    }

    public async Task UpdateProjectSkillAsync(ProjectSkill projectSkill)
    {
        _context.ProjectSkills.Update(projectSkill);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteProjectSkillAsync(int projectId, int skillId)
    {
        var projectSkill = await _context.ProjectSkills
            .FirstOrDefaultAsync(ps => ps.ProjectId == projectId && ps.SkillId == skillId);
        if (projectSkill != null)
        {
            _context.ProjectSkills.Remove(projectSkill);
            await _context.SaveChangesAsync();
        }
    }
}