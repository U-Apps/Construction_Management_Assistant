using ConstructionManagementAssistant.Core.DTOs.StatisticsDTO;

namespace ConstructionManagementAssistant.Core.Interfaces;

public interface IDashboardRepository
{
    Task<TeamStatisticsDto> GetTeamStatisticsAsync();
    Task<ProjectStatisticsDto> GetProjectsStatistics();
    Task<TaskStatisticsDto> GetTasksStatisticsAync();
    Task<EquipmentStatisticsDto> GetEquipmentStatisticsAsync();
    Task<DocumentsStatisticsDto> GetDocumentsStatisticsAsync();

}