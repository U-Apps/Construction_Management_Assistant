namespace ConstructionManagementAssistant.Core.DTOs.ReportDTO
{
    public class ProjectDtoForFreportDto
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public string? Description { get; init; }
        public DateOnly? StartDate { get; init; }
        public DateOnly? ExpectedEndDate { get; init; }
        public ClientDtoForReport Client { get; set; }
        public SiteEngineerDtoForReport? SiteEngineer { get; set; }
        public string Status { get; init; }
        public string? SiteAddress { get; init; }
        public string? GeographicalCoordinates { get; init; }
        public string? CancelationReason { get; init; }
        public DateOnly? CancelationDate { get; init; }
        public DateOnly? CompletionDate { get; init; }
        public DateOnly? HandoverDate { get; init; }
        public DateTime CreatedDate { get; init; }
        public List<StageWithTasksDtoForReport> Stages { get; init; } = [];
        public List<EquipmentReservationDtoForReport> EquipmentReservations { get; init; } = [];
    }


}
