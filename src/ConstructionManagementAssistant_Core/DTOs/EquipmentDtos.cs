namespace ConstructionManagementAssistant.Core.DTOs;

public class GetEquipmentDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Model { get; set; }
    public string Status { get; set; }
    public DateTime PurchaseDate { get; set; }
}

public class EquipmentDetailsDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Model { get; set; }
    public string SerialNumber { get; set; }
    public string Status { get; set; }
    public DateTime PurchaseDate { get; set; }
    public string Notes { get; set; }
}



public class AddEquipmentDto
{
    public string Name { get; set; }
    public string Model { get; set; }
    public string SerialNumber { get; set; }
    public DateTime PurchaseDate { get; set; }
    public string Notes { get; set; }
}

public class UpdateEquipmentDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Model { get; set; }
    public string SerialNumber { get; set; }
    public DateTime PurchaseDate { get; set; }
    public string Notes { get; set; }
}



