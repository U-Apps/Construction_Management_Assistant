using ConstructionManagementAssistant_Core.DTOs;
using ConstructionManagementAssistant_Core.Entites;
using ConstructionManagementAssistant_Core.Models.Response;

namespace ConstructionManagementAssistant_Core.Interfaces
{
    public interface IProjectRepository : IBaseRepository<Project>
    {
        public Task<GetProjectsDto> GetProjectById(int id);
        public Task<PagedResult<GetProjectsDto>> GetAllProjects(
            int pageNumber,
            int pageSize,
            string? searchTerm = null );
        public Task<BaseResponse<string>> AddProjectAsync(AddProjectDto addProjectDto);
        public Task<BaseResponse<string>> UpdateProjectAsync(UpdateProjectDto updateProjectDto);

    }
}
