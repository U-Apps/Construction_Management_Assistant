namespace ConstructionManagementAssistant.Core;
public class Worker : Person
{
    public bool IsAvailable { get; set; }
    public int? SpecialtyId { get; set; }

    public WorkerSpecialty? Specialty { get; set; }
}
