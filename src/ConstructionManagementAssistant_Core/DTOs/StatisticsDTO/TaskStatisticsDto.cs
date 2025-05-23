namespace ConstructionManagementAssistant.Core.DTOs.StatisticsDTO;

public class TaskStatisticsDto
{
    public int TotalTasks { get; set; }
    public int ActiveTasks { get; set; }
    public int CompletedTasks { get; set; }
    public int OverdueTasks { get; set; }
}
