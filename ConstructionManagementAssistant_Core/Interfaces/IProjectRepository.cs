using ConstructionManagementAssistant_Core.DTOs;
using ConstructionManagementAssistant_Core.Entites;
using ConstructionManagementAssistant_Core.Models.Response;

namespace ConstructionManagementAssistant_Core.Interfaces
{
    public interface IProjectRepository : IBaseRepository<Project>
    {
        public Task<GetProjectDto> GetProjectById(int id);
        public Task<PagedResult<GetProjectDto>> GetAllProjects(
            int pageNumber,
            int pageSize,
            string? searchTerm = null );
    }
}
