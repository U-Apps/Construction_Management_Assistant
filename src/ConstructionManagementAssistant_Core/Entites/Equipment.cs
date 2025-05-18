namespace ConstructionManagementAssistant.Core.Entites;

public class Equipment : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Model { get; set; }
    public string SerialNumber { get; set; }
    public EquipmentStatus Status { get; set; }
    public DateTime PurchaseDate { get; set; }
    public string Notes { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? ModifiedDate { get; set; }


    public List<EquipmentReservation> Assignments { get; set; }
}


