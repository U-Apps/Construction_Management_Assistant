namespace ConstructionManagementAssistant.Core.Entites;

public class EquipmentAssignment
{
    public int Id { get; set; }
    public int EquipmentId { get; set; }
    public Equipment Equipment { get; set; }

    public int ProjectId { get; set; }
    public Project Project { get; set; }

    public DateTime CheckoutDate { get; set; } // the date it was booked
    public DateTime ExpectedReturnDate { get; set; }
    public DateTime? ActualReturnDate { get; set; }
}
