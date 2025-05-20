using ConstructionManagementAssistant.Core.Models.Response;

namespace ConstructionManagementAssistant.Core.Interfaces
{
    public interface IProjectRepository : IBaseRepository<Project>
    {
        Task<ProjectDetailsDto?> GetProjectById(int id);
        Task<PagedResult<GetProjectsDto>> GetAllProjects(
            int pageNumber,
            int pageSize,
            ProjectStatus? status = null,
            string? searchTerm = null);

        Task<List<ProjectNameDto>> GetAllProjectNames();

        Task<BaseResponse<string>> CancelProjectAsync(int projectId, string cancelationReason);
        Task<BaseResponse<string>> PendProjectAsync(int projectId);
        Task<BaseResponse<string>> AddProjectAsync(AddProjectDto addProjectDto);
        Task<BaseResponse<string>> UpdateProjectAsync(UpdateProjectDto updateProjectDto);
        Task<BaseResponse<string>> DeleteProjectAsync(int id);


    }
}
