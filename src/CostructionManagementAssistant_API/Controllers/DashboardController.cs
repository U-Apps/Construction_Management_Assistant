using ConstructionManagementAssistant.Core.DTOs.StatisticsDTO;

namespace ConstructionManagementAssistant.API.Controllers;

[ApiController]
public class DashboardController(IUnitOfWork unitOfWork) : ControllerBase
{
    [HttpGet(SystemApiRouts.Dashboard.GetTeamStatistics)]
    [ProducesResponseType(typeof(TeamStatisticsDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetTeamStatistics()
    {
        var result = await unitOfWork.Dashboard.GetTeamStatisticsAsync();
        return Ok(result);
    }

    [HttpGet(SystemApiRouts.Dashboard.GetProjectStatistics)]
    [ProducesResponseType(typeof(ProjectStatisticsDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetProjectStatistics()
    {
        var result = await unitOfWork.Dashboard.GetProjectsStatistics();
        return Ok(result);
    }

    [HttpGet(SystemApiRouts.Dashboard.GetTaskStatistics)]
    [ProducesResponseType(typeof(TaskStatisticsDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetTaskStatistics()
    {
        var result = await unitOfWork.Dashboard.GetTasksStatisticsAync();
        return Ok(result);
    }

    [HttpGet(SystemApiRouts.Dashboard.GetEquipmentStatistics)]
    [ProducesResponseType(typeof(EquipmentStatisticsDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetEquipmentStatistics()
    {
        var result = await unitOfWork.Dashboard.GetEquipmentStatisticsAsync();
        return Ok(result);
    }

    [HttpGet(SystemApiRouts.Dashboard.GetDocumentsStatistics)]
    [ProducesResponseType(typeof(DocumentsStatisticsDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetDocumentsStatistics()
    {
        var result = await unitOfWork.Dashboard.GetDocumentsStatisticsAsync();
        return Ok(result);
    }
}
