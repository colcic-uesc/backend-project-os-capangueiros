using System.Collections.Generic;
using System.Threading.Tasks;

public interface ISkillService
{
    Task<Skill> CreateSkillAsync(Skill skill);
    Task<Skill> GetSkillByIdAsync(int skillId);
    Task<IEnumerable<Skill>> GetAllSkillsAsync();
    Task UpdateSkillAsync(Skill skill);
    Task DeleteSkillAsync(int skillId);
}