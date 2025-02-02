using ConstructionManagementAssistant_Core.Entites;

namespace ConstructionManagementAssistant_Core;
public class Worker : Person, IEntity
{
    public bool IsAvailable { get; set; }
    public int? SpecialtyId { get; set; }

    public WorkerSpecialty? Specialty { get; set; }
}
