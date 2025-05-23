namespace ConstructionManagementAssistant.Core.DTOs.StatisticsDTO;

public class ProjectStatisticsDto
{
    public int TotalProjects { get; set; }
    public int ActiveProjects { get; set; }
    public int CancelledProjects { get; set; }
    public int CompletedProjects { get; set; }
    public int PendingProjects { get; set; }
}
