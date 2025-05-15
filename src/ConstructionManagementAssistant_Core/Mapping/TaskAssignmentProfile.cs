namespace ConstructionManagementAssistant.Core.Mapping;

public static class TaskAssignmentProfile
{
    public static Expression<Func<TaskAssignment, GetTaskAssignmentDto>> ToGetTaskAssignmentDto()
    {
        return assignment => new GetTaskAssignmentDto
        {
            TaskId = assignment.TaskId,
            WorkerId = assignment.WorkerId,
            AssignedDate = assignment.AssignedDate,
            WorkerName = assignment.Worker.GetFullName(),
            TaskName = assignment.Task.Name
        };
    }

}
