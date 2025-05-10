namespace ConstructionManagementAssistant.Core.Entites;

public class TaskAssignment
{
    public int TaskId { get; set; }
    public Task Task { get; set; }

    public int WorkerId { get; set; }
    public Worker Worker { get; set; }

    public DateTime AssignedDate { get; set; } = DateTime.Now;
}
