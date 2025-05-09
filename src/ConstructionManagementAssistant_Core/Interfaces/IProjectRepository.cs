using ConstructionManagementAssistant.Core.DTOs;
using ConstructionManagementAssistant.Core.Entites;
using ConstructionManagementAssistant.Core.Models.Response;

namespace ConstructionManagementAssistant.Core.Interfaces
{
    public interface IProjectRepository : IBaseRepository<Project>
    {
        public Task<ProjectDetailsDto> GetProjectById(int id);
        public Task<PagedResult<GetProjectsDto>> GetAllProjects(
            int pageNumber,
            int pageSize,
            ProjectStatus? status =null, 
            string? searchTerm = null );
        public Task<BaseResponse<string>> AddProjectAsync(AddProjectDto addProjectDto);
        public Task<BaseResponse<string>> UpdateProjectAsync(UpdateProjectDto updateProjectDto);
        public Task<BaseResponse<string>> DeleteProjectAsync(int id);


    }
}
