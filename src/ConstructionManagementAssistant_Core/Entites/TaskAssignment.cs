namespace ConstructionManagementAssistant.Core.Entites;

public class TaskAssignment
{
    public int TaskId { get; set; }
    public ProjectTask Task { get; set; }

    public int WorkerId { get; set; }
    public Worker Worker { get; set; }

    public DateOnly AssignedDate { get; set; }
}
