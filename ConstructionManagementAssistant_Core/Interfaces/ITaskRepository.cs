using ConstructionManagementAssistant_Core.Models.Response;
namespace ConstructionManagementAssistant_Core.Interfaces;

public interface ITaskRepository : IBaseRepository<Entites.Task>
{
    Task<GetTaskDto> GetTaskById(int id);
    Task<PagedResult<GetTaskDto>> GetAllTasks(int pageNumber = 1, int pageSize = 10, string? searchTerm = null);
    Task<BaseResponse<string>> AddTaskAsync(AddTaskDto taskDto);
    Task<BaseResponse<string>> UpdateTaskAsync(UpdateTaskDto taskDto);
    Task<BaseResponse<string>> DeleteTaskAsync(int id);
}
