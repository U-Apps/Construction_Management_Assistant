using System.ComponentModel.DataAnnotations.Schema;

namespace ConstructionManagementAssistant.Core.Entites;

public class Equipment : IEntity
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public AppUser User { get; set; }
    public string Name { get; set; }
    public string Model { get; set; }
    public string SerialNumber { get; set; }
    public DateTime PurchaseDate { get; set; }
    public string Notes { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? ModifiedDate { get; set; }

    [NotMapped]
    public EquipmentStatus Status { get; set; }

    public List<EquipmentReservation> Assignments { get; set; }
}


