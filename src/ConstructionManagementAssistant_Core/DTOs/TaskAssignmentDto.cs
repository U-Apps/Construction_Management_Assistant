namespace ConstructionManagementAssistant.Core.DTOs;

public class GetTaskAssignmentDto
{
    public int TaskId { get; set; }
    public int WorkerId { get; set; }
    public DateOnly AssignedDate { get; set; }
    public string TaskName { get; set; }
    public string WorkerName { get; set; }
}



public class AddTaskAssignmentDto
{
    public int TaskId { get; set; }
    public List<int> WorkerIds { get; set; }
}
