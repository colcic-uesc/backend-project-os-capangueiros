using System.Collections.Generic;
using System.Threading.Tasks;

public interface IProjectSkillService
{
    Task<ProjectSkill> CreateProjectSkillAsync(ProjectSkill projectSkill);
    Task<ProjectSkill> GetProjectSkillByIdAsync(int projectId, int skillId);
    Task<IEnumerable<ProjectSkill>> GetAllProjectSkillsAsync();
    Task UpdateProjectSkillAsync(ProjectSkill projectSkill);
    Task DeleteProjectSkillAsync(int projectId, int skillId);
}