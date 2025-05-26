namespace ConstructionManagementAssistant.Core.DTOs.ReportDTO
{
    public class ProjectTaskDtoForReport
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public string? Description { get; init; }
        public DateOnly? StartDate { get; init; }
        public DateOnly? ExpectedEndDate { get; init; }
        public bool IsCompleted { get; init; }

    }


}
