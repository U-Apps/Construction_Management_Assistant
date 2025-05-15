namespace ConstructionManagementAssistant.API.Controllers;

[ApiController]
public class TaskAssignmentsController : ControllerBase
{
    private readonly ITaskAssignmentRepository _taskAssignmentRepository;

    public TaskAssignmentsController(ITaskAssignmentRepository taskAssignmentRepository)
    {
        _taskAssignmentRepository = taskAssignmentRepository;
    }

    [HttpGet]
    [Route(SystemApiRouts.TaskAssignments.GetByTaskId)]
    public async Task<IActionResult> GetByTaskId(int taskId)
    {
        var assignments = await _taskAssignmentRepository.GetAssignmentsByTaskId(taskId);
        return Ok(new BaseResponse<IEnumerable<GetTaskAssignmentDto>>
        {
            Success = true,
            Message = "Assignments fetched successfully.",
            Data = assignments
        });
    }

    [HttpGet]
    [Route(SystemApiRouts.TaskAssignments.GetByWorkerId)]
    public async Task<IActionResult> GetByWorkerId(int workerId)
    {
        var assignments = await _taskAssignmentRepository.GetAssignmentsByWorkerId(workerId);
        return Ok(new BaseResponse<IEnumerable<GetTaskAssignmentDto>>
        {
            Success = true,
            Message = "Assignments fetched successfully.",
            Data = assignments
        });
    }


    [HttpPost]
    [Route(SystemApiRouts.TaskAssignments.AssignWorkersToTask)]
    public async Task<IActionResult> AssignWorkersToTask([FromBody] AddTaskAssignmentDto dto)
    {
        var result = await _taskAssignmentRepository.AssignWorkersToTask(dto.TaskId, dto.WorkerIds);
        if (result.Success)
            return Ok(result);
        return BadRequest(result);
    }
}
