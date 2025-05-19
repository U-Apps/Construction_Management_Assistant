namespace ConstructionManagementAssistant.Core.DTOs;

public class GetEquipmentReservationDto
{
    public int Id { get; set; }
    public int ProjectId { get; set; }
    public string ProjectName { get; set; }
    public int EquipmentId { get; set; }
    public string EquipmentName { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public ReservationStatus ReservationStatus { get; set; }

}


public class ReserveEquipmentDto
{
    public int EquipmentId { get; set; }
    public int ProjectId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}
