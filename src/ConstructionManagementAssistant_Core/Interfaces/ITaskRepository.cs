using ConstructionManagementAssistant.Core.Models.Response;
namespace ConstructionManagementAssistant.Core.Interfaces;

public interface ITaskRepository : IBaseRepository<Task>
{
    Task<GetTaskDetailsDto?> GetTaskById(int id);
    Task<PagedResult<GetTaskDto>> GetAllTasks(int stageId, int pageNumber = 1, int pageSize = 10, string? searchTerm = null);
    Task<BaseResponse<string>> AddTaskAsync(AddTaskDto taskDto);
    Task<BaseResponse<string>> CompleteTaskAsync(int taskId);
    Task<BaseResponse<string>> AssignWorkersToTask(int taskId, List<int> workerIds);

    Task<BaseResponse<string>> UnCheckTaskAsync(int taskId);
    Task<BaseResponse<string>> UpdateTaskAsync(UpdateTaskDto taskDto);
    Task<BaseResponse<string>> DeleteTaskAsync(int id);
}
