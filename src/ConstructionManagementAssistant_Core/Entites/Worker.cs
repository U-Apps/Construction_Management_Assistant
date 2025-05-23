namespace ConstructionManagementAssistant.Core;
public class Worker : Person
{
    public int? SpecialtyId { get; set; }
    public int UserId { get; set; }
    public AppUser User { get; set; }
    public WorkerSpecialty Specialty { get; set; }
    public ICollection<TaskAssignment> TaskAssignments = [];

}
