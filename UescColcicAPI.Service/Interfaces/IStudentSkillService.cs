using System.Collections.Generic;
using System.Threading.Tasks;

public interface IStudentSkillService
{
    Task<StudentSkill> CreateStudentSkillAsync(StudentSkill studentSkill);
    Task<StudentSkill> GetStudentSkillByIdAsync(int studentId, int skillId);
    Task<IEnumerable<StudentSkill>> GetAllStudentSkillsAsync();
    Task UpdateStudentSkillAsync(StudentSkill studentSkill);
    Task DeleteStudentSkillAsync(int studentId, int skillId);
}