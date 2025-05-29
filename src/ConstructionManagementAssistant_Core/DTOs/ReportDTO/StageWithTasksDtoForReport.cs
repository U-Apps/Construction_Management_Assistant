namespace ConstructionManagementAssistant.Core.DTOs.ReportDTO
{
    public class StageWithTasksDtoForReport
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public string? Description { get; init; }
        public DateOnly? StartDate { get; init; }
        public DateOnly? ExpectedEndDate { get; init; }

        public List<ProjectTaskDtoForReport> Tasks { get; init; } = [];
    }


}
