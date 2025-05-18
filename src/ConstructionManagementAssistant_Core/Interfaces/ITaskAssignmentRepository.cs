using ConstructionManagementAssistant.Core.Models.Response;

namespace ConstructionManagementAssistant.Core.Interfaces;

public interface ITaskAssignmentRepository
{
    Task<BaseResponse<string>> AssignWorkersToTask(int taskId, List<int> workerIds);
    Task<BaseResponse<string>> UnAssignWorkersToTask(int taskId, List<int> workerIds);
    Task<IEnumerable<GetTaskAssignmentDto>> GetAssignmentsByTaskId(int taskId);
    Task<IEnumerable<GetTaskAssignmentDto>> GetAssignmentsByWorkerId(int workerId);
}
