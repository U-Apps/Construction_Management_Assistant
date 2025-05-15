namespace ConstructionManagementAssistant.Core.Mapping;


public static class EquipmentProfile
{
    public static Expression<Func<Equipment, GetEquipmentDto>> ToGetEquipmentDto()
    {
        return equipment => new GetEquipmentDto
        {
            Id = equipment.Id,
            Name = equipment.Name,
            Model = equipment.Model,
            //SerialNumber = equipment.SerialNumber,
            Status = equipment.Status.ToString(),
            PurchaseDate = equipment.PurchaseDate
        };
    }

    public static Expression<Func<Equipment, EquipmentDetailsDto>> ToEquipmentDetailsDto()
    {
        return equipment => new EquipmentDetailsDto
        {
            Id = equipment.Id,
            Name = equipment.Name,
            Model = equipment.Model,
            SerialNumber = equipment.SerialNumber,
            Status = equipment.Status.ToString(),
            PurchaseDate = equipment.PurchaseDate,
            Notes = equipment.Notes,
            Assignments = equipment.Assignments.Select(a => new GetEquipmentAssignmentDto
            {
                Id = a.Id,
                ProjectId = a.ProjectId,
                ProjectName = a.Project.Name,
                BookDate = a.BookDate,
                ExpectedReturnDate = a.ExpectedReturnDate,
                ActualReturnDate = a.ActualReturnDate
            }).ToList()
        };
    }

    public static Equipment ToEquipment(this AddEquipmentDto dto)
    {
        return new Equipment
        {
            Name = dto.Name,
            Model = dto.Model,
            SerialNumber = dto.SerialNumber,
            Status = EquipmentStatus.Available,
            PurchaseDate = dto.PurchaseDate,
            Notes = dto.Notes,
            CreatedDate = DateTime.Now
        };
    }

    public static void UpdateEquipment(this Equipment equipment, UpdateEquipmentDto dto)
    {
        equipment.Name = dto.Name;
        equipment.Model = dto.Model;
        equipment.SerialNumber = dto.SerialNumber;
        equipment.PurchaseDate = dto.PurchaseDate;
        equipment.Notes = dto.Notes;
        equipment.ModifiedDate = DateTime.Now;
    }
}
