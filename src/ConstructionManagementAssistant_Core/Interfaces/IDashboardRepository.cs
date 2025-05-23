using ConstructionManagementAssistant.Core.DTOs.StatisticsDTO;

namespace ConstructionManagementAssistant.Core.Interfaces;

public interface IDashboardRepository
{
    Task<TeamStatisticsDto> GetTeamStatisticsAsync(string userId);
    Task<ProjectStatisticsDto> GetProjectsStatistics(string userId);
    Task<TaskStatisticsDto> GetTasksStatisticsAync(string userId);
    Task<EquipmentStatisticsDto> GetEquipmentStatisticsAsync(string userId);
    Task<DocumentsStatisticsDto> GetDocumentsStatisticsAsync(string userId);

}