namespace ConstructionManagementAssistant.Core.DTOs;

public class GetEquipmentAssignmentDto
{
    public int Id { get; set; }
    public int ProjectId { get; set; }
    public string ProjectName { get; set; }
    public int EquipmentId { get; set; }
    public string EquipmentName { get; set; }
    public DateTime BookDate { get; set; }
    public DateTime ExpectedReturnDate { get; set; }
    public DateTime? ActualReturnDate { get; set; }
}


public class AssignEquipmentDto
{
    public int EquipmentId { get; set; }
    public int ProjectId { get; set; }
    public DateTime ExpectedReturnDate { get; set; }
}
