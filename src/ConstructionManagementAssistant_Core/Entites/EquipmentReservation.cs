using System.ComponentModel.DataAnnotations.Schema;

namespace ConstructionManagementAssistant.Core.Entites;

public class EquipmentReservation
{
    public int Id { get; set; }
    public int EquipmentId { get; set; }
    public Equipment Equipment { get; set; }

    public int ProjectId { get; set; }
    public Project Project { get; set; }

    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    [NotMapped]
    public bool IsActive { get; set; }
}
