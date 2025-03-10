using Microsoft.EntityFrameworkCore;
using UescColcicAPI.Core;

namespace UescColcicAPI.Service.Interfaces
{
    public interface IProjectService
    {
        Task<IEnumerable<Project>> GetAllProjectsAsync();
        Task<Project> GetProjectByIdAsync(int projectId);
        Task<Project> CreateProjectAsync(Project project);
        Task<bool> UpdateProjectAsync(Project project);
        Task<bool> DeleteProjectAsync(int projectId);
    }
}